using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Game_Rental
{
    public partial class ReturnGames : Form
    {
        private string connectionString = "server=localhost;database=game_rental;user=root;password=\"1241994752002Sh;\";SslMode=None;";
        public ReturnGames()
        {
            InitializeComponent();
        }
        private void ReturnGames_Load(object sender, EventArgs e)
        {
            LoadRentedGames();
        }
        private void LoadRentedGames()
        {
            string query = @"SELECT r.Game_ID, g.Game_Name, g.Category,
                           r.Rent_Date, r.Return_Date, r.Actual_Return_Date
                           FROM rent r
                           JOIN game g ON r.Game_ID = g.Game_ID
                           WHERE r.Client_ID = @clientID AND r.Status = 1"; 
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@clientID", CurrentUser.UserID);
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            dgvRentedGames.DataSource = table;
                            if (dgvRentedGames.Columns.Contains("Game_ID"))
                            {
                                dgvRentedGames.Columns["Game_ID"].Visible = false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading rented games: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnReturnGame_Click(object sender, EventArgs e)
        {
            if (dgvRentedGames.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a game to return.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int gameID = Convert.ToInt32(dgvRentedGames.SelectedRows[0].Cells["Game_ID"].Value);
            DateTime rentDate = Convert.ToDateTime(dgvRentedGames.SelectedRows[0].Cells["Rent_Date"].Value);
            DateTime dueDate = Convert.ToDateTime(dgvRentedGames.SelectedRows[0].Cells["Return_Date"].Value);
            DateTime today = DateTime.Today;

            if (today == rentDate)
            {
                MessageBox.Show("You must keep the game for at least one day before returning it.", "Return Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (today < dueDate)
            {
                DialogResult confirmResult = MessageBox.Show(
                    $"Are you sure you want to return the game early?\nDue Date: {dueDate.ToShortDateString()}",
                    "Confirm Early Return",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (confirmResult == DialogResult.No)
                {
                    return; 
                }
            }
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction()) 
                {
                    try
                    {
                        string updateQuery = @"UPDATE rent 
                                             SET Status = 0, 
                                             Actual_Return_Date = @today 
                                             WHERE Game_ID = @gameID 
                                             AND Client_ID = @clientID
                                             AND Status = 1";
                        using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@gameID", gameID);
                            cmd.Parameters.AddWithValue("@clientID", CurrentUser.UserID);
                            cmd.Parameters.AddWithValue("@today", today);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected == 0)
                            {
                                MessageBox.Show("Error processing return.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                transaction.Rollback();
                                return;
                            }
                        }
                        transaction.Commit();

                        if (today > dueDate)
                        {
                            MessageBox.Show($"Game returned late! Due Date was {dueDate.ToShortDateString()}", "Late Return", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (today < dueDate)
                        {
                            MessageBox.Show($"Game returned early! Due Date was {dueDate.ToShortDateString()}", "Early Return", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"Game returned successfully! Return Date: {today.ToShortDateString()}", "Return Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        LoadRentedGames();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            ClientDashboard clientDashboard = new ClientDashboard();
            clientDashboard.Show();
            this.Close();
        }
    }
}

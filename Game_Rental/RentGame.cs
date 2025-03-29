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
    public partial class RentGame : Form
    {
        private string connString = "server=localhost;database=game_rental;user=root;password=\"1241994752002Sh;\";SslMode=None;";
        public RentGame()
        {
            InitializeComponent();
        }
        private void RentGame_Load(object sender, EventArgs e)
        {
            LoadAvailableGames();
            LoadVendorsAndCategories();
        }
        private void LoadAvailableGames()
        {
            string query = @"SELECT g.Game_ID, g.Game_Name, g.Category,
                           g.Add_Date, g.Price, v.Vendor_Name 
                           FROM game g
                           JOIN vendor v ON g.Vendor_ID = v.Vendor_ID
                           WHERE g.Game_ID NOT IN (SELECT Game_ID FROM rent WHERE Status = 1)";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvAvailableGames.DataSource = dt;
                        if (dgvAvailableGames.Columns.Contains("Game_ID"))
                        {
                            dgvAvailableGames.Columns["Game_ID"].Visible = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading available games: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadVendorsAndCategories()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    cmbVendor.Items.Clear();
                    cmbCategory.Items.Clear();
                    cmbVendor.Items.Add("-- Select a Vendor --");
                    cmbCategory.Items.Add("-- Select a Category --");

                    using (MySqlCommand cmd = new MySqlCommand("SELECT Vendor_Name FROM vendor", conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbVendor.Items.Add(reader["Vendor_Name"].ToString());
                        }
                    }
                    using (MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT Category FROM game", conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbCategory.Items.Add(reader["Category"].ToString());
                        }
                    }
                    cmbVendor.SelectedIndex = 0;
                    cmbCategory.SelectedIndex = 0;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnApply_Filter_Click(object sender, EventArgs e)
        {
            string gameName = txtSearchGame.Text.Trim();
            string vendor = cmbVendor.SelectedItem?.ToString();
            string category = cmbCategory.SelectedItem?.ToString();

            string query = @"SELECT g.Game_ID, g.Game_Name, g.Category,
                           g.Add_Date, g.Price, v.Vendor_Name 
                           FROM game g
                           JOIN vendor v ON g.Vendor_ID = v.Vendor_ID
                           WHERE g.Game_ID NOT IN (SELECT Game_ID FROM rent WHERE Status = 1)";

            if (!string.IsNullOrEmpty(gameName))
            {
                query += " AND g.Game_Name LIKE @gameName";
            }
            if (!string.IsNullOrEmpty(vendor) && vendor != "-- Select a Vendor --")
            {
                query += " AND v.Vendor_Name = @vendor";
            }
            if (!string.IsNullOrEmpty(category) && category != "-- Select a Category --")
            {
                query += " AND g.Category = @category";
            }

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(gameName)) cmd.Parameters.AddWithValue("@gameName", "%" + gameName + "%");
                        if (!string.IsNullOrEmpty(vendor)) cmd.Parameters.AddWithValue("@vendor", vendor);
                        if (!string.IsNullOrEmpty(category)) cmd.Parameters.AddWithValue("@category", category);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvAvailableGames.DataSource = dt;
                            if (dgvAvailableGames.Columns.Contains("Game_ID"))
                            {
                                dgvAvailableGames.Columns["Game_ID"].Visible = false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error applying filter: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnRent_Click(object sender, EventArgs e)
        {
            if (dgvAvailableGames.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a game to rent.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int gameID = Convert.ToInt32(dgvAvailableGames.SelectedRows[0].Cells["Game_ID"].Value);
            DateTime returnDate = dtpReturnDate.Value;
            int clientID = CurrentUser.UserID; 

            if (CurrentUser.UserType != "Client")
            {
                MessageBox.Show("Only clients can rent games!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (returnDate <= DateTime.Today || returnDate < DateTime.Today.AddDays(1))
            {
                MessageBox.Show("Return date must be in the future.", "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult confirmResult = MessageBox.Show(
                       "Are you sure you want to rent the game?",
                       "Confirm Submission",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question
                   );

            if (confirmResult == DialogResult.No)
            {
                return; 
            }
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    MySqlTransaction transaction = conn.BeginTransaction();
                    string insertQuery = @"
                INSERT INTO rent (Client_ID, Game_ID, Rent_Date, Return_Date, Actual_Return_Date, Status) 
                VALUES (@clientID, @gameID, @rentDate, @returnDate, NULL, 1)";
                    using (MySqlCommand cmdInsert = new MySqlCommand(insertQuery, conn, transaction))
                    {
                        cmdInsert.Parameters.AddWithValue("@clientID", clientID);
                        cmdInsert.Parameters.AddWithValue("@gameID", gameID);
                        cmdInsert.Parameters.AddWithValue("@rentDate", DateTime.Today);
                        cmdInsert.Parameters.AddWithValue("@returnDate", returnDate);
                        cmdInsert.ExecuteNonQuery();
                    }

                    transaction.Commit();

                    MessageBox.Show("Game rented successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAvailableGames(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error renting game: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnResetFilters_Click(object sender, EventArgs e)
        {
            txtSearchGame.Clear();
            cmbCategory.SelectedIndex = 0;
            cmbVendor.SelectedIndex = 0;
            LoadAvailableGames();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            ClientDashboard clientDashboard = new ClientDashboard();
            clientDashboard.Show();
            this.Close();
        }
    }
}


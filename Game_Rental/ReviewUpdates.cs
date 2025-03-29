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
    public partial class ReviewUpdates : Form
    {
        private string connString = "server=localhost;database=game_rental;user=root;password=\"1241994752002Sh;\";SslMode=None;";
        public ReviewUpdates()
        {
            InitializeComponent();
        }
        private void ReviewUpdates_Load(object sender, EventArgs e)
        {
            LoadPendingUpdates();
        }
        private void LoadPendingUpdates()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT g.Game_ID, g.Game_Name AS 'Current Name', g.Category AS 'Current Category', 
                       g.Add_Date, g.Price AS 'Current Price', g.Admin_ID, g.Vendor_ID, gu.Update_ID,
                       gu.Updated_Name, gu.Updated_Category, gu.Updated_Price, 
                       gu.Updated_Description, gu.Update_Date, gu.Approval_Status, gu.Approval_Date
                FROM game g
                 JOIN game_updates gu ON g.Game_ID = gu.Game_ID
                WHERE g.Admin_ID = @adminID AND  gu.Approval_Status= 'Pending' ";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@adminID", CurrentUser.UserID); 
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvUpdates.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading pending updates: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvUpdates.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a game update to approve.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult confirmResult = MessageBox.Show(
                      $"Are you sure you want to Approve the update'?",
                      "Confirm Submission",
                      MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question
                       );
            if (confirmResult == DialogResult.No)
            {
                return;
            }
            int updateID = Convert.ToInt32(dgvUpdates.SelectedRows[0].Cells["Update_ID"].Value);
            int gameID = Convert.ToInt32(dgvUpdates.SelectedRows[0].Cells["Game_ID"].Value);
            string updatedName = dgvUpdates.SelectedRows[0].Cells["Updated_Name"].Value != DBNull.Value
                ? dgvUpdates.SelectedRows[0].Cells["Updated_Name"].Value.ToString()
                : null;
            string updatedCategory = dgvUpdates.SelectedRows[0].Cells["Updated_Category"].Value != DBNull.Value
                ? dgvUpdates.SelectedRows[0].Cells["Updated_Category"].Value.ToString()
                : null;
            decimal? updatedPrice = dgvUpdates.SelectedRows[0].Cells["Updated_Price"].Value != DBNull.Value
                ? (decimal?)Convert.ToDecimal(dgvUpdates.SelectedRows[0].Cells["Updated_Price"].Value)
                : null;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlTransaction transaction = conn.BeginTransaction()) 
                    {
                        string updateGameQuery = @"
                    UPDATE game 
                    SET Game_Name = COALESCE(@updatedName, Game_Name), 
                        Category = COALESCE(@updatedCategory, Category), 
                        Price = COALESCE(@updatedPrice, Price) 
                    WHERE Game_ID = @gameID";
                        using (MySqlCommand cmd = new MySqlCommand(updateGameQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@gameID", gameID);
                            cmd.Parameters.AddWithValue("@updatedName", (object)updatedName ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@updatedCategory", (object)updatedCategory ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@updatedPrice", (object)updatedPrice ?? DBNull.Value);
                            cmd.ExecuteNonQuery();
                        }

                        string approveUpdateQuery = @"
                    UPDATE game_updates 
                    SET Approval_Status = 'Approved', Approval_Date = NOW() 
                    WHERE Update_ID = @updateID";
                        using (MySqlCommand cmd = new MySqlCommand(approveUpdateQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@updateID", updateID);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit(); 
                        MessageBox.Show("Game update approved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPendingUpdates(); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error approving update: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dgvUpdates.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an update to reject.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int updateID = Convert.ToInt32(dgvUpdates.SelectedRows[0].Cells["Update_ID"].Value);
            DialogResult confirmResult = MessageBox.Show(
                "Are you sure you want to reject this game update? This action cannot be undone.",
                "Confirm Rejection",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            if (confirmResult == DialogResult.No)
            {
                return; 
            }
            string updateQuery = @"
                UPDATE game_updates 
                SET Approval_Status = 'Rejected', Approval_Date = NOW() 
                WHERE Update_ID = @updateID";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@updateID", updateID);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Game update rejected successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPendingUpdates(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error rejecting update: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
            this.Close();
        }
    }
}

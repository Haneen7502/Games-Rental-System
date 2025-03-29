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
    public partial class ReviewUploads: Form
    {
        public ReviewUploads()
        {
            InitializeComponent();
        }
        private void ReviewUploads_Load(object sender, EventArgs e)
        {
            LoadPendingUploads();
        }
        private string connString = "server=localhost;database=game_rental;user=root;password=\"1241994752002Sh;\";SslMode=None;";
        private void LoadPendingUploads()
        {
            string query = "SELECT * FROM game_uploads WHERE Approval_Status = 'Pending'";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvUploads.DataSource = dt; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading pending uploads: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvUploads.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a game to approve.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int uploadID = Convert.ToInt32(dgvUploads.SelectedRows[0].Cells["Upload_ID"].Value);
            string gameName = dgvUploads.SelectedRows[0].Cells["Game_Name"].Value.ToString();
            string category = dgvUploads.SelectedRows[0].Cells["Category"].Value.ToString();
            decimal price = Convert.ToDecimal(dgvUploads.SelectedRows[0].Cells["Price"].Value);
            int vendorID = Convert.ToInt32(dgvUploads.SelectedRows[0].Cells["Vendor_ID"].Value);
            DialogResult confirmResult = MessageBox.Show(
                      $"Are you sure you want to Approve the game '{gameName}'?",
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
                    using (MySqlTransaction transaction = conn.BeginTransaction()) 
                    {
                        string insertQuery = @"
                    INSERT INTO game (Game_Name, Category, Add_Date, Price, Admin_ID, Vendor_ID)
                    VALUES (@gameName, @category,NOW(), @price, @adminID, @vendorID)";
                        using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@gameName", gameName);
                            cmd.Parameters.AddWithValue("@category", category);
                            cmd.Parameters.AddWithValue("@price", price);
                            cmd.Parameters.AddWithValue("@adminID", CurrentUser.UserID); 
                            cmd.Parameters.AddWithValue("@vendorID", vendorID);
                            cmd.ExecuteNonQuery();
                        }
                        string updateQuery = @"
                    UPDATE game_uploads 
                    SET Approval_Status = 'Approved', Approval_Date = NOW()
                    WHERE Upload_ID = @uploadID";
                        using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@uploadID", uploadID);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit(); 
                        MessageBox.Show("Game approved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPendingUploads(); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error approving game: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dgvUploads.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a game to reject.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int uploadID = Convert.ToInt32(dgvUploads.SelectedRows[0].Cells["Upload_ID"].Value);
            DialogResult confirmResult = MessageBox.Show(
                "Are you sure you want to reject this game upload? This action cannot be undone.",
                "Confirm Rejection",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            if (confirmResult == DialogResult.No)
            {
                return; 
            }

            string updateQuery = @"
        UPDATE game_uploads 
        SET Approval_Status = 'Rejected', Approval_Date = NOW()
        WHERE Upload_ID = @uploadID";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@uploadID", uploadID);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Game rejected successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPendingUploads(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error rejecting game: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

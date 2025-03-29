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
    public partial class UpdateGame : Form
    {
        private string connString = "server=localhost;database=game_rental;user=root;password=\"1241994752002Sh;\";SslMode=None;";
        public UpdateGame()
        {
            InitializeComponent();
        }
        private void UpdateGame_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadVendorGames();
        }
        private void LoadVendorGames()
        {
            string query = @"SELECT g.Game_ID, g.Game_Name AS 'Current Name', g.Category AS 'Current Category', 
                           g.Add_Date, g.Price AS 'Current Price', 
                           gu.Updated_Name, gu.Updated_Category, gu.Updated_Price, 
                           gu.Updated_Description, gu.Update_Date, gu.Approval_Status, gu.Approval_Date
                           FROM game g
                           LEFT JOIN game_updates gu ON g.Game_ID = gu.Game_ID 
                           WHERE g.Vendor_ID = @vendorID";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@vendorID", CurrentUser.UserID);
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvVendorGames.DataSource = dt;
                            if (dgvVendorGames.Columns.Contains("Game_ID"))
                            {
                                dgvVendorGames.Columns["Game_ID"].Visible = false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading vendor games: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadCategories()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    cmbNewCategory.Items.Clear(); 
                    cmbNewCategory.Items.Add("-- Select a Category --"); 
                    using (MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT Category FROM game", conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbNewCategory.Items.Add(reader["Category"].ToString());
                        }
                    }
                    cmbNewCategory.SelectedIndex = 0; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading categories: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnSubmitUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewGameName.Text) &&
                string.IsNullOrWhiteSpace(txtNewPrice.Text) &&
                cmbNewCategory.SelectedIndex == 0)
            {
                MessageBox.Show("Please update at least one field (Name, Price, or Category).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUpdateDescription.Text))
            {
                MessageBox.Show("Please enter an update description.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvVendorGames.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a game to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int gameID = Convert.ToInt32(dgvVendorGames.SelectedRows[0].Cells["Game_ID"].Value);
            string currentGameName = dgvVendorGames.SelectedRows[0].Cells["Current Name"].Value.ToString();
            string updatedName = !string.IsNullOrWhiteSpace(txtNewGameName.Text) ? txtNewGameName.Text.Trim() : null;
            string updatedCategory = cmbNewCategory.SelectedIndex > 0 ? cmbNewCategory.SelectedItem.ToString() : null;
            decimal? updatedPrice = !string.IsNullOrWhiteSpace(txtNewPrice.Text) ? (decimal?)Convert.ToDecimal(txtNewPrice.Text) : null;
            string updateDescription = txtUpdateDescription.Text.Trim();
            DateTime updateDate = DateTime.Today;
            int vendorID = CurrentUser.UserID;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string checkPendingQuery = "SELECT COUNT(*) FROM game_updates WHERE Game_ID = @gameID AND Approval_Status = 'Pending'";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkPendingQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@gameID", gameID);
                        int existingUpdates = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (existingUpdates > 0)
                        {
                            MessageBox.Show("An update for this game is already pending approval.", "Duplicate Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(updatedName) && updatedName != currentGameName)
                    {
                        string checkNameQuery = "SELECT COUNT(*) FROM game WHERE Game_Name = @updatedName";
                        using (MySqlCommand nameCheckCmd = new MySqlCommand(checkNameQuery, conn))
                        {
                            nameCheckCmd.Parameters.AddWithValue("@updatedName", updatedName);
                            int nameExists = Convert.ToInt32(nameCheckCmd.ExecuteScalar());

                            if (nameExists > 0)
                            {
                                MessageBox.Show($"A game with the name '{updatedName}' already exists. Please choose a different name.", "Duplicate Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    DialogResult confirmResult = MessageBox.Show(
                        $"Are you sure you want to update the game '{currentGameName}'?",
                        "Confirm Submission",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                    if (confirmResult == DialogResult.No)
                    {
                        return; 
                    }

                    string insertQuery = @"
                INSERT INTO game_updates (Game_ID, Updated_Name, Updated_Category, Updated_Price, Updated_Description, 
                                          Update_Date, Approval_Status, Vendor_ID)
                VALUES (@gameID, @updatedName, @updatedCategory, @updatedPrice, @updateDescription, 
                        @updateDate, 'Pending', @vendorID)";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@gameID", gameID);
                        cmd.Parameters.AddWithValue("@updatedName", (object)updatedName ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@updatedCategory", (object)updatedCategory ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@updatedPrice", (object)updatedPrice ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@updateDescription", updateDescription);
                        cmd.Parameters.AddWithValue("@updateDate", updateDate);
                        cmd.Parameters.AddWithValue("@vendorID", vendorID);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Game update submitted! Pending admin approval.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadVendorGames(); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error submitting update: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnCancelUpdate_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show(
            "Are you sure you want to cancel the update? Any unsaved changes will be lost.",
            "Confirm Cancellation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
            );
            if (confirmResult == DialogResult.Yes)
            {
                VendorDashboard vendorDashboardForm = new VendorDashboard();
                vendorDashboardForm.Show();
                this.Close();
            }
        }
        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; 
            }
            if (e.KeyChar == '.' && (txtNewPrice.Text.Length == 0 || txtNewPrice.Text.Contains(".")))
            {
                e.Handled = true;
            }
        }
    }
}

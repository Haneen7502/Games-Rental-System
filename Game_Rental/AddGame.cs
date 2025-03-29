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
    public partial class AddGame : Form
    {
        private string connString = "server=localhost;database=game_rental;user=root;password=\"1241994752002Sh;\";SslMode=None;";

        public AddGame()
        {
            InitializeComponent();
        }
        private void AddGame_Load(object sender, EventArgs e)
        {
            LoadVendorGames();
            LoadCategories();
        }
        private void LoadVendorGames()
        {
            string query = @"SELECT Game_Name, Category, Add_Date, Price, 
                           Approval_Status, Approval_Date
                           FROM game_uploads
                           WHERE Vendor_ID = @vendorID";
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
                            dgvUploadedGames.DataSource = dt;
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
                    cmbCategory.Items.Clear(); 
                    cmbCategory.Items.Add("-- Select a Category --"); 
                    using (MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT Category FROM game", conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbCategory.Items.Add(reader["Category"].ToString());
                        }
                    }
                    cmbCategory.SelectedIndex = 0; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading categories: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGameName.Text) || string.IsNullOrWhiteSpace(txtPrice.Text) || cmbCategory.SelectedIndex == 0)
            {
                MessageBox.Show("Please fill in all fields!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string gameName = txtGameName.Text.Trim();
            string category = cmbCategory.SelectedItem.ToString();
            decimal price = decimal.Parse(txtPrice.Text);
            DateTime addDate = dtpAddDate.Value;
            int vendorID = CurrentUser.UserID; 
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string checkQuery = "SELECT COUNT(*) FROM game WHERE Game_Name = @gameName";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@gameName", gameName);
                        int existingGames = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (existingGames > 0)
                        {
                            MessageBox.Show("A game with this name already exists. Please choose a different name.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    DialogResult confirmResult = MessageBox.Show(
                        $"Are you sure you want to upload the game '{gameName}'?",
                        "Confirm Submission",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (confirmResult == DialogResult.No)
                    {
                        return; 
                    }

                    string insertQuery = @"
                INSERT INTO game_uploads (Game_Name, Category, Add_Date, Price, Vendor_ID, Approval_Status)
                VALUES (@gameName, @category, @addDate, @price, @vendorID, 'Pending')";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@gameName", gameName);
                        cmd.Parameters.AddWithValue("@category", category);
                        cmd.Parameters.AddWithValue("@addDate", addDate);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@vendorID", vendorID);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Game uploaded successfully! Pending admin approval.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadVendorGames(); 
                        }
                        else
                        {
                            MessageBox.Show("Failed to upload game. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error submitting game: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show(
            "Are you sure you want to cancel the upload? Any unsaved changes will be lost.",
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
            
            if (e.KeyChar == '.' && (txtPrice.Text.Length == 0 || txtPrice.Text.Contains(".")))
            {
                e.Handled = true;
            }
        }
    }
}

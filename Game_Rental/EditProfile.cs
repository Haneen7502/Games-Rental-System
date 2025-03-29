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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace Game_Rental
{
    public partial class EditProfile : Form
    {
        private string connString = "server=localhost;database=game_rental;user=root;password=\"1241994752002Sh;\";SslMode=None;";
        public EditProfile()
        {
            InitializeComponent();
        }
        private void EditProfile_Load(object sender, EventArgs e)
        {
            LoadUserInfo();
        }
        private void LoadUserInfo()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    var (userTable, nameColumn, idColumn) = GetUserTableAndColumns();
                    if (userTable == null) return; 
                    string query = $"SELECT {nameColumn}, Pass FROM {userTable} WHERE {idColumn} = @userID";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userID", CurrentUser.UserID);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtName.Text = reader[nameColumn].ToString();
                                txtPassword.Text = "********"; 
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private (string userTable, string nameColumn, string idColumn) GetUserTableAndColumns()
        {
            switch (CurrentUser.UserType)
            {
                case "Client":
                    return ("client", "Client_Name", "Client_ID");
                case "Vendor":
                    return ("vendor", "Vendor_Name", "Vendor_ID");
                case "Admin":
                    return ("admin", "Admin_Name", "Admin_ID");
                default:
                    MessageBox.Show("Unknown user type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return (null, null, null);
            }
        }
        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    var (userTable, nameColumn, idColumn) = GetUserTableAndColumns();
                    if (userTable == null) return;

                    string newName = txtEditName.Text.Trim();
                    string newPassword = txtEditPassword.Text.Trim();
                    string confirmPassword = txtConfirmNewPassword.Text.Trim();

                    if (string.IsNullOrWhiteSpace(newName) && string.IsNullOrWhiteSpace(newPassword))
                    {
                        MessageBox.Show("No changes detected. Please enter a new name or password.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (!string.IsNullOrWhiteSpace(newPassword))
                    {
                        if (newPassword != confirmPassword)
                        {
                            MessageBox.Show("Passwords do not match!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string queryCheck = $"SELECT {nameColumn}, Pass FROM {userTable} WHERE {idColumn} = @userID";
                    string oldName = "", oldPassword = "";
                    using (MySqlCommand cmdCheck = new MySqlCommand(queryCheck, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@userID", CurrentUser.UserID);
                        using (MySqlDataReader reader = cmdCheck.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                oldName = reader[nameColumn].ToString();
                                oldPassword = reader["Pass"].ToString();
                            }
                        }
                    }

                    bool isNameChanged = !string.IsNullOrWhiteSpace(newName) && newName != oldName;
                    bool isPasswordChanged = !string.IsNullOrWhiteSpace(newPassword) && newPassword != "********" && newPassword != oldPassword;

                    if (!isNameChanged && !isPasswordChanged)
                    {
                        MessageBox.Show("No changes detected.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (isNameChanged)
                    {
                        string queryCheckExist = $"SELECT COUNT(*) FROM {userTable} WHERE {nameColumn} = @newName AND {idColumn} <> @userID";
                        using (MySqlCommand cmdCheckExist = new MySqlCommand(queryCheckExist, conn))
                        {
                            cmdCheckExist.Parameters.AddWithValue("@newName", newName);
                            cmdCheckExist.Parameters.AddWithValue("@userID", CurrentUser.UserID);

                            int count = Convert.ToInt32(cmdCheckExist.ExecuteScalar());
                            if (count > 0)
                            {
                                MessageBox.Show("This username is already taken. Please choose another one.", "Duplicate Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    DialogResult confirmResult = MessageBox.Show(
                        "Are you sure you want to update your profile?",
                        "Confirm Update",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.No) return;

                    List<string> updateFields = new List<string>();
                    if (isNameChanged) updateFields.Add($"{nameColumn} = @newName");
                    if (isPasswordChanged) updateFields.Add("Pass = @newPassword");
                    CurrentUser.Username = newName;
                    string updateQuery = $"UPDATE {userTable} SET {string.Join(", ", updateFields)} WHERE {idColumn} = @userID";
                    using (MySqlCommand cmdUpdate = new MySqlCommand(updateQuery, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@userID", CurrentUser.UserID);
                        if (isNameChanged) cmdUpdate.Parameters.AddWithValue("@newName", newName);
                        if (isPasswordChanged) cmdUpdate.Parameters.AddWithValue("@newPassword", newPassword);

                        int rowsAffected = cmdUpdate.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No changes were made.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating profile: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (CurrentUser.UserType == "Admin")
            {
                AdminDashboard adminDashboard = new AdminDashboard();
                adminDashboard.Show();
                this.Close();
            }
            else if (CurrentUser.UserType == "Client")
            {
                ClientDashboard clientDashboard = new ClientDashboard();
                clientDashboard.Show();
                this.Close();
            }
            else if (CurrentUser.UserType == "Vendor")
            {
                VendorDashboard vendorDashboard = new VendorDashboard();
                vendorDashboard.Show();
                this.Close();
            }
        }
    }
}

using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Game_Rental
{
    public partial class SignUpForm : Form
    {
        private string connectionString = "server=localhost;database=game_rental;user=root;password=\"1241994752002Sh;\";SslMode=None;";
        public SignUpForm()
        {
            InitializeComponent();
        }
        private void SignUpForm_Load(object sender, EventArgs e)
        {
        }
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();
            string userType = ""; 
            if (rbAdmin.Checked) userType = "Admin";
            else if (rbVendor.Checked) userType = "Vendor";
            else if (rbClient.Checked) userType = "Client";

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Username is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(userType))
            {
                MessageBox.Show("Please select a User Type!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            RegisterUser(username, password, userType);
        }
        private void RegisterUser(string username, string password, string userType)
        {
            if (IsUsernameTaken(username))
            {
                MessageBox.Show("Username already exists! Please choose another.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "";

            if (userType == "Admin")
            {
                query = "INSERT INTO admin (Admin_Name, Pass) VALUES (@username, @password)";
            }
            else if (userType == "Vendor")
            {
                query = "INSERT INTO vendor (Vendor_Name, Pass) VALUES (@username, @password)";
            }
            else if (userType == "Client")
            {
                query = "INSERT INTO client (Client_Name, Pass) VALUES (@username, @password)";
            }
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password); 
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User registered successfully! Redirecting to login...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoginForm loginForm = new LoginForm();
                            loginForm.Show();
                            this.Close(); 
                        }
                        else
                        {
                            MessageBox.Show("Registration failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Database Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool IsUsernameTaken(string username)
        {
            string query = @"
                SELECT COUNT(*) FROM (
                    SELECT Admin_Name AS Name FROM admin
                    UNION 
                    SELECT Vendor_Name FROM vendor
                    UNION 
                    SELECT Client_Name FROM client
                ) AS AllUsers
                WHERE Name = @username";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0; 
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Database Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true; 
                }
            }
        }
    }
}

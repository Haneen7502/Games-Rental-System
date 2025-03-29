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
using MySqlX.XDevAPI;
namespace Game_Rental
{
    public partial class LoginForm: Form
    {
        private string connectionString = "server=localhost;database=game_rental;user=root;password=\"1241994752002Sh;\";SslMode=None;";
        public LoginForm()
        {
            InitializeComponent();
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

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
            var userData = RetrieveUserData(username);
            if (userData == null)
            {
                DialogResult result = MessageBox.Show("User not found! Would you like to sign up?", "Login Failed", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SignUpForm signUpForm = new SignUpForm();
                    signUpForm.Show();
                    this.Hide();
                }
                return;
            }
            CurrentUser.Username = username;
            CurrentUser.UserType = userData.Value.UserType;
            CurrentUser.UserID = userData.Value.UserID;

            if (ValidateUser(CurrentUser.Username, password, CurrentUser.UserType))
            {
                MessageBox.Show($"Login Successful! Welcome, {username} ({CurrentUser.UserType}).", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (CurrentUser.UserType == "Client") new ClientDashboard().Show();
                else if (CurrentUser.UserType == "Admin") new AdminDashboard().Show();
                else if (CurrentUser.UserType == "Vendor") new VendorDashboard().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidateUser(string username, string password, string userType)
        {
            string query = $"SELECT COUNT(*) FROM {userType} WHERE {userType}_Name = @username AND Pass = @password";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Database Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        private void linkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.Show();
            this.Hide(); 
        }
        private (string UserType, int UserID)? RetrieveUserData(string username)
        {
            string query = @"
        SELECT 'Admin' AS UserType, Admin_ID AS UserID FROM Admin WHERE Admin_Name = @username
        UNION 
        SELECT 'Vendor', Vendor_ID FROM Vendor WHERE Vendor_Name = @username
        UNION 
        SELECT 'Client', Client_ID FROM Client WHERE Client_Name = @username
        LIMIT 1"; 
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return (reader.GetString(0), reader.GetInt32(1));
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Database Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return null; 
        }
    }
}

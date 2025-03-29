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
    public partial class BrowseGames : Form
    {
        private string connString = "server=localhost;database=game_rental;user=root;password=\"1241994752002Sh;\";SslMode=None;";
        public BrowseGames()
        {
            InitializeComponent();
        }
        private void BrowseGames_Load(object sender, EventArgs e)
        {
            LoadVendorsAndCategories();
            LoadGames();
        }
        private void LoadGames()
        {
            string query = @"SELECT g.Game_ID, g.Game_Name, g.Category, 
                           g.Add_Date, g.Price, g.Admin_ID, 
                           g.Vendor_ID, v.Vendor_Name
                           FROM game g 
                           JOIN vendor v 
                           ON g.Vendor_ID = v.Vendor_ID";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvGames.DataSource = dt;
                        if (CurrentUser.UserType != "Admin" && dgvGames.Columns.Count > 0)
                        {
                            if (dgvGames.Columns.Contains("Game_ID")) dgvGames.Columns["Game_ID"].Visible = false;
                            if (dgvGames.Columns.Contains("Admin_ID")) dgvGames.Columns["Admin_ID"].Visible = false;
                            if (dgvGames.Columns.Contains("Vendor_ID")) dgvGames.Columns["Vendor_ID"].Visible = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading games: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string gameName = txtGameName.Text.Trim();
            string vendor = cmbVendor.SelectedItem?.ToString();
            string category = cmbCategory.SelectedItem?.ToString();
            int selectedYear = dtpYear.Value.Year; 
            bool isAdmin = CurrentUser.UserType == "Admin";
            string query = isAdmin
            ? @"SELECT g.Game_ID, g.Game_Name, g.Category, g.Add_Date, g.Price, g.Admin_ID, g.Vendor_ID, v.Vendor_Name 
        FROM game g
        JOIN vendor v ON g.Vendor_ID = v.Vendor_ID
        WHERE 1=1"
            : @"SELECT g.Game_Name, g.Category, g.Add_Date, g.Price, v.Vendor_Name 
        FROM game g
        JOIN vendor v ON g.Vendor_ID = v.Vendor_ID
        WHERE 1=1";

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
            if (dtpYear.Checked) 
            {
                query += " AND YEAR(g.Add_Date) = @year";
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
                        if (dtpYear.Checked) cmd.Parameters.AddWithValue("@year", selectedYear);
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvGames.DataSource = dt; 
                       
                            if (!isAdmin && dgvGames.Columns.Count > 0)
                            {
                                if (dgvGames.Columns.Contains("Game_ID")) dgvGames.Columns["Game_ID"].Visible = false;
                                if (dgvGames.Columns.Contains("Admin_ID")) dgvGames.Columns["Admin_ID"].Visible = false;
                                if (dgvGames.Columns.Contains("Vendor_ID")) dgvGames.Columns["Vendor_ID"].Visible = false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error searching for games: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnResetFilters_Click(object sender, EventArgs e)
        {
            txtGameName.Clear();  
            cmbCategory.SelectedIndex = 0;
            cmbVendor.SelectedIndex = 0; 
            dtpYear.Checked = false; 
            LoadGames();
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

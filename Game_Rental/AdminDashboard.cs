using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Rental
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }
        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            lblWelcomeMessageAdmin.Text = $"🎮 Welcome, {CurrentUser.Username}!";
        }
        private void btnBrowseGames_Click(object sender, EventArgs e)
        {
            BrowseGames browseGamesForm = new BrowseGames(); 
            browseGamesForm.Show(); 
            this.Close();
        }
        private void btnReviewGame_Click(object sender, EventArgs e)
        {
            ReviewUploads reviewUploadsForm = new ReviewUploads(); 
            reviewUploadsForm.Show(); 
            this.Close();
        }
        private void btnReviewUpdates_Click(object sender, EventArgs e)
        {
            ReviewUpdates reviewUpdatesForm = new ReviewUpdates(); 
            reviewUpdatesForm.Show(); 
            this.Close();
        }
        private void btnProfile_Click(object sender, EventArgs e)
        {
            EditProfile editProfileForm = new EditProfile();
            editProfileForm.Show();
            this.Close();
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

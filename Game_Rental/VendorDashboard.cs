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
    public partial class VendorDashboard: Form
    {
        public VendorDashboard()
        {
            InitializeComponent();
        }
        private void VendorDashboard_Load(object sender, EventArgs e)
        {
            lblWelcomeMessage.Text = $"🎮 Welcome, {CurrentUser.Username}!";
        }
        private void btnBrowseGames_Click(object sender, EventArgs e)
        {
            BrowseGames browseGamesForm = new BrowseGames(); 
            browseGamesForm.Show(); 
            this.Close();
        }
        private void btnAddGame_Click(object sender, EventArgs e)
        {
            AddGame addGameForm = new AddGame(); 
            addGameForm.Show(); 
            this.Close();
        }
        private void btnUpdateGame_Click(object sender, EventArgs e)
        {
            UpdateGame updateGameForm = new UpdateGame(); 
            updateGameForm.Show(); 
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

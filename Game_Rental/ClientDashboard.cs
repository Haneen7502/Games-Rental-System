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
    public partial class ClientDashboard: Form
    {
        public ClientDashboard()
        {
            InitializeComponent();
        }
        private void ClientDashboard_Load(object sender, EventArgs e)
        {
            lblWelcomeMessage.Text = $"🎮 Welcome, {CurrentUser.Username}!";
        }
        private void btnBrowseGames_Click(object sender, EventArgs e)
        {
            BrowseGames browseGamesForm = new BrowseGames();
            browseGamesForm.Show(); 
            this.Close();

        }
        private void btnRentGame_Click(object sender, EventArgs e)
        {
            RentGame rentGameForm = new RentGame(); 
            rentGameForm.Show(); 
            this.Close();
        }
        private void btnReturnGame_Click(object sender, EventArgs e)
        {
            ReturnGames returnGameForm = new ReturnGames();
            returnGameForm.Show();
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

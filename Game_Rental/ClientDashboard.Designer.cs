namespace Game_Rental
{
    partial class ClientDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRentGame = new System.Windows.Forms.Button();
            this.btnReturnGame = new System.Windows.Forms.Button();
            this.btnBrowseGames = new System.Windows.Forms.Button();
            this.lblWelcomeMessage = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRentGame
            // 
            this.btnRentGame.Location = new System.Drawing.Point(333, 87);
            this.btnRentGame.Name = "btnRentGame";
            this.btnRentGame.Size = new System.Drawing.Size(131, 31);
            this.btnRentGame.TabIndex = 0;
            this.btnRentGame.Text = "Rent a Game";
            this.btnRentGame.UseVisualStyleBackColor = true;
            this.btnRentGame.Click += new System.EventHandler(this.btnRentGame_Click);
            // 
            // btnReturnGame
            // 
            this.btnReturnGame.Location = new System.Drawing.Point(333, 145);
            this.btnReturnGame.Name = "btnReturnGame";
            this.btnReturnGame.Size = new System.Drawing.Size(131, 32);
            this.btnReturnGame.TabIndex = 1;
            this.btnReturnGame.Text = "Return a Game";
            this.btnReturnGame.UseVisualStyleBackColor = true;
            this.btnReturnGame.Click += new System.EventHandler(this.btnReturnGame_Click);
            // 
            // btnBrowseGames
            // 
            this.btnBrowseGames.Location = new System.Drawing.Point(333, 203);
            this.btnBrowseGames.Name = "btnBrowseGames";
            this.btnBrowseGames.Size = new System.Drawing.Size(131, 30);
            this.btnBrowseGames.TabIndex = 2;
            this.btnBrowseGames.Text = "Browse Games";
            this.btnBrowseGames.UseVisualStyleBackColor = true;
            this.btnBrowseGames.Click += new System.EventHandler(this.btnBrowseGames_Click);
            // 
            // lblWelcomeMessage
            // 
            this.lblWelcomeMessage.AutoSize = true;
            this.lblWelcomeMessage.Location = new System.Drawing.Point(311, 44);
            this.lblWelcomeMessage.Name = "lblWelcomeMessage";
            this.lblWelcomeMessage.Size = new System.Drawing.Size(0, 16);
            this.lblWelcomeMessage.TabIndex = 3;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(333, 257);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(131, 30);
            this.btnLogOut.TabIndex = 4;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.Location = new System.Drawing.Point(687, 12);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(101, 35);
            this.btnProfile.TabIndex = 5;
            this.btnProfile.Text = "Profile";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // ClientDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.lblWelcomeMessage);
            this.Controls.Add(this.btnBrowseGames);
            this.Controls.Add(this.btnReturnGame);
            this.Controls.Add(this.btnRentGame);
            this.Name = "ClientDashboard";
            this.Text = "ClientDashboard";
            this.Load += new System.EventHandler(this.ClientDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRentGame;
        private System.Windows.Forms.Button btnReturnGame;
        private System.Windows.Forms.Button btnBrowseGames;
        private System.Windows.Forms.Label lblWelcomeMessage;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnProfile;
    }
}
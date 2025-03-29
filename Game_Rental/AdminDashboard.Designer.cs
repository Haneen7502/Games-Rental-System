namespace Game_Rental
{
    partial class AdminDashboard
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
            this.lblWelcomeMessageAdmin = new System.Windows.Forms.Label();
            this.btnReviewGame = new System.Windows.Forms.Button();
            this.btnBrowseGames = new System.Windows.Forms.Button();
            this.btnReviewUpdates = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWelcomeMessageAdmin
            // 
            this.lblWelcomeMessageAdmin.AutoSize = true;
            this.lblWelcomeMessageAdmin.Location = new System.Drawing.Point(327, 40);
            this.lblWelcomeMessageAdmin.Name = "lblWelcomeMessageAdmin";
            this.lblWelcomeMessageAdmin.Size = new System.Drawing.Size(0, 16);
            this.lblWelcomeMessageAdmin.TabIndex = 0;
            // 
            // btnReviewGame
            // 
            this.btnReviewGame.Location = new System.Drawing.Point(345, 73);
            this.btnReviewGame.Name = "btnReviewGame";
            this.btnReviewGame.Size = new System.Drawing.Size(131, 34);
            this.btnReviewGame.TabIndex = 2;
            this.btnReviewGame.Text = "Review Uploads\r\n";
            this.btnReviewGame.UseVisualStyleBackColor = true;
            this.btnReviewGame.Click += new System.EventHandler(this.btnReviewGame_Click);
            // 
            // btnBrowseGames
            // 
            this.btnBrowseGames.Location = new System.Drawing.Point(345, 226);
            this.btnBrowseGames.Name = "btnBrowseGames";
            this.btnBrowseGames.Size = new System.Drawing.Size(131, 33);
            this.btnBrowseGames.TabIndex = 3;
            this.btnBrowseGames.Text = "Browse Games";
            this.btnBrowseGames.UseVisualStyleBackColor = true;
            this.btnBrowseGames.Click += new System.EventHandler(this.btnBrowseGames_Click);
            // 
            // btnReviewUpdates
            // 
            this.btnReviewUpdates.Location = new System.Drawing.Point(345, 145);
            this.btnReviewUpdates.Name = "btnReviewUpdates";
            this.btnReviewUpdates.Size = new System.Drawing.Size(131, 36);
            this.btnReviewUpdates.TabIndex = 4;
            this.btnReviewUpdates.Text = "Review Updates";
            this.btnReviewUpdates.UseVisualStyleBackColor = true;
            this.btnReviewUpdates.Click += new System.EventHandler(this.btnReviewUpdates_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(345, 291);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(131, 30);
            this.btnLogOut.TabIndex = 5;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.Location = new System.Drawing.Point(687, 12);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(101, 35);
            this.btnProfile.TabIndex = 6;
            this.btnProfile.Text = "Profile";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnReviewUpdates);
            this.Controls.Add(this.btnBrowseGames);
            this.Controls.Add(this.btnReviewGame);
            this.Controls.Add(this.lblWelcomeMessageAdmin);
            this.Name = "AdminDashboard";
            this.Text = "AdminDashboard";
            this.Load += new System.EventHandler(this.AdminDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcomeMessageAdmin;
        private System.Windows.Forms.Button btnReviewGame;
        private System.Windows.Forms.Button btnBrowseGames;
        private System.Windows.Forms.Button btnReviewUpdates;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnProfile;
    }
}
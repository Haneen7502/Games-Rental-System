namespace Game_Rental
{
    partial class ReturnGames
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
            this.dgvRentedGames = new System.Windows.Forms.DataGridView();
            this.btnReturnGame = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentedGames)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRentedGames
            // 
            this.dgvRentedGames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRentedGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRentedGames.Location = new System.Drawing.Point(0, 192);
            this.dgvRentedGames.Name = "dgvRentedGames";
            this.dgvRentedGames.RowHeadersWidth = 51;
            this.dgvRentedGames.RowTemplate.Height = 24;
            this.dgvRentedGames.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRentedGames.Size = new System.Drawing.Size(800, 259);
            this.dgvRentedGames.TabIndex = 0;
            // 
            // btnReturnGame
            // 
            this.btnReturnGame.Location = new System.Drawing.Point(312, 64);
            this.btnReturnGame.Name = "btnReturnGame";
            this.btnReturnGame.Size = new System.Drawing.Size(193, 52);
            this.btnReturnGame.TabIndex = 1;
            this.btnReturnGame.Text = "Return Selected Game";
            this.btnReturnGame.UseVisualStyleBackColor = true;
            this.btnReturnGame.Click += new System.EventHandler(this.btnReturnGame_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(713, 9);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back 🔙";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(330, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(144, 16);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Return a Rented Game";
            // 
            // ReturnGames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnReturnGame);
            this.Controls.Add(this.dgvRentedGames);
            this.Name = "ReturnGames";
            this.Text = "ReturnGames";
            this.Load += new System.EventHandler(this.ReturnGames_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentedGames)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRentedGames;
        private System.Windows.Forms.Button btnReturnGame;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;
    }
}
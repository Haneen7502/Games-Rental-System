namespace Game_Rental
{
    partial class AddGame
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
            this.btnSubmitGame = new System.Windows.Forms.Button();
            this.dgvUploadedGames = new System.Windows.Forms.DataGridView();
            this.txtGameName = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblVendor = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpAddDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUploadedGames)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSubmitGame
            // 
            this.btnSubmitGame.Location = new System.Drawing.Point(196, 185);
            this.btnSubmitGame.Name = "btnSubmitGame";
            this.btnSubmitGame.Size = new System.Drawing.Size(92, 35);
            this.btnSubmitGame.TabIndex = 0;
            this.btnSubmitGame.Text = "Submit";
            this.btnSubmitGame.UseVisualStyleBackColor = true;
            this.btnSubmitGame.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // dgvUploadedGames
            // 
            this.dgvUploadedGames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUploadedGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUploadedGames.Location = new System.Drawing.Point(-1, 269);
            this.dgvUploadedGames.Name = "dgvUploadedGames";
            this.dgvUploadedGames.RowHeadersWidth = 51;
            this.dgvUploadedGames.RowTemplate.Height = 24;
            this.dgvUploadedGames.Size = new System.Drawing.Size(800, 180);
            this.dgvUploadedGames.TabIndex = 2;
            // 
            // txtGameName
            // 
            this.txtGameName.Location = new System.Drawing.Point(343, 37);
            this.txtGameName.Name = "txtGameName";
            this.txtGameName.Size = new System.Drawing.Size(100, 22);
            this.txtGameName.TabIndex = 3;
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(331, 116);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(121, 24);
            this.cmbCategory.TabIndex = 4;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(339, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(102, 16);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Add New Game";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(502, 185);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 35);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(341, 234);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(127, 16);
            this.lblVendor.TabIndex = 7;
            this.lblVendor.Text = "Your Current Games";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(343, 75);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 22);
            this.txtPrice.TabIndex = 8;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(253, 40);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(87, 16);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "Game Name:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(298, 78);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(41, 16);
            this.lblPrice.TabIndex = 10;
            this.lblPrice.Text = "Price:";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(263, 120);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(65, 16);
            this.lblCategory.TabIndex = 11;
            this.lblCategory.Text = "Category:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(224, 158);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(67, 16);
            this.lblDate.TabIndex = 12;
            this.lblDate.Text = "Add Date:";
            // 
            // dtpAddDate
            // 
            this.dtpAddDate.CustomFormat = "yyyy-MM-dd";
            this.dtpAddDate.Enabled = false;
            this.dtpAddDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAddDate.Location = new System.Drawing.Point(296, 155);
            this.dtpAddDate.Name = "dtpAddDate";
            this.dtpAddDate.Size = new System.Drawing.Size(200, 22);
            this.dtpAddDate.TabIndex = 13;
            // 
            // AddGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtpAddDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblVendor);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.txtGameName);
            this.Controls.Add(this.dgvUploadedGames);
            this.Controls.Add(this.btnSubmitGame);
            this.Name = "AddGame";
            this.Text = "AddGame";
            this.Load += new System.EventHandler(this.AddGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUploadedGames)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmitGame;
        private System.Windows.Forms.DataGridView dgvUploadedGames;
        private System.Windows.Forms.TextBox txtGameName;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpAddDate;
    }
}
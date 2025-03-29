namespace Game_Rental
{
    partial class UpdateGame
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
            this.dgvVendorGames = new System.Windows.Forms.DataGridView();
            this.txtNewGameName = new System.Windows.Forms.TextBox();
            this.btnSubmitUpdate = new System.Windows.Forms.Button();
            this.cmbNewCategory = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtNewPrice = new System.Windows.Forms.TextBox();
            this.txtUpdateDescription = new System.Windows.Forms.TextBox();
            this.dtpUpdateDate = new System.Windows.Forms.DateTimePicker();
            this.btnCancelUpdate = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDis = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendorGames)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVendorGames
            // 
            this.dgvVendorGames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVendorGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendorGames.Location = new System.Drawing.Point(-1, 270);
            this.dgvVendorGames.Name = "dgvVendorGames";
            this.dgvVendorGames.RowHeadersWidth = 51;
            this.dgvVendorGames.RowTemplate.Height = 24;
            this.dgvVendorGames.Size = new System.Drawing.Size(1272, 180);
            this.dgvVendorGames.TabIndex = 0;
            // 
            // txtNewGameName
            // 
            this.txtNewGameName.Location = new System.Drawing.Point(619, 41);
            this.txtNewGameName.Name = "txtNewGameName";
            this.txtNewGameName.Size = new System.Drawing.Size(121, 22);
            this.txtNewGameName.TabIndex = 1;
            // 
            // btnSubmitUpdate
            // 
            this.btnSubmitUpdate.Location = new System.Drawing.Point(57, 231);
            this.btnSubmitUpdate.Name = "btnSubmitUpdate";
            this.btnSubmitUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnSubmitUpdate.TabIndex = 2;
            this.btnSubmitUpdate.Text = "Submit";
            this.btnSubmitUpdate.UseVisualStyleBackColor = true;
            this.btnSubmitUpdate.Click += new System.EventHandler(this.btnSubmitUpdate_Click);
            // 
            // cmbNewCategory
            // 
            this.cmbNewCategory.FormattingEnabled = true;
            this.cmbNewCategory.Location = new System.Drawing.Point(619, 127);
            this.cmbNewCategory.Name = "cmbNewCategory";
            this.cmbNewCategory.Size = new System.Drawing.Size(121, 24);
            this.cmbNewCategory.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(627, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(103, 16);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Update a Game";
            // 
            // txtNewPrice
            // 
            this.txtNewPrice.Location = new System.Drawing.Point(619, 84);
            this.txtNewPrice.Name = "txtNewPrice";
            this.txtNewPrice.Size = new System.Drawing.Size(121, 22);
            this.txtNewPrice.TabIndex = 7;
            this.txtNewPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // txtUpdateDescription
            // 
            this.txtUpdateDescription.Location = new System.Drawing.Point(619, 167);
            this.txtUpdateDescription.Name = "txtUpdateDescription";
            this.txtUpdateDescription.Size = new System.Drawing.Size(121, 22);
            this.txtUpdateDescription.TabIndex = 8;
            // 
            // dtpUpdateDate
            // 
            this.dtpUpdateDate.CustomFormat = "yyyy-MM-dd";
            this.dtpUpdateDate.Enabled = false;
            this.dtpUpdateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpUpdateDate.Location = new System.Drawing.Point(583, 211);
            this.dtpUpdateDate.Name = "dtpUpdateDate";
            this.dtpUpdateDate.Size = new System.Drawing.Size(200, 22);
            this.dtpUpdateDate.TabIndex = 14;
            // 
            // btnCancelUpdate
            // 
            this.btnCancelUpdate.Location = new System.Drawing.Point(1152, 241);
            this.btnCancelUpdate.Name = "btnCancelUpdate";
            this.btnCancelUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnCancelUpdate.TabIndex = 15;
            this.btnCancelUpdate.Text = "Cancel";
            this.btnCancelUpdate.UseVisualStyleBackColor = true;
            this.btnCancelUpdate.Click += new System.EventHandler(this.btnCancelUpdate_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(515, 44);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(103, 16);
            this.lblName.TabIndex = 16;
            this.lblName.Text = "Updated Name:";
            // 
            // lblDis
            // 
            this.lblDis.AutoSize = true;
            this.lblDis.Location = new System.Drawing.Point(486, 170);
            this.lblDis.Name = "lblDis";
            this.lblDis.Size = new System.Drawing.Size(129, 16);
            this.lblDis.TabIndex = 19;
            this.lblDis.Text = "Update Description :";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(519, 88);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(97, 16);
            this.lblPrice.TabIndex = 21;
            this.lblPrice.Text = "Updated Price:";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(495, 131);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(121, 16);
            this.lblCategory.TabIndex = 22;
            this.lblCategory.Text = "Updated Category:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(493, 214);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(87, 16);
            this.lblDate.TabIndex = 23;
            this.lblDate.Text = "Update Date:";
            // 
            // UpdateGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 450);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblDis);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnCancelUpdate);
            this.Controls.Add(this.dtpUpdateDate);
            this.Controls.Add(this.txtUpdateDescription);
            this.Controls.Add(this.txtNewPrice);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cmbNewCategory);
            this.Controls.Add(this.btnSubmitUpdate);
            this.Controls.Add(this.txtNewGameName);
            this.Controls.Add(this.dgvVendorGames);
            this.Name = "UpdateGame";
            this.Text = "UpdateGame";
            this.Load += new System.EventHandler(this.UpdateGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendorGames)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVendorGames;
        private System.Windows.Forms.TextBox txtNewGameName;
        private System.Windows.Forms.Button btnSubmitUpdate;
        private System.Windows.Forms.ComboBox cmbNewCategory;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtNewPrice;
        private System.Windows.Forms.TextBox txtUpdateDescription;
        private System.Windows.Forms.DateTimePicker dtpUpdateDate;
        private System.Windows.Forms.Button btnCancelUpdate;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDis;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblDate;
    }
}
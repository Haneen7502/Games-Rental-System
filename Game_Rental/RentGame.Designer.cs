namespace Game_Rental
{
    partial class RentGame
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
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbVendor = new System.Windows.Forms.ComboBox();
            this.txtSearchGame = new System.Windows.Forms.TextBox();
            this.btnResetFilters = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnRent = new System.Windows.Forms.Button();
            this.dtpReturnDate = new System.Windows.Forms.DateTimePicker();
            this.dgvAvailableGames = new System.Windows.Forms.DataGridView();
            this.lblGamename = new System.Windows.Forms.Label();
            this.lblVendor = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnApply_Filter = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableGames)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(321, 50);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(121, 24);
            this.cmbCategory.TabIndex = 0;
            // 
            // cmbVendor
            // 
            this.cmbVendor.FormattingEnabled = true;
            this.cmbVendor.Location = new System.Drawing.Point(556, 48);
            this.cmbVendor.Name = "cmbVendor";
            this.cmbVendor.Size = new System.Drawing.Size(121, 24);
            this.cmbVendor.TabIndex = 1;
            // 
            // txtSearchGame
            // 
            this.txtSearchGame.Location = new System.Drawing.Point(96, 52);
            this.txtSearchGame.Name = "txtSearchGame";
            this.txtSearchGame.Size = new System.Drawing.Size(100, 22);
            this.txtSearchGame.TabIndex = 2;
            // 
            // btnResetFilters
            // 
            this.btnResetFilters.Location = new System.Drawing.Point(698, 48);
            this.btnResetFilters.Name = "btnResetFilters";
            this.btnResetFilters.Size = new System.Drawing.Size(90, 23);
            this.btnResetFilters.TabIndex = 3;
            this.btnResetFilters.Text = "Reset Filters";
            this.btnResetFilters.UseVisualStyleBackColor = true;
            this.btnResetFilters.Click += new System.EventHandler(this.btnResetFilters_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(713, 378);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back 🔙";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnRent
            // 
            this.btnRent.Location = new System.Drawing.Point(465, 378);
            this.btnRent.Name = "btnRent";
            this.btnRent.Size = new System.Drawing.Size(75, 23);
            this.btnRent.TabIndex = 5;
            this.btnRent.Text = "Rent";
            this.btnRent.UseVisualStyleBackColor = true;
            this.btnRent.Click += new System.EventHandler(this.btnRent_Click);
            // 
            // dtpReturnDate
            // 
            this.dtpReturnDate.CustomFormat = "yyyy-MM-dd";
            this.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReturnDate.Location = new System.Drawing.Point(119, 380);
            this.dtpReturnDate.Name = "dtpReturnDate";
            this.dtpReturnDate.Size = new System.Drawing.Size(200, 22);
            this.dtpReturnDate.TabIndex = 7;
            // 
            // dgvAvailableGames
            // 
            this.dgvAvailableGames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAvailableGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailableGames.Location = new System.Drawing.Point(0, 156);
            this.dgvAvailableGames.Name = "dgvAvailableGames";
            this.dgvAvailableGames.RowHeadersWidth = 51;
            this.dgvAvailableGames.RowTemplate.Height = 24;
            this.dgvAvailableGames.Size = new System.Drawing.Size(800, 180);
            this.dgvAvailableGames.TabIndex = 8;
            // 
            // lblGamename
            // 
            this.lblGamename.AutoSize = true;
            this.lblGamename.Location = new System.Drawing.Point(12, 55);
            this.lblGamename.Name = "lblGamename";
            this.lblGamename.Size = new System.Drawing.Size(66, 16);
            this.lblGamename.TabIndex = 9;
            this.lblGamename.Text = "By Name:";
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(467, 54);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(73, 16);
            this.lblVendor.TabIndex = 10;
            this.lblVendor.Text = "By Vendor:";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(216, 55);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(84, 16);
            this.lblCategory.TabIndex = 11;
            this.lblCategory.Text = "By Category:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 385);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Return Date:";
            // 
            // btnApply_Filter
            // 
            this.btnApply_Filter.Location = new System.Drawing.Point(321, 102);
            this.btnApply_Filter.Name = "btnApply_Filter";
            this.btnApply_Filter.Size = new System.Drawing.Size(91, 30);
            this.btnApply_Filter.TabIndex = 13;
            this.btnApply_Filter.Text = "Apply";
            this.btnApply_Filter.UseVisualStyleBackColor = true;
            this.btnApply_Filter.Click += new System.EventHandler(this.btnApply_Filter_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(333, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(82, 16);
            this.lblTitle.TabIndex = 14;
            this.lblTitle.Text = "Rent Games";
            // 
            // RentGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnApply_Filter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblVendor);
            this.Controls.Add(this.lblGamename);
            this.Controls.Add(this.dgvAvailableGames);
            this.Controls.Add(this.dtpReturnDate);
            this.Controls.Add(this.btnRent);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnResetFilters);
            this.Controls.Add(this.txtSearchGame);
            this.Controls.Add(this.cmbVendor);
            this.Controls.Add(this.cmbCategory);
            this.Name = "RentGame";
            this.Text = "RentGame";
            this.Load += new System.EventHandler(this.RentGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableGames)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbVendor;
        private System.Windows.Forms.TextBox txtSearchGame;
        private System.Windows.Forms.Button btnResetFilters;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnRent;
        private System.Windows.Forms.DateTimePicker dtpReturnDate;
        private System.Windows.Forms.DataGridView dgvAvailableGames;
        private System.Windows.Forms.Label lblGamename;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApply_Filter;
        private System.Windows.Forms.Label lblTitle;
    }
}
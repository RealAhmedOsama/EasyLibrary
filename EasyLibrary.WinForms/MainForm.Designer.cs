namespace EasyLibrary.WinForms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            BtnDashboard = new Button();
            pictureBox9 = new PictureBox();
            BtnBorrowTransactions = new Button();
            pictureBox7 = new PictureBox();
            BtnReservationTransactions = new Button();
            pictureBox8 = new PictureBox();
            BtnRolesManagement = new Button();
            pictureBox6 = new PictureBox();
            BtnUsersManagement = new Button();
            pictureBox5 = new PictureBox();
            BtnMembersManagement = new Button();
            pictureBox4 = new PictureBox();
            BtnCategoriesManagement = new Button();
            pictureBox3 = new PictureBox();
            BtnBooksManagement = new Button();
            pictureBox2 = new PictureBox();
            BtnAbout = new Button();
            pictureBox10 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Easy_Library;
            pictureBox1.Location = new Point(286, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(262, 156);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BtnAbout);
            groupBox1.Controls.Add(pictureBox10);
            groupBox1.Controls.Add(BtnDashboard);
            groupBox1.Controls.Add(pictureBox9);
            groupBox1.Controls.Add(BtnBorrowTransactions);
            groupBox1.Controls.Add(pictureBox7);
            groupBox1.Controls.Add(BtnReservationTransactions);
            groupBox1.Controls.Add(pictureBox8);
            groupBox1.Controls.Add(BtnRolesManagement);
            groupBox1.Controls.Add(pictureBox6);
            groupBox1.Controls.Add(BtnUsersManagement);
            groupBox1.Controls.Add(pictureBox5);
            groupBox1.Controls.Add(BtnMembersManagement);
            groupBox1.Controls.Add(pictureBox4);
            groupBox1.Controls.Add(BtnCategoriesManagement);
            groupBox1.Controls.Add(pictureBox3);
            groupBox1.Controls.Add(BtnBooksManagement);
            groupBox1.Controls.Add(pictureBox2);
            groupBox1.Location = new Point(12, 174);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(810, 285);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Navigations";
            // 
            // BtnDashboard
            // 
            BtnDashboard.BackColor = Color.FromArgb(25, 118, 210);
            BtnDashboard.FlatAppearance.BorderSize = 0;
            BtnDashboard.FlatAppearance.CheckedBackColor = Color.FromArgb(30, 136, 229);
            BtnDashboard.FlatAppearance.MouseDownBackColor = Color.FromArgb(13, 71, 161);
            BtnDashboard.FlatAppearance.MouseOverBackColor = Color.FromArgb(21, 101, 192);
            BtnDashboard.FlatStyle = FlatStyle.Flat;
            BtnDashboard.ForeColor = Color.White;
            BtnDashboard.Location = new Point(14, 101);
            BtnDashboard.Name = "BtnDashboard";
            BtnDashboard.Size = new Size(146, 34);
            BtnDashboard.TabIndex = 19;
            BtnDashboard.Text = "Dashboard";
            BtnDashboard.UseVisualStyleBackColor = false;
            BtnDashboard.Click += BtnDashboard_Click;
            // 
            // pictureBox9
            // 
            pictureBox9.Image = (Image)resources.GetObject("pictureBox9.Image");
            pictureBox9.Location = new Point(55, 22);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(64, 64);
            pictureBox9.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox9.TabIndex = 18;
            pictureBox9.TabStop = false;
            // 
            // BtnBorrowTransactions
            // 
            BtnBorrowTransactions.BackColor = Color.FromArgb(25, 118, 210);
            BtnBorrowTransactions.FlatAppearance.BorderSize = 0;
            BtnBorrowTransactions.FlatAppearance.CheckedBackColor = Color.FromArgb(30, 136, 229);
            BtnBorrowTransactions.FlatAppearance.MouseDownBackColor = Color.FromArgb(13, 71, 161);
            BtnBorrowTransactions.FlatAppearance.MouseOverBackColor = Color.FromArgb(21, 101, 192);
            BtnBorrowTransactions.FlatStyle = FlatStyle.Flat;
            BtnBorrowTransactions.ForeColor = Color.White;
            BtnBorrowTransactions.Location = new Point(332, 236);
            BtnBorrowTransactions.Name = "BtnBorrowTransactions";
            BtnBorrowTransactions.Size = new Size(146, 34);
            BtnBorrowTransactions.TabIndex = 17;
            BtnBorrowTransactions.Text = "Borrow Transactions";
            BtnBorrowTransactions.UseVisualStyleBackColor = false;
            BtnBorrowTransactions.Click += BtnBorrowTransactions_Click;
            // 
            // pictureBox7
            // 
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(373, 157);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(64, 64);
            pictureBox7.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox7.TabIndex = 16;
            pictureBox7.TabStop = false;
            // 
            // BtnReservationTransactions
            // 
            BtnReservationTransactions.BackColor = Color.FromArgb(25, 118, 210);
            BtnReservationTransactions.FlatAppearance.BorderSize = 0;
            BtnReservationTransactions.FlatAppearance.CheckedBackColor = Color.FromArgb(30, 136, 229);
            BtnReservationTransactions.FlatAppearance.MouseDownBackColor = Color.FromArgb(13, 71, 161);
            BtnReservationTransactions.FlatAppearance.MouseOverBackColor = Color.FromArgb(21, 101, 192);
            BtnReservationTransactions.FlatStyle = FlatStyle.Flat;
            BtnReservationTransactions.ForeColor = Color.White;
            BtnReservationTransactions.Location = new Point(173, 236);
            BtnReservationTransactions.Name = "BtnReservationTransactions";
            BtnReservationTransactions.Size = new Size(146, 34);
            BtnReservationTransactions.TabIndex = 15;
            BtnReservationTransactions.Text = "Reservation Transactions";
            BtnReservationTransactions.UseVisualStyleBackColor = false;
            BtnReservationTransactions.Click += BtnReservationTransactions_Click;
            // 
            // pictureBox8
            // 
            pictureBox8.Image = (Image)resources.GetObject("pictureBox8.Image");
            pictureBox8.Location = new Point(214, 157);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(64, 64);
            pictureBox8.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox8.TabIndex = 14;
            pictureBox8.TabStop = false;
            // 
            // BtnRolesManagement
            // 
            BtnRolesManagement.BackColor = Color.FromArgb(25, 118, 210);
            BtnRolesManagement.FlatAppearance.BorderSize = 0;
            BtnRolesManagement.FlatAppearance.CheckedBackColor = Color.FromArgb(30, 136, 229);
            BtnRolesManagement.FlatAppearance.MouseDownBackColor = Color.FromArgb(13, 71, 161);
            BtnRolesManagement.FlatAppearance.MouseOverBackColor = Color.FromArgb(21, 101, 192);
            BtnRolesManagement.FlatStyle = FlatStyle.Flat;
            BtnRolesManagement.ForeColor = Color.White;
            BtnRolesManagement.Location = new Point(14, 236);
            BtnRolesManagement.Name = "BtnRolesManagement";
            BtnRolesManagement.Size = new Size(146, 34);
            BtnRolesManagement.TabIndex = 13;
            BtnRolesManagement.Text = "Roles Management";
            BtnRolesManagement.UseVisualStyleBackColor = false;
            BtnRolesManagement.Click += BtnRolesManagement_Click;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(55, 157);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(64, 64);
            pictureBox6.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox6.TabIndex = 12;
            pictureBox6.TabStop = false;
            // 
            // BtnUsersManagement
            // 
            BtnUsersManagement.BackColor = Color.FromArgb(25, 118, 210);
            BtnUsersManagement.FlatAppearance.BorderSize = 0;
            BtnUsersManagement.FlatAppearance.CheckedBackColor = Color.FromArgb(30, 136, 229);
            BtnUsersManagement.FlatAppearance.MouseDownBackColor = Color.FromArgb(13, 71, 161);
            BtnUsersManagement.FlatAppearance.MouseOverBackColor = Color.FromArgb(21, 101, 192);
            BtnUsersManagement.FlatStyle = FlatStyle.Flat;
            BtnUsersManagement.ForeColor = Color.White;
            BtnUsersManagement.Location = new Point(650, 101);
            BtnUsersManagement.Name = "BtnUsersManagement";
            BtnUsersManagement.Size = new Size(146, 34);
            BtnUsersManagement.TabIndex = 11;
            BtnUsersManagement.Text = "Users Management";
            BtnUsersManagement.UseVisualStyleBackColor = false;
            BtnUsersManagement.Click += BtnUsersManagement_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(691, 22);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(64, 64);
            pictureBox5.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox5.TabIndex = 10;
            pictureBox5.TabStop = false;
            // 
            // BtnMembersManagement
            // 
            BtnMembersManagement.BackColor = Color.FromArgb(25, 118, 210);
            BtnMembersManagement.FlatAppearance.BorderSize = 0;
            BtnMembersManagement.FlatAppearance.CheckedBackColor = Color.FromArgb(30, 136, 229);
            BtnMembersManagement.FlatAppearance.MouseDownBackColor = Color.FromArgb(13, 71, 161);
            BtnMembersManagement.FlatAppearance.MouseOverBackColor = Color.FromArgb(21, 101, 192);
            BtnMembersManagement.FlatStyle = FlatStyle.Flat;
            BtnMembersManagement.ForeColor = Color.White;
            BtnMembersManagement.Location = new Point(491, 101);
            BtnMembersManagement.Name = "BtnMembersManagement";
            BtnMembersManagement.Size = new Size(146, 34);
            BtnMembersManagement.TabIndex = 9;
            BtnMembersManagement.Text = "Members Management";
            BtnMembersManagement.UseVisualStyleBackColor = false;
            BtnMembersManagement.Click += BtnMembersManagement_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(532, 22);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(64, 64);
            pictureBox4.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox4.TabIndex = 8;
            pictureBox4.TabStop = false;
            // 
            // BtnCategoriesManagement
            // 
            BtnCategoriesManagement.BackColor = Color.FromArgb(25, 118, 210);
            BtnCategoriesManagement.FlatAppearance.BorderSize = 0;
            BtnCategoriesManagement.FlatAppearance.CheckedBackColor = Color.FromArgb(30, 136, 229);
            BtnCategoriesManagement.FlatAppearance.MouseDownBackColor = Color.FromArgb(13, 71, 161);
            BtnCategoriesManagement.FlatAppearance.MouseOverBackColor = Color.FromArgb(21, 101, 192);
            BtnCategoriesManagement.FlatStyle = FlatStyle.Flat;
            BtnCategoriesManagement.ForeColor = Color.White;
            BtnCategoriesManagement.Location = new Point(332, 101);
            BtnCategoriesManagement.Name = "BtnCategoriesManagement";
            BtnCategoriesManagement.Size = new Size(146, 34);
            BtnCategoriesManagement.TabIndex = 7;
            BtnCategoriesManagement.Text = "Categories Management";
            BtnCategoriesManagement.UseVisualStyleBackColor = false;
            BtnCategoriesManagement.Click += BtnCategoriesManagement_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(373, 22);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(64, 64);
            pictureBox3.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            // 
            // BtnBooksManagement
            // 
            BtnBooksManagement.BackColor = Color.FromArgb(25, 118, 210);
            BtnBooksManagement.FlatAppearance.BorderSize = 0;
            BtnBooksManagement.FlatAppearance.CheckedBackColor = Color.FromArgb(30, 136, 229);
            BtnBooksManagement.FlatAppearance.MouseDownBackColor = Color.FromArgb(13, 71, 161);
            BtnBooksManagement.FlatAppearance.MouseOverBackColor = Color.FromArgb(21, 101, 192);
            BtnBooksManagement.FlatStyle = FlatStyle.Flat;
            BtnBooksManagement.ForeColor = Color.White;
            BtnBooksManagement.Location = new Point(173, 101);
            BtnBooksManagement.Name = "BtnBooksManagement";
            BtnBooksManagement.Size = new Size(146, 34);
            BtnBooksManagement.TabIndex = 5;
            BtnBooksManagement.Text = "Books Management";
            BtnBooksManagement.UseVisualStyleBackColor = false;
            BtnBooksManagement.Click += BtnBooksManagement_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(214, 22);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(64, 64);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // BtnAbout
            // 
            BtnAbout.BackColor = Color.FromArgb(25, 118, 210);
            BtnAbout.FlatAppearance.BorderSize = 0;
            BtnAbout.FlatAppearance.CheckedBackColor = Color.FromArgb(30, 136, 229);
            BtnAbout.FlatAppearance.MouseDownBackColor = Color.FromArgb(13, 71, 161);
            BtnAbout.FlatAppearance.MouseOverBackColor = Color.FromArgb(21, 101, 192);
            BtnAbout.FlatStyle = FlatStyle.Flat;
            BtnAbout.ForeColor = Color.White;
            BtnAbout.Location = new Point(491, 236);
            BtnAbout.Name = "BtnAbout";
            BtnAbout.Size = new Size(146, 34);
            BtnAbout.TabIndex = 21;
            BtnAbout.Text = "About";
            BtnAbout.UseVisualStyleBackColor = false;
            BtnAbout.Click += BtnAbout_Click;
            // 
            // pictureBox10
            // 
            pictureBox10.Image = (Image)resources.GetObject("pictureBox10.Image");
            pictureBox10.Location = new Point(532, 157);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(64, 64);
            pictureBox10.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox10.TabIndex = 20;
            pictureBox10.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(834, 470);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Easy Library";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private Button BtnBooksManagement;
        private PictureBox pictureBox2;
        private Button BtnCategoriesManagement;
        private PictureBox pictureBox3;
        private Button BtnRolesManagement;
        private PictureBox pictureBox6;
        private Button BtnUsersManagement;
        private PictureBox pictureBox5;
        private Button BtnMembersManagement;
        private PictureBox pictureBox4;
        private Button BtnBorrowTransactions;
        private PictureBox pictureBox7;
        private Button BtnReservationTransactions;
        private PictureBox pictureBox8;
        private Button BtnDashboard;
        private PictureBox pictureBox9;
        private Button BtnAbout;
        private PictureBox pictureBox10;
    }
}
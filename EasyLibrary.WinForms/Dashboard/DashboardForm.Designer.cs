namespace EasyLibrary.WinForms.Dashboard
{
    partial class DashboardForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            groupBox1 = new GroupBox();
            LblTotalBooksCount = new Label();
            pictureBox2 = new PictureBox();
            groupBox2 = new GroupBox();
            LblTotalMembersCount = new Label();
            pictureBox4 = new PictureBox();
            groupBox3 = new GroupBox();
            LblBorrowedThisMonthCount = new Label();
            LblBorrowedTodayCount = new Label();
            pictureBox7 = new PictureBox();
            groupBox4 = new GroupBox();
            ListTopRatedBooks = new ListBox();
            LblTopRatedBookName = new Label();
            label5 = new Label();
            pictureBox3 = new PictureBox();
            groupBox5 = new GroupBox();
            ListReservationPending = new ListBox();
            LblReservationPendingCount = new Label();
            pictureBox8 = new PictureBox();
            groupBox6 = new GroupBox();
            ListBoxOverdueBooks = new ListBox();
            LblTotalOverdueBooksCount = new Label();
            pictureBox1 = new PictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(LblTotalBooksCount);
            groupBox1.Controls.Add(pictureBox2);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(255, 100);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Total Books";
            // 
            // LblTotalBooksCount
            // 
            LblTotalBooksCount.AutoSize = true;
            LblTotalBooksCount.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            LblTotalBooksCount.Location = new Point(6, 46);
            LblTotalBooksCount.Name = "LblTotalBooksCount";
            LblTotalBooksCount.Size = new Size(133, 17);
            LblTotalBooksCount.TabIndex = 6;
            LblTotalBooksCount.Text = "Total Books Count: 0";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(189, 22);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(64, 64);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(LblTotalMembersCount);
            groupBox2.Controls.Add(pictureBox4);
            groupBox2.Location = new Point(289, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(255, 100);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Members";
            // 
            // LblTotalMembersCount
            // 
            LblTotalMembersCount.AutoSize = true;
            LblTotalMembersCount.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            LblTotalMembersCount.Location = new Point(6, 46);
            LblTotalMembersCount.Name = "LblTotalMembersCount";
            LblTotalMembersCount.Size = new Size(153, 17);
            LblTotalMembersCount.TabIndex = 10;
            LblTotalMembersCount.Text = "Total Members Count: 0";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(189, 22);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(64, 64);
            pictureBox4.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox4.TabIndex = 9;
            pictureBox4.TabStop = false;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(LblBorrowedThisMonthCount);
            groupBox3.Controls.Add(LblBorrowedTodayCount);
            groupBox3.Controls.Add(pictureBox7);
            groupBox3.Location = new Point(566, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(255, 100);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Borrowed Today / This Month";
            // 
            // LblBorrowedThisMonthCount
            // 
            LblBorrowedThisMonthCount.AutoSize = true;
            LblBorrowedThisMonthCount.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            LblBorrowedThisMonthCount.Location = new Point(6, 60);
            LblBorrowedThisMonthCount.Name = "LblBorrowedThisMonthCount";
            LblBorrowedThisMonthCount.Size = new Size(154, 17);
            LblBorrowedThisMonthCount.TabIndex = 20;
            LblBorrowedThisMonthCount.Text = "Borrowed This Month: 0";
            // 
            // LblBorrowedTodayCount
            // 
            LblBorrowedTodayCount.AutoSize = true;
            LblBorrowedTodayCount.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            LblBorrowedTodayCount.Location = new Point(6, 33);
            LblBorrowedTodayCount.Name = "LblBorrowedTodayCount";
            LblBorrowedTodayCount.Size = new Size(121, 17);
            LblBorrowedTodayCount.TabIndex = 18;
            LblBorrowedTodayCount.Text = "Borrowed Today: 0";
            // 
            // pictureBox7
            // 
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(189, 22);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(64, 64);
            pictureBox7.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox7.TabIndex = 17;
            pictureBox7.TabStop = false;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(ListTopRatedBooks);
            groupBox4.Controls.Add(LblTopRatedBookName);
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(pictureBox3);
            groupBox4.Location = new Point(566, 118);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(255, 431);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "Top Rated Book (Avg)";
            // 
            // ListTopRatedBooks
            // 
            ListTopRatedBooks.FormattingEnabled = true;
            ListTopRatedBooks.Location = new Point(6, 101);
            ListTopRatedBooks.Name = "ListTopRatedBooks";
            ListTopRatedBooks.Size = new Size(243, 319);
            ListTopRatedBooks.TabIndex = 23;
            // 
            // LblTopRatedBookName
            // 
            LblTopRatedBookName.AutoSize = true;
            LblTopRatedBookName.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            LblTopRatedBookName.Location = new Point(6, 60);
            LblTopRatedBookName.Name = "LblTopRatedBookName";
            LblTopRatedBookName.Size = new Size(79, 17);
            LblTopRatedBookName.TabIndex = 22;
            LblTopRatedBookName.Text = "Book Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label5.Location = new Point(6, 33);
            label5.Name = "label5";
            label5.Size = new Size(104, 17);
            label5.TabIndex = 21;
            label5.Text = "Top Rated Book";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(189, 22);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(64, 64);
            pictureBox3.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox3.TabIndex = 16;
            pictureBox3.TabStop = false;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(ListReservationPending);
            groupBox5.Controls.Add(LblReservationPendingCount);
            groupBox5.Controls.Add(pictureBox8);
            groupBox5.Location = new Point(289, 118);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(255, 431);
            groupBox5.TabIndex = 4;
            groupBox5.TabStop = false;
            groupBox5.Text = "Reservations Pending";
            // 
            // ListReservationPending
            // 
            ListReservationPending.FormattingEnabled = true;
            ListReservationPending.Location = new Point(6, 101);
            ListReservationPending.Name = "ListReservationPending";
            ListReservationPending.Size = new Size(243, 319);
            ListReservationPending.TabIndex = 21;
            // 
            // LblReservationPendingCount
            // 
            LblReservationPendingCount.AutoSize = true;
            LblReservationPendingCount.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            LblReservationPendingCount.Location = new Point(6, 46);
            LblReservationPendingCount.Name = "LblReservationPendingCount";
            LblReservationPendingCount.Size = new Size(148, 17);
            LblReservationPendingCount.TabIndex = 16;
            LblReservationPendingCount.Text = "Reservation Pending: 0";
            // 
            // pictureBox8
            // 
            pictureBox8.Image = (Image)resources.GetObject("pictureBox8.Image");
            pictureBox8.Location = new Point(189, 22);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(64, 64);
            pictureBox8.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox8.TabIndex = 15;
            pictureBox8.TabStop = false;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(ListBoxOverdueBooks);
            groupBox6.Controls.Add(LblTotalOverdueBooksCount);
            groupBox6.Controls.Add(pictureBox1);
            groupBox6.Location = new Point(12, 118);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(255, 431);
            groupBox6.TabIndex = 3;
            groupBox6.TabStop = false;
            groupBox6.Text = "Overdue Books";
            // 
            // ListBoxOverdueBooks
            // 
            ListBoxOverdueBooks.FormattingEnabled = true;
            ListBoxOverdueBooks.Location = new Point(6, 101);
            ListBoxOverdueBooks.Name = "ListBoxOverdueBooks";
            ListBoxOverdueBooks.Size = new Size(243, 319);
            ListBoxOverdueBooks.TabIndex = 20;
            // 
            // LblTotalOverdueBooksCount
            // 
            LblTotalOverdueBooksCount.AutoSize = true;
            LblTotalOverdueBooksCount.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            LblTotalOverdueBooksCount.Location = new Point(6, 46);
            LblTotalOverdueBooksCount.Name = "LblTotalOverdueBooksCount";
            LblTotalOverdueBooksCount.Size = new Size(148, 17);
            LblTotalOverdueBooksCount.TabIndex = 19;
            LblTotalOverdueBooksCount.Text = "Total Overdue Books: 0";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(189, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(64, 64);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 18;
            pictureBox1.TabStop = false;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(834, 561);
            Controls.Add(groupBox4);
            Controls.Add(groupBox5);
            Controls.Add(groupBox6);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            Load += DashboardForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private PictureBox pictureBox2;
        private PictureBox pictureBox4;
        private PictureBox pictureBox7;
        private PictureBox pictureBox1;
        private PictureBox pictureBox8;
        private Label LblTotalBooksCount;
        private PictureBox pictureBox3;
        private Label LblTotalMembersCount;
        private Label LblBorrowedTodayCount;
        private Label LblBorrowedThisMonthCount;
        private Label LblTotalOverdueBooksCount;
        private Label LblReservationPendingCount;
        private Label LblTopRatedBookName;
        private Label label5;
        private ListBox ListTopRatedBooks;
        private ListBox ListReservationPending;
        private ListBox ListBoxOverdueBooks;
    }
}

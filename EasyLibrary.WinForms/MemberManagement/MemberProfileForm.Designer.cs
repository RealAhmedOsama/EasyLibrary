namespace EasyLibrary.WinForms.MemberManagement
{
    partial class MemberProfileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemberProfileForm));
            DtpMembershipDate = new DateTimePicker();
            chkMemberStatus = new CheckBox();
            txtMemberPhone = new TextBox();
            txtMemberEmail = new TextBox();
            label7 = new Label();
            txtMemberName = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            LblTotalBorrowedBooks = new Label();
            DgvAllBorrowedBooks = new DataGridView();
            groupBox2 = new GroupBox();
            groupBox1 = new GroupBox();
            groupBox3 = new GroupBox();
            LblTottalReservedBooks = new Label();
            DgvAllReservedBooks = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DgvAllBorrowedBooks).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvAllReservedBooks).BeginInit();
            SuspendLayout();
            // 
            // DtpMembershipDate
            // 
            DtpMembershipDate.Format = DateTimePickerFormat.Short;
            DtpMembershipDate.Location = new Point(408, 84);
            DtpMembershipDate.Name = "DtpMembershipDate";
            DtpMembershipDate.Size = new Size(345, 23);
            DtpMembershipDate.TabIndex = 24;
            // 
            // chkMemberStatus
            // 
            chkMemberStatus.AutoSize = true;
            chkMemberStatus.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            chkMemberStatus.Location = new Point(11, 130);
            chkMemberStatus.Name = "chkMemberStatus";
            chkMemberStatus.Size = new Size(64, 21);
            chkMemberStatus.TabIndex = 20;
            chkMemberStatus.Text = "Active";
            chkMemberStatus.UseVisualStyleBackColor = true;
            // 
            // txtMemberPhone
            // 
            txtMemberPhone.Location = new Point(9, 83);
            txtMemberPhone.Name = "txtMemberPhone";
            txtMemberPhone.PlaceholderText = "Member Phone Number";
            txtMemberPhone.Size = new Size(345, 23);
            txtMemberPhone.TabIndex = 17;
            // 
            // txtMemberEmail
            // 
            txtMemberEmail.Location = new Point(408, 37);
            txtMemberEmail.Name = "txtMemberEmail";
            txtMemberEmail.PlaceholderText = "Member Email";
            txtMemberEmail.Size = new Size(345, 23);
            txtMemberEmail.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(8, 109);
            label7.Name = "label7";
            label7.Size = new Size(46, 17);
            label7.TabIndex = 15;
            label7.Text = "Status";
            // 
            // txtMemberName
            // 
            txtMemberName.Location = new Point(9, 37);
            txtMemberName.Name = "txtMemberName";
            txtMemberName.PlaceholderText = "Member Name";
            txtMemberName.Size = new Size(345, 23);
            txtMemberName.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(405, 64);
            label5.Name = "label5";
            label5.Size = new Size(117, 17);
            label5.TabIndex = 13;
            label5.Text = "MemberShip Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(6, 64);
            label4.Name = "label4";
            label4.Size = new Size(47, 17);
            label4.TabIndex = 12;
            label4.Text = "Phone";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(405, 18);
            label3.Name = "label3";
            label3.Size = new Size(40, 17);
            label3.TabIndex = 11;
            label3.Text = "Email";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(8, 18);
            label1.Name = "label1";
            label1.Size = new Size(44, 17);
            label1.TabIndex = 10;
            label1.Text = "Name";
            // 
            // LblTotalBorrowedBooks
            // 
            LblTotalBorrowedBooks.AutoSize = true;
            LblTotalBorrowedBooks.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            LblTotalBorrowedBooks.ForeColor = Color.Black;
            LblTotalBorrowedBooks.Location = new Point(6, 164);
            LblTotalBorrowedBooks.Name = "LblTotalBorrowedBooks";
            LblTotalBorrowedBooks.Size = new Size(132, 13);
            LblTotalBorrowedBooks.TabIndex = 18;
            LblTotalBorrowedBooks.Text = "Total Borrowed Books: 0";
            // 
            // DgvAllBorrowedBooks
            // 
            DgvAllBorrowedBooks.BackgroundColor = Color.White;
            DgvAllBorrowedBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvAllBorrowedBooks.Location = new Point(8, 22);
            DgvAllBorrowedBooks.Name = "DgvAllBorrowedBooks";
            DgvAllBorrowedBooks.Size = new Size(793, 139);
            DgvAllBorrowedBooks.TabIndex = 16;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(LblTotalBorrowedBooks);
            groupBox2.Controls.Add(DgvAllBorrowedBooks);
            groupBox2.Location = new Point(12, 176);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(810, 184);
            groupBox2.TabIndex = 20;
            groupBox2.TabStop = false;
            groupBox2.Text = "Borrowing History";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(DtpMembershipDate);
            groupBox1.Controls.Add(chkMemberStatus);
            groupBox1.Controls.Add(txtMemberPhone);
            groupBox1.Controls.Add(txtMemberEmail);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtMemberName);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(810, 158);
            groupBox1.TabIndex = 19;
            groupBox1.TabStop = false;
            groupBox1.Text = "Member Information";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(LblTottalReservedBooks);
            groupBox3.Controls.Add(DgvAllReservedBooks);
            groupBox3.Location = new Point(12, 365);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(810, 184);
            groupBox3.TabIndex = 21;
            groupBox3.TabStop = false;
            groupBox3.Text = "Reservation History";
            // 
            // LblTottalReservedBooks
            // 
            LblTottalReservedBooks.AutoSize = true;
            LblTottalReservedBooks.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            LblTottalReservedBooks.ForeColor = Color.Black;
            LblTottalReservedBooks.Location = new Point(6, 164);
            LblTottalReservedBooks.Name = "LblTottalReservedBooks";
            LblTottalReservedBooks.Size = new Size(129, 13);
            LblTottalReservedBooks.TabIndex = 18;
            LblTottalReservedBooks.Text = "Total Reserved Books: 0";
            // 
            // DgvAllReservedBooks
            // 
            DgvAllReservedBooks.BackgroundColor = Color.White;
            DgvAllReservedBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvAllReservedBooks.Location = new Point(8, 22);
            DgvAllReservedBooks.Name = "DgvAllReservedBooks";
            DgvAllReservedBooks.Size = new Size(793, 139);
            DgvAllReservedBooks.TabIndex = 16;
            // 
            // MemberProfileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(834, 561);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimizeBox = false;
            Name = "MemberProfileForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Member Profile";
            ((System.ComponentModel.ISupportInitialize)DgvAllBorrowedBooks).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvAllReservedBooks).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker DtpMembershipDate;
        private CheckBox chkMemberStatus;
        private TextBox txtMemberPhone;
        private TextBox txtMemberEmail;
        private Label label7;
        private TextBox txtMemberName;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private Label LblTotalBorrowedBooks;
        private DataGridView DgvAllBorrowedBooks;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private Label LblTottalReservedBooks;
        private DataGridView DgvAllReservedBooks;
    }
}
namespace EasyLibrary.WinForms.BorrowTransactions
{
    partial class BorrowTransactionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BorrowTransactionsForm));
            DtpExpirationDate = new DateTimePicker();
            CmbBooks = new ComboBox();
            chkActiveReservation = new CheckBox();
            label7 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            txtSearchInput = new TextBox();
            DtpReservationDate = new DateTimePicker();
            groupBox2 = new GroupBox();
            LblTotalBooks = new Label();
            BtnRefresh = new Button();
            DgvAllBooks = new DataGridView();
            BtnSearch = new Button();
            label2 = new Label();
            BtnUpdateBook = new Button();
            groupBox1 = new GroupBox();
            DtpDueDate = new DateTimePicker();
            label6 = new Label();
            CmbMembers = new ComboBox();
            BtnClearInformation = new Button();
            BtnDeleteBook = new Button();
            btnAddBorrowTrasaction = new Button();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvAllBooks).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // DtpExpirationDate
            // 
            DtpExpirationDate.Format = DateTimePickerFormat.Short;
            DtpExpirationDate.Location = new Point(408, 83);
            DtpExpirationDate.Name = "DtpExpirationDate";
            DtpExpirationDate.Size = new Size(345, 23);
            DtpExpirationDate.TabIndex = 27;
            // 
            // CmbBooks
            // 
            CmbBooks.FormattingEnabled = true;
            CmbBooks.Location = new Point(9, 37);
            CmbBooks.Name = "CmbBooks";
            CmbBooks.Size = new Size(345, 23);
            CmbBooks.TabIndex = 24;
            // 
            // chkActiveReservation
            // 
            chkActiveReservation.AutoSize = true;
            chkActiveReservation.Checked = true;
            chkActiveReservation.CheckState = CheckState.Checked;
            chkActiveReservation.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            chkActiveReservation.Location = new Point(411, 130);
            chkActiveReservation.Name = "chkActiveReservation";
            chkActiveReservation.Size = new Size(140, 21);
            chkActiveReservation.TabIndex = 20;
            chkActiveReservation.Text = "Active Reservation";
            chkActiveReservation.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(408, 109);
            label7.Name = "label7";
            label7.Size = new Size(45, 17);
            label7.TabIndex = 15;
            label7.Text = "Active";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(405, 64);
            label5.Name = "label5";
            label5.Size = new Size(101, 17);
            label5.TabIndex = 13;
            label5.Text = "Expiration Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(6, 64);
            label4.Name = "label4";
            label4.Size = new Size(84, 17);
            label4.TabIndex = 12;
            label4.Text = "Borrow Date";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(405, 18);
            label3.Name = "label3";
            label3.Size = new Size(59, 17);
            label3.TabIndex = 11;
            label3.Text = "Member";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(8, 18);
            label1.Name = "label1";
            label1.Size = new Size(39, 17);
            label1.TabIndex = 10;
            label1.Text = "Book";
            // 
            // txtSearchInput
            // 
            txtSearchInput.Location = new Point(60, 19);
            txtSearchInput.Name = "txtSearchInput";
            txtSearchInput.PlaceholderText = "Enter Book Title or Member Name";
            txtSearchInput.Size = new Size(518, 23);
            txtSearchInput.TabIndex = 13;
            // 
            // DtpReservationDate
            // 
            DtpReservationDate.Format = DateTimePickerFormat.Short;
            DtpReservationDate.Location = new Point(9, 83);
            DtpReservationDate.Name = "DtpReservationDate";
            DtpReservationDate.Size = new Size(345, 23);
            DtpReservationDate.TabIndex = 26;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(LblTotalBooks);
            groupBox2.Controls.Add(BtnRefresh);
            groupBox2.Controls.Add(DgvAllBooks);
            groupBox2.Controls.Add(BtnSearch);
            groupBox2.Controls.Add(txtSearchInput);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(12, 218);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(810, 331);
            groupBox2.TabIndex = 20;
            groupBox2.TabStop = false;
            groupBox2.Text = "Borrow Transactions";
            // 
            // LblTotalBooks
            // 
            LblTotalBooks.AutoSize = true;
            LblTotalBooks.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            LblTotalBooks.ForeColor = Color.Black;
            LblTotalBooks.Location = new Point(9, 309);
            LblTotalBooks.Name = "LblTotalBooks";
            LblTotalBooks.Size = new Size(143, 13);
            LblTotalBooks.TabIndex = 18;
            LblTotalBooks.Text = "Total Borrow Trasactions: 0";
            // 
            // BtnRefresh
            // 
            BtnRefresh.BackColor = Color.FromArgb(248, 249, 250);
            BtnRefresh.FlatStyle = FlatStyle.Flat;
            BtnRefresh.ForeColor = Color.Black;
            BtnRefresh.Location = new Point(727, 18);
            BtnRefresh.Name = "BtnRefresh";
            BtnRefresh.Size = new Size(75, 26);
            BtnRefresh.TabIndex = 17;
            BtnRefresh.Text = "Refresh";
            BtnRefresh.UseVisualStyleBackColor = false;
            BtnRefresh.Click += BtnRefresh_Click;
            // 
            // DgvAllBooks
            // 
            DgvAllBooks.BackgroundColor = Color.White;
            DgvAllBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvAllBooks.Location = new Point(9, 48);
            DgvAllBooks.Name = "DgvAllBooks";
            DgvAllBooks.Size = new Size(793, 256);
            DgvAllBooks.TabIndex = 16;
            // 
            // BtnSearch
            // 
            BtnSearch.BackColor = Color.FromArgb(248, 249, 250);
            BtnSearch.FlatStyle = FlatStyle.Flat;
            BtnSearch.ForeColor = Color.Black;
            BtnSearch.Location = new Point(586, 18);
            BtnSearch.Name = "BtnSearch";
            BtnSearch.Size = new Size(135, 26);
            BtnSearch.TabIndex = 15;
            BtnSearch.Text = "Search Now";
            BtnSearch.UseVisualStyleBackColor = false;
            BtnSearch.Click += BtnSearch_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(8, 22);
            label2.Name = "label2";
            label2.Size = new Size(48, 17);
            label2.TabIndex = 11;
            label2.Text = "Search";
            // 
            // BtnUpdateBook
            // 
            BtnUpdateBook.BackColor = Color.FromArgb(13, 110, 253);
            BtnUpdateBook.FlatStyle = FlatStyle.Flat;
            BtnUpdateBook.ForeColor = Color.White;
            BtnUpdateBook.Location = new Point(210, 159);
            BtnUpdateBook.Name = "BtnUpdateBook";
            BtnUpdateBook.Size = new Size(190, 31);
            BtnUpdateBook.TabIndex = 21;
            BtnUpdateBook.Text = "Update Borrow Trasaction";
            BtnUpdateBook.UseVisualStyleBackColor = false;
            BtnUpdateBook.Click += BtnUpdateBook_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(DtpDueDate);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(DtpExpirationDate);
            groupBox1.Controls.Add(DtpReservationDate);
            groupBox1.Controls.Add(CmbMembers);
            groupBox1.Controls.Add(CmbBooks);
            groupBox1.Controls.Add(BtnClearInformation);
            groupBox1.Controls.Add(BtnDeleteBook);
            groupBox1.Controls.Add(BtnUpdateBook);
            groupBox1.Controls.Add(chkActiveReservation);
            groupBox1.Controls.Add(btnAddBorrowTrasaction);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(810, 200);
            groupBox1.TabIndex = 19;
            groupBox1.TabStop = false;
            groupBox1.Text = "Borrow Transaction Information";
            // 
            // DtpDueDate
            // 
            DtpDueDate.Format = DateTimePickerFormat.Short;
            DtpDueDate.Location = new Point(12, 128);
            DtpDueDate.Name = "DtpDueDate";
            DtpDueDate.Size = new Size(345, 23);
            DtpDueDate.TabIndex = 29;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(9, 109);
            label6.Name = "label6";
            label6.Size = new Size(64, 17);
            label6.TabIndex = 28;
            label6.Text = "Due Date";
            // 
            // CmbMembers
            // 
            CmbMembers.FormattingEnabled = true;
            CmbMembers.Location = new Point(408, 37);
            CmbMembers.Name = "CmbMembers";
            CmbMembers.Size = new Size(345, 23);
            CmbMembers.TabIndex = 25;
            // 
            // BtnClearInformation
            // 
            BtnClearInformation.BackColor = Color.FromArgb(108, 117, 125);
            BtnClearInformation.FlatStyle = FlatStyle.Flat;
            BtnClearInformation.ForeColor = Color.White;
            BtnClearInformation.Location = new Point(612, 159);
            BtnClearInformation.Name = "BtnClearInformation";
            BtnClearInformation.Size = new Size(190, 31);
            BtnClearInformation.TabIndex = 23;
            BtnClearInformation.Text = "Clear Information";
            BtnClearInformation.UseVisualStyleBackColor = false;
            BtnClearInformation.Click += BtnClearInformation_Click;
            // 
            // BtnDeleteBook
            // 
            BtnDeleteBook.BackColor = Color.FromArgb(220, 53, 69);
            BtnDeleteBook.FlatStyle = FlatStyle.Flat;
            BtnDeleteBook.ForeColor = Color.White;
            BtnDeleteBook.Location = new Point(411, 159);
            BtnDeleteBook.Name = "BtnDeleteBook";
            BtnDeleteBook.Size = new Size(190, 31);
            BtnDeleteBook.TabIndex = 22;
            BtnDeleteBook.Text = "Delete Borrow Trasaction";
            BtnDeleteBook.UseVisualStyleBackColor = false;
            BtnDeleteBook.Click += BtnDeleteBook_Click;
            // 
            // btnAddBorrowTrasaction
            // 
            btnAddBorrowTrasaction.BackColor = Color.FromArgb(25, 135, 84);
            btnAddBorrowTrasaction.FlatStyle = FlatStyle.Flat;
            btnAddBorrowTrasaction.ForeColor = Color.White;
            btnAddBorrowTrasaction.Location = new Point(9, 159);
            btnAddBorrowTrasaction.Name = "btnAddBorrowTrasaction";
            btnAddBorrowTrasaction.Size = new Size(190, 31);
            btnAddBorrowTrasaction.TabIndex = 14;
            btnAddBorrowTrasaction.Text = "Add Borrow Trasaction";
            btnAddBorrowTrasaction.UseVisualStyleBackColor = false;
            btnAddBorrowTrasaction.Click += btnAddBorrowTrasaction_Click;
            // 
            // BorrowTransactionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(834, 561);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "BorrowTransactionsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Borrow Transactions";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvAllBooks).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker DtpExpirationDate;
        private ComboBox CmbBooks;
        private CheckBox chkActiveReservation;
        private Label label7;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private TextBox txtSearchInput;
        private DateTimePicker DtpReservationDate;
        private GroupBox groupBox2;
        private Label LblTotalBooks;
        private Button BtnRefresh;
        private DataGridView DgvAllBooks;
        private Button BtnSearch;
        private Label label2;
        private Button BtnUpdateBook;
        private GroupBox groupBox1;
        private ComboBox CmbMembers;
        private Button BtnClearInformation;
        private Button BtnDeleteBook;
        private Button btnAddBorrowTrasaction;
        private DateTimePicker DtpDueDate;
        private Label label6;
    }
}
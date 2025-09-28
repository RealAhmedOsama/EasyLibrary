namespace EasyLibrary.WinForms.BookManagement
{
    partial class BookManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookManagementForm));
            label1 = new Label();
            txtBookTitle = new TextBox();
            btnAddBook = new Button();
            groupBox1 = new GroupBox();
            BtnClearInformation = new Button();
            BtnDeleteBook = new Button();
            BtnUpdateBook = new Button();
            chkBookAvilable = new CheckBox();
            cmbCategoies = new ComboBox();
            txtBookPublishedYear = new TextBox();
            txtIsbn = new TextBox();
            txtBookAuthor = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            groupBox2 = new GroupBox();
            LblTopReservedBook = new Label();
            LblTopBorrowedBook = new Label();
            LblLowRatedBook = new Label();
            LblTopRatedBook = new Label();
            LblTotalBooks = new Label();
            BtnRefresh = new Button();
            DgvAllBooks = new DataGridView();
            BtnSearch = new Button();
            txtSearchInput = new TextBox();
            label2 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvAllBooks).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(8, 18);
            label1.Name = "label1";
            label1.Size = new Size(33, 17);
            label1.TabIndex = 10;
            label1.Text = "Title";
            // 
            // txtBookTitle
            // 
            txtBookTitle.Location = new Point(9, 37);
            txtBookTitle.Name = "txtBookTitle";
            txtBookTitle.PlaceholderText = "Enter Book Title";
            txtBookTitle.Size = new Size(345, 23);
            txtBookTitle.TabIndex = 12;
            // 
            // btnAddBook
            // 
            btnAddBook.BackColor = Color.FromArgb(25, 135, 84);
            btnAddBook.FlatStyle = FlatStyle.Flat;
            btnAddBook.ForeColor = Color.White;
            btnAddBook.Location = new Point(9, 159);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(190, 31);
            btnAddBook.TabIndex = 14;
            btnAddBook.Text = "Add Book";
            btnAddBook.UseVisualStyleBackColor = false;
            btnAddBook.Click += btnAddBook_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BtnClearInformation);
            groupBox1.Controls.Add(BtnDeleteBook);
            groupBox1.Controls.Add(BtnUpdateBook);
            groupBox1.Controls.Add(chkBookAvilable);
            groupBox1.Controls.Add(btnAddBook);
            groupBox1.Controls.Add(cmbCategoies);
            groupBox1.Controls.Add(txtBookPublishedYear);
            groupBox1.Controls.Add(txtIsbn);
            groupBox1.Controls.Add(txtBookAuthor);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtBookTitle);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(810, 200);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Book Information";
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
            BtnDeleteBook.Text = "Delete Book";
            BtnDeleteBook.UseVisualStyleBackColor = false;
            BtnDeleteBook.Click += BtnDeleteBook_Click;
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
            BtnUpdateBook.Text = "Update Book";
            BtnUpdateBook.UseVisualStyleBackColor = false;
            BtnUpdateBook.Click += BtnUpdateBook_Click;
            // 
            // chkBookAvilable
            // 
            chkBookAvilable.AutoSize = true;
            chkBookAvilable.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            chkBookAvilable.Location = new Point(408, 130);
            chkBookAvilable.Name = "chkBookAvilable";
            chkBookAvilable.Size = new Size(109, 21);
            chkBookAvilable.TabIndex = 20;
            chkBookAvilable.Text = "Book Avilable";
            chkBookAvilable.UseVisualStyleBackColor = true;
            // 
            // cmbCategoies
            // 
            cmbCategoies.FormattingEnabled = true;
            cmbCategoies.Location = new Point(9, 129);
            cmbCategoies.Name = "cmbCategoies";
            cmbCategoies.Size = new Size(345, 23);
            cmbCategoies.TabIndex = 19;
            // 
            // txtBookPublishedYear
            // 
            txtBookPublishedYear.Location = new Point(408, 83);
            txtBookPublishedYear.Name = "txtBookPublishedYear";
            txtBookPublishedYear.PlaceholderText = "Enter Book Published Year";
            txtBookPublishedYear.Size = new Size(345, 23);
            txtBookPublishedYear.TabIndex = 18;
            // 
            // txtIsbn
            // 
            txtIsbn.Location = new Point(9, 83);
            txtIsbn.Name = "txtIsbn";
            txtIsbn.PlaceholderText = "Enter Book ISBN";
            txtIsbn.Size = new Size(345, 23);
            txtIsbn.TabIndex = 17;
            // 
            // txtBookAuthor
            // 
            txtBookAuthor.Location = new Point(408, 37);
            txtBookAuthor.Name = "txtBookAuthor";
            txtBookAuthor.PlaceholderText = "Enter Book Author";
            txtBookAuthor.Size = new Size(345, 23);
            txtBookAuthor.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(405, 109);
            label7.Name = "label7";
            label7.Size = new Size(55, 17);
            label7.TabIndex = 15;
            label7.Text = "Avilable";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(6, 109);
            label6.Name = "label6";
            label6.Size = new Size(64, 17);
            label6.TabIndex = 14;
            label6.Text = "Category";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(405, 64);
            label5.Name = "label5";
            label5.Size = new Size(34, 17);
            label5.TabIndex = 13;
            label5.Text = "Year";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(6, 64);
            label4.Name = "label4";
            label4.Size = new Size(37, 17);
            label4.TabIndex = 12;
            label4.Text = "ISBN";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(405, 18);
            label3.Name = "label3";
            label3.Size = new Size(51, 17);
            label3.TabIndex = 11;
            label3.Text = "Author";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(LblTopReservedBook);
            groupBox2.Controls.Add(LblTopBorrowedBook);
            groupBox2.Controls.Add(LblLowRatedBook);
            groupBox2.Controls.Add(LblTopRatedBook);
            groupBox2.Controls.Add(LblTotalBooks);
            groupBox2.Controls.Add(BtnRefresh);
            groupBox2.Controls.Add(DgvAllBooks);
            groupBox2.Controls.Add(BtnSearch);
            groupBox2.Controls.Add(txtSearchInput);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(12, 218);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(810, 331);
            groupBox2.TabIndex = 16;
            groupBox2.TabStop = false;
            groupBox2.Text = "Books";
            // 
            // LblTopReservedBook
            // 
            LblTopReservedBook.AutoSize = true;
            LblTopReservedBook.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            LblTopReservedBook.ForeColor = Color.Black;
            LblTopReservedBook.Location = new Point(290, 308);
            LblTopReservedBook.Name = "LblTopReservedBook";
            LblTopReservedBook.Size = new Size(127, 13);
            LblTopReservedBook.TabIndex = 22;
            LblTopReservedBook.Text = "Top Reserved Book: NA";
            // 
            // LblTopBorrowedBook
            // 
            LblTopBorrowedBook.AutoSize = true;
            LblTopBorrowedBook.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            LblTopBorrowedBook.ForeColor = Color.Black;
            LblTopBorrowedBook.Location = new Point(9, 308);
            LblTopBorrowedBook.Name = "LblTopBorrowedBook";
            LblTopBorrowedBook.Size = new Size(130, 13);
            LblTopBorrowedBook.TabIndex = 21;
            LblTopBorrowedBook.Text = "Top Borrowed Book: NA";
            // 
            // LblLowRatedBook
            // 
            LblLowRatedBook.AutoSize = true;
            LblLowRatedBook.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            LblLowRatedBook.ForeColor = Color.Black;
            LblLowRatedBook.Location = new Point(538, 290);
            LblLowRatedBook.Name = "LblLowRatedBook";
            LblLowRatedBook.Size = new Size(111, 13);
            LblLowRatedBook.TabIndex = 20;
            LblLowRatedBook.Text = "Low Rated Book: NA";
            // 
            // LblTopRatedBook
            // 
            LblTopRatedBook.AutoSize = true;
            LblTopRatedBook.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            LblTopRatedBook.ForeColor = Color.Black;
            LblTopRatedBook.Location = new Point(290, 290);
            LblTopRatedBook.Name = "LblTopRatedBook";
            LblTopRatedBook.Size = new Size(110, 13);
            LblTopRatedBook.TabIndex = 19;
            LblTopRatedBook.Text = "Top Rated Book: NA";
            // 
            // LblTotalBooks
            // 
            LblTotalBooks.AutoSize = true;
            LblTotalBooks.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            LblTotalBooks.ForeColor = Color.Black;
            LblTotalBooks.Location = new Point(9, 290);
            LblTotalBooks.Name = "LblTotalBooks";
            LblTotalBooks.Size = new Size(79, 13);
            LblTotalBooks.TabIndex = 18;
            LblTotalBooks.Text = "Total Books: 0";
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
            DgvAllBooks.Size = new Size(793, 237);
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
            // txtSearchInput
            // 
            txtSearchInput.Location = new Point(60, 19);
            txtSearchInput.Name = "txtSearchInput";
            txtSearchInput.PlaceholderText = "Enter Book Title";
            txtSearchInput.Size = new Size(518, 23);
            txtSearchInput.TabIndex = 13;
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
            // BookManagementForm
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
            Name = "BookManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Books Management";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvAllBooks).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox txtBookTitle;
        private Button btnAddBook;
        private GroupBox groupBox1;
        private Label label3;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txtBookAuthor;
        private TextBox txtIsbn;
        private TextBox txtBookPublishedYear;
        private CheckBox chkBookAvilable;
        private ComboBox cmbCategoies;
        private Button BtnClearInformation;
        private Button BtnDeleteBook;
        private Button BtnUpdateBook;
        private GroupBox groupBox2;
        private Button BtnSearch;
        private TextBox txtSearchInput;
        private Label label2;
        private DataGridView DgvAllBooks;
        private Button BtnRefresh;
        private Label LblTotalBooks;
        private Label LblLowRatedBook;
        private Label LblTopRatedBook;
        private Label LblTopReservedBook;
        private Label LblTopBorrowedBook;
    }
}
namespace EasyLibrary.WinForms.CategoryManagement
{
    partial class CategoryManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryManagementForm));
            groupBox2 = new GroupBox();
            LblTotalCategories = new Label();
            BtnRefresh = new Button();
            DgvAllCategories = new DataGridView();
            BtnSearch = new Button();
            txtSearchInput = new TextBox();
            label2 = new Label();
            groupBox1 = new GroupBox();
            TxtDescription = new TextBox();
            BtnClearInformation = new Button();
            BtnDeleteCategory = new Button();
            BtnUpdateCategory = new Button();
            chkCategoryAvilable = new CheckBox();
            btnAddCategory = new Button();
            txtCategoryName = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvAllCategories).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(LblTotalCategories);
            groupBox2.Controls.Add(BtnRefresh);
            groupBox2.Controls.Add(DgvAllCategories);
            groupBox2.Controls.Add(BtnSearch);
            groupBox2.Controls.Add(txtSearchInput);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(12, 218);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(810, 331);
            groupBox2.TabIndex = 18;
            groupBox2.TabStop = false;
            groupBox2.Text = "Books";
            // 
            // LblTotalCategories
            // 
            LblTotalCategories.AutoSize = true;
            LblTotalCategories.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            LblTotalCategories.ForeColor = Color.Black;
            LblTotalCategories.Location = new Point(9, 307);
            LblTotalCategories.Name = "LblTotalCategories";
            LblTotalCategories.Size = new Size(102, 13);
            LblTotalCategories.TabIndex = 18;
            LblTotalCategories.Text = "Total Categories: 0";
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
            // DgvAllCategories
            // 
            DgvAllCategories.BackgroundColor = Color.White;
            DgvAllCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvAllCategories.Location = new Point(9, 48);
            DgvAllCategories.Name = "DgvAllCategories";
            DgvAllCategories.Size = new Size(793, 253);
            DgvAllCategories.TabIndex = 16;
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
            txtSearchInput.BorderStyle = BorderStyle.FixedSingle;
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
            // groupBox1
            // 
            groupBox1.Controls.Add(TxtDescription);
            groupBox1.Controls.Add(BtnClearInformation);
            groupBox1.Controls.Add(BtnDeleteCategory);
            groupBox1.Controls.Add(BtnUpdateCategory);
            groupBox1.Controls.Add(chkCategoryAvilable);
            groupBox1.Controls.Add(btnAddCategory);
            groupBox1.Controls.Add(txtCategoryName);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(810, 200);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            groupBox1.Text = "Category Information";
            // 
            // TxtDescription
            // 
            TxtDescription.Location = new Point(8, 84);
            TxtDescription.Multiline = true;
            TxtDescription.Name = "TxtDescription";
            TxtDescription.PlaceholderText = "Enter Category Description";
            TxtDescription.Size = new Size(794, 69);
            TxtDescription.TabIndex = 24;
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
            // BtnDeleteCategory
            // 
            BtnDeleteCategory.BackColor = Color.FromArgb(220, 53, 69);
            BtnDeleteCategory.FlatStyle = FlatStyle.Flat;
            BtnDeleteCategory.ForeColor = Color.White;
            BtnDeleteCategory.Location = new Point(411, 159);
            BtnDeleteCategory.Name = "BtnDeleteCategory";
            BtnDeleteCategory.Size = new Size(190, 31);
            BtnDeleteCategory.TabIndex = 22;
            BtnDeleteCategory.Text = "Delete Category";
            BtnDeleteCategory.UseVisualStyleBackColor = false;
            BtnDeleteCategory.Click += BtnDeleteCategory_Click;
            // 
            // BtnUpdateCategory
            // 
            BtnUpdateCategory.BackColor = Color.FromArgb(13, 110, 253);
            BtnUpdateCategory.FlatStyle = FlatStyle.Flat;
            BtnUpdateCategory.ForeColor = Color.White;
            BtnUpdateCategory.Location = new Point(210, 159);
            BtnUpdateCategory.Name = "BtnUpdateCategory";
            BtnUpdateCategory.Size = new Size(190, 31);
            BtnUpdateCategory.TabIndex = 21;
            BtnUpdateCategory.Text = "Update Category";
            BtnUpdateCategory.UseVisualStyleBackColor = false;
            BtnUpdateCategory.Click += BtnUpdateCategory_Click;
            // 
            // chkCategoryAvilable
            // 
            chkCategoryAvilable.AutoSize = true;
            chkCategoryAvilable.FlatStyle = FlatStyle.Flat;
            chkCategoryAvilable.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            chkCategoryAvilable.Location = new Point(411, 38);
            chkCategoryAvilable.Name = "chkCategoryAvilable";
            chkCategoryAvilable.Size = new Size(131, 21);
            chkCategoryAvilable.TabIndex = 20;
            chkCategoryAvilable.Text = "Category Avilable";
            chkCategoryAvilable.UseVisualStyleBackColor = true;
            // 
            // btnAddCategory
            // 
            btnAddCategory.BackColor = Color.FromArgb(25, 135, 84);
            btnAddCategory.FlatStyle = FlatStyle.Flat;
            btnAddCategory.ForeColor = Color.White;
            btnAddCategory.Location = new Point(9, 159);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(190, 31);
            btnAddCategory.TabIndex = 14;
            btnAddCategory.Text = "Add Category";
            btnAddCategory.UseVisualStyleBackColor = false;
            btnAddCategory.Click += btnAddCategory_Click;
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(9, 37);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.PlaceholderText = "Enter Category Name";
            txtCategoryName.Size = new Size(345, 23);
            txtCategoryName.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(6, 64);
            label4.Name = "label4";
            label4.Size = new Size(76, 17);
            label4.TabIndex = 12;
            label4.Text = "Description";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(405, 18);
            label3.Name = "label3";
            label3.Size = new Size(55, 17);
            label3.TabIndex = 11;
            label3.Text = "Avilable";
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
            // CategoryManagementForm
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
            Name = "CategoryManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Category Management";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvAllCategories).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private Label LblTotalCategories;
        private Button BtnRefresh;
        private DataGridView DgvAllCategories;
        private Button BtnSearch;
        private TextBox txtSearchInput;
        private Label label2;
        private GroupBox groupBox1;
        private Button BtnClearInformation;
        private Button BtnDeleteCategory;
        private Button BtnUpdateCategory;
        private CheckBox chkCategoryAvilable;
        private Button btnAddCategory;
        private TextBox txtCategoryName;
        private Label label3;
        private Label label1;
        private TextBox TxtDescription;
        private Label label4;
    }
}
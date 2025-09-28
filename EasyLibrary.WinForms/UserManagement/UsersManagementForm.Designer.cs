namespace EasyLibrary.WinForms.UserManagement
{
    partial class UsersManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersManagementForm));
            groupBox2 = new GroupBox();
            LblTotalBooks = new Label();
            BtnRefresh = new Button();
            DgvAllUsers = new DataGridView();
            BtnSearch = new Button();
            txtSearchInput = new TextBox();
            label2 = new Label();
            groupBox1 = new GroupBox();
            cmbRoles = new ComboBox();
            BtnClearInformation = new Button();
            BtnDeleteMember = new Button();
            BtnUpdateMember = new Button();
            chkUserStatus = new CheckBox();
            btnAddMember = new Button();
            txtUserEmail = new TextBox();
            txtPassword = new TextBox();
            label7 = new Label();
            txtUsername = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvAllUsers).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(LblTotalBooks);
            groupBox2.Controls.Add(BtnRefresh);
            groupBox2.Controls.Add(DgvAllUsers);
            groupBox2.Controls.Add(BtnSearch);
            groupBox2.Controls.Add(txtSearchInput);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(12, 218);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(810, 331);
            groupBox2.TabIndex = 20;
            groupBox2.TabStop = false;
            groupBox2.Text = "Members";
            // 
            // LblTotalBooks
            // 
            LblTotalBooks.AutoSize = true;
            LblTotalBooks.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            LblTotalBooks.ForeColor = Color.Black;
            LblTotalBooks.Location = new Point(9, 306);
            LblTotalBooks.Name = "LblTotalBooks";
            LblTotalBooks.Size = new Size(95, 13);
            LblTotalBooks.TabIndex = 18;
            LblTotalBooks.Text = "Total Members: 0";
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
            // DgvAllUsers
            // 
            DgvAllUsers.BackgroundColor = Color.White;
            DgvAllUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvAllUsers.Location = new Point(9, 48);
            DgvAllUsers.Name = "DgvAllUsers";
            DgvAllUsers.Size = new Size(793, 253);
            DgvAllUsers.TabIndex = 16;
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
            txtSearchInput.PlaceholderText = "Enter Username or Email";
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
            groupBox1.Controls.Add(cmbRoles);
            groupBox1.Controls.Add(BtnClearInformation);
            groupBox1.Controls.Add(BtnDeleteMember);
            groupBox1.Controls.Add(BtnUpdateMember);
            groupBox1.Controls.Add(chkUserStatus);
            groupBox1.Controls.Add(btnAddMember);
            groupBox1.Controls.Add(txtUserEmail);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtUsername);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(810, 200);
            groupBox1.TabIndex = 19;
            groupBox1.TabStop = false;
            groupBox1.Text = "Member Information";
            // 
            // cmbRoles
            // 
            cmbRoles.FormattingEnabled = true;
            cmbRoles.Location = new Point(408, 84);
            cmbRoles.Name = "cmbRoles";
            cmbRoles.Size = new Size(345, 23);
            cmbRoles.TabIndex = 24;
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
            BtnClearInformation.Text = "Clear User";
            BtnClearInformation.UseVisualStyleBackColor = false;
            BtnClearInformation.Click += BtnClearInformation_Click;
            // 
            // BtnDeleteMember
            // 
            BtnDeleteMember.BackColor = Color.FromArgb(220, 53, 69);
            BtnDeleteMember.FlatStyle = FlatStyle.Flat;
            BtnDeleteMember.ForeColor = Color.White;
            BtnDeleteMember.Location = new Point(411, 159);
            BtnDeleteMember.Name = "BtnDeleteMember";
            BtnDeleteMember.Size = new Size(190, 31);
            BtnDeleteMember.TabIndex = 22;
            BtnDeleteMember.Text = "Delete User";
            BtnDeleteMember.UseVisualStyleBackColor = false;
            BtnDeleteMember.Click += BtnDeleteMember_Click;
            // 
            // BtnUpdateMember
            // 
            BtnUpdateMember.BackColor = Color.FromArgb(13, 110, 253);
            BtnUpdateMember.FlatStyle = FlatStyle.Flat;
            BtnUpdateMember.ForeColor = Color.White;
            BtnUpdateMember.Location = new Point(210, 159);
            BtnUpdateMember.Name = "BtnUpdateMember";
            BtnUpdateMember.Size = new Size(190, 31);
            BtnUpdateMember.TabIndex = 21;
            BtnUpdateMember.Text = "Update User";
            BtnUpdateMember.UseVisualStyleBackColor = false;
            BtnUpdateMember.Click += BtnUpdateMember_Click;
            // 
            // chkUserStatus
            // 
            chkUserStatus.AutoSize = true;
            chkUserStatus.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            chkUserStatus.Location = new Point(11, 130);
            chkUserStatus.Name = "chkUserStatus";
            chkUserStatus.Size = new Size(64, 21);
            chkUserStatus.TabIndex = 20;
            chkUserStatus.Text = "Active";
            chkUserStatus.UseVisualStyleBackColor = true;
            // 
            // btnAddMember
            // 
            btnAddMember.BackColor = Color.FromArgb(25, 135, 84);
            btnAddMember.FlatStyle = FlatStyle.Flat;
            btnAddMember.ForeColor = Color.White;
            btnAddMember.Location = new Point(9, 159);
            btnAddMember.Name = "btnAddMember";
            btnAddMember.Size = new Size(190, 31);
            btnAddMember.TabIndex = 14;
            btnAddMember.Text = "Add User";
            btnAddMember.UseVisualStyleBackColor = false;
            btnAddMember.Click += btnAddMember_Click;
            // 
            // txtUserEmail
            // 
            txtUserEmail.Location = new Point(9, 83);
            txtUserEmail.Name = "txtUserEmail";
            txtUserEmail.PlaceholderText = "Enter User Email";
            txtUserEmail.Size = new Size(345, 23);
            txtUserEmail.TabIndex = 17;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(408, 37);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Enter Password";
            txtPassword.Size = new Size(345, 23);
            txtPassword.TabIndex = 16;
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
            // txtUsername
            // 
            txtUsername.Location = new Point(9, 37);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Enter Username";
            txtUsername.Size = new Size(345, 23);
            txtUsername.TabIndex = 12;
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
            label5.Text = "Role";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(6, 64);
            label4.Name = "label4";
            label4.Size = new Size(40, 17);
            label4.TabIndex = 12;
            label4.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(405, 18);
            label3.Name = "label3";
            label3.Size = new Size(66, 17);
            label3.TabIndex = 11;
            label3.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(8, 18);
            label1.Name = "label1";
            label1.Size = new Size(69, 17);
            label1.TabIndex = 10;
            label1.Text = "Username";
            // 
            // UsersManagementForm
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
            Name = "UsersManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Users Management";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvAllUsers).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private Label LblTotalBooks;
        private Button BtnRefresh;
        private DataGridView DgvAllUsers;
        private Button BtnSearch;
        private TextBox txtSearchInput;
        private Label label2;
        private GroupBox groupBox1;
        private Button BtnClearInformation;
        private Button BtnDeleteMember;
        private Button BtnUpdateMember;
        private CheckBox chkUserStatus;
        private Button btnAddMember;
        private TextBox txtUserEmail;
        private TextBox txtPassword;
        private Label label7;
        private TextBox txtUsername;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private ComboBox cmbRoles;
    }
}
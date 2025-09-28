namespace EasyLibrary.WinForms.MemberManagement
{
    partial class MemberManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemberManagementForm));
            groupBox2 = new GroupBox();
            LblTotalBooks = new Label();
            BtnRefresh = new Button();
            DgvAllMembers = new DataGridView();
            BtnSearch = new Button();
            txtSearchInput = new TextBox();
            label2 = new Label();
            groupBox1 = new GroupBox();
            DtpMembershipDate = new DateTimePicker();
            BtnClearInformation = new Button();
            BtnDeleteMember = new Button();
            BtnUpdateMember = new Button();
            chkMemberStatus = new CheckBox();
            btnAddMember = new Button();
            txtMemberPhone = new TextBox();
            txtMemberEmail = new TextBox();
            label7 = new Label();
            txtMemberName = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvAllMembers).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(LblTotalBooks);
            groupBox2.Controls.Add(BtnRefresh);
            groupBox2.Controls.Add(DgvAllMembers);
            groupBox2.Controls.Add(BtnSearch);
            groupBox2.Controls.Add(txtSearchInput);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(12, 218);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(810, 331);
            groupBox2.TabIndex = 18;
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
            // DgvAllMembers
            // 
            DgvAllMembers.BackgroundColor = Color.White;
            DgvAllMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvAllMembers.Location = new Point(9, 48);
            DgvAllMembers.Name = "DgvAllMembers";
            DgvAllMembers.Size = new Size(793, 253);
            DgvAllMembers.TabIndex = 16;
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
            txtSearchInput.PlaceholderText = "Enter Member Name";
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
            groupBox1.Controls.Add(DtpMembershipDate);
            groupBox1.Controls.Add(BtnClearInformation);
            groupBox1.Controls.Add(BtnDeleteMember);
            groupBox1.Controls.Add(BtnUpdateMember);
            groupBox1.Controls.Add(chkMemberStatus);
            groupBox1.Controls.Add(btnAddMember);
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
            groupBox1.Size = new Size(810, 200);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            groupBox1.Text = "Member Information";
            // 
            // DtpMembershipDate
            // 
            DtpMembershipDate.Format = DateTimePickerFormat.Short;
            DtpMembershipDate.Location = new Point(408, 84);
            DtpMembershipDate.Name = "DtpMembershipDate";
            DtpMembershipDate.Size = new Size(345, 23);
            DtpMembershipDate.TabIndex = 24;
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
            // BtnDeleteMember
            // 
            BtnDeleteMember.BackColor = Color.FromArgb(220, 53, 69);
            BtnDeleteMember.FlatStyle = FlatStyle.Flat;
            BtnDeleteMember.ForeColor = Color.White;
            BtnDeleteMember.Location = new Point(411, 159);
            BtnDeleteMember.Name = "BtnDeleteMember";
            BtnDeleteMember.Size = new Size(190, 31);
            BtnDeleteMember.TabIndex = 22;
            BtnDeleteMember.Text = "Delete Member";
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
            BtnUpdateMember.Text = "Update Member";
            BtnUpdateMember.UseVisualStyleBackColor = false;
            BtnUpdateMember.Click += BtnUpdateMember_Click;
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
            // btnAddMember
            // 
            btnAddMember.BackColor = Color.FromArgb(25, 135, 84);
            btnAddMember.FlatStyle = FlatStyle.Flat;
            btnAddMember.ForeColor = Color.White;
            btnAddMember.Location = new Point(9, 159);
            btnAddMember.Name = "btnAddMember";
            btnAddMember.Size = new Size(190, 31);
            btnAddMember.TabIndex = 14;
            btnAddMember.Text = "Add Member";
            btnAddMember.UseVisualStyleBackColor = false;
            btnAddMember.Click += btnAddMember_Click;
            // 
            // txtMemberPhone
            // 
            txtMemberPhone.Location = new Point(9, 83);
            txtMemberPhone.Name = "txtMemberPhone";
            txtMemberPhone.PlaceholderText = "Enter Member Phone Number";
            txtMemberPhone.Size = new Size(345, 23);
            txtMemberPhone.TabIndex = 17;
            // 
            // txtMemberEmail
            // 
            txtMemberEmail.Location = new Point(408, 37);
            txtMemberEmail.Name = "txtMemberEmail";
            txtMemberEmail.PlaceholderText = "Enter Member Email";
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
            txtMemberName.PlaceholderText = "Enter Member Name";
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
            // MemberManagementForm
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
            Name = "MemberManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Member Management";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvAllMembers).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private Label LblTotalBooks;
        private Button BtnRefresh;
        private DataGridView DgvAllMembers;
        private Button BtnSearch;
        private TextBox txtSearchInput;
        private Label label2;
        private GroupBox groupBox1;
        private Button BtnClearInformation;
        private Button BtnDeleteMember;
        private Button BtnUpdateMember;
        private CheckBox chkMemberStatus;
        private Button btnAddMember;
        private TextBox txtMemberPhone;
        private TextBox txtMemberEmail;
        private Label label7;
        private TextBox txtMemberName;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private DateTimePicker DtpMembershipDate;
    }
}
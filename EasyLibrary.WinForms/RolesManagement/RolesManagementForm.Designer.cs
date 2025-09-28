namespace EasyLibrary.WinForms.RolesManagement
{
    partial class RolesManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RolesManagementForm));
            BtnClearInformation = new Button();
            BtnDeleteRole = new Button();
            BtnUpdateRole = new Button();
            chkRoleStatus = new CheckBox();
            btnAddRole = new Button();
            txtRoleDescription = new TextBox();
            label7 = new Label();
            txtRoleName = new TextBox();
            label4 = new Label();
            label1 = new Label();
            LblTotalRoles = new Label();
            BtnRefresh = new Button();
            DgvAllRoles = new DataGridView();
            BtnSearch = new Button();
            txtSearchInput = new TextBox();
            label2 = new Label();
            groupBox2 = new GroupBox();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)DgvAllRoles).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
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
            // BtnDeleteRole
            // 
            BtnDeleteRole.BackColor = Color.FromArgb(220, 53, 69);
            BtnDeleteRole.FlatStyle = FlatStyle.Flat;
            BtnDeleteRole.ForeColor = Color.White;
            BtnDeleteRole.Location = new Point(411, 159);
            BtnDeleteRole.Name = "BtnDeleteRole";
            BtnDeleteRole.Size = new Size(190, 31);
            BtnDeleteRole.TabIndex = 22;
            BtnDeleteRole.Text = "Delete Role";
            BtnDeleteRole.UseVisualStyleBackColor = false;
            BtnDeleteRole.Click += BtnDeleteRole_Click;
            // 
            // BtnUpdateRole
            // 
            BtnUpdateRole.BackColor = Color.FromArgb(13, 110, 253);
            BtnUpdateRole.FlatStyle = FlatStyle.Flat;
            BtnUpdateRole.ForeColor = Color.White;
            BtnUpdateRole.Location = new Point(210, 159);
            BtnUpdateRole.Name = "BtnUpdateRole";
            BtnUpdateRole.Size = new Size(190, 31);
            BtnUpdateRole.TabIndex = 21;
            BtnUpdateRole.Text = "Update Role";
            BtnUpdateRole.UseVisualStyleBackColor = false;
            BtnUpdateRole.Click += BtnUpdateRole_Click;
            // 
            // chkRoleStatus
            // 
            chkRoleStatus.AutoSize = true;
            chkRoleStatus.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            chkRoleStatus.Location = new Point(411, 38);
            chkRoleStatus.Name = "chkRoleStatus";
            chkRoleStatus.Size = new Size(64, 21);
            chkRoleStatus.TabIndex = 20;
            chkRoleStatus.Text = "Active";
            chkRoleStatus.UseVisualStyleBackColor = true;
            // 
            // btnAddRole
            // 
            btnAddRole.BackColor = Color.FromArgb(25, 135, 84);
            btnAddRole.FlatStyle = FlatStyle.Flat;
            btnAddRole.ForeColor = Color.White;
            btnAddRole.Location = new Point(9, 159);
            btnAddRole.Name = "btnAddRole";
            btnAddRole.Size = new Size(190, 31);
            btnAddRole.TabIndex = 14;
            btnAddRole.Text = "Add Role";
            btnAddRole.UseVisualStyleBackColor = false;
            btnAddRole.Click += btnAddRole_Click;
            // 
            // txtRoleDescription
            // 
            txtRoleDescription.Location = new Point(9, 83);
            txtRoleDescription.Multiline = true;
            txtRoleDescription.Name = "txtRoleDescription";
            txtRoleDescription.PlaceholderText = "Enter Role Description";
            txtRoleDescription.Size = new Size(793, 70);
            txtRoleDescription.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(405, 18);
            label7.Name = "label7";
            label7.Size = new Size(46, 17);
            label7.TabIndex = 15;
            label7.Text = "Status";
            // 
            // txtRoleName
            // 
            txtRoleName.Location = new Point(9, 37);
            txtRoleName.Name = "txtRoleName";
            txtRoleName.PlaceholderText = "Enter Role Name";
            txtRoleName.Size = new Size(345, 23);
            txtRoleName.TabIndex = 12;
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
            // LblTotalRoles
            // 
            LblTotalRoles.AutoSize = true;
            LblTotalRoles.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            LblTotalRoles.ForeColor = Color.Black;
            LblTotalRoles.Location = new Point(9, 306);
            LblTotalRoles.Name = "LblTotalRoles";
            LblTotalRoles.Size = new Size(75, 13);
            LblTotalRoles.TabIndex = 18;
            LblTotalRoles.Text = "Total Roles: 0";
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
            // DgvAllRoles
            // 
            DgvAllRoles.BackgroundColor = Color.White;
            DgvAllRoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvAllRoles.Location = new Point(9, 48);
            DgvAllRoles.Name = "DgvAllRoles";
            DgvAllRoles.Size = new Size(793, 253);
            DgvAllRoles.TabIndex = 16;
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
            txtSearchInput.PlaceholderText = "Enter Role Name";
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
            // groupBox2
            // 
            groupBox2.Controls.Add(LblTotalRoles);
            groupBox2.Controls.Add(BtnRefresh);
            groupBox2.Controls.Add(DgvAllRoles);
            groupBox2.Controls.Add(BtnSearch);
            groupBox2.Controls.Add(txtSearchInput);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(12, 218);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(810, 331);
            groupBox2.TabIndex = 20;
            groupBox2.TabStop = false;
            groupBox2.Text = "Roles";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BtnClearInformation);
            groupBox1.Controls.Add(BtnDeleteRole);
            groupBox1.Controls.Add(BtnUpdateRole);
            groupBox1.Controls.Add(chkRoleStatus);
            groupBox1.Controls.Add(btnAddRole);
            groupBox1.Controls.Add(txtRoleDescription);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtRoleName);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(810, 200);
            groupBox1.TabIndex = 19;
            groupBox1.TabStop = false;
            groupBox1.Text = "Role Information";
            // 
            // RolesManagementForm
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
            Name = "RolesManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Roles Management";
            ((System.ComponentModel.ISupportInitialize)DgvAllRoles).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button BtnClearInformation;
        private Button BtnDeleteRole;
        private Button BtnUpdateRole;
        private CheckBox chkRoleStatus;
        private Button btnAddRole;
        private TextBox txtRoleDescription;
        private Label label7;
        private TextBox txtRoleName;
        private Label label4;
        private Label label1;
        private Label LblTotalRoles;
        private Button BtnRefresh;
        private DataGridView DgvAllRoles;
        private Button BtnSearch;
        private TextBox txtSearchInput;
        private Label label2;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
    }
}
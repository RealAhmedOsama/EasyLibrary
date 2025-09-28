namespace EasyLibrary.WinForms.Auth
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            label1 = new Label();
            btnLogin = new Button();
            label2 = new Label();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(57, 137);
            label1.Name = "label1";
            label1.Size = new Size(40, 17);
            label1.TabIndex = 5;
            label1.Text = "Email";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Location = new Point(60, 244);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(263, 31);
            btnLogin.TabIndex = 9;
            btnLogin.Text = "Login Now";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(57, 193);
            label2.Name = "label2";
            label2.Size = new Size(66, 17);
            label2.TabIndex = 6;
            label2.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(60, 213);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Enter Your Password";
            txtPassword.Size = new Size(263, 25);
            txtPassword.TabIndex = 8;
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(60, 157);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Enter Your Email";
            txtEmail.Size = new Size(263, 25);
            txtEmail.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(784, 461);
            tableLayoutPanel1.TabIndex = 10;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(64, 64, 64);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(386, 455);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(395, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(386, 455);
            panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Easy_Library;
            pictureBox1.Location = new Point(42, 77);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(300, 300);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(784, 461);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Easy Library - Login";
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button btnLogin;
        private Label label2;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
    }
}
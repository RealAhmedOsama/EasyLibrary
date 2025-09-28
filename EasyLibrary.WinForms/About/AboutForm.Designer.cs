namespace EasyLibrary.WinForms.About
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            textBox1 = new TextBox();
            groupBox2 = new GroupBox();
            textBox2 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Easy_Library;
            pictureBox1.Location = new Point(250, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(300, 165);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(12, 183);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(760, 126);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Application Information";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            textBox1.Location = new Point(6, 22);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(748, 98);
            textBox1.TabIndex = 0;
            textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox2);
            groupBox2.Location = new Point(12, 315);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(760, 158);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Credits";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            textBox2.Location = new Point(6, 19);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(748, 131);
            textBox2.TabIndex = 1;
            textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(784, 484);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "AboutForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AboutForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}
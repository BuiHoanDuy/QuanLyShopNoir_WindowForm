namespace QuanLyNoir_BTL
{
    partial class SignIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignIn));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            show_icon = new PictureBox();
            tbx_password = new TextBox();
            splitter1 = new Splitter();
            btn_signin = new Button();
            btn_forgotpassword = new Button();
            chbx_rememberme = new CheckBox();
            tbx_username = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label6 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)show_icon).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(32, 87);
            panel1.Name = "panel1";
            panel1.Size = new Size(513, 640);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(59, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(392, 425);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 163);
            label2.Location = new Point(136, 516);
            label2.Name = "label2";
            label2.Size = new Size(232, 28);
            label2.TabIndex = 1;
            label2.Text = "Please log in to continue";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(181, 483);
            label1.Name = "label1";
            label1.Size = new Size(152, 20);
            label1.TabIndex = 0;
            label1.Text = "You are not logged in";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(splitter1);
            panel2.Controls.Add(btn_signin);
            panel2.Controls.Add(btn_forgotpassword);
            panel2.Controls.Add(chbx_rememberme);
            panel2.Controls.Add(tbx_username);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(570, -11);
            panel2.Name = "panel2";
            panel2.Size = new Size(705, 780);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(show_icon);
            panel3.Controls.Add(tbx_password);
            panel3.Location = new Point(101, 387);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(461, 30);
            panel3.TabIndex = 10;
            // 
            // show_icon
            // 
            show_icon.Cursor = Cursors.Hand;
            show_icon.Image = Properties.Resources.show_icon;
            show_icon.Location = new Point(438, 3);
            show_icon.Margin = new Padding(3, 4, 3, 4);
            show_icon.Name = "show_icon";
            show_icon.Size = new Size(18, 21);
            show_icon.TabIndex = 11;
            show_icon.TabStop = false;
            show_icon.Click += show_icon_Click;
            // 
            // tbx_password
            // 
            tbx_password.Anchor = AnchorStyles.Top;
            tbx_password.BorderStyle = BorderStyle.None;
            tbx_password.Location = new Point(3, 4);
            tbx_password.Name = "tbx_password";
            tbx_password.PasswordChar = '*';
            tbx_password.Size = new Size(429, 20);
            tbx_password.TabIndex = 4;
            // 
            // splitter1
            // 
            splitter1.BackColor = SystemColors.ActiveCaptionText;
            splitter1.Location = new Point(0, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(5, 780);
            splitter1.TabIndex = 8;
            splitter1.TabStop = false;
            // 
            // btn_signin
            // 
            btn_signin.BackColor = Color.DarkOliveGreen;
            btn_signin.Cursor = Cursors.Hand;
            btn_signin.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_signin.ForeColor = SystemColors.ButtonFace;
            btn_signin.Location = new Point(126, 513);
            btn_signin.Name = "btn_signin";
            btn_signin.Size = new Size(385, 43);
            btn_signin.TabIndex = 7;
            btn_signin.Text = "Sign in";
            btn_signin.UseVisualStyleBackColor = false;
            btn_signin.Click += btn_signin_Click;
            // 
            // btn_forgotpassword
            // 
            btn_forgotpassword.Cursor = Cursors.Hand;
            btn_forgotpassword.Location = new Point(393, 432);
            btn_forgotpassword.Name = "btn_forgotpassword";
            btn_forgotpassword.Size = new Size(169, 29);
            btn_forgotpassword.TabIndex = 6;
            btn_forgotpassword.Text = "Forgot Password";
            btn_forgotpassword.UseVisualStyleBackColor = true;
            btn_forgotpassword.Click += btn_forgotpassword_Click;
            // 
            // chbx_rememberme
            // 
            chbx_rememberme.AutoSize = true;
            chbx_rememberme.Cursor = Cursors.Hand;
            chbx_rememberme.Location = new Point(105, 437);
            chbx_rememberme.Name = "chbx_rememberme";
            chbx_rememberme.Size = new Size(129, 24);
            chbx_rememberme.TabIndex = 5;
            chbx_rememberme.Text = "Remember Me";
            chbx_rememberme.UseVisualStyleBackColor = true;
            // 
            // tbx_username
            // 
            tbx_username.Location = new Point(101, 281);
            tbx_username.Name = "tbx_username";
            tbx_username.Size = new Size(461, 27);
            tbx_username.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Palatino Linotype", 13.8F, FontStyle.Bold);
            label5.Location = new Point(91, 344);
            label5.Name = "label5";
            label5.Size = new Size(130, 31);
            label5.TabIndex = 2;
            label5.Text = "* Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Palatino Linotype", 13.8F, FontStyle.Bold);
            label4.Location = new Point(90, 235);
            label4.Name = "label4";
            label4.Size = new Size(138, 31);
            label4.TabIndex = 1;
            label4.Text = "* Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(62, 160);
            label3.Name = "label3";
            label3.Size = new Size(129, 39);
            label3.TabIndex = 0;
            label3.Text = "Sign in";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 134);
            label6.Location = new Point(40, 32);
            label6.Name = "label6";
            label6.Size = new Size(84, 39);
            label6.TabIndex = 2;
            label6.Text = "Noir";
            // 
            // SignIn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.White;
            ClientSize = new Size(1307, 748);
            Controls.Add(label6);
            Controls.Add(panel2);
            Controls.Add(panel1);
            KeyPreview = true;
            Name = "SignIn";
            Text = "Login";
            TopMost = true;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)show_icon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label1;
        private Panel panel2;
        private TextBox tbx_password;
        private TextBox tbx_username;
        private Label label5;
        private Label label4;
        private Label label3;
        private Button btn_signin;
        private Button btn_forgotpassword;
        private CheckBox chbx_rememberme;
        private Label label6;
        private Splitter splitter1;
        private Panel panel3;
        private PictureBox show_icon;
    }
}




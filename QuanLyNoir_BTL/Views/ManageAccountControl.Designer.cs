namespace QuanLyNoir_BTL.Views
{
    partial class ManageAccountControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnl_accountInfomation = new Panel();
            btn_reset = new Button();
            lbl_thongtin = new Label();
            btn_delete = new Button();
            btn_update = new Button();
            btn_create = new Button();
            tbx_phone = new TextBox();
            tbx_email = new TextBox();
            tbx_password = new TextBox();
            tbx_username = new TextBox();
            tbx_name = new TextBox();
            lbl_role = new Label();
            cbbx_role = new ComboBox();
            lbl_phoneNumber = new Label();
            lbl_email = new Label();
            lbl_password = new Label();
            lbl_username = new Label();
            lbl_name = new Label();
            dtgv_accountList = new DataGridView();
            tbx_timkiem = new TextBox();
            cbbx_cot = new ComboBox();
            cbbx_sapxep = new ComboBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            cbbx_sodong = new ComboBox();
            lbl_trang = new Label();
            btn_trangsau = new Button();
            btn_trangtruoc = new Button();
            label10 = new Label();
            pnl_accountInfomation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgv_accountList).BeginInit();
            SuspendLayout();
            // 
            // pnl_accountInfomation
            // 
            pnl_accountInfomation.Controls.Add(btn_reset);
            pnl_accountInfomation.Controls.Add(lbl_thongtin);
            pnl_accountInfomation.Controls.Add(btn_delete);
            pnl_accountInfomation.Controls.Add(btn_update);
            pnl_accountInfomation.Controls.Add(btn_create);
            pnl_accountInfomation.Controls.Add(tbx_phone);
            pnl_accountInfomation.Controls.Add(tbx_email);
            pnl_accountInfomation.Controls.Add(tbx_password);
            pnl_accountInfomation.Controls.Add(tbx_username);
            pnl_accountInfomation.Controls.Add(tbx_name);
            pnl_accountInfomation.Controls.Add(lbl_role);
            pnl_accountInfomation.Controls.Add(cbbx_role);
            pnl_accountInfomation.Controls.Add(lbl_phoneNumber);
            pnl_accountInfomation.Controls.Add(lbl_email);
            pnl_accountInfomation.Controls.Add(lbl_password);
            pnl_accountInfomation.Controls.Add(lbl_username);
            pnl_accountInfomation.Controls.Add(lbl_name);
            pnl_accountInfomation.Location = new Point(20, 43);
            pnl_accountInfomation.Name = "pnl_accountInfomation";
            pnl_accountInfomation.Size = new Size(435, 732);
            pnl_accountInfomation.TabIndex = 0;
            // 
            // btn_reset
            // 
            btn_reset.Location = new Point(170, 590);
            btn_reset.Name = "btn_reset";
            btn_reset.Size = new Size(94, 29);
            btn_reset.TabIndex = 16;
            btn_reset.Text = "Reset";
            btn_reset.UseVisualStyleBackColor = true;
            btn_reset.Click += btn_reset_Click;
            // 
            // lbl_thongtin
            // 
            lbl_thongtin.AutoSize = true;
            lbl_thongtin.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lbl_thongtin.Location = new Point(57, 21);
            lbl_thongtin.Name = "lbl_thongtin";
            lbl_thongtin.Size = new Size(307, 25);
            lbl_thongtin.TabIndex = 15;
            lbl_thongtin.Text = "ACCOUNT INFORMATION";
            // 
            // btn_delete
            // 
            btn_delete.Location = new Point(326, 539);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(94, 29);
            btn_delete.TabIndex = 14;
            btn_delete.Text = "Delete";
            btn_delete.UseVisualStyleBackColor = true;
            btn_delete.Click += btn_delete_Click;
            // 
            // btn_update
            // 
            btn_update.Location = new Point(170, 539);
            btn_update.Name = "btn_update";
            btn_update.Size = new Size(94, 29);
            btn_update.TabIndex = 13;
            btn_update.Text = "Update";
            btn_update.UseVisualStyleBackColor = true;
            btn_update.Click += btn_update_Click;
            // 
            // btn_create
            // 
            btn_create.Location = new Point(17, 539);
            btn_create.Name = "btn_create";
            btn_create.Size = new Size(94, 29);
            btn_create.TabIndex = 12;
            btn_create.Text = "Create";
            btn_create.UseVisualStyleBackColor = true;
            btn_create.Click += btn_create_Click;
            // 
            // tbx_phone
            // 
            tbx_phone.Location = new Point(142, 369);
            tbx_phone.Name = "tbx_phone";
            tbx_phone.Size = new Size(257, 27);
            tbx_phone.TabIndex = 11;
            // 
            // tbx_email
            // 
            tbx_email.Location = new Point(142, 296);
            tbx_email.Name = "tbx_email";
            tbx_email.Size = new Size(257, 27);
            tbx_email.TabIndex = 10;
            // 
            // tbx_password
            // 
            tbx_password.Location = new Point(142, 216);
            tbx_password.Name = "tbx_password";
            tbx_password.Size = new Size(257, 27);
            tbx_password.TabIndex = 9;
            // 
            // tbx_username
            // 
            tbx_username.Location = new Point(137, 144);
            tbx_username.Name = "tbx_username";
            tbx_username.Size = new Size(258, 27);
            tbx_username.TabIndex = 8;
            // 
            // tbx_name
            // 
            tbx_name.Location = new Point(146, 71);
            tbx_name.Name = "tbx_name";
            tbx_name.Size = new Size(257, 27);
            tbx_name.TabIndex = 7;
            // 
            // lbl_role
            // 
            lbl_role.AutoSize = true;
            lbl_role.Font = new Font("Georgia", 12F, FontStyle.Bold);
            lbl_role.Location = new Point(16, 446);
            lbl_role.Name = "lbl_role";
            lbl_role.Size = new Size(64, 24);
            lbl_role.TabIndex = 6;
            lbl_role.Text = "Role:";
            // 
            // cbbx_role
            // 
            cbbx_role.FormattingEnabled = true;
            cbbx_role.Items.AddRange(new object[] { "Staff", "Admin" });
            cbbx_role.Location = new Point(142, 442);
            cbbx_role.Name = "cbbx_role";
            cbbx_role.Size = new Size(253, 28);
            cbbx_role.TabIndex = 5;
            // 
            // lbl_phoneNumber
            // 
            lbl_phoneNumber.AutoSize = true;
            lbl_phoneNumber.Font = new Font("Georgia", 12F, FontStyle.Bold);
            lbl_phoneNumber.Location = new Point(16, 372);
            lbl_phoneNumber.Name = "lbl_phoneNumber";
            lbl_phoneNumber.Size = new Size(83, 24);
            lbl_phoneNumber.TabIndex = 4;
            lbl_phoneNumber.Text = "Phone:";
            // 
            // lbl_email
            // 
            lbl_email.AutoSize = true;
            lbl_email.Font = new Font("Georgia", 12F, FontStyle.Bold);
            lbl_email.Location = new Point(16, 299);
            lbl_email.Name = "lbl_email";
            lbl_email.Size = new Size(77, 24);
            lbl_email.TabIndex = 3;
            lbl_email.Text = "Email:";
            // 
            // lbl_password
            // 
            lbl_password.AutoSize = true;
            lbl_password.Font = new Font("Georgia", 12F, FontStyle.Bold);
            lbl_password.Location = new Point(16, 223);
            lbl_password.Name = "lbl_password";
            lbl_password.Size = new Size(116, 24);
            lbl_password.TabIndex = 2;
            lbl_password.Text = "Password:";
            // 
            // lbl_username
            // 
            lbl_username.AutoSize = true;
            lbl_username.Font = new Font("Georgia", 12F, FontStyle.Bold);
            lbl_username.Location = new Point(16, 147);
            lbl_username.Name = "lbl_username";
            lbl_username.Size = new Size(122, 24);
            lbl_username.TabIndex = 1;
            lbl_username.Text = "Username:";
            // 
            // lbl_name
            // 
            lbl_name.AutoSize = true;
            lbl_name.Font = new Font("Georgia", 12F, FontStyle.Bold);
            lbl_name.Location = new Point(16, 78);
            lbl_name.Name = "lbl_name";
            lbl_name.Size = new Size(77, 24);
            lbl_name.TabIndex = 0;
            lbl_name.Text = "Name:";
            // 
            // dtgv_accountList
            // 
            dtgv_accountList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgv_accountList.BackgroundColor = SystemColors.ControlLightLight;
            dtgv_accountList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgv_accountList.Location = new Point(461, 114);
            dtgv_accountList.Margin = new Padding(3, 3, 5, 3);
            dtgv_accountList.Name = "dtgv_accountList";
            dtgv_accountList.ReadOnly = true;
            dtgv_accountList.RowHeadersWidth = 51;
            dtgv_accountList.Size = new Size(976, 588);
            dtgv_accountList.TabIndex = 1;
            dtgv_accountList.CellClick += dtgv_accountList_CellClick;
            // 
            // tbx_timkiem
            // 
            tbx_timkiem.Location = new Point(1126, 64);
            tbx_timkiem.Name = "tbx_timkiem";
            tbx_timkiem.Size = new Size(213, 27);
            tbx_timkiem.TabIndex = 20;
            tbx_timkiem.TextChanged += tbx_timkiem_TextChanged;
            // 
            // cbbx_cot
            // 
            cbbx_cot.FormattingEnabled = true;
            cbbx_cot.Location = new Point(860, 63);
            cbbx_cot.Name = "cbbx_cot";
            cbbx_cot.Size = new Size(151, 28);
            cbbx_cot.TabIndex = 19;
            cbbx_cot.SelectedIndexChanged += cbbx_cot_SelectedIndexChanged;
            // 
            // cbbx_sapxep
            // 
            cbbx_sapxep.FormattingEnabled = true;
            cbbx_sapxep.Location = new Point(609, 64);
            cbbx_sapxep.Name = "cbbx_sapxep";
            cbbx_sapxep.Size = new Size(151, 28);
            cbbx_sapxep.TabIndex = 18;
            cbbx_sapxep.SelectedIndexChanged += cbbx_sapxep_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(1083, 71);
            label9.Name = "label9";
            label9.Size = new Size(37, 20);
            label9.TabIndex = 17;
            label9.Text = "Find";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(782, 71);
            label8.Name = "label8";
            label8.Size = new Size(60, 20);
            label8.TabIndex = 16;
            label8.Text = "Column";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(526, 71);
            label7.Name = "label7";
            label7.Size = new Size(62, 20);
            label7.TabIndex = 15;
            label7.Text = "Arrange";
            // 
            // cbbx_sodong
            // 
            cbbx_sodong.FormattingEnabled = true;
            cbbx_sodong.Location = new Point(699, 722);
            cbbx_sodong.Name = "cbbx_sodong";
            cbbx_sodong.Size = new Size(78, 28);
            cbbx_sodong.TabIndex = 25;
            cbbx_sodong.SelectedIndexChanged += cbbx_sodong_SelectedIndexChanged;
            // 
            // lbl_trang
            // 
            lbl_trang.AutoSize = true;
            lbl_trang.Location = new Point(953, 726);
            lbl_trang.Name = "lbl_trang";
            lbl_trang.Size = new Size(41, 20);
            lbl_trang.TabIndex = 24;
            lbl_trang.Text = "Page";
            // 
            // btn_trangsau
            // 
            btn_trangsau.Location = new Point(1052, 722);
            btn_trangsau.Name = "btn_trangsau";
            btn_trangsau.Size = new Size(94, 29);
            btn_trangsau.TabIndex = 23;
            btn_trangsau.Text = "Next";
            btn_trangsau.UseVisualStyleBackColor = true;
            btn_trangsau.Click += btn_trangsau_Click;
            // 
            // btn_trangtruoc
            // 
            btn_trangtruoc.Location = new Point(838, 722);
            btn_trangtruoc.Name = "btn_trangtruoc";
            btn_trangtruoc.Size = new Size(94, 29);
            btn_trangtruoc.TabIndex = 22;
            btn_trangtruoc.Text = "Prevous";
            btn_trangtruoc.UseVisualStyleBackColor = true;
            btn_trangtruoc.Click += btn_trangtruoc_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(644, 726);
            label10.Name = "label10";
            label10.Size = new Size(38, 20);
            label10.TabIndex = 21;
            label10.Text = "Row";
            // 
            // ManageAccountControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cbbx_sodong);
            Controls.Add(lbl_trang);
            Controls.Add(btn_trangsau);
            Controls.Add(btn_trangtruoc);
            Controls.Add(label10);
            Controls.Add(tbx_timkiem);
            Controls.Add(cbbx_cot);
            Controls.Add(cbbx_sapxep);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(dtgv_accountList);
            Controls.Add(pnl_accountInfomation);
            Name = "ManageAccountControl";
            Size = new Size(1521, 778);
            Load += ManageAccountControl_Load;
            pnl_accountInfomation.ResumeLayout(false);
            pnl_accountInfomation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgv_accountList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnl_accountInfomation;
        private Button btn_delete;
        private Button btn_update;
        private Button btn_create;
        private DataGridView dtgv_accountList;
        private TextBox tbx_timkiem;
        private ComboBox cbbx_cot;
        private ComboBox cbbx_sapxep;
        private Label label9;
        private Label label8;
        private Label label7;
        private ComboBox cbbx_sodong;
        private Label lbl_trang;
        private Button btn_trangsau;
        private Button btn_trangtruoc;
        private Label label10;
        private Label lbl_thongtin;
        private TextBox tbx_phone;
        private TextBox tbx_email;
        private TextBox tbx_password;
        private TextBox tbx_username;
        private TextBox tbx_name;
        private Label lbl_role;
        private ComboBox cbbx_role;
        private Label lbl_phoneNumber;
        private Label lbl_email;
        private Label lbl_password;
        private Label lbl_username;
        private Label lbl_name;
        private Button btn_reset;
    }
}

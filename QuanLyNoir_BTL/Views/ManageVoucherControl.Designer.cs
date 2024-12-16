namespace QuanLyNoir_BTL.Views
{
    partial class ManageVoucherControl
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
            label1 = new Label();
            cbbx_find = new ComboBox();
            grbx_status = new GroupBox();
            rdbtn_status_inactive = new RadioButton();
            rdbtn_status_activated = new RadioButton();
            rdbtn_status_all = new RadioButton();
            grbx_date = new GroupBox();
            btn_today_startday = new Button();
            btn_today_endday = new Button();
            label3 = new Label();
            label2 = new Label();
            dtpk_end = new DateTimePicker();
            dtpk_start = new DateTimePicker();
            grbx_type = new GroupBox();
            rdbtn_type_fixed = new RadioButton();
            rdbtn_type_percentage = new RadioButton();
            rdbtn_type_all = new RadioButton();
            dtgv_voucherlist = new DataGridView();
            pictureBox1 = new PictureBox();
            btn_addNewVoucher = new Button();
            cbbx_sodong = new ComboBox();
            lbl_trang = new Label();
            btn_trangsau = new Button();
            btn_trangtruoc = new Button();
            label10 = new Label();
            cbbx_cot = new ComboBox();
            cbbx_sapxep = new ComboBox();
            label8 = new Label();
            label7 = new Label();
            btn_reset = new Button();
            btn_edit = new Button();
            btn_delete = new Button();
            grbx_status.SuspendLayout();
            grbx_date.SuspendLayout();
            grbx_type.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgv_voucherlist).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(50, 31);
            label1.Name = "label1";
            label1.Size = new Size(228, 31);
            label1.TabIndex = 36;
            label1.Text = "MANAGE VOUCHER";
            // 
            // cbbx_find
            // 
            cbbx_find.FormattingEnabled = true;
            cbbx_find.Location = new Point(428, 34);
            cbbx_find.Name = "cbbx_find";
            cbbx_find.Size = new Size(436, 28);
            cbbx_find.TabIndex = 37;
            cbbx_find.SelectedIndexChanged += cbbx_find_TextChanged;
            cbbx_find.TextChanged += cbbx_find_TextChanged;
            // 
            // grbx_status
            // 
            grbx_status.Controls.Add(rdbtn_status_inactive);
            grbx_status.Controls.Add(rdbtn_status_activated);
            grbx_status.Controls.Add(rdbtn_status_all);
            grbx_status.Location = new Point(47, 92);
            grbx_status.Name = "grbx_status";
            grbx_status.Size = new Size(289, 168);
            grbx_status.TabIndex = 38;
            grbx_status.TabStop = false;
            grbx_status.Text = "Status";
            // 
            // rdbtn_status_inactive
            // 
            rdbtn_status_inactive.AutoSize = true;
            rdbtn_status_inactive.Cursor = Cursors.Hand;
            rdbtn_status_inactive.Location = new Point(46, 121);
            rdbtn_status_inactive.Name = "rdbtn_status_inactive";
            rdbtn_status_inactive.Size = new Size(81, 24);
            rdbtn_status_inactive.TabIndex = 2;
            rdbtn_status_inactive.Text = "Inactive";
            rdbtn_status_inactive.UseVisualStyleBackColor = true;
            rdbtn_status_inactive.CheckedChanged += rdbtn_Status_CheckedChanged;
            // 
            // rdbtn_status_activated
            // 
            rdbtn_status_activated.AutoSize = true;
            rdbtn_status_activated.Cursor = Cursors.Hand;
            rdbtn_status_activated.Location = new Point(46, 78);
            rdbtn_status_activated.Name = "rdbtn_status_activated";
            rdbtn_status_activated.Size = new Size(93, 24);
            rdbtn_status_activated.TabIndex = 1;
            rdbtn_status_activated.Text = "Activated";
            rdbtn_status_activated.UseVisualStyleBackColor = true;
            rdbtn_status_activated.CheckedChanged += rdbtn_Status_CheckedChanged;
            // 
            // rdbtn_status_all
            // 
            rdbtn_status_all.AutoSize = true;
            rdbtn_status_all.Checked = true;
            rdbtn_status_all.Cursor = Cursors.Hand;
            rdbtn_status_all.Location = new Point(46, 38);
            rdbtn_status_all.Name = "rdbtn_status_all";
            rdbtn_status_all.Size = new Size(48, 24);
            rdbtn_status_all.TabIndex = 0;
            rdbtn_status_all.TabStop = true;
            rdbtn_status_all.Text = "All";
            rdbtn_status_all.UseVisualStyleBackColor = true;
            rdbtn_status_all.CheckedChanged += rdbtn_Status_CheckedChanged;
            // 
            // grbx_date
            // 
            grbx_date.Controls.Add(btn_today_startday);
            grbx_date.Controls.Add(btn_today_endday);
            grbx_date.Controls.Add(label3);
            grbx_date.Controls.Add(label2);
            grbx_date.Controls.Add(dtpk_end);
            grbx_date.Controls.Add(dtpk_start);
            grbx_date.Location = new Point(47, 288);
            grbx_date.Name = "grbx_date";
            grbx_date.Size = new Size(289, 180);
            grbx_date.TabIndex = 39;
            grbx_date.TabStop = false;
            grbx_date.Text = "Date";
            // 
            // btn_today_startday
            // 
            btn_today_startday.Cursor = Cursors.Hand;
            btn_today_startday.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btn_today_startday.Location = new Point(208, 35);
            btn_today_startday.Name = "btn_today_startday";
            btn_today_startday.Size = new Size(64, 25);
            btn_today_startday.TabIndex = 5;
            btn_today_startday.Text = "Today";
            btn_today_startday.UseVisualStyleBackColor = true;
            btn_today_startday.Click += btn_today_startday_Click;
            // 
            // btn_today_endday
            // 
            btn_today_endday.Cursor = Cursors.Hand;
            btn_today_endday.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btn_today_endday.Location = new Point(208, 109);
            btn_today_endday.Name = "btn_today_endday";
            btn_today_endday.Size = new Size(64, 25);
            btn_today_endday.TabIndex = 4;
            btn_today_endday.Text = "Today";
            btn_today_endday.UseVisualStyleBackColor = true;
            btn_today_endday.Click += btn_today_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 111);
            label3.Name = "label3";
            label3.Size = new Size(71, 20);
            label3.TabIndex = 3;
            label3.Text = "End date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 35);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 2;
            label2.Text = "Start date:";
            // 
            // dtpk_end
            // 
            dtpk_end.CustomFormat = "";
            dtpk_end.Location = new Point(22, 134);
            dtpk_end.Name = "dtpk_end";
            dtpk_end.Size = new Size(250, 27);
            dtpk_end.TabIndex = 1;
            dtpk_end.Value = new DateTime(2030, 1, 1, 0, 0, 0, 0);
            dtpk_end.ValueChanged += dtpk_end_ValueChanged;
            // 
            // dtpk_start
            // 
            dtpk_start.CustomFormat = "";
            dtpk_start.Location = new Point(22, 61);
            dtpk_start.Name = "dtpk_start";
            dtpk_start.Size = new Size(250, 27);
            dtpk_start.TabIndex = 0;
            dtpk_start.Value = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            dtpk_start.ValueChanged += dtpk_start_ValueChanged;
            // 
            // grbx_type
            // 
            grbx_type.Controls.Add(rdbtn_type_fixed);
            grbx_type.Controls.Add(rdbtn_type_percentage);
            grbx_type.Controls.Add(rdbtn_type_all);
            grbx_type.Location = new Point(47, 494);
            grbx_type.Name = "grbx_type";
            grbx_type.Size = new Size(289, 159);
            grbx_type.TabIndex = 40;
            grbx_type.TabStop = false;
            grbx_type.Text = "Type";
            // 
            // rdbtn_type_fixed
            // 
            rdbtn_type_fixed.AutoSize = true;
            rdbtn_type_fixed.Cursor = Cursors.Hand;
            rdbtn_type_fixed.Location = new Point(46, 109);
            rdbtn_type_fixed.Name = "rdbtn_type_fixed";
            rdbtn_type_fixed.Size = new Size(65, 24);
            rdbtn_type_fixed.TabIndex = 5;
            rdbtn_type_fixed.Text = "Fixed";
            rdbtn_type_fixed.UseVisualStyleBackColor = true;
            rdbtn_type_fixed.CheckedChanged += rdbtn_Type_CheckedChanged;
            // 
            // rdbtn_type_percentage
            // 
            rdbtn_type_percentage.AutoSize = true;
            rdbtn_type_percentage.Cursor = Cursors.Hand;
            rdbtn_type_percentage.Location = new Point(46, 66);
            rdbtn_type_percentage.Name = "rdbtn_type_percentage";
            rdbtn_type_percentage.Size = new Size(103, 24);
            rdbtn_type_percentage.TabIndex = 4;
            rdbtn_type_percentage.Text = "Percentage";
            rdbtn_type_percentage.UseVisualStyleBackColor = true;
            rdbtn_type_percentage.CheckedChanged += rdbtn_Type_CheckedChanged;
            // 
            // rdbtn_type_all
            // 
            rdbtn_type_all.AutoSize = true;
            rdbtn_type_all.Checked = true;
            rdbtn_type_all.Cursor = Cursors.Hand;
            rdbtn_type_all.Location = new Point(46, 26);
            rdbtn_type_all.Name = "rdbtn_type_all";
            rdbtn_type_all.Size = new Size(48, 24);
            rdbtn_type_all.TabIndex = 3;
            rdbtn_type_all.TabStop = true;
            rdbtn_type_all.Text = "All";
            rdbtn_type_all.UseVisualStyleBackColor = true;
            rdbtn_type_all.CheckedChanged += rdbtn_Type_CheckedChanged;
            // 
            // dtgv_voucherlist
            // 
            dtgv_voucherlist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgv_voucherlist.BackgroundColor = Color.White;
            dtgv_voucherlist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgv_voucherlist.Location = new Point(381, 100);
            dtgv_voucherlist.Name = "dtgv_voucherlist";
            dtgv_voucherlist.ReadOnly = true;
            dtgv_voucherlist.RowHeadersWidth = 51;
            dtgv_voucherlist.Size = new Size(1084, 553);
            dtgv_voucherlist.TabIndex = 41;
            dtgv_voucherlist.CellClick += dtgv_voucherlist_CellClick;
            // 
            // pictureBox1
            // 
            pictureBox1.Enabled = false;
            pictureBox1.Image = Properties.Resources.search;
            pictureBox1.Location = new Point(379, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(43, 34);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 42;
            pictureBox1.TabStop = false;
            // 
            // btn_addNewVoucher
            // 
            btn_addNewVoucher.Cursor = Cursors.Hand;
            btn_addNewVoucher.Location = new Point(1298, 54);
            btn_addNewVoucher.Name = "btn_addNewVoucher";
            btn_addNewVoucher.Size = new Size(167, 40);
            btn_addNewVoucher.TabIndex = 43;
            btn_addNewVoucher.Text = "Add new voucher";
            btn_addNewVoucher.UseVisualStyleBackColor = true;
            btn_addNewVoucher.Click += btn_addNewVoucher_Click;
            // 
            // cbbx_sodong
            // 
            cbbx_sodong.FormattingEnabled = true;
            cbbx_sodong.Location = new Point(700, 689);
            cbbx_sodong.Name = "cbbx_sodong";
            cbbx_sodong.Size = new Size(78, 28);
            cbbx_sodong.TabIndex = 48;
            cbbx_sodong.SelectedIndexChanged += cbbx_sodong_SelectedIndexChanged;
            cbbx_sodong.TextChanged += cbbx_sodong_SelectedIndexChanged;
            // 
            // lbl_trang
            // 
            lbl_trang.AutoSize = true;
            lbl_trang.Location = new Point(954, 693);
            lbl_trang.Name = "lbl_trang";
            lbl_trang.Size = new Size(41, 20);
            lbl_trang.TabIndex = 47;
            lbl_trang.Text = "Page";
            // 
            // btn_trangsau
            // 
            btn_trangsau.Cursor = Cursors.Hand;
            btn_trangsau.Location = new Point(1053, 689);
            btn_trangsau.Name = "btn_trangsau";
            btn_trangsau.Size = new Size(94, 29);
            btn_trangsau.TabIndex = 46;
            btn_trangsau.Text = "Next";
            btn_trangsau.UseVisualStyleBackColor = true;
            btn_trangsau.Click += btn_trangsau_Click;
            // 
            // btn_trangtruoc
            // 
            btn_trangtruoc.Cursor = Cursors.Hand;
            btn_trangtruoc.Location = new Point(839, 689);
            btn_trangtruoc.Name = "btn_trangtruoc";
            btn_trangtruoc.Size = new Size(94, 29);
            btn_trangtruoc.TabIndex = 45;
            btn_trangtruoc.Text = "Prevous";
            btn_trangtruoc.UseVisualStyleBackColor = true;
            btn_trangtruoc.Click += btn_trangtruoc_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(645, 693);
            label10.Name = "label10";
            label10.Size = new Size(38, 20);
            label10.TabIndex = 44;
            label10.Text = "Row";
            // 
            // cbbx_cot
            // 
            cbbx_cot.FormattingEnabled = true;
            cbbx_cot.Location = new Point(713, 67);
            cbbx_cot.Name = "cbbx_cot";
            cbbx_cot.Size = new Size(151, 28);
            cbbx_cot.TabIndex = 52;
            cbbx_cot.SelectedIndexChanged += cbbx_cot_SelectedIndexChanged;
            cbbx_cot.TextChanged += cbbx_cot_SelectedIndexChanged;
            // 
            // cbbx_sapxep
            // 
            cbbx_sapxep.FormattingEnabled = true;
            cbbx_sapxep.Location = new Point(462, 68);
            cbbx_sapxep.Name = "cbbx_sapxep";
            cbbx_sapxep.Size = new Size(151, 28);
            cbbx_sapxep.TabIndex = 51;
            cbbx_sapxep.SelectedIndexChanged += cbbx_sapxep_SelectedIndexChanged;
            cbbx_sapxep.TextChanged += cbbx_sapxep_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(635, 75);
            label8.Name = "label8";
            label8.Size = new Size(60, 20);
            label8.TabIndex = 50;
            label8.Text = "Column";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(379, 75);
            label7.Name = "label7";
            label7.Size = new Size(62, 20);
            label7.TabIndex = 49;
            label7.Text = "Arrange";
            // 
            // btn_reset
            // 
            btn_reset.Cursor = Cursors.Hand;
            btn_reset.Location = new Point(138, 671);
            btn_reset.Name = "btn_reset";
            btn_reset.Size = new Size(94, 29);
            btn_reset.TabIndex = 53;
            btn_reset.Text = "RESET";
            btn_reset.UseVisualStyleBackColor = true;
            btn_reset.Click += btn_reset_Click;
            // 
            // btn_edit
            // 
            btn_edit.Cursor = Cursors.Hand;
            btn_edit.Enabled = false;
            btn_edit.Location = new Point(1163, 65);
            btn_edit.Name = "btn_edit";
            btn_edit.Size = new Size(94, 29);
            btn_edit.TabIndex = 54;
            btn_edit.Text = "Edit";
            btn_edit.UseVisualStyleBackColor = true;
            btn_edit.Click += btn_edit_Click;
            // 
            // btn_delete
            // 
            btn_delete.Cursor = Cursors.Hand;
            btn_delete.Enabled = false;
            btn_delete.Location = new Point(1063, 65);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(94, 29);
            btn_delete.TabIndex = 55;
            btn_delete.Text = "Delete";
            btn_delete.UseVisualStyleBackColor = true;
            btn_delete.Click += btn_delete_Click;
            // 
            // ManageVoucherControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            Controls.Add(btn_delete);
            Controls.Add(btn_edit);
            Controls.Add(btn_reset);
            Controls.Add(cbbx_cot);
            Controls.Add(cbbx_sapxep);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(cbbx_sodong);
            Controls.Add(lbl_trang);
            Controls.Add(btn_trangsau);
            Controls.Add(btn_trangtruoc);
            Controls.Add(label10);
            Controls.Add(btn_addNewVoucher);
            Controls.Add(pictureBox1);
            Controls.Add(dtgv_voucherlist);
            Controls.Add(grbx_type);
            Controls.Add(grbx_date);
            Controls.Add(grbx_status);
            Controls.Add(cbbx_find);
            Controls.Add(label1);
            Name = "ManageVoucherControl";
            Size = new Size(1528, 789);
            Load += ManageVoucherControl_Load;
            grbx_status.ResumeLayout(false);
            grbx_status.PerformLayout();
            grbx_date.ResumeLayout(false);
            grbx_date.PerformLayout();
            grbx_type.ResumeLayout(false);
            grbx_type.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgv_voucherlist).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbbx_find;
        private GroupBox grbx_status;
        private RadioButton rdbtn_status_all;
        private RadioButton rdbtn_status_inactive;
        private RadioButton rdbtn_status_activated;
        private GroupBox grbx_date;
        private Label label2;
        private DateTimePicker dtpk_end;
        private DateTimePicker dtpk_start;
        private Label label3;
        private GroupBox grbx_type;
        private RadioButton rdbtn_type_fixed;
        private RadioButton rdbtn_type_percentage;
        private RadioButton rdbtn_type_all;
        private DataGridView dtgv_voucherlist;
        private PictureBox pictureBox1;
        private Button btn_addNewVoucher;
        private ComboBox cbbx_sodong;
        private Label lbl_trang;
        private Button btn_trangsau;
        private Button btn_trangtruoc;
        private Label label10;
        private ComboBox cbbx_cot;
        private ComboBox cbbx_sapxep;
        private Label label8;
        private Label label7;
        private Button btn_reset;
        private Button btn_today_endday;
        private Button btn_today_startday;
        private Button btn_edit;
        private Button btn_delete;
    }
}

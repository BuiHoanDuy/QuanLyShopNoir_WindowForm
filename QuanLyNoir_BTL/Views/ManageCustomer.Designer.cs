namespace QuanLyNoir_BTL.Views
{
    partial class ManageCustomer
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
            tbx_timkiem = new TextBox();
            cbbx_cot = new ComboBox();
            cbbx_sapxep = new ComboBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            dtgv_customerList = new DataGridView();
            cbbx_sodong = new ComboBox();
            lbl_trang = new Label();
            btn_trangsau = new Button();
            btn_trangtruoc = new Button();
            label10 = new Label();
            panel1 = new Panel();
            lbl_detail = new Label();
            dtgv_detail = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dtgv_customerList).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgv_detail).BeginInit();
            SuspendLayout();
            // 
            // tbx_timkiem
            // 
            tbx_timkiem.Location = new Point(589, 85);
            tbx_timkiem.Name = "tbx_timkiem";
            tbx_timkiem.Size = new Size(213, 27);
            tbx_timkiem.TabIndex = 27;
            tbx_timkiem.TextChanged += tbx_timkiem_TextChanged;
            // 
            // cbbx_cot
            // 
            cbbx_cot.FormattingEnabled = true;
            cbbx_cot.Location = new Point(343, 85);
            cbbx_cot.Name = "cbbx_cot";
            cbbx_cot.Size = new Size(181, 28);
            cbbx_cot.TabIndex = 26;
            cbbx_cot.SelectedIndexChanged += cbbx_cot_SelectedIndexChanged;
            // 
            // cbbx_sapxep
            // 
            cbbx_sapxep.FormattingEnabled = true;
            cbbx_sapxep.Location = new Point(133, 86);
            cbbx_sapxep.Name = "cbbx_sapxep";
            cbbx_sapxep.Size = new Size(111, 28);
            cbbx_sapxep.TabIndex = 25;
            cbbx_sapxep.SelectedIndexChanged += cbbx_sapxep_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(546, 92);
            label9.Name = "label9";
            label9.Size = new Size(37, 20);
            label9.TabIndex = 24;
            label9.Text = "Find";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(277, 93);
            label8.Name = "label8";
            label8.Size = new Size(60, 20);
            label8.TabIndex = 23;
            label8.Text = "Column";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(50, 93);
            label7.Name = "label7";
            label7.Size = new Size(62, 20);
            label7.TabIndex = 22;
            label7.Text = "Arrange";
            // 
            // dtgv_customerList
            // 
            dtgv_customerList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgv_customerList.BackgroundColor = SystemColors.ControlLightLight;
            dtgv_customerList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgv_customerList.Location = new Point(47, 131);
            dtgv_customerList.Margin = new Padding(3, 3, 5, 3);
            dtgv_customerList.Name = "dtgv_customerList";
            dtgv_customerList.ReadOnly = true;
            dtgv_customerList.RowHeadersWidth = 51;
            dtgv_customerList.Size = new Size(782, 588);
            dtgv_customerList.TabIndex = 21;
            dtgv_customerList.CellClick += dtgv_customerList_CellClick;
            dtgv_customerList.CellContentClick += dtgv_customerList_CellClick;
            // 
            // cbbx_sodong
            // 
            cbbx_sodong.FormattingEnabled = true;
            cbbx_sodong.Location = new Point(177, 730);
            cbbx_sodong.Name = "cbbx_sodong";
            cbbx_sodong.Size = new Size(78, 28);
            cbbx_sodong.TabIndex = 32;
            cbbx_sodong.SelectedIndexChanged += cbbx_sodong_SelectedIndexChanged;
            // 
            // lbl_trang
            // 
            lbl_trang.AutoSize = true;
            lbl_trang.Location = new Point(431, 734);
            lbl_trang.Name = "lbl_trang";
            lbl_trang.Size = new Size(41, 20);
            lbl_trang.TabIndex = 31;
            lbl_trang.Text = "Page";
            // 
            // btn_trangsau
            // 
            btn_trangsau.Cursor = Cursors.Hand;
            btn_trangsau.Location = new Point(530, 730);
            btn_trangsau.Name = "btn_trangsau";
            btn_trangsau.Size = new Size(94, 29);
            btn_trangsau.TabIndex = 30;
            btn_trangsau.Text = "Next";
            btn_trangsau.UseVisualStyleBackColor = true;
            btn_trangsau.Click += btn_trangsau_Click;
            // 
            // btn_trangtruoc
            // 
            btn_trangtruoc.Cursor = Cursors.Hand;
            btn_trangtruoc.Location = new Point(316, 730);
            btn_trangtruoc.Name = "btn_trangtruoc";
            btn_trangtruoc.Size = new Size(94, 29);
            btn_trangtruoc.TabIndex = 29;
            btn_trangtruoc.Text = "Prevous";
            btn_trangtruoc.UseVisualStyleBackColor = true;
            btn_trangtruoc.Click += btn_trangtruoc_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(122, 734);
            label10.Name = "label10";
            label10.Size = new Size(38, 20);
            label10.TabIndex = 28;
            label10.Text = "Row";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(lbl_detail);
            panel1.Controls.Add(dtgv_detail);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(cbbx_sodong);
            panel1.Controls.Add(dtgv_customerList);
            panel1.Controls.Add(lbl_trang);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(btn_trangsau);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(btn_trangtruoc);
            panel1.Controls.Add(cbbx_sapxep);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(cbbx_cot);
            panel1.Controls.Add(tbx_timkiem);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1528, 789);
            panel1.TabIndex = 33;
            // 
            // lbl_detail
            // 
            lbl_detail.AutoSize = true;
            lbl_detail.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lbl_detail.Location = new Point(853, 85);
            lbl_detail.Name = "lbl_detail";
            lbl_detail.Size = new Size(284, 28);
            lbl_detail.TabIndex = 35;
            lbl_detail.Text = "Purchase history's customer:";
            // 
            // dtgv_detail
            // 
            dtgv_detail.BackgroundColor = SystemColors.ControlLightLight;
            dtgv_detail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgv_detail.Location = new Point(853, 131);
            dtgv_detail.Name = "dtgv_detail";
            dtgv_detail.RowHeadersWidth = 51;
            dtgv_detail.Size = new Size(652, 588);
            dtgv_detail.TabIndex = 34;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(34, 13);
            label1.Name = "label1";
            label1.Size = new Size(312, 46);
            label1.TabIndex = 33;
            label1.Text = "Manage Customer";
            // 
            // ManageCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "ManageCustomer";
            Size = new Size(1528, 789);
            Load += ManageCustomer_Load;
            ((System.ComponentModel.ISupportInitialize)dtgv_customerList).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgv_detail).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox tbx_timkiem;
        private ComboBox cbbx_cot;
        private ComboBox cbbx_sapxep;
        private Label label9;
        private Label label8;
        private Label label7;
        private DataGridView dtgv_customerList;
        private ComboBox cbbx_sodong;
        private Label lbl_trang;
        private Button btn_trangsau;
        private Button btn_trangtruoc;
        private Label label10;
        private Panel panel1;
        private Label label1;
        private Label lbl_detail;
        private DataGridView dtgv_detail;
    }
}

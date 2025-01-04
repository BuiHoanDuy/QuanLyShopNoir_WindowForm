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
            ((System.ComponentModel.ISupportInitialize)dtgv_customerList).BeginInit();
            SuspendLayout();
            // 
            // tbx_timkiem
            // 
            tbx_timkiem.Location = new Point(1187, 34);
            tbx_timkiem.Name = "tbx_timkiem";
            tbx_timkiem.Size = new Size(213, 27);
            tbx_timkiem.TabIndex = 27;
            tbx_timkiem.TextChanged += tbx_timkiem_TextChanged;
            // 
            // cbbx_cot
            // 
            cbbx_cot.FormattingEnabled = true;
            cbbx_cot.Location = new Point(921, 33);
            cbbx_cot.Name = "cbbx_cot";
            cbbx_cot.Size = new Size(151, 28);
            cbbx_cot.TabIndex = 26;
            cbbx_cot.SelectedIndexChanged += cbbx_cot_SelectedIndexChanged;
            // 
            // cbbx_sapxep
            // 
            cbbx_sapxep.FormattingEnabled = true;
            cbbx_sapxep.Location = new Point(670, 34);
            cbbx_sapxep.Name = "cbbx_sapxep";
            cbbx_sapxep.Size = new Size(151, 28);
            cbbx_sapxep.TabIndex = 25;
            cbbx_sapxep.SelectedIndexChanged += cbbx_sapxep_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(1144, 41);
            label9.Name = "label9";
            label9.Size = new Size(37, 20);
            label9.TabIndex = 24;
            label9.Text = "Find";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(843, 41);
            label8.Name = "label8";
            label8.Size = new Size(60, 20);
            label8.TabIndex = 23;
            label8.Text = "Column";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(587, 41);
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
            dtgv_customerList.Location = new Point(522, 84);
            dtgv_customerList.Margin = new Padding(3, 3, 5, 3);
            dtgv_customerList.Name = "dtgv_customerList";
            dtgv_customerList.ReadOnly = true;
            dtgv_customerList.RowHeadersWidth = 51;
            dtgv_customerList.Size = new Size(976, 588);
            dtgv_customerList.TabIndex = 21;
            dtgv_customerList.CellClick += dtgv_customerList_CellClick;
            dtgv_customerList.CellContentClick += dtgv_customerList_CellClick;
            // 
            // cbbx_sodong
            // 
            cbbx_sodong.FormattingEnabled = true;
            cbbx_sodong.Location = new Point(862, 691);
            cbbx_sodong.Name = "cbbx_sodong";
            cbbx_sodong.Size = new Size(78, 28);
            cbbx_sodong.TabIndex = 32;
            cbbx_sodong.SelectedIndexChanged += cbbx_sodong_SelectedIndexChanged;
            // 
            // lbl_trang
            // 
            lbl_trang.AutoSize = true;
            lbl_trang.Location = new Point(1116, 695);
            lbl_trang.Name = "lbl_trang";
            lbl_trang.Size = new Size(41, 20);
            lbl_trang.TabIndex = 31;
            lbl_trang.Text = "Page";
            // 
            // btn_trangsau
            // 
            btn_trangsau.Cursor = Cursors.Hand;
            btn_trangsau.Location = new Point(1215, 691);
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
            btn_trangtruoc.Location = new Point(1001, 691);
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
            label10.Location = new Point(807, 695);
            label10.Name = "label10";
            label10.Size = new Size(38, 20);
            label10.TabIndex = 28;
            label10.Text = "Row";
            // 
            // ManageCustomer
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
            Controls.Add(dtgv_customerList);
            Name = "ManageCustomer";
            Size = new Size(1528, 789);
            Load += ManageCustomer_Load;
            ((System.ComponentModel.ISupportInitialize)dtgv_customerList).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
    }
}

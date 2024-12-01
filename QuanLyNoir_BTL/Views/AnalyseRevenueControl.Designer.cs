namespace QuanLyNoir_BTL.Views
{
    partial class AnalyseRevenueControl
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
            btn_revenueAnalyse = new Button();
            btn_jacket = new Button();
            btn_bag = new Button();
            btn_newcollection = new Button();
            label2 = new Label();
            llbl_daily = new LinkLabel();
            llbl_monthly = new LinkLabel();
            cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            panel1 = new Panel();
            lbl_totalOrder = new Label();
            lbl_totalRevenue = new Label();
            label3 = new Label();
            panel2 = new Panel();
            label6 = new Label();
            cbbx_month = new ComboBox();
            label5 = new Label();
            cbbx_year = new ComboBox();
            label4 = new Label();
            btn_detail = new Button();
            dataGridView1 = new DataGridView();
            btn_chart = new Button();
            lbl_trang = new Label();
            btn_trangsau = new Button();
            btn_trangtruoc = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(59, 24);
            label1.Name = "label1";
            label1.Size = new Size(144, 46);
            label1.TabIndex = 0;
            label1.Text = "Analyse";
            // 
            // btn_revenueAnalyse
            // 
            btn_revenueAnalyse.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_revenueAnalyse.BackColor = Color.DarkSlateGray;
            btn_revenueAnalyse.Cursor = Cursors.Hand;
            btn_revenueAnalyse.FlatStyle = FlatStyle.Flat;
            btn_revenueAnalyse.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold);
            btn_revenueAnalyse.ForeColor = Color.Pink;
            btn_revenueAnalyse.Location = new Point(59, 82);
            btn_revenueAnalyse.Name = "btn_revenueAnalyse";
            btn_revenueAnalyse.Size = new Size(82, 33);
            btn_revenueAnalyse.TabIndex = 43;
            btn_revenueAnalyse.Text = "Revenue";
            btn_revenueAnalyse.UseVisualStyleBackColor = false;
            // 
            // btn_jacket
            // 
            btn_jacket.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_jacket.BackColor = SystemColors.ControlLightLight;
            btn_jacket.Cursor = Cursors.Hand;
            btn_jacket.FlatStyle = FlatStyle.Flat;
            btn_jacket.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold);
            btn_jacket.Location = new Point(318, 82);
            btn_jacket.Name = "btn_jacket";
            btn_jacket.Size = new Size(75, 33);
            btn_jacket.TabIndex = 42;
            btn_jacket.Text = "Orders";
            btn_jacket.UseVisualStyleBackColor = false;
            // 
            // btn_bag
            // 
            btn_bag.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_bag.BackColor = SystemColors.ControlLightLight;
            btn_bag.Cursor = Cursors.Hand;
            btn_bag.FlatStyle = FlatStyle.Flat;
            btn_bag.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold);
            btn_bag.ForeColor = Color.Black;
            btn_bag.Location = new Point(242, 82);
            btn_bag.Name = "btn_bag";
            btn_bag.Size = new Size(63, 33);
            btn_bag.TabIndex = 41;
            btn_bag.Text = "Profit";
            btn_bag.UseVisualStyleBackColor = false;
            // 
            // btn_newcollection
            // 
            btn_newcollection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_newcollection.BackColor = SystemColors.ControlLightLight;
            btn_newcollection.Cursor = Cursors.Hand;
            btn_newcollection.FlatStyle = FlatStyle.Flat;
            btn_newcollection.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold);
            btn_newcollection.ForeColor = SystemColors.ActiveCaptionText;
            btn_newcollection.Location = new Point(151, 82);
            btn_newcollection.Name = "btn_newcollection";
            btn_newcollection.Size = new Size(80, 33);
            btn_newcollection.TabIndex = 40;
            btn_newcollection.Text = "Product";
            btn_newcollection.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label2.Location = new Point(59, 148);
            label2.Name = "label2";
            label2.Size = new Size(223, 31);
            label2.TabIndex = 44;
            label2.Text = "Daily Revenue Chart";
            // 
            // llbl_daily
            // 
            llbl_daily.ActiveLinkColor = SystemColors.ActiveCaptionText;
            llbl_daily.AutoSize = true;
            llbl_daily.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            llbl_daily.ForeColor = Color.Silver;
            llbl_daily.LinkColor = Color.DimGray;
            llbl_daily.Location = new Point(1277, 95);
            llbl_daily.Name = "llbl_daily";
            llbl_daily.Size = new Size(44, 20);
            llbl_daily.TabIndex = 45;
            llbl_daily.TabStop = true;
            llbl_daily.Text = "Daily";
            llbl_daily.VisitedLinkColor = Color.Black;
            llbl_daily.LinkClicked += llbl_daily_LinkClicked;
            // 
            // llbl_monthly
            // 
            llbl_monthly.ActiveLinkColor = SystemColors.ActiveCaptionText;
            llbl_monthly.AutoSize = true;
            llbl_monthly.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            llbl_monthly.LinkColor = Color.Black;
            llbl_monthly.Location = new Point(1338, 95);
            llbl_monthly.Name = "llbl_monthly";
            llbl_monthly.Size = new Size(67, 20);
            llbl_monthly.TabIndex = 47;
            llbl_monthly.TabStop = true;
            llbl_monthly.Text = "Monthly";
            llbl_monthly.VisitedLinkColor = Color.Black;
            llbl_monthly.LinkClicked += llbl_monthly_LinkClicked;
            // 
            // cartesianChart1
            // 
            cartesianChart1.Location = new Point(59, 214);
            cartesianChart1.Name = "cartesianChart1";
            cartesianChart1.Size = new Size(1411, 487);
            cartesianChart1.TabIndex = 48;
            cartesianChart1.Text = "cartesianChart1";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(lbl_totalOrder);
            panel1.Controls.Add(lbl_totalRevenue);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(497, 82);
            panel1.Name = "panel1";
            panel1.Size = new Size(293, 125);
            panel1.TabIndex = 49;
            // 
            // lbl_totalOrder
            // 
            lbl_totalOrder.AutoSize = true;
            lbl_totalOrder.ForeColor = SystemColors.ControlDarkDark;
            lbl_totalOrder.Location = new Point(21, 89);
            lbl_totalOrder.Name = "lbl_totalOrder";
            lbl_totalOrder.Size = new Size(63, 20);
            lbl_totalOrder.TabIndex = 2;
            lbl_totalOrder.Text = "0 orders";
            // 
            // lbl_totalRevenue
            // 
            lbl_totalRevenue.AutoSize = true;
            lbl_totalRevenue.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lbl_totalRevenue.Location = new Point(21, 49);
            lbl_totalRevenue.Name = "lbl_totalRevenue";
            lbl_totalRevenue.Size = new Size(34, 28);
            lbl_totalRevenue.TabIndex = 1;
            lbl_totalRevenue.Text = "0$";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label3.Location = new Point(21, 13);
            label3.Name = "label3";
            label3.Size = new Size(102, 20);
            label3.TabIndex = 0;
            label3.Text = "Total revenue";
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(label6);
            panel2.Controls.Add(cbbx_month);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(cbbx_year);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(827, 82);
            panel2.Name = "panel2";
            panel2.Size = new Size(278, 125);
            panel2.TabIndex = 50;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label6.Location = new Point(18, 13);
            label6.Name = "label6";
            label6.Size = new Size(42, 20);
            label6.TabIndex = 4;
            label6.Text = "Time";
            // 
            // cbbx_month
            // 
            cbbx_month.FormattingEnabled = true;
            cbbx_month.Location = new Point(97, 81);
            cbbx_month.Name = "cbbx_month";
            cbbx_month.Size = new Size(151, 28);
            cbbx_month.TabIndex = 3;
            cbbx_month.SelectedIndexChanged += cbbx_month_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label5.Location = new Point(40, 86);
            label5.Name = "label5";
            label5.Size = new Size(55, 20);
            label5.TabIndex = 2;
            label5.Text = "Month";
            // 
            // cbbx_year
            // 
            cbbx_year.FormattingEnabled = true;
            cbbx_year.Location = new Point(97, 43);
            cbbx_year.Name = "cbbx_year";
            cbbx_year.Size = new Size(151, 28);
            cbbx_year.TabIndex = 1;
            cbbx_year.SelectedIndexChanged += cbbx_year_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label4.Location = new Point(40, 48);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 0;
            label4.Text = "Year";
            // 
            // btn_detail
            // 
            btn_detail.BackColor = Color.DarkSlateGray;
            btn_detail.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_detail.ForeColor = Color.Pink;
            btn_detail.Location = new Point(1227, 173);
            btn_detail.Name = "btn_detail";
            btn_detail.Size = new Size(168, 34);
            btn_detail.TabIndex = 51;
            btn_detail.Text = "Detail";
            btn_detail.UseVisualStyleBackColor = false;
            btn_detail.Click += btn_detail_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(59, 232);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1336, 442);
            dataGridView1.TabIndex = 52;
            dataGridView1.Visible = false;
            // 
            // btn_chart
            // 
            btn_chart.BackColor = Color.DarkSlateGray;
            btn_chart.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_chart.ForeColor = Color.Pink;
            btn_chart.Location = new Point(1227, 174);
            btn_chart.Name = "btn_chart";
            btn_chart.Size = new Size(168, 34);
            btn_chart.TabIndex = 53;
            btn_chart.Text = "Chart";
            btn_chart.UseVisualStyleBackColor = false;
            btn_chart.Visible = false;
            btn_chart.Click += btn_chart_Click;
            // 
            // lbl_trang
            // 
            lbl_trang.AutoSize = true;
            lbl_trang.Location = new Point(643, 687);
            lbl_trang.Name = "lbl_trang";
            lbl_trang.Size = new Size(41, 20);
            lbl_trang.TabIndex = 56;
            lbl_trang.Text = "Page";
            lbl_trang.Visible = false;
            // 
            // btn_trangsau
            // 
            btn_trangsau.Cursor = Cursors.Hand;
            btn_trangsau.Location = new Point(742, 683);
            btn_trangsau.Name = "btn_trangsau";
            btn_trangsau.Size = new Size(94, 29);
            btn_trangsau.TabIndex = 55;
            btn_trangsau.Text = "Next";
            btn_trangsau.UseVisualStyleBackColor = true;
            btn_trangsau.Visible = false;
            btn_trangsau.Click += btn_trangsau_Click;
            // 
            // btn_trangtruoc
            // 
            btn_trangtruoc.Cursor = Cursors.Hand;
            btn_trangtruoc.Location = new Point(528, 683);
            btn_trangtruoc.Name = "btn_trangtruoc";
            btn_trangtruoc.Size = new Size(94, 29);
            btn_trangtruoc.TabIndex = 54;
            btn_trangtruoc.Text = "Prevous";
            btn_trangtruoc.UseVisualStyleBackColor = true;
            btn_trangtruoc.Visible = false;
            btn_trangtruoc.Click += btn_trangtruoc_Click;
            // 
            // AnalyseRevenueControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(lbl_trang);
            Controls.Add(btn_trangsau);
            Controls.Add(btn_trangtruoc);
            Controls.Add(btn_chart);
            Controls.Add(dataGridView1);
            Controls.Add(btn_detail);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(cartesianChart1);
            Controls.Add(llbl_monthly);
            Controls.Add(llbl_daily);
            Controls.Add(label2);
            Controls.Add(btn_revenueAnalyse);
            Controls.Add(btn_jacket);
            Controls.Add(btn_bag);
            Controls.Add(btn_newcollection);
            Controls.Add(label1);
            Name = "AnalyseRevenueControl";
            Size = new Size(1528, 788);
            Load += AnalyseRevenueControl_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btn_revenueAnalyse;
        private Button btn_jacket;
        private Button btn_bag;
        private Button btn_newcollection;
        private Label label2;
        private LinkLabel llbl_daily;
        private LinkLabel llbl_monthly;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private Panel panel1;
        private Label label3;
        private Label lbl_totalOrder;
        private Label lbl_totalRevenue;
        private Panel panel2;
        private ComboBox cbbx_month;
        private Label label5;
        private ComboBox cbbx_year;
        private Label label4;
        private Label label6;
        private Button btn_detail;
        private DataGridView dataGridView1;
        private Button btn_chart;
        private Label lbl_trang;
        private Button btn_trangsau;
        private Button btn_trangtruoc;
    }
}

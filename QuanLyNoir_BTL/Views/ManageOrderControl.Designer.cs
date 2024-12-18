namespace QuanLyNoir_BTL.Views
{
    partial class ManageOrderControl
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
            btn_chart = new Button();
            btn_detail = new Button();
            panel2 = new Panel();
            dateTimePicker = new DateTimePicker();
            label6 = new Label();
            cbbx_month = new ComboBox();
            label5 = new Label();
            cbbx_year = new ComboBox();
            label4 = new Label();
            panel1 = new Panel();
            lbl_totalOrder = new Label();
            label3 = new Label();
            label1 = new Label();
            dataGridView_Order = new DataGridView();
            panel3 = new Panel();
            llbl_daily = new LinkLabel();
            llbl_monthly = new LinkLabel();
            llbl_yearly = new LinkLabel();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Order).BeginInit();
            SuspendLayout();
            // 
            // btn_chart
            // 
            btn_chart.BackColor = Color.DarkSlateGray;
            btn_chart.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_chart.ForeColor = Color.Pink;
            btn_chart.Location = new Point(1067, 110);
            btn_chart.Margin = new Padding(3, 2, 3, 2);
            btn_chart.Name = "btn_chart";
            btn_chart.Size = new Size(147, 26);
            btn_chart.TabIndex = 58;
            btn_chart.Text = "Chart";
            btn_chart.UseVisualStyleBackColor = false;
            btn_chart.Visible = false;
            // 
            // btn_detail
            // 
            btn_detail.BackColor = Color.DarkSlateGray;
            btn_detail.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_detail.ForeColor = Color.Pink;
            btn_detail.Location = new Point(1067, 110);
            btn_detail.Margin = new Padding(3, 2, 3, 2);
            btn_detail.Name = "btn_detail";
            btn_detail.Size = new Size(147, 26);
            btn_detail.TabIndex = 57;
            btn_detail.Text = "Detail";
            btn_detail.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(dateTimePicker);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(cbbx_month);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(cbbx_year);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(717, 41);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(244, 131);
            panel2.TabIndex = 56;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(35, 90);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(183, 23);
            dateTimePicker.TabIndex = 65;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label6.Location = new Point(16, 10);
            label6.Name = "label6";
            label6.Size = new Size(34, 15);
            label6.TabIndex = 4;
            label6.Text = "Time";
            // 
            // cbbx_month
            // 
            cbbx_month.Enabled = false;
            cbbx_month.FormattingEnabled = true;
            cbbx_month.Location = new Point(85, 61);
            cbbx_month.Margin = new Padding(3, 2, 3, 2);
            cbbx_month.Name = "cbbx_month";
            cbbx_month.Size = new Size(133, 23);
            cbbx_month.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label5.Location = new Point(35, 64);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 2;
            label5.Text = "Month";
            // 
            // cbbx_year
            // 
            cbbx_year.Enabled = false;
            cbbx_year.FormattingEnabled = true;
            cbbx_year.Location = new Point(85, 32);
            cbbx_year.Margin = new Padding(3, 2, 3, 2);
            cbbx_year.Name = "cbbx_year";
            cbbx_year.Size = new Size(133, 23);
            cbbx_year.TabIndex = 1;
            cbbx_year.SelectedIndexChanged += cbbx_year_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label4.Location = new Point(35, 36);
            label4.Name = "label4";
            label4.Size = new Size(29, 15);
            label4.TabIndex = 0;
            label4.Text = "Year";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(lbl_totalOrder);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(544, 41);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(141, 95);
            panel1.TabIndex = 55;
            // 
            // lbl_totalOrder
            // 
            lbl_totalOrder.AutoSize = true;
            lbl_totalOrder.ForeColor = SystemColors.ControlDarkDark;
            lbl_totalOrder.Location = new Point(85, 64);
            lbl_totalOrder.Name = "lbl_totalOrder";
            lbl_totalOrder.Size = new Size(49, 15);
            lbl_totalOrder.TabIndex = 2;
            lbl_totalOrder.Text = "0 orders";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label3.Location = new Point(16, 10);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 0;
            label3.Text = "Total orders";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(47, 41);
            label1.Name = "label1";
            label1.Size = new Size(112, 37);
            label1.TabIndex = 59;
            label1.Text = "Căng vl";
            // 
            // dataGridView_Order
            // 
            dataGridView_Order.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Order.Location = new Point(47, 200);
            dataGridView_Order.Name = "dataGridView_Order";
            dataGridView_Order.Size = new Size(914, 375);
            dataGridView_Order.TabIndex = 60;
            dataGridView_Order.CellContentClick += dataGridView_Order_CellContentClick;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Location = new Point(1001, 200);
            panel3.Name = "panel3";
            panel3.Size = new Size(272, 375);
            panel3.TabIndex = 61;
            // 
            // llbl_daily
            // 
            llbl_daily.ActiveLinkColor = SystemColors.ActiveCaptionText;
            llbl_daily.AutoSize = true;
            llbl_daily.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            llbl_daily.ForeColor = Color.Black;
            llbl_daily.LinkColor = Color.Black;
            llbl_daily.Location = new Point(1054, 53);
            llbl_daily.Name = "llbl_daily";
            llbl_daily.Size = new Size(34, 15);
            llbl_daily.TabIndex = 62;
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
            llbl_monthly.LinkColor = Color.DimGray;
            llbl_monthly.Location = new Point(1108, 53);
            llbl_monthly.Name = "llbl_monthly";
            llbl_monthly.Size = new Size(52, 15);
            llbl_monthly.TabIndex = 63;
            llbl_monthly.TabStop = true;
            llbl_monthly.Text = "Monthly";
            llbl_monthly.VisitedLinkColor = Color.Black;
            llbl_monthly.LinkClicked += llbl_monthly_LinkClicked;
            // 
            // llbl_yearly
            // 
            llbl_yearly.ActiveLinkColor = SystemColors.ActiveCaptionText;
            llbl_yearly.AutoSize = true;
            llbl_yearly.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            llbl_yearly.LinkColor = Color.DimGray;
            llbl_yearly.Location = new Point(1179, 53);
            llbl_yearly.Name = "llbl_yearly";
            llbl_yearly.Size = new Size(38, 15);
            llbl_yearly.TabIndex = 64;
            llbl_yearly.TabStop = true;
            llbl_yearly.Text = "Yearly";
            llbl_yearly.VisitedLinkColor = Color.Black;
            llbl_yearly.LinkClicked += llbl_yearly_LinkClicked;
            // 
            // ManageOrderControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(llbl_yearly);
            Controls.Add(llbl_monthly);
            Controls.Add(llbl_daily);
            Controls.Add(panel3);
            Controls.Add(dataGridView_Order);
            Controls.Add(label1);
            Controls.Add(btn_chart);
            Controls.Add(btn_detail);
            Controls.Add(panel2);
            Controls.Add(panel1);
            ForeColor = Color.Black;
            Name = "ManageOrderControl";
            Size = new Size(1337, 591);
            Load += ManageOrderControl_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Order).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_chart;
        private Button btn_detail;
        private Panel panel2;
        private Label label6;
        private ComboBox cbbx_month;
        private Label label5;
        private ComboBox cbbx_year;
        private Label label4;
        private Panel panel1;
        private Label lbl_totalOrder;
        private Label label3;
        private Label label1;
        private DataGridView dataGridView_Order;
        private Panel panel3;
        private LinkLabel llbl_daily;
        private LinkLabel llbl_monthly;
        private LinkLabel llbl_yearly;
        private DateTimePicker dateTimePicker;
    }
}

using System.Windows.Forms;

namespace QuanLyNoir_BTL.Views
{
    partial class RevenueDetail
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dtgv_invoiceDetail = new DataGridView();
            lbl_name = new Label();
            lbl_total = new Label();
            lbl_revenue = new Label();
            lbl_date = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dtgv_invoiceDetail).BeginInit();
            SuspendLayout();
            // 
            // dtgv_invoiceDetail
            // 
            dtgv_invoiceDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgv_invoiceDetail.BackgroundColor = SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.DarkSlateGray;
            dataGridViewCellStyle2.Font = new Font("Arial", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.Pink;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dtgv_invoiceDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dtgv_invoiceDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgv_invoiceDetail.EnableHeadersVisualStyles = false;
            dtgv_invoiceDetail.Location = new Point(74, 153);
            dtgv_invoiceDetail.Name = "dtgv_invoiceDetail";
            dtgv_invoiceDetail.RowHeadersWidth = 51;
            dtgv_invoiceDetail.Size = new Size(1025, 550);
            dtgv_invoiceDetail.TabIndex = 0;
            // 
            // lbl_name
            // 
            lbl_name.AutoSize = true;
            lbl_name.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            lbl_name.Location = new Point(84, 63);
            lbl_name.Name = "lbl_name";
            lbl_name.Size = new Size(106, 25);
            lbl_name.TabIndex = 1;
            lbl_name.Text = "Created by:";
            // 
            // lbl_total
            // 
            lbl_total.AutoSize = true;
            lbl_total.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            lbl_total.Location = new Point(424, 63);
            lbl_total.Name = "lbl_total";
            lbl_total.Size = new Size(56, 25);
            lbl_total.TabIndex = 2;
            lbl_total.Text = "Total:";
            // 
            // lbl_revenue
            // 
            lbl_revenue.AutoSize = true;
            lbl_revenue.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            lbl_revenue.Location = new Point(424, 106);
            lbl_revenue.Name = "lbl_revenue";
            lbl_revenue.Size = new Size(88, 25);
            lbl_revenue.TabIndex = 3;
            lbl_revenue.Text = "Revenue:";
            // 
            // lbl_date
            // 
            lbl_date.AutoSize = true;
            lbl_date.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lbl_date.Location = new Point(84, 106);
            lbl_date.Name = "lbl_date";
            lbl_date.Size = new Size(55, 25);
            lbl_date.TabIndex = 4;
            lbl_date.Text = "Date:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lucida Sans", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(84, 22);
            label1.Name = "label1";
            label1.Size = new Size(80, 26);
            label1.TabIndex = 5;
            label1.Text = "Detail";
            // 
            // RevenueDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1163, 715);
            Controls.Add(label1);
            Controls.Add(lbl_date);
            Controls.Add(lbl_revenue);
            Controls.Add(lbl_total);
            Controls.Add(lbl_name);
            Controls.Add(dtgv_invoiceDetail);
            Name = "RevenueDetail";
            Text = "RevenueDetail";
            ((System.ComponentModel.ISupportInitialize)dtgv_invoiceDetail).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dtgv_invoiceDetail;
        private Label lbl_name;
        private Label lbl_total;
        private Label lbl_revenue;
        private Label lbl_date;
        private Label label1;
    }
}
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
            dtgv_invoiceDetail = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dtgv_invoiceDetail).BeginInit();
            SuspendLayout();
            // 
            // dtgv_invoiceDetail
            // 
            dtgv_invoiceDetail.BackgroundColor = SystemColors.ControlLightLight;
            dtgv_invoiceDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgv_invoiceDetail.Location = new Point(12, 92);
            dtgv_invoiceDetail.Name = "dtgv_invoiceDetail";
            dtgv_invoiceDetail.RowHeadersWidth = 51;
            dtgv_invoiceDetail.Size = new Size(963, 611);
            dtgv_invoiceDetail.TabIndex = 0;
            // 
            // RevenueDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(987, 715);
            Controls.Add(dtgv_invoiceDetail);
            Name = "RevenueDetail";
            Text = "RevenueDetail";
            ((System.ComponentModel.ISupportInitialize)dtgv_invoiceDetail).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dtgv_invoiceDetail;
    }
}
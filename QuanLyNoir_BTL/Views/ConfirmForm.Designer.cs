namespace QuanLyNoir_BTL.Views
{
    partial class ConfirmForm
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
            flpnl_cart = new FlowLayoutPanel();
            cbbx_voucher = new ComboBox();
            cbbx_paymentMethod = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            cbbx_moneyReceive = new ComboBox();
            lbl_totalBill = new Label();
            tbx_refund = new TextBox();
            btn_confirm = new Button();
            btn_cancel = new Button();
            SuspendLayout();
            // 
            // flpnl_cart
            // 
            flpnl_cart.AutoScroll = true;
            flpnl_cart.Location = new Point(3, 2);
            flpnl_cart.Name = "flpnl_cart";
            flpnl_cart.Size = new Size(863, 240);
            flpnl_cart.TabIndex = 0;
            // 
            // cbbx_voucher
            // 
            cbbx_voucher.FormattingEnabled = true;
            cbbx_voucher.Location = new Point(115, 315);
            cbbx_voucher.Name = "cbbx_voucher";
            cbbx_voucher.Size = new Size(295, 28);
            cbbx_voucher.TabIndex = 1;
            cbbx_voucher.SelectedIndexChanged += cbbx_voucher_SelectedIndexChanged;
            // 
            // cbbx_paymentMethod
            // 
            cbbx_paymentMethod.FormattingEnabled = true;
            cbbx_paymentMethod.Items.AddRange(new object[] { "Cash", "Credit Card", "Bank Transfer" });
            cbbx_paymentMethod.Location = new Point(188, 360);
            cbbx_paymentMethod.Name = "cbbx_paymentMethod";
            cbbx_paymentMethod.Size = new Size(222, 28);
            cbbx_paymentMethod.TabIndex = 2;
            cbbx_paymentMethod.SelectedIndexChanged += cbbx_paymentMethod_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label1.Location = new Point(30, 317);
            label1.Name = "label1";
            label1.Size = new Size(80, 25);
            label1.TabIndex = 3;
            label1.Text = "Voucher";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label2.Location = new Point(30, 363);
            label2.Name = "label2";
            label2.Size = new Size(155, 25);
            label2.TabIndex = 4;
            label2.Text = "Payment Method";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label3.Location = new Point(460, 275);
            label3.Name = "label3";
            label3.Size = new Size(149, 25);
            label3.TabIndex = 5;
            label3.Text = "Money received:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label4.Location = new Point(460, 317);
            label4.Name = "label4";
            label4.Size = new Size(76, 25);
            label4.TabIndex = 6;
            label4.Text = "Refund:";
            // 
            // cbbx_moneyReceive
            // 
            cbbx_moneyReceive.FormattingEnabled = true;
            cbbx_moneyReceive.Items.AddRange(new object[] { "0", "100", "200", "500", "1000", "2000", "5000" });
            cbbx_moneyReceive.Location = new Point(618, 272);
            cbbx_moneyReceive.Name = "cbbx_moneyReceive";
            cbbx_moneyReceive.Size = new Size(182, 28);
            cbbx_moneyReceive.TabIndex = 7;
            cbbx_moneyReceive.SelectedIndexChanged += cbbx_moneyReceive_SelectedIndexChanged;
            // 
            // lbl_totalBill
            // 
            lbl_totalBill.AutoSize = true;
            lbl_totalBill.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            lbl_totalBill.Location = new Point(30, 275);
            lbl_totalBill.Name = "lbl_totalBill";
            lbl_totalBill.Size = new Size(112, 25);
            lbl_totalBill.TabIndex = 9;
            lbl_totalBill.Text = "Total Bill: 0$";
            // 
            // tbx_refund
            // 
            tbx_refund.BackColor = Color.White;
            tbx_refund.Location = new Point(618, 315);
            tbx_refund.Name = "tbx_refund";
            tbx_refund.ReadOnly = true;
            tbx_refund.Size = new Size(182, 27);
            tbx_refund.TabIndex = 11;
            tbx_refund.Text = "0";
            // 
            // btn_confirm
            // 
            btn_confirm.Location = new Point(460, 363);
            btn_confirm.Name = "btn_confirm";
            btn_confirm.Size = new Size(214, 29);
            btn_confirm.TabIndex = 12;
            btn_confirm.Text = "CONFIRM";
            btn_confirm.UseVisualStyleBackColor = true;
            btn_confirm.Click += btn_confirm_Click;
            // 
            // btn_cancel
            // 
            btn_cancel.Location = new Point(706, 363);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(94, 29);
            btn_cancel.TabIndex = 13;
            btn_cancel.Text = "CANCEL";
            btn_cancel.UseVisualStyleBackColor = true;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // ConfirmForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(881, 426);
            Controls.Add(btn_cancel);
            Controls.Add(btn_confirm);
            Controls.Add(tbx_refund);
            Controls.Add(lbl_totalBill);
            Controls.Add(cbbx_moneyReceive);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cbbx_paymentMethod);
            Controls.Add(cbbx_voucher);
            Controls.Add(flpnl_cart);
            Name = "ConfirmForm";
            Text = "ConfirmForm";
            Load += ConfirmForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private FlowLayoutPanel flpnl_cart;
        private ComboBox cbbx_voucher;
        private ComboBox cbbx_paymentMethod;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cbbx_moneyReceive;
        private Label lbl_totalBill;
        private TextBox tbx_refund;
        private Button btn_confirm;
        private Button btn_cancel;
        #endregion
    }
}
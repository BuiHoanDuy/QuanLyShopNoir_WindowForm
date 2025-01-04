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
            lbl_nameCus = new Label();
            lbl_cus = new Label();
            lbl_emailCus = new Label();
            lbl_phoneCus = new Label();
            tbx_nameCus = new TextBox();
            tbx_emailCus = new TextBox();
            tbx_phoneCus = new TextBox();
            SuspendLayout();
            // 
            // flpnl_cart
            // 
            flpnl_cart.AutoScroll = true;
            flpnl_cart.BackColor = SystemColors.ControlLightLight;
            flpnl_cart.Location = new Point(12, 3);
            flpnl_cart.Name = "flpnl_cart";
            flpnl_cart.Size = new Size(833, 335);
            flpnl_cart.TabIndex = 0;
            // 
            // cbbx_voucher
            // 
            cbbx_voucher.FormattingEnabled = true;
            cbbx_voucher.Location = new Point(591, 435);
            cbbx_voucher.Name = "cbbx_voucher";
            cbbx_voucher.Size = new Size(254, 28);
            cbbx_voucher.TabIndex = 1;
            cbbx_voucher.TextChanged += cbbx_voucher_SelectedIndexChanged;
            // 
            // cbbx_paymentMethod
            // 
            cbbx_paymentMethod.FormattingEnabled = true;
            cbbx_paymentMethod.Items.AddRange(new object[] { "Cash", "Credit Card", "Bank Transfer" });
            cbbx_paymentMethod.Location = new Point(591, 480);
            cbbx_paymentMethod.Name = "cbbx_paymentMethod";
            cbbx_paymentMethod.Size = new Size(253, 28);
            cbbx_paymentMethod.TabIndex = 2;
            cbbx_paymentMethod.SelectedIndexChanged += cbbx_paymentMethod_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label1.Location = new Point(433, 437);
            label1.Name = "label1";
            label1.Size = new Size(85, 25);
            label1.TabIndex = 3;
            label1.Text = "Voucher:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label2.Location = new Point(433, 483);
            label2.Name = "label2";
            label2.Size = new Size(159, 25);
            label2.TabIndex = 4;
            label2.Text = "Payment Method:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label3.Location = new Point(432, 535);
            label3.Name = "label3";
            label3.Size = new Size(149, 25);
            label3.TabIndex = 5;
            label3.Text = "Money received:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label4.Location = new Point(432, 587);
            label4.Name = "label4";
            label4.Size = new Size(76, 25);
            label4.TabIndex = 6;
            label4.Text = "Refund:";
            // 
            // cbbx_moneyReceive
            // 
            cbbx_moneyReceive.FormattingEnabled = true;
            cbbx_moneyReceive.Items.AddRange(new object[] { "0", "100", "200", "500", "1000", "2000", "5000" });
            cbbx_moneyReceive.Location = new Point(591, 532);
            cbbx_moneyReceive.Name = "cbbx_moneyReceive";
            cbbx_moneyReceive.Size = new Size(253, 28);
            cbbx_moneyReceive.TabIndex = 7;
            cbbx_moneyReceive.SelectedIndexChanged += cbbx_moneyReceive_SelectedIndexChanged;
            cbbx_moneyReceive.TextChanged += cbbx_moneyReceive_SelectedIndexChanged;
            // 
            // lbl_totalBill
            // 
            lbl_totalBill.AutoSize = true;
            lbl_totalBill.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            lbl_totalBill.Location = new Point(434, 387);
            lbl_totalBill.Name = "lbl_totalBill";
            lbl_totalBill.Size = new Size(112, 25);
            lbl_totalBill.TabIndex = 9;
            lbl_totalBill.Text = "Total Bill: 0$";
            // 
            // tbx_refund
            // 
            tbx_refund.BackColor = Color.White;
            tbx_refund.Location = new Point(591, 584);
            tbx_refund.Name = "tbx_refund";
            tbx_refund.ReadOnly = true;
            tbx_refund.Size = new Size(254, 27);
            tbx_refund.TabIndex = 11;
            tbx_refund.Text = "0";
            // 
            // btn_confirm
            // 
            btn_confirm.BackColor = Color.FromArgb(0, 64, 0);
            btn_confirm.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_confirm.ForeColor = SystemColors.ControlLightLight;
            btn_confirm.Location = new Point(432, 649);
            btn_confirm.Name = "btn_confirm";
            btn_confirm.Size = new Size(414, 47);
            btn_confirm.TabIndex = 12;
            btn_confirm.Text = "CONFIRM";
            btn_confirm.UseVisualStyleBackColor = false;
            btn_confirm.Click += btn_confirm_Click;
            // 
            // btn_cancel
            // 
            btn_cancel.Location = new Point(30, 649);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(367, 47);
            btn_cancel.TabIndex = 13;
            btn_cancel.Text = "CANCEL";
            btn_cancel.UseVisualStyleBackColor = true;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // lbl_nameCus
            // 
            lbl_nameCus.AutoSize = true;
            lbl_nameCus.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            lbl_nameCus.Location = new Point(30, 483);
            lbl_nameCus.Name = "lbl_nameCus";
            lbl_nameCus.Size = new Size(65, 25);
            lbl_nameCus.TabIndex = 14;
            lbl_nameCus.Text = "Name:";
            // 
            // lbl_cus
            // 
            lbl_cus.AutoSize = true;
            lbl_cus.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            lbl_cus.Location = new Point(172, 387);
            lbl_cus.Name = "lbl_cus";
            lbl_cus.Size = new Size(93, 25);
            lbl_cus.TabIndex = 16;
            lbl_cus.Text = "Customer";
            // 
            // lbl_emailCus
            // 
            lbl_emailCus.AutoSize = true;
            lbl_emailCus.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            lbl_emailCus.Location = new Point(30, 532);
            lbl_emailCus.Name = "lbl_emailCus";
            lbl_emailCus.Size = new Size(60, 25);
            lbl_emailCus.TabIndex = 17;
            lbl_emailCus.Text = "Email:";
            // 
            // lbl_phoneCus
            // 
            lbl_phoneCus.AutoSize = true;
            lbl_phoneCus.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            lbl_phoneCus.Location = new Point(30, 438);
            lbl_phoneCus.Name = "lbl_phoneCus";
            lbl_phoneCus.Size = new Size(69, 25);
            lbl_phoneCus.TabIndex = 19;
            lbl_phoneCus.Text = "Phone:";
            // 
            // tbx_nameCus
            // 
            tbx_nameCus.Enabled = false;
            tbx_nameCus.Location = new Point(98, 483);
            tbx_nameCus.Margin = new Padding(3, 4, 3, 4);
            tbx_nameCus.Name = "tbx_nameCus";
            tbx_nameCus.Size = new Size(298, 27);
            tbx_nameCus.TabIndex = 24;
            // 
            // tbx_emailCus
            // 
            tbx_emailCus.Enabled = false;
            tbx_emailCus.Location = new Point(98, 532);
            tbx_emailCus.Margin = new Padding(3, 4, 3, 4);
            tbx_emailCus.Name = "tbx_emailCus";
            tbx_emailCus.Size = new Size(298, 27);
            tbx_emailCus.TabIndex = 25;
            // 
            // tbx_phoneCus
            // 
            tbx_phoneCus.Location = new Point(98, 438);
            tbx_phoneCus.Margin = new Padding(3, 4, 3, 4);
            tbx_phoneCus.Name = "tbx_phoneCus";
            tbx_phoneCus.Size = new Size(298, 27);
            tbx_phoneCus.TabIndex = 26;
            tbx_phoneCus.TextChanged += tbx_phoneCus_TextChanged;
            // 
            // ConfirmForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(859, 724);
            Controls.Add(tbx_phoneCus);
            Controls.Add(tbx_emailCus);
            Controls.Add(tbx_nameCus);
            Controls.Add(lbl_phoneCus);
            Controls.Add(lbl_emailCus);
            Controls.Add(lbl_cus);
            Controls.Add(lbl_nameCus);
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
            FormClosing += ConfirmForm_FormClosing;
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
        private Label lbl_nameCus;
        private Label lbl_cus;
        private Label lbl_emailCus;
        private Label lbl_phoneCus;

        private TextBox tbx_nameCus;
        private TextBox tbx_emailCus;
        private TextBox tbx_phoneCus;
    }
}
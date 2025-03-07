﻿
namespace QuanLyNoir_BTL
{
    partial class MenuForm
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
            btn_signout = new Button();
            panel1 = new Panel();
            btn_manageAccount = new Button();
            btn_manageVoucher = new Button();
            btn_analyseRevenue = new Button();
            btn_manageCustomer = new Button();
            btn_manageproduct = new Button();
            label6 = new Label();
            lbl_name = new Label();
            pnl_control = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btn_signout
            // 
            btn_signout.Cursor = Cursors.Hand;
            btn_signout.Location = new Point(1246, 12);
            btn_signout.Name = "btn_signout";
            btn_signout.Size = new Size(106, 29);
            btn_signout.TabIndex = 0;
            btn_signout.Text = "Sign out";
            btn_signout.UseVisualStyleBackColor = true;
            btn_signout.Click += btn_signout_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btn_manageAccount);
            panel1.Controls.Add(btn_manageVoucher);
            panel1.Controls.Add(btn_analyseRevenue);
            panel1.Controls.Add(btn_manageCustomer);
            panel1.Controls.Add(btn_manageproduct);
            panel1.Controls.Add(label6);
            panel1.Location = new Point(-2, 47);
            panel1.Name = "panel1";
            panel1.Size = new Size(1665, 64);
            panel1.TabIndex = 1;
            // 
            // btn_manageAccount
            // 
            btn_manageAccount.BackColor = Color.White;
            btn_manageAccount.Cursor = Cursors.Hand;
            btn_manageAccount.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_manageAccount.Location = new Point(273, 10);
            btn_manageAccount.Name = "btn_manageAccount";
            btn_manageAccount.Size = new Size(204, 44);
            btn_manageAccount.TabIndex = 8;
            btn_manageAccount.Text = "Manage Account";
            btn_manageAccount.UseVisualStyleBackColor = false;
            btn_manageAccount.Click += btn_manageAccount_Click;
            // 
            // btn_manageVoucher
            // 
            btn_manageVoucher.Cursor = Cursors.Hand;
            btn_manageVoucher.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_manageVoucher.Location = new Point(512, 10);
            btn_manageVoucher.Name = "btn_manageVoucher";
            btn_manageVoucher.Size = new Size(204, 44);
            btn_manageVoucher.TabIndex = 7;
            btn_manageVoucher.Text = "Manage Voucher";
            btn_manageVoucher.UseVisualStyleBackColor = true;
            btn_manageVoucher.Click += btn_manageVoucher_Click;
            // 
            // btn_analyseRevenue
            // 
            btn_analyseRevenue.Cursor = Cursors.Hand;
            btn_analyseRevenue.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_analyseRevenue.Location = new Point(1247, 10);
            btn_analyseRevenue.Name = "btn_analyseRevenue";
            btn_analyseRevenue.Size = new Size(204, 44);
            btn_analyseRevenue.TabIndex = 6;
            btn_analyseRevenue.Text = "Analyse Revenue";
            btn_analyseRevenue.UseVisualStyleBackColor = true;
            btn_analyseRevenue.Click += btn_analyseRevenue_Click;
            // 
            // btn_manageCustomer
            // 
            btn_manageCustomer.Cursor = Cursors.Hand;
            btn_manageCustomer.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_manageCustomer.Location = new Point(998, 10);
            btn_manageCustomer.Name = "btn_manageCustomer";
            btn_manageCustomer.Size = new Size(204, 44);
            btn_manageCustomer.TabIndex = 5;
            btn_manageCustomer.Text = "Manage Customers";
            btn_manageCustomer.UseVisualStyleBackColor = true;
            btn_manageCustomer.Click += btn_manageOrder_Click;
            // 
            // btn_manageproduct
            // 
            btn_manageproduct.BackColor = Color.FromArgb(0, 64, 0);
            btn_manageproduct.Cursor = Cursors.Hand;
            btn_manageproduct.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_manageproduct.ForeColor = Color.FromArgb(255, 128, 255);
            btn_manageproduct.Location = new Point(754, 10);
            btn_manageproduct.Name = "btn_manageproduct";
            btn_manageproduct.Size = new Size(204, 44);
            btn_manageproduct.TabIndex = 4;
            btn_manageproduct.Text = "Manage Product";
            btn_manageproduct.UseVisualStyleBackColor = false;
            btn_manageproduct.Click += btn_manageproduct_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 134);
            label6.Location = new Point(50, 19);
            label6.Name = "label6";
            label6.Size = new Size(68, 31);
            label6.TabIndex = 3;
            label6.Text = "Noir";
            // 
            // lbl_name
            // 
            lbl_name.AutoSize = true;
            lbl_name.Location = new Point(1358, 16);
            lbl_name.Name = "lbl_name";
            lbl_name.Size = new Size(37, 15);
            lbl_name.TabIndex = 18;
            lbl_name.Text = "name";
            // 
            // pnl_control
            // 
            pnl_control.BackColor = Color.Transparent;
            pnl_control.Location = new Point(-2, 108);
            pnl_control.Name = "pnl_control";
            pnl_control.Size = new Size(1530, 790);
            pnl_control.TabIndex = 19;
            // 
            // MenuForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Info;
            ClientSize = new Size(1524, 895);
            Controls.Add(lbl_name);
            Controls.Add(panel1);
            Controls.Add(btn_signout);
            Controls.Add(pnl_control);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            Name = "MenuForm";
            Text = "ManageProduct";
            TransparencyKey = Color.FromArgb(255, 192, 192);
            FormClosing += ManageProduct_FormClosing;
            Load += MenuForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_signout;
        private Panel panel1;
        private Button btn_analyseRevenue;
        private Button btn_manageCustomer;
        private Button btn_manageproduct;
        private Label label6;
        private Label lbl_name;
        private Button btn_manageAccount;
        private Button btn_manageVoucher;
        private Panel pnl_control;
    }
}
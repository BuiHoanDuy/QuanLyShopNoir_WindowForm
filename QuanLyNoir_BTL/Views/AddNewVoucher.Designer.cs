namespace QuanLyNoir_BTL.Views
{
    partial class AddNewVoucher
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
            label1 = new Label();
            groupBox1 = new GroupBox();
            btn_random = new Button();
            tbx_voucherCode = new TextBox();
            groupBox2 = new GroupBox();
            rdbtn_fixed = new RadioButton();
            rdbtn_percentage = new RadioButton();
            groupBox3 = new GroupBox();
            label9 = new Label();
            label2 = new Label();
            tbx_discountValue = new TextBox();
            ntbx_maxUsage = new NumericUpDown();
            groupBox4 = new GroupBox();
            label3 = new Label();
            groupBox5 = new GroupBox();
            label4 = new Label();
            tbx_minOrderValue = new TextBox();
            groupBox6 = new GroupBox();
            dtpk_startday = new DateTimePicker();
            groupBox7 = new GroupBox();
            cbbx_dayOrMonth = new ComboBox();
            ntbx_validityPeriod = new NumericUpDown();
            rdbtn_validityPeriod = new RadioButton();
            rdbtn_fixedDay = new RadioButton();
            dtpk_endday = new DateTimePicker();
            groupBox8 = new GroupBox();
            rdbtn_unactivated = new RadioButton();
            rdbtn_activated = new RadioButton();
            btn_save = new Button();
            btn_reset = new Button();
            btn_update = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ntbx_maxUsage).BeginInit();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ntbx_validityPeriod).BeginInit();
            groupBox8.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lucida Sans", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(81, 35);
            label1.Name = "label1";
            label1.Size = new Size(219, 26);
            label1.TabIndex = 0;
            label1.Text = "Add New Voucher";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(btn_random);
            groupBox1.Controls.Add(tbx_voucherCode);
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.Location = new Point(81, 79);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(338, 90);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Voucher code";
            // 
            // btn_random
            // 
            btn_random.Location = new Point(256, 34);
            btn_random.Name = "btn_random";
            btn_random.Size = new Size(76, 29);
            btn_random.TabIndex = 1;
            btn_random.Text = "Random";
            btn_random.UseVisualStyleBackColor = true;
            btn_random.Click += btn_random_Click;
            // 
            // tbx_voucherCode
            // 
            tbx_voucherCode.Location = new Point(24, 35);
            tbx_voucherCode.Name = "tbx_voucherCode";
            tbx_voucherCode.Size = new Size(226, 27);
            tbx_voucherCode.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(rdbtn_fixed);
            groupBox2.Controls.Add(rdbtn_percentage);
            groupBox2.Location = new Point(81, 196);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(338, 90);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Discount type";
            // 
            // rdbtn_fixed
            // 
            rdbtn_fixed.AutoSize = true;
            rdbtn_fixed.Cursor = Cursors.Hand;
            rdbtn_fixed.Location = new Point(185, 39);
            rdbtn_fixed.Name = "rdbtn_fixed";
            rdbtn_fixed.Size = new Size(65, 24);
            rdbtn_fixed.TabIndex = 1;
            rdbtn_fixed.Text = "Fixed";
            rdbtn_fixed.UseVisualStyleBackColor = true;
            // 
            // rdbtn_percentage
            // 
            rdbtn_percentage.AutoSize = true;
            rdbtn_percentage.Checked = true;
            rdbtn_percentage.Cursor = Cursors.Hand;
            rdbtn_percentage.Location = new Point(30, 39);
            rdbtn_percentage.Name = "rdbtn_percentage";
            rdbtn_percentage.Size = new Size(103, 24);
            rdbtn_percentage.TabIndex = 0;
            rdbtn_percentage.TabStop = true;
            rdbtn_percentage.Text = "Percentage";
            rdbtn_percentage.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.Transparent;
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(tbx_discountValue);
            groupBox3.Location = new Point(81, 323);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(338, 90);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "Discount value";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Enabled = false;
            label9.Location = new Point(195, 54);
            label9.Name = "label9";
            label9.Size = new Size(99, 20);
            label9.TabIndex = 2;
            label9.Text = "(Ex: 20 = 20$)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Enabled = false;
            label2.Location = new Point(195, 34);
            label2.Name = "label2";
            label2.Size = new Size(114, 20);
            label2.TabIndex = 1;
            label2.Text = "(Ex: 0.25 = 25%)";
            // 
            // tbx_discountValue
            // 
            tbx_discountValue.Location = new Point(30, 43);
            tbx_discountValue.Name = "tbx_discountValue";
            tbx_discountValue.Size = new Size(159, 27);
            tbx_discountValue.TabIndex = 0;
            tbx_discountValue.TextAlign = HorizontalAlignment.Center;
            // 
            // ntbx_maxUsage
            // 
            ntbx_maxUsage.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            ntbx_maxUsage.Location = new Point(30, 38);
            ntbx_maxUsage.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            ntbx_maxUsage.Name = "ntbx_maxUsage";
            ntbx_maxUsage.Size = new Size(159, 27);
            ntbx_maxUsage.TabIndex = 0;
            ntbx_maxUsage.TextAlign = HorizontalAlignment.Center;
            ntbx_maxUsage.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.Transparent;
            groupBox4.Controls.Add(label3);
            groupBox4.Controls.Add(ntbx_maxUsage);
            groupBox4.Location = new Point(81, 447);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(338, 90);
            groupBox4.TabIndex = 11;
            groupBox4.TabStop = false;
            groupBox4.Text = "Max usage";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Enabled = false;
            label3.Location = new Point(201, 40);
            label3.Name = "label3";
            label3.Size = new Size(131, 20);
            label3.TabIndex = 3;
            label3.Text = "(Ex: 50 = 50 times)";
            // 
            // groupBox5
            // 
            groupBox5.BackColor = Color.Transparent;
            groupBox5.Controls.Add(label4);
            groupBox5.Controls.Add(tbx_minOrderValue);
            groupBox5.Location = new Point(506, 79);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(338, 90);
            groupBox5.TabIndex = 12;
            groupBox5.TabStop = false;
            groupBox5.Text = "Minimum order value";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Enabled = false;
            label4.Location = new Point(217, 37);
            label4.Name = "label4";
            label4.Size = new Size(99, 20);
            label4.TabIndex = 3;
            label4.Text = "(Ex: 20 = 20$)";
            // 
            // tbx_minOrderValue
            // 
            tbx_minOrderValue.Location = new Point(37, 34);
            tbx_minOrderValue.Name = "tbx_minOrderValue";
            tbx_minOrderValue.Size = new Size(174, 27);
            tbx_minOrderValue.TabIndex = 1;
            tbx_minOrderValue.Text = "0";
            tbx_minOrderValue.TextAlign = HorizontalAlignment.Center;
            // 
            // groupBox6
            // 
            groupBox6.BackColor = Color.Transparent;
            groupBox6.Controls.Add(dtpk_startday);
            groupBox6.Location = new Point(506, 196);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(338, 90);
            groupBox6.TabIndex = 13;
            groupBox6.TabStop = false;
            groupBox6.Text = "Start day";
            // 
            // dtpk_startday
            // 
            dtpk_startday.Location = new Point(37, 39);
            dtpk_startday.MinDate = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            dtpk_startday.Name = "dtpk_startday";
            dtpk_startday.Size = new Size(250, 27);
            dtpk_startday.TabIndex = 0;
            // 
            // groupBox7
            // 
            groupBox7.BackColor = Color.Transparent;
            groupBox7.Controls.Add(cbbx_dayOrMonth);
            groupBox7.Controls.Add(ntbx_validityPeriod);
            groupBox7.Controls.Add(rdbtn_validityPeriod);
            groupBox7.Controls.Add(rdbtn_fixedDay);
            groupBox7.Controls.Add(dtpk_endday);
            groupBox7.Location = new Point(506, 323);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(338, 214);
            groupBox7.TabIndex = 14;
            groupBox7.TabStop = false;
            groupBox7.Text = "End day";
            // 
            // cbbx_dayOrMonth
            // 
            cbbx_dayOrMonth.FormattingEnabled = true;
            cbbx_dayOrMonth.Items.AddRange(new object[] { "Day", "Month" });
            cbbx_dayOrMonth.Location = new Point(186, 161);
            cbbx_dayOrMonth.Name = "cbbx_dayOrMonth";
            cbbx_dayOrMonth.Size = new Size(130, 28);
            cbbx_dayOrMonth.TabIndex = 4;
            // 
            // ntbx_validityPeriod
            // 
            ntbx_validityPeriod.Location = new Point(66, 162);
            ntbx_validityPeriod.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            ntbx_validityPeriod.Name = "ntbx_validityPeriod";
            ntbx_validityPeriod.Size = new Size(110, 27);
            ntbx_validityPeriod.TabIndex = 3;
            ntbx_validityPeriod.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // rdbtn_validityPeriod
            // 
            rdbtn_validityPeriod.AutoSize = true;
            rdbtn_validityPeriod.Checked = true;
            rdbtn_validityPeriod.Cursor = Cursors.Hand;
            rdbtn_validityPeriod.Location = new Point(37, 124);
            rdbtn_validityPeriod.Name = "rdbtn_validityPeriod";
            rdbtn_validityPeriod.Size = new Size(127, 24);
            rdbtn_validityPeriod.TabIndex = 2;
            rdbtn_validityPeriod.TabStop = true;
            rdbtn_validityPeriod.Text = "Validity period";
            rdbtn_validityPeriod.UseVisualStyleBackColor = true;
            rdbtn_validityPeriod.CheckedChanged += rdbtn_validityPeriod_CheckedChanged;
            // 
            // rdbtn_fixedDay
            // 
            rdbtn_fixedDay.AutoSize = true;
            rdbtn_fixedDay.Cursor = Cursors.Hand;
            rdbtn_fixedDay.Location = new Point(37, 38);
            rdbtn_fixedDay.Name = "rdbtn_fixedDay";
            rdbtn_fixedDay.Size = new Size(93, 24);
            rdbtn_fixedDay.TabIndex = 1;
            rdbtn_fixedDay.Text = "Fixed day";
            rdbtn_fixedDay.UseVisualStyleBackColor = true;
            rdbtn_fixedDay.CheckedChanged += rdbtn_fixedDay_CheckedChanged;
            // 
            // dtpk_endday
            // 
            dtpk_endday.Location = new Point(66, 78);
            dtpk_endday.Name = "dtpk_endday";
            dtpk_endday.Size = new Size(250, 27);
            dtpk_endday.TabIndex = 0;
            dtpk_endday.Value = new DateTime(2025, 1, 31, 0, 0, 0, 0);
            // 
            // groupBox8
            // 
            groupBox8.BackColor = Color.Transparent;
            groupBox8.Controls.Add(rdbtn_unactivated);
            groupBox8.Controls.Add(rdbtn_activated);
            groupBox8.Location = new Point(81, 573);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(338, 90);
            groupBox8.TabIndex = 15;
            groupBox8.TabStop = false;
            groupBox8.Text = "Status";
            // 
            // rdbtn_unactivated
            // 
            rdbtn_unactivated.AutoSize = true;
            rdbtn_unactivated.Cursor = Cursors.Hand;
            rdbtn_unactivated.Location = new Point(185, 39);
            rdbtn_unactivated.Name = "rdbtn_unactivated";
            rdbtn_unactivated.Size = new Size(109, 24);
            rdbtn_unactivated.TabIndex = 1;
            rdbtn_unactivated.Text = "Unactivated";
            rdbtn_unactivated.UseVisualStyleBackColor = true;
            // 
            // rdbtn_activated
            // 
            rdbtn_activated.AutoSize = true;
            rdbtn_activated.Checked = true;
            rdbtn_activated.Cursor = Cursors.Hand;
            rdbtn_activated.Location = new Point(30, 39);
            rdbtn_activated.Name = "rdbtn_activated";
            rdbtn_activated.Size = new Size(93, 24);
            rdbtn_activated.TabIndex = 0;
            rdbtn_activated.TabStop = true;
            rdbtn_activated.Text = "Activated";
            rdbtn_activated.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            btn_save.BackColor = Color.FromArgb(190, 210, 180);
            btn_save.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_save.ForeColor = Color.FromArgb(51, 51, 51);
            btn_save.Location = new Point(506, 573);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(338, 55);
            btn_save.TabIndex = 16;
            btn_save.Text = "Save";
            btn_save.UseVisualStyleBackColor = false;
            btn_save.Click += btn_save_Click;
            // 
            // btn_reset
            // 
            btn_reset.BackColor = Color.FromArgb(190, 198, 160);
            btn_reset.Cursor = Cursors.Hand;
            btn_reset.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_reset.ForeColor = Color.FromArgb(51, 51, 51);
            btn_reset.Location = new Point(750, 634);
            btn_reset.Name = "btn_reset";
            btn_reset.Size = new Size(94, 29);
            btn_reset.TabIndex = 17;
            btn_reset.Text = "Reset";
            btn_reset.UseVisualStyleBackColor = false;
            btn_reset.Click += btn_reset_Click;
            // 
            // btn_update
            // 
            btn_update.BackColor = Color.FromArgb(190, 210, 180);
            btn_update.Cursor = Cursors.Hand;
            btn_update.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_update.ForeColor = Color.FromArgb(51, 51, 51);
            btn_update.Location = new Point(506, 573);
            btn_update.Name = "btn_update";
            btn_update.Size = new Size(338, 55);
            btn_update.TabIndex = 18;
            btn_update.Text = "Update";
            btn_update.UseVisualStyleBackColor = false;
            btn_update.Click += btn_update_Click;
            // 
            // AddNewVoucher
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(987, 715);
            Controls.Add(btn_update);
            Controls.Add(btn_reset);
            Controls.Add(btn_save);
            Controls.Add(groupBox8);
            Controls.Add(groupBox7);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "AddNewVoucher";
            Text = "AddNewVoucher";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ntbx_maxUsage).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ntbx_validityPeriod).EndInit();
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Button btn_random;
        private TextBox tbx_voucherCode;
        private GroupBox groupBox2;
        private RadioButton rdbtn_fixed;
        private RadioButton rdbtn_percentage;
        private GroupBox groupBox3;
        private NumericUpDown ntbx_maxUsage;
        private Label label9;
        private Label label2;
        private TextBox tbx_discountValue;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private TextBox tbx_minOrderValue;
        private GroupBox groupBox6;
        private GroupBox groupBox7;
        private DateTimePicker dtpk_startday;
        private DateTimePicker dtpk_endday;
        private GroupBox groupBox8;
        private RadioButton rdbtn_unactivated;
        private RadioButton rdbtn_activated;
        private Button btn_save;
        private Label label3;
        private Label label4;
        private ComboBox cbbx_dayOrMonth;
        private NumericUpDown ntbx_validityPeriod;
        private RadioButton rdbtn_validityPeriod;
        private RadioButton rdbtn_fixedDay;
        private Button btn_reset;
        private Button btn_update;
    }
}
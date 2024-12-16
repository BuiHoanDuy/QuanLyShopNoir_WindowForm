namespace QuanLyNoir_BTL.Views
{
    partial class TakingProductForm
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
            groupBox3 = new GroupBox();
            lbl_size = new Label();
            btn_xl = new Button();
            btn_l = new Button();
            btn_m = new Button();
            btn_s = new Button();
            btn_none = new Button();
            pictureBox1 = new PictureBox();
            lbl_name = new Label();
            btn_save = new Button();
            btn_down = new Button();
            pnl_amount = new Panel();
            lbl_amount = new Label();
            btn_up = new Button();
            btn_reset = new Button();
            tbx_colorNote = new TextBox();
            pnl_colorBox = new Panel();
            label5 = new Label();
            lbl_inventory = new Label();
            label2 = new Label();
            label1 = new Label();
            lbl_price = new Label();
            label4 = new Label();
            lbl_total = new Label();
            label7 = new Label();
            label8 = new Label();
            lbl_tempAmount = new Label();
            label10 = new Label();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnl_amount.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lbl_size);
            groupBox3.Controls.Add(btn_xl);
            groupBox3.Controls.Add(btn_l);
            groupBox3.Controls.Add(btn_m);
            groupBox3.Controls.Add(btn_s);
            groupBox3.Controls.Add(btn_none);
            groupBox3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            groupBox3.Location = new Point(65, 117);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(394, 91);
            groupBox3.TabIndex = 23;
            groupBox3.TabStop = false;
            groupBox3.Text = "Size";
            // 
            // lbl_size
            // 
            lbl_size.AutoSize = true;
            lbl_size.ForeColor = Color.Red;
            lbl_size.Location = new Point(118, -2);
            lbl_size.Name = "lbl_size";
            lbl_size.Size = new Size(13, 20);
            lbl_size.TabIndex = 19;
            lbl_size.Text = " ";
            // 
            // btn_xl
            // 
            btn_xl.Enabled = false;
            btn_xl.Location = new Point(263, 35);
            btn_xl.Name = "btn_xl";
            btn_xl.Size = new Size(48, 35);
            btn_xl.TabIndex = 4;
            btn_xl.Text = "XL";
            btn_xl.UseVisualStyleBackColor = true;
            btn_xl.Click += btn_xl_Click;
            // 
            // btn_l
            // 
            btn_l.Enabled = false;
            btn_l.Location = new Point(209, 35);
            btn_l.Name = "btn_l";
            btn_l.Size = new Size(48, 35);
            btn_l.TabIndex = 3;
            btn_l.Text = "L";
            btn_l.UseVisualStyleBackColor = true;
            btn_l.Click += btn_l_Click;
            // 
            // btn_m
            // 
            btn_m.Enabled = false;
            btn_m.Location = new Point(155, 35);
            btn_m.Name = "btn_m";
            btn_m.Size = new Size(48, 35);
            btn_m.TabIndex = 2;
            btn_m.Text = "M";
            btn_m.UseVisualStyleBackColor = true;
            btn_m.Click += btn_m_Click;
            // 
            // btn_s
            // 
            btn_s.Enabled = false;
            btn_s.Location = new Point(101, 35);
            btn_s.Name = "btn_s";
            btn_s.Size = new Size(48, 35);
            btn_s.TabIndex = 1;
            btn_s.Text = "S";
            btn_s.UseVisualStyleBackColor = true;
            btn_s.Click += btn_s_Click;
            // 
            // btn_none
            // 
            btn_none.BackColor = Color.DarkSeaGreen;
            btn_none.ForeColor = Color.AliceBlue;
            btn_none.Location = new Point(6, 35);
            btn_none.Name = "btn_none";
            btn_none.Size = new Size(71, 35);
            btn_none.TabIndex = 0;
            btn_none.Text = "None";
            btn_none.UseVisualStyleBackColor = false;
            btn_none.Click += btn_none_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.AllowDrop = true;
            pictureBox1.BackColor = Color.FromArgb(254, 249, 242);
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(509, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(321, 284);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            // 
            // lbl_name
            // 
            lbl_name.AutoSize = true;
            lbl_name.Font = new Font("Calibri", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lbl_name.Location = new Point(65, 27);
            lbl_name.Name = "lbl_name";
            lbl_name.Size = new Size(172, 28);
            lbl_name.TabIndex = 21;
            lbl_name.Text = "Name of product";
            // 
            // btn_save
            // 
            btn_save.Location = new Point(509, 369);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(251, 45);
            btn_save.TabIndex = 41;
            btn_save.Text = "SAVE";
            btn_save.UseVisualStyleBackColor = true;
            btn_save.Click += btn_save_Click;
            // 
            // btn_down
            // 
            btn_down.BackColor = Color.IndianRed;
            btn_down.Cursor = Cursors.Hand;
            btn_down.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btn_down.ForeColor = SystemColors.ControlLightLight;
            btn_down.Location = new Point(0, 0);
            btn_down.Name = "btn_down";
            btn_down.Size = new Size(83, 54);
            btn_down.TabIndex = 43;
            btn_down.Text = "-";
            btn_down.UseVisualStyleBackColor = false;
            btn_down.Click += btn_down_Click;
            // 
            // pnl_amount
            // 
            pnl_amount.BackColor = Color.IndianRed;
            pnl_amount.Controls.Add(lbl_amount);
            pnl_amount.Controls.Add(btn_up);
            pnl_amount.Controls.Add(btn_down);
            pnl_amount.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 163);
            pnl_amount.ForeColor = SystemColors.ControlLightLight;
            pnl_amount.Location = new Point(509, 295);
            pnl_amount.Name = "pnl_amount";
            pnl_amount.Size = new Size(321, 54);
            pnl_amount.TabIndex = 44;
            // 
            // lbl_amount
            // 
            lbl_amount.Location = new Point(120, 4);
            lbl_amount.Name = "lbl_amount";
            lbl_amount.Size = new Size(82, 47);
            lbl_amount.TabIndex = 46;
            lbl_amount.Text = "1";
            lbl_amount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_up
            // 
            btn_up.BackColor = Color.IndianRed;
            btn_up.Cursor = Cursors.Hand;
            btn_up.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btn_up.ForeColor = SystemColors.ControlLightLight;
            btn_up.Location = new Point(238, 0);
            btn_up.Name = "btn_up";
            btn_up.Size = new Size(83, 54);
            btn_up.TabIndex = 45;
            btn_up.Text = "+";
            btn_up.UseVisualStyleBackColor = false;
            btn_up.Click += btn_up_Click;
            // 
            // btn_reset
            // 
            btn_reset.Location = new Point(766, 369);
            btn_reset.Name = "btn_reset";
            btn_reset.Size = new Size(64, 45);
            btn_reset.TabIndex = 45;
            btn_reset.Text = "RESET";
            btn_reset.UseVisualStyleBackColor = true;
            btn_reset.Click += btn_reset_Click;
            // 
            // tbx_colorNote
            // 
            tbx_colorNote.ForeColor = Color.Gray;
            tbx_colorNote.Location = new Point(180, 70);
            tbx_colorNote.Name = "tbx_colorNote";
            tbx_colorNote.ReadOnly = true;
            tbx_colorNote.Size = new Size(125, 27);
            tbx_colorNote.TabIndex = 48;
            tbx_colorNote.Text = "Color Name";
            tbx_colorNote.TextAlign = HorizontalAlignment.Center;
            // 
            // pnl_colorBox
            // 
            pnl_colorBox.Location = new Point(126, 71);
            pnl_colorBox.Name = "pnl_colorBox";
            pnl_colorBox.Size = new Size(33, 27);
            pnl_colorBox.TabIndex = 46;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label5.Location = new Point(67, 73);
            label5.Name = "label5";
            label5.Size = new Size(51, 20);
            label5.TabIndex = 49;
            label5.Text = "Color:";
            // 
            // lbl_inventory
            // 
            lbl_inventory.AutoSize = true;
            lbl_inventory.Location = new Point(166, 220);
            lbl_inventory.Name = "lbl_inventory";
            lbl_inventory.Size = new Size(17, 20);
            lbl_inventory.TabIndex = 50;
            lbl_inventory.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label2.Location = new Point(71, 220);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 51;
            label2.Text = "Inventory:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label1.Location = new Point(71, 256);
            label1.Name = "label1";
            label1.Size = new Size(47, 20);
            label1.TabIndex = 53;
            label1.Text = "Price:";
            // 
            // lbl_price
            // 
            lbl_price.AutoSize = true;
            lbl_price.Location = new Point(166, 256);
            lbl_price.Name = "lbl_price";
            lbl_price.Size = new Size(17, 20);
            lbl_price.TabIndex = 52;
            lbl_price.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label4.Location = new Point(71, 326);
            label4.Name = "label4";
            label4.Size = new Size(84, 20);
            label4.TabIndex = 55;
            label4.Text = "Total price:";
            // 
            // lbl_total
            // 
            lbl_total.AutoSize = true;
            lbl_total.Location = new Point(166, 326);
            lbl_total.Name = "lbl_total";
            lbl_total.Size = new Size(17, 20);
            lbl_total.TabIndex = 54;
            lbl_total.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(71, 299);
            label7.Name = "label7";
            label7.Size = new Size(159, 20);
            label7.TabIndex = 56;
            label7.Text = "_________________________";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label8.Location = new Point(71, 281);
            label8.Name = "label8";
            label8.Size = new Size(68, 20);
            label8.TabIndex = 58;
            label8.Text = "Amount:";
            // 
            // lbl_tempAmount
            // 
            lbl_tempAmount.AutoSize = true;
            lbl_tempAmount.Location = new Point(166, 281);
            lbl_tempAmount.Name = "lbl_tempAmount";
            lbl_tempAmount.Size = new Size(17, 20);
            lbl_tempAmount.TabIndex = 57;
            lbl_tempAmount.Text = "0";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(60, 269);
            label10.Name = "label10";
            label10.Size = new Size(16, 20);
            label10.TabIndex = 59;
            label10.Text = "x";
            // 
            // TakingProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(925, 443);
            Controls.Add(label10);
            Controls.Add(label8);
            Controls.Add(lbl_tempAmount);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(lbl_total);
            Controls.Add(label1);
            Controls.Add(lbl_price);
            Controls.Add(label2);
            Controls.Add(lbl_inventory);
            Controls.Add(label5);
            Controls.Add(tbx_colorNote);
            Controls.Add(pnl_colorBox);
            Controls.Add(btn_reset);
            Controls.Add(pnl_amount);
            Controls.Add(btn_save);
            Controls.Add(groupBox3);
            Controls.Add(pictureBox1);
            Controls.Add(lbl_name);
            Name = "TakingProductForm";
            Text = " ";
            Load += TakingProductForm_Load;
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnl_amount.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox3;
        private Label lbl_size;
        private Button btn_xl;
        private Button btn_l;
        private Button btn_m;
        private Button btn_s;
        private Button btn_none;
        private PictureBox pictureBox1;
        private Label lbl_name;
        private Button btn_save;
        private Button btn_down;
        private Panel pnl_amount;
        private Button btn_up;
        private Label lbl_amount;
        private Button btn_reset;
        private TextBox tbx_colorNote;
        private Panel pnl_colorBox;
        private Label label5;
        private Label lbl_inventory;
        private Label label2;
        private Label label1;
        private Label lbl_price;
        private Label label4;
        private Label lbl_total;
        private Label label7;
        private Label label8;
        private Label lbl_tempAmount;
        private Label label10;
    }
}
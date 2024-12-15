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
            lbl_color = new Label();
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
            grbx_color = new GroupBox();
            flp_color = new FlowLayoutPanel();
            label1 = new Label();
            btn_down = new Button();
            pnl_amount = new Panel();
            lbl_amount = new Label();
            btn_up = new Button();
            btn_reset = new Button();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            grbx_color.SuspendLayout();
            pnl_amount.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_color
            // 
            lbl_color.AutoSize = true;
            lbl_color.ForeColor = Color.Red;
            lbl_color.Location = new Point(509, 199);
            lbl_color.Name = "lbl_color";
            lbl_color.Size = new Size(13, 20);
            lbl_color.TabIndex = 32;
            lbl_color.Text = " ";
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
            groupBox3.Location = new Point(65, 79);
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
            btn_xl.Location = new Point(263, 35);
            btn_xl.Name = "btn_xl";
            btn_xl.Size = new Size(48, 35);
            btn_xl.TabIndex = 4;
            btn_xl.Text = "XL";
            btn_xl.UseVisualStyleBackColor = true;
            // 
            // btn_l
            // 
            btn_l.Location = new Point(209, 35);
            btn_l.Name = "btn_l";
            btn_l.Size = new Size(48, 35);
            btn_l.TabIndex = 3;
            btn_l.Text = "L";
            btn_l.UseVisualStyleBackColor = true;
            // 
            // btn_m
            // 
            btn_m.Location = new Point(155, 35);
            btn_m.Name = "btn_m";
            btn_m.Size = new Size(48, 35);
            btn_m.TabIndex = 2;
            btn_m.Text = "M";
            btn_m.UseVisualStyleBackColor = true;
            // 
            // btn_s
            // 
            btn_s.Location = new Point(101, 35);
            btn_s.Name = "btn_s";
            btn_s.Size = new Size(48, 35);
            btn_s.TabIndex = 1;
            btn_s.Text = "S";
            btn_s.UseVisualStyleBackColor = true;
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
            // 
            // grbx_color
            // 
            grbx_color.Controls.Add(flp_color);
            grbx_color.Controls.Add(label1);
            grbx_color.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            grbx_color.Location = new Point(65, 199);
            grbx_color.Name = "grbx_color";
            grbx_color.Size = new Size(394, 91);
            grbx_color.TabIndex = 42;
            grbx_color.TabStop = false;
            grbx_color.Text = "Color";
            // 
            // flp_color
            // 
            flp_color.Location = new Point(29, 39);
            flp_color.Name = "flp_color";
            flp_color.Size = new Size(331, 30);
            flp_color.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Red;
            label1.Location = new Point(118, -2);
            label1.Name = "label1";
            label1.Size = new Size(13, 20);
            label1.TabIndex = 19;
            label1.Text = " ";
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
            lbl_amount.Text = "0";
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
            // TakingProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(925, 443);
            Controls.Add(btn_reset);
            Controls.Add(pnl_amount);
            Controls.Add(grbx_color);
            Controls.Add(btn_save);
            Controls.Add(lbl_color);
            Controls.Add(groupBox3);
            Controls.Add(pictureBox1);
            Controls.Add(lbl_name);
            Name = "TakingProductForm";
            Text = " ";
            Load += TakingProductForm_Load;
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            grbx_color.ResumeLayout(false);
            grbx_color.PerformLayout();
            pnl_amount.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_color;
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
        private GroupBox grbx_color;
        private Label label1;
        private Button btn_down;
        private Panel pnl_amount;
        private Button btn_up;
        private Label lbl_amount;
        private Button btn_reset;
        private FlowLayoutPanel flp_color;
    }
}
namespace QuanLyNoir_BTL.Views
{
    partial class AddNewProduct
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
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            lbl_name = new Label();
            tbx_name = new TextBox();
            groupBox2 = new GroupBox();
            lbl_type = new Label();
            cbbx_type = new ComboBox();
            groupBox3 = new GroupBox();
            lbl_size = new Label();
            btn_xxxl = new Button();
            btn_xxl = new Button();
            btn_xl = new Button();
            btn_l = new Button();
            btn_m = new Button();
            btn_s = new Button();
            btn_xs = new Button();
            groupBox4 = new GroupBox();
            lbl_inventory = new Label();
            label2 = new Label();
            tbx_inventory = new TextBox();
            groupBox5 = new GroupBox();
            lbl_price = new Label();
            label3 = new Label();
            tbx_price = new TextBox();
            tbx_material = new TextBox();
            label4 = new Label();
            groupBox6 = new GroupBox();
            lbl_material = new Label();
            label5 = new Label();
            btn_choosecolor = new Button();
            btn_addtostore = new Button();
            label6 = new Label();
            linkLabel1 = new LinkLabel();
            pnl_colorBox = new Panel();
            lbl_colorCode = new Label();
            tbx_colorNote = new TextBox();
            groupBox7 = new GroupBox();
            lbl_height = new Label();
            lbl_width = new Label();
            label8 = new Label();
            label7 = new Label();
            tbx_height = new TextBox();
            tbx_width = new TextBox();
            btn_reset = new Button();
            btn_update = new Button();
            lbl_color = new Label();
            bgWorker = new System.ComponentModel.BackgroundWorker();
            progressBar1 = new ProgressBar();
            btn_addcolor = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox7.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(91, 28);
            label1.Name = "label1";
            label1.Size = new Size(180, 28);
            label1.TabIndex = 0;
            label1.Text = "Add new product ";
            // 
            // pictureBox1
            // 
            pictureBox1.AllowDrop = true;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(91, 75);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(321, 284);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.DragDrop += pictureBox1_DragDrop;
            pictureBox1.DragEnter += pictureBox1_DragEnter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lbl_name);
            groupBox1.Controls.Add(tbx_name);
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(91, 379);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(321, 91);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Name of product";
            // 
            // lbl_name
            // 
            lbl_name.AutoSize = true;
            lbl_name.ForeColor = Color.Red;
            lbl_name.Location = new Point(130, 0);
            lbl_name.Name = "lbl_name";
            lbl_name.Size = new Size(13, 20);
            lbl_name.TabIndex = 1;
            lbl_name.Text = " ";
            // 
            // tbx_name
            // 
            tbx_name.Location = new Point(14, 39);
            tbx_name.Name = "tbx_name";
            tbx_name.Size = new Size(279, 27);
            tbx_name.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lbl_type);
            groupBox2.Controls.Add(cbbx_type);
            groupBox2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(91, 493);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(321, 91);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Type of product";
            // 
            // lbl_type
            // 
            lbl_type.AutoSize = true;
            lbl_type.ForeColor = Color.Red;
            lbl_type.Location = new Point(122, 0);
            lbl_type.Name = "lbl_type";
            lbl_type.Size = new Size(13, 20);
            lbl_type.TabIndex = 2;
            lbl_type.Text = " ";
            // 
            // cbbx_type
            // 
            cbbx_type.FormattingEnabled = true;
            cbbx_type.Items.AddRange(new object[] { "Type A", "Type B", "Type C" });
            cbbx_type.Location = new Point(14, 42);
            cbbx_type.Name = "cbbx_type";
            cbbx_type.Size = new Size(279, 28);
            cbbx_type.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lbl_size);
            groupBox3.Controls.Add(btn_xxxl);
            groupBox3.Controls.Add(btn_xxl);
            groupBox3.Controls.Add(btn_xl);
            groupBox3.Controls.Add(btn_l);
            groupBox3.Controls.Add(btn_m);
            groupBox3.Controls.Add(btn_s);
            groupBox3.Controls.Add(btn_xs);
            groupBox3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            groupBox3.Location = new Point(481, 75);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(394, 91);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Size of product";
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
            // btn_xxxl
            // 
            btn_xxxl.Location = new Point(330, 26);
            btn_xxxl.Name = "btn_xxxl";
            btn_xxxl.Size = new Size(51, 35);
            btn_xxxl.TabIndex = 6;
            btn_xxxl.Text = "XXXL";
            btn_xxxl.UseVisualStyleBackColor = true;
            btn_xxxl.Click += btn_3xl_Click;
            // 
            // btn_xxl
            // 
            btn_xxl.Location = new Point(276, 26);
            btn_xxl.Name = "btn_xxl";
            btn_xxl.Size = new Size(48, 35);
            btn_xxl.TabIndex = 5;
            btn_xxl.Text = "XXL";
            btn_xxl.UseVisualStyleBackColor = true;
            btn_xxl.Click += btn_xxl_Click;
            // 
            // btn_xl
            // 
            btn_xl.Location = new Point(222, 26);
            btn_xl.Name = "btn_xl";
            btn_xl.Size = new Size(48, 35);
            btn_xl.TabIndex = 4;
            btn_xl.Text = "XL";
            btn_xl.UseVisualStyleBackColor = true;
            btn_xl.Click += btn_xl_Click;
            // 
            // btn_l
            // 
            btn_l.Location = new Point(168, 26);
            btn_l.Name = "btn_l";
            btn_l.Size = new Size(48, 35);
            btn_l.TabIndex = 3;
            btn_l.Text = "L";
            btn_l.UseVisualStyleBackColor = true;
            btn_l.Click += btn_l_Click;
            // 
            // btn_m
            // 
            btn_m.Location = new Point(114, 26);
            btn_m.Name = "btn_m";
            btn_m.Size = new Size(48, 35);
            btn_m.TabIndex = 2;
            btn_m.Text = "M";
            btn_m.UseVisualStyleBackColor = true;
            btn_m.Click += btn_m_Click;
            // 
            // btn_s
            // 
            btn_s.Location = new Point(60, 26);
            btn_s.Name = "btn_s";
            btn_s.Size = new Size(48, 35);
            btn_s.TabIndex = 1;
            btn_s.Text = "S";
            btn_s.UseVisualStyleBackColor = true;
            btn_s.Click += btn_s_Click;
            // 
            // btn_xs
            // 
            btn_xs.Location = new Point(6, 26);
            btn_xs.Name = "btn_xs";
            btn_xs.Size = new Size(48, 35);
            btn_xs.TabIndex = 0;
            btn_xs.Text = "XS";
            btn_xs.UseVisualStyleBackColor = true;
            btn_xs.Click += btn_xs_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(lbl_inventory);
            groupBox4.Controls.Add(label2);
            groupBox4.Controls.Add(tbx_inventory);
            groupBox4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            groupBox4.Location = new Point(481, 274);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(394, 91);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "Inventory";
            // 
            // lbl_inventory
            // 
            lbl_inventory.AutoSize = true;
            lbl_inventory.ForeColor = Color.Red;
            lbl_inventory.Location = new Point(82, 0);
            lbl_inventory.Name = "lbl_inventory";
            lbl_inventory.Size = new Size(13, 20);
            lbl_inventory.TabIndex = 21;
            lbl_inventory.Text = " ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(311, 42);
            label2.Name = "label2";
            label2.Size = new Size(45, 20);
            label2.TabIndex = 1;
            label2.Text = "items";
            // 
            // tbx_inventory
            // 
            tbx_inventory.Location = new Point(14, 39);
            tbx_inventory.Name = "tbx_inventory";
            tbx_inventory.Size = new Size(279, 27);
            tbx_inventory.TabIndex = 0;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(lbl_price);
            groupBox5.Controls.Add(label3);
            groupBox5.Controls.Add(tbx_price);
            groupBox5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            groupBox5.Location = new Point(481, 379);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(394, 91);
            groupBox5.TabIndex = 6;
            groupBox5.TabStop = false;
            groupBox5.Text = "Price";
            // 
            // lbl_price
            // 
            lbl_price.AutoSize = true;
            lbl_price.ForeColor = Color.Red;
            lbl_price.Location = new Point(49, -1);
            lbl_price.Name = "lbl_price";
            lbl_price.Size = new Size(13, 20);
            lbl_price.TabIndex = 2;
            lbl_price.Text = " ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(311, 42);
            label3.Name = "label3";
            label3.Size = new Size(59, 20);
            label3.TabIndex = 1;
            label3.Text = "$/items";
            // 
            // tbx_price
            // 
            tbx_price.Location = new Point(14, 39);
            tbx_price.Name = "tbx_price";
            tbx_price.Size = new Size(279, 27);
            tbx_price.TabIndex = 0;
            // 
            // tbx_material
            // 
            tbx_material.Location = new Point(14, 39);
            tbx_material.Name = "tbx_material";
            tbx_material.Size = new Size(279, 27);
            tbx_material.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(311, 42);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 1;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(lbl_material);
            groupBox6.Controls.Add(label4);
            groupBox6.Controls.Add(tbx_material);
            groupBox6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            groupBox6.Location = new Point(481, 493);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(394, 91);
            groupBox6.TabIndex = 7;
            groupBox6.TabStop = false;
            groupBox6.Text = "Material of product";
            // 
            // lbl_material
            // 
            lbl_material.AutoSize = true;
            lbl_material.ForeColor = Color.Red;
            lbl_material.Location = new Point(147, 0);
            lbl_material.Name = "lbl_material";
            lbl_material.Size = new Size(13, 20);
            lbl_material.TabIndex = 21;
            lbl_material.Text = " ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label5.Location = new Point(484, 204);
            label5.Name = "label5";
            label5.Size = new Size(51, 20);
            label5.TabIndex = 8;
            label5.Text = "Color:";
            // 
            // btn_choosecolor
            // 
            btn_choosecolor.Location = new Point(557, 200);
            btn_choosecolor.Name = "btn_choosecolor";
            btn_choosecolor.Size = new Size(129, 29);
            btn_choosecolor.TabIndex = 9;
            btn_choosecolor.Text = "choose color";
            btn_choosecolor.UseVisualStyleBackColor = true;
            btn_choosecolor.Click += btn_choosecolor_Click;
            // 
            // btn_addtostore
            // 
            btn_addtostore.Location = new Point(481, 604);
            btn_addtostore.Name = "btn_addtostore";
            btn_addtostore.Size = new Size(394, 45);
            btn_addtostore.TabIndex = 10;
            btn_addtostore.Text = "Add to store";
            btn_addtostore.UseVisualStyleBackColor = true;
            btn_addtostore.Click += btn_addtostore_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Sitka Display", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 163);
            label6.Location = new Point(123, 204);
            label6.Name = "label6";
            label6.Size = new Size(192, 26);
            label6.TabIndex = 11;
            label6.Text = "Drop your image here, or ";
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.SeaGreen;
            linkLabel1.AutoSize = true;
            linkLabel1.BackColor = Color.Transparent;
            linkLabel1.DisabledLinkColor = Color.SeaGreen;
            linkLabel1.Font = new Font("Sitka Heading", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 163);
            linkLabel1.LinkColor = Color.SeaGreen;
            linkLabel1.Location = new Point(306, 204);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(69, 26);
            linkLabel1.TabIndex = 12;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "browse";
            linkLabel1.VisitedLinkColor = Color.SeaGreen;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // pnl_colorBox
            // 
            pnl_colorBox.Location = new Point(703, 202);
            pnl_colorBox.Name = "pnl_colorBox";
            pnl_colorBox.Size = new Size(33, 27);
            pnl_colorBox.TabIndex = 13;
            // 
            // lbl_colorCode
            // 
            lbl_colorCode.AutoSize = true;
            lbl_colorCode.Location = new Point(754, 205);
            lbl_colorCode.Name = "lbl_colorCode";
            lbl_colorCode.Size = new Size(13, 20);
            lbl_colorCode.TabIndex = 14;
            lbl_colorCode.Text = " ";
            // 
            // tbx_colorNote
            // 
            tbx_colorNote.ForeColor = Color.Gray;
            tbx_colorNote.Location = new Point(757, 201);
            tbx_colorNote.Name = "tbx_colorNote";
            tbx_colorNote.Size = new Size(125, 27);
            tbx_colorNote.TabIndex = 15;
            tbx_colorNote.Text = "Color Name";
            tbx_colorNote.TextAlign = HorizontalAlignment.Center;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(lbl_height);
            groupBox7.Controls.Add(lbl_width);
            groupBox7.Controls.Add(label8);
            groupBox7.Controls.Add(label7);
            groupBox7.Controls.Add(tbx_height);
            groupBox7.Controls.Add(tbx_width);
            groupBox7.Location = new Point(92, 601);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(320, 94);
            groupBox7.TabIndex = 16;
            groupBox7.TabStop = false;
            groupBox7.Text = "Size";
            // 
            // lbl_height
            // 
            lbl_height.AutoSize = true;
            lbl_height.ForeColor = Color.Red;
            lbl_height.Location = new Point(112, 56);
            lbl_height.Name = "lbl_height";
            lbl_height.Size = new Size(13, 20);
            lbl_height.TabIndex = 21;
            lbl_height.Text = " ";
            // 
            // lbl_width
            // 
            lbl_width.AutoSize = true;
            lbl_width.ForeColor = Color.Red;
            lbl_width.Location = new Point(106, 23);
            lbl_width.Name = "lbl_width";
            lbl_width.Size = new Size(13, 20);
            lbl_width.TabIndex = 3;
            lbl_width.Text = " ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(59, 57);
            label8.Name = "label8";
            label8.Size = new Size(54, 20);
            label8.TabIndex = 3;
            label8.Text = "Height";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(59, 24);
            label7.Name = "label7";
            label7.Size = new Size(49, 20);
            label7.TabIndex = 2;
            label7.Text = "Width";
            // 
            // tbx_height
            // 
            tbx_height.Location = new Point(145, 54);
            tbx_height.Name = "tbx_height";
            tbx_height.Size = new Size(147, 27);
            tbx_height.TabIndex = 1;
            // 
            // tbx_width
            // 
            tbx_width.Location = new Point(145, 21);
            tbx_width.Name = "tbx_width";
            tbx_width.Size = new Size(147, 27);
            tbx_width.TabIndex = 0;
            // 
            // btn_reset
            // 
            btn_reset.BackColor = SystemColors.Control;
            btn_reset.Location = new Point(781, 659);
            btn_reset.Name = "btn_reset";
            btn_reset.Size = new Size(94, 37);
            btn_reset.TabIndex = 17;
            btn_reset.Text = "Reset";
            btn_reset.UseVisualStyleBackColor = false;
            btn_reset.Click += btn_reset_Click;
            // 
            // btn_update
            // 
            btn_update.Location = new Point(481, 604);
            btn_update.Name = "btn_update";
            btn_update.Size = new Size(394, 45);
            btn_update.TabIndex = 18;
            btn_update.Text = "Update";
            btn_update.UseVisualStyleBackColor = true;
            btn_update.Visible = false;
            btn_update.Click += btn_update_Click;
            // 
            // lbl_color
            // 
            lbl_color.AutoSize = true;
            lbl_color.ForeColor = Color.Red;
            lbl_color.Location = new Point(535, 200);
            lbl_color.Name = "lbl_color";
            lbl_color.Size = new Size(13, 20);
            lbl_color.TabIndex = 20;
            lbl_color.Text = " ";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(-3, -6);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(994, 15);
            progressBar1.TabIndex = 21;
            // 
            // btn_addcolor
            // 
            btn_addcolor.Location = new Point(481, 659);
            btn_addcolor.Name = "btn_addcolor";
            btn_addcolor.Size = new Size(394, 45);
            btn_addcolor.TabIndex = 22;
            btn_addcolor.Text = "Add Color";
            btn_addcolor.UseVisualStyleBackColor = true;
            btn_addcolor.Visible = false;
            btn_addcolor.Click += btn_addcolor_Click;
            // 
            // AddNewProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(987, 715);
            Controls.Add(btn_addcolor);
            Controls.Add(progressBar1);
            Controls.Add(lbl_color);
            Controls.Add(btn_update);
            Controls.Add(btn_reset);
            Controls.Add(groupBox7);
            Controls.Add(tbx_colorNote);
            Controls.Add(lbl_colorCode);
            Controls.Add(pnl_colorBox);
            Controls.Add(linkLabel1);
            Controls.Add(label6);
            Controls.Add(btn_addtostore);
            Controls.Add(btn_choosecolor);
            Controls.Add(label5);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Name = "AddNewProduct";
            Text = "AddNewProduct";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private TextBox tbx_name;
        private GroupBox groupBox2;
        private ComboBox cbbx_type;
        private GroupBox groupBox3;
        private Button btn_xxxl;
        private Button btn_xxl;
        private Button btn_xl;
        private Button btn_l;
        private Button btn_m;
        private Button btn_s;
        private Button btn_xs;
        private GroupBox groupBox4;
        private Label label2;
        private TextBox tbx_inventory;
        private GroupBox groupBox5;
        private Label label3;
        private TextBox tbx_price;
        private TextBox tbx_material;
        private Label label4;
        private GroupBox groupBox6;
        private Label label5;
        private Button btn_choosecolor;
        private Button btn_addtostore;
        private Label label6;
        private LinkLabel linkLabel1;
        private Panel pnl_colorBox;
        private Label lbl_colorCode;
        private TextBox tbx_colorNote;
        private GroupBox groupBox7;
        private Label label8;
        private Label label7;
        private TextBox tbx_height;
        private TextBox tbx_width;
        private Button btn_reset;
        private Button btn_update;
        private Label lbl_name;
        private Label lbl_type;
        private Label lbl_size;
        private Label lbl_inventory;
        private Label lbl_price;
        private Label lbl_material;
        private Label lbl_width;
        private Label lbl_color;
        private Label lbl_height;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private ProgressBar progressBar1;
        private Button btn_addcolor;
    }
}
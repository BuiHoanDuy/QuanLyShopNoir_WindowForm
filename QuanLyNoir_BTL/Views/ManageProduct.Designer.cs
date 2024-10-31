namespace QuanLyNoir_BTL
{
    partial class ManageProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageProduct));
            button1 = new Button();
            panel1 = new Panel();
            button4 = new Button();
            button3 = new Button();
            btn_manageproduct = new Button();
            label6 = new Label();
            label1 = new Label();
            btn_newcollection = new Button();
            btn_bag = new Button();
            btn_jacket = new Button();
            btn_voucher = new Button();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            groupBox1 = new GroupBox();
            pictureBox2 = new PictureBox();
            tbx_search = new TextBox();
            groupBox2 = new GroupBox();
            tbx_inventory = new TextBox();
            label3 = new Label();
            groupBox3 = new GroupBox();
            lbl_priceFilter = new Label();
            label10 = new Label();
            label9 = new Label();
            label11 = new Label();
            label8 = new Label();
            scrb_price = new HScrollBar();
            pnl_product = new Panel();
            btn_previous = new Button();
            btn_next = new Button();
            lbl_page = new Label();
            btn_reset = new Button();
            lbl_name = new Label();
            llbl_addnewproduct = new LinkLabel();
            btn_addnewproduct = new Button();
            loadWorker = new System.ComponentModel.BackgroundWorker();
            deleteWorker = new System.ComponentModel.BackgroundWorker();
            createWorker = new System.ComponentModel.BackgroundWorker();
            progressBar1 = new ProgressBar();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(1246, 12);
            button1.Name = "button1";
            button1.Size = new Size(106, 29);
            button1.TabIndex = 0;
            button1.Text = "Sign out";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(btn_manageproduct);
            panel1.Controls.Add(label6);
            panel1.Location = new Point(-2, 47);
            panel1.Name = "panel1";
            panel1.Size = new Size(1665, 64);
            panel1.TabIndex = 1;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button4.Location = new Point(1247, 10);
            button4.Name = "button4";
            button4.Size = new Size(204, 44);
            button4.TabIndex = 6;
            button4.Text = "Analyse Revenue";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button3.Location = new Point(998, 10);
            button3.Name = "button3";
            button3.Size = new Size(204, 44);
            button3.TabIndex = 5;
            button3.Text = "Manage Order";
            button3.UseVisualStyleBackColor = true;
            // 
            // btn_manageproduct
            // 
            btn_manageproduct.BackColor = Color.FromArgb(0, 64, 0);
            btn_manageproduct.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_manageproduct.ForeColor = Color.FromArgb(255, 128, 255);
            btn_manageproduct.Location = new Point(754, 10);
            btn_manageproduct.Name = "btn_manageproduct";
            btn_manageproduct.Size = new Size(204, 44);
            btn_manageproduct.TabIndex = 4;
            btn_manageproduct.Text = "Manage Product";
            btn_manageproduct.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("STLiti", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 134);
            label6.Location = new Point(50, 19);
            label6.Name = "label6";
            label6.Size = new Size(75, 35);
            label6.TabIndex = 3;
            label6.Text = "Noir";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(48, 146);
            label1.Name = "label1";
            label1.Size = new Size(227, 31);
            label1.TabIndex = 2;
            label1.Text = "MANAGE PRODUCT";
            // 
            // btn_newcollection
            // 
            btn_newcollection.BackColor = Color.DarkSlateGray;
            btn_newcollection.FlatStyle = FlatStyle.Flat;
            btn_newcollection.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_newcollection.ForeColor = Color.Pink;
            btn_newcollection.Location = new Point(48, 194);
            btn_newcollection.Name = "btn_newcollection";
            btn_newcollection.Size = new Size(147, 29);
            btn_newcollection.TabIndex = 3;
            btn_newcollection.Text = "New Collection";
            btn_newcollection.UseVisualStyleBackColor = false;
            btn_newcollection.Click += btn_newcollection_Click;
            // 
            // btn_bag
            // 
            btn_bag.BackColor = SystemColors.Control;
            btn_bag.FlatStyle = FlatStyle.Flat;
            btn_bag.ForeColor = Color.Black;
            btn_bag.Location = new Point(202, 194);
            btn_bag.Name = "btn_bag";
            btn_bag.Size = new Size(74, 29);
            btn_bag.TabIndex = 4;
            btn_bag.Text = "Bag";
            btn_bag.UseVisualStyleBackColor = false;
            btn_bag.Click += btn_bag_Click;
            // 
            // btn_jacket
            // 
            btn_jacket.FlatStyle = FlatStyle.Flat;
            btn_jacket.Location = new Point(287, 194);
            btn_jacket.Name = "btn_jacket";
            btn_jacket.Size = new Size(81, 29);
            btn_jacket.TabIndex = 5;
            btn_jacket.Text = "Jacket";
            btn_jacket.UseVisualStyleBackColor = true;
            btn_jacket.Click += btn_jacket_Click;
            // 
            // btn_voucher
            // 
            btn_voucher.FlatStyle = FlatStyle.Flat;
            btn_voucher.Location = new Point(375, 194);
            btn_voucher.Name = "btn_voucher";
            btn_voucher.Size = new Size(101, 29);
            btn_voucher.TabIndex = 6;
            btn_voucher.Text = "Voucher";
            btn_voucher.UseVisualStyleBackColor = true;
            btn_voucher.Click += btn_voucher_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label2.Location = new Point(52, 9);
            label2.Name = "label2";
            label2.Size = new Size(44, 20);
            label2.TabIndex = 7;
            label2.Text = "Filter";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.filter;
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(3, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(42, 37);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(48, 241);
            panel2.Name = "panel2";
            panel2.Size = new Size(108, 38);
            panel2.TabIndex = 9;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pictureBox2);
            groupBox1.Controls.Add(tbx_search);
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            groupBox1.Location = new Point(46, 303);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(318, 84);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Search";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(264, 34);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(35, 27);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // tbx_search
            // 
            tbx_search.Location = new Point(12, 34);
            tbx_search.Name = "tbx_search";
            tbx_search.Size = new Size(245, 27);
            tbx_search.TabIndex = 0;
            tbx_search.TextChanged += tbx_search_TextChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tbx_inventory);
            groupBox2.Controls.Add(label3);
            groupBox2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            groupBox2.Location = new Point(46, 409);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(318, 74);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Inventory";
            // 
            // tbx_inventory
            // 
            tbx_inventory.Location = new Point(104, 29);
            tbx_inventory.Name = "tbx_inventory";
            tbx_inventory.Size = new Size(173, 27);
            tbx_inventory.TabIndex = 2;
            tbx_inventory.TextChanged += tbx_inventory_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 32);
            label3.Name = "label3";
            label3.Size = new Size(68, 20);
            label3.TabIndex = 0;
            label3.Text = "Amount:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lbl_priceFilter);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(scrb_price);
            groupBox3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            groupBox3.Location = new Point(46, 502);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(318, 125);
            groupBox3.TabIndex = 12;
            groupBox3.TabStop = false;
            groupBox3.Text = "Price";
            // 
            // lbl_priceFilter
            // 
            lbl_priceFilter.AutoSize = true;
            lbl_priceFilter.Location = new Point(122, 41);
            lbl_priceFilter.Name = "lbl_priceFilter";
            lbl_priceFilter.Size = new Size(45, 20);
            lbl_priceFilter.TabIndex = 15;
            lbl_priceFilter.Text = "0.00$";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(225, 41);
            label10.Name = "label10";
            label10.Size = new Size(17, 20);
            label10.TabIndex = 14;
            label10.Text = "$";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(2, 41);
            label9.Name = "label9";
            label9.Size = new Size(17, 20);
            label9.TabIndex = 2;
            label9.Text = "$";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(241, 41);
            label11.Name = "label11";
            label11.Size = new Size(59, 20);
            label11.TabIndex = 13;
            label11.Text = "1000.00";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(18, 41);
            label8.Name = "label8";
            label8.Size = new Size(37, 20);
            label8.TabIndex = 1;
            label8.Text = "0.00";
            // 
            // scrb_price
            // 
            scrb_price.Location = new Point(17, 75);
            scrb_price.Maximum = 1009;
            scrb_price.Name = "scrb_price";
            scrb_price.Size = new Size(282, 26);
            scrb_price.SmallChange = 10;
            scrb_price.TabIndex = 0;
            scrb_price.Value = 1000;
            scrb_price.Scroll += scrb_price_Scroll;
            // 
            // pnl_product
            // 
            pnl_product.Location = new Point(493, 146);
            pnl_product.Name = "pnl_product";
            pnl_product.Size = new Size(1033, 675);
            pnl_product.TabIndex = 13;
            // 
            // btn_previous
            // 
            btn_previous.Location = new Point(900, 844);
            btn_previous.Name = "btn_previous";
            btn_previous.Size = new Size(106, 29);
            btn_previous.TabIndex = 14;
            btn_previous.Text = "Previous";
            btn_previous.UseVisualStyleBackColor = true;
            btn_previous.Click += btn_previous_Click;
            // 
            // btn_next
            // 
            btn_next.Location = new Point(1101, 844);
            btn_next.Name = "btn_next";
            btn_next.Size = new Size(106, 29);
            btn_next.TabIndex = 15;
            btn_next.Text = "Next";
            btn_next.UseVisualStyleBackColor = true;
            btn_next.Click += btn_next_Click;
            // 
            // lbl_page
            // 
            lbl_page.AutoSize = true;
            lbl_page.Location = new Point(1012, 848);
            lbl_page.Name = "lbl_page";
            lbl_page.Size = new Size(21, 20);
            lbl_page.TabIndex = 16;
            lbl_page.Text = "...";
            // 
            // btn_reset
            // 
            btn_reset.BackColor = Color.DarkSlateGray;
            btn_reset.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_reset.ForeColor = Color.AliceBlue;
            btn_reset.Location = new Point(46, 657);
            btn_reset.Name = "btn_reset";
            btn_reset.Size = new Size(318, 48);
            btn_reset.TabIndex = 17;
            btn_reset.Text = "RESET";
            btn_reset.UseVisualStyleBackColor = false;
            btn_reset.Click += btn_filternow_Click;
            // 
            // lbl_name
            // 
            lbl_name.AutoSize = true;
            lbl_name.Location = new Point(1358, 16);
            lbl_name.Name = "lbl_name";
            lbl_name.Size = new Size(47, 20);
            lbl_name.TabIndex = 18;
            lbl_name.Text = "name";
            // 
            // llbl_addnewproduct
            // 
            llbl_addnewproduct.AutoSize = true;
            llbl_addnewproduct.DisabledLinkColor = Color.Black;
            llbl_addnewproduct.LinkColor = Color.Black;
            llbl_addnewproduct.Location = new Point(551, 127);
            llbl_addnewproduct.Name = "llbl_addnewproduct";
            llbl_addnewproduct.Size = new Size(127, 20);
            llbl_addnewproduct.TabIndex = 0;
            llbl_addnewproduct.TabStop = true;
            llbl_addnewproduct.Text = "Add new product";
            llbl_addnewproduct.VisitedLinkColor = Color.Black;
            llbl_addnewproduct.LinkClicked += llbl_addnewproduct_LinkClicked;
            // 
            // btn_addnewproduct
            // 
            btn_addnewproduct.Image = (Image)resources.GetObject("btn_addnewproduct.Image");
            btn_addnewproduct.Location = new Point(511, 123);
            btn_addnewproduct.Name = "btn_addnewproduct";
            btn_addnewproduct.Size = new Size(34, 28);
            btn_addnewproduct.TabIndex = 19;
            btn_addnewproduct.UseVisualStyleBackColor = true;
            // 
            // loadWorker
            // 

            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(-19, -4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(1559, 17);
            progressBar1.TabIndex = 20;
            // 
            // ManageProduct
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1524, 895);
            Controls.Add(progressBar1);
            Controls.Add(btn_addnewproduct);
            Controls.Add(llbl_addnewproduct);
            Controls.Add(lbl_name);
            Controls.Add(btn_reset);
            Controls.Add(lbl_page);
            Controls.Add(btn_next);
            Controls.Add(btn_previous);
            Controls.Add(pnl_product);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel2);
            Controls.Add(btn_voucher);
            Controls.Add(btn_jacket);
            Controls.Add(btn_bag);
            Controls.Add(btn_newcollection);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(button1);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            Name = "ManageProduct";
            Text = "ManageProduct";
            TransparencyKey = Color.FromArgb(255, 192, 192);
            FormClosing += ManageProduct_FormClosing;
            Load += ManageProduct_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Panel panel1;
        private Button button4;
        private Button button3;
        private Button btn_manageproduct;
        private Label label6;
        private Label label1;
        private Button btn_newcollection;
        private Button btn_bag;
        private Button btn_jacket;
        private Button btn_voucher;
        private Label label2;
        private PictureBox pictureBox1;
        private Panel panel2;
        private GroupBox groupBox1;
        private TextBox tbx_search;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private PictureBox pictureBox2;
        private TextBox tbx_inventory;
        private Label label3;
        private Label label10;
        private Label label9;
        private Label label11;
        private Label label8;
        private HScrollBar scrb_price;
        private Label lbl_priceFilter;
        private Panel pnl_product;
        private Button btn_previous;
        private Button btn_next;
        private Label lbl_page;
        private Button btn_reset;
        private Label lbl_name;
        private LinkLabel llbl_addnewproduct;
        private Button btn_addnewproduct;
        private System.ComponentModel.BackgroundWorker loadWorker;
        private System.ComponentModel.BackgroundWorker deleteWorker;
        private System.ComponentModel.BackgroundWorker createWorker;
        private ProgressBar progressBar1;
    }
}
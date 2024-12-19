namespace QuanLyNoir_BTL.Views
{
    partial class ManageProductControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageProductControl));
            loadWorker = new System.ComponentModel.BackgroundWorker();
            progressBar1 = new ProgressBar();
            panel1 = new Panel();
            btn_reset = new Button();
            groupBox3 = new GroupBox();
            lbl_priceFilter = new Label();
            label10 = new Label();
            label9 = new Label();
            label11 = new Label();
            label8 = new Label();
            scrb_price = new HScrollBar();
            groupBox2 = new GroupBox();
            tbx_inventory = new TextBox();
            label3 = new Label();
            groupBox1 = new GroupBox();
            pictureBox2 = new PictureBox();
            tbx_search = new TextBox();
            btn_all = new Button();
            btn_jacket = new Button();
            btn_bag = new Button();
            btn_newcollection = new Button();
            label1 = new Label();
            pnl_control = new Panel();
            btn_addnewproduct = new Button();
            llbl_addnewproduct = new LinkLabel();
            lbl_page = new Label();
            btn_next = new Button();
            btn_previous = new Button();
            pnl_product = new Panel();
            panel1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            pnl_control.SuspendLayout();
            SuspendLayout();
            // 
            // loadWorker
            // 
            loadWorker.WorkerReportsProgress = true;
            loadWorker.WorkerSupportsCancellation = true;
            loadWorker.DoWork += loadWorker_DoWork;
            loadWorker.ProgressChanged += loadWorker_ProgressChanged;
            loadWorker.RunWorkerCompleted += loadWorker_RunWorkerCompleted;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(-8, -8);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(1528, 10);
            progressBar1.TabIndex = 36;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(btn_reset);
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(btn_all);
            panel1.Controls.Add(btn_jacket);
            panel1.Controls.Add(btn_bag);
            panel1.Controls.Add(btn_newcollection);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(24, 42);
            panel1.Name = "panel1";
            panel1.Size = new Size(429, 673);
            panel1.TabIndex = 37;
            // 
            // btn_reset
            // 
            btn_reset.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_reset.BackColor = Color.DarkSlateGray;
            btn_reset.Cursor = Cursors.Hand;
            btn_reset.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_reset.ForeColor = Color.AliceBlue;
            btn_reset.Location = new Point(8, 471);
            btn_reset.Name = "btn_reset";
            btn_reset.Size = new Size(325, 46);
            btn_reset.TabIndex = 44;
            btn_reset.Text = "RESET";
            btn_reset.UseVisualStyleBackColor = false;
            btn_reset.Click += btn_reset_Click;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(lbl_priceFilter);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(scrb_price);
            groupBox3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            groupBox3.Location = new Point(8, 318);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(325, 132);
            groupBox3.TabIndex = 43;
            groupBox3.TabStop = false;
            groupBox3.Text = "Price limit";
            // 
            // lbl_priceFilter
            // 
            lbl_priceFilter.AutoSize = true;
            lbl_priceFilter.Location = new Point(122, 41);
            lbl_priceFilter.Name = "lbl_priceFilter";
            lbl_priceFilter.Size = new Size(72, 32);
            lbl_priceFilter.TabIndex = 15;
            lbl_priceFilter.Text = "0.00$";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(225, 41);
            label10.Name = "label10";
            label10.Size = new Size(27, 32);
            label10.TabIndex = 14;
            label10.Text = "$";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(2, 41);
            label9.Name = "label9";
            label9.Size = new Size(27, 32);
            label9.TabIndex = 2;
            label9.Text = "$";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(241, 41);
            label11.Name = "label11";
            label11.Size = new Size(95, 32);
            label11.TabIndex = 13;
            label11.Text = "1000.00";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(18, 41);
            label8.Name = "label8";
            label8.Size = new Size(59, 32);
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
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(tbx_inventory);
            groupBox2.Controls.Add(label3);
            groupBox2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            groupBox2.Location = new Point(8, 219);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(325, 78);
            groupBox2.TabIndex = 42;
            groupBox2.TabStop = false;
            groupBox2.Text = "Inventory limit";
            // 
            // tbx_inventory
            // 
            tbx_inventory.Cursor = Cursors.IBeam;
            tbx_inventory.Location = new Point(104, 29);
            tbx_inventory.Name = "tbx_inventory";
            tbx_inventory.Size = new Size(173, 39);
            tbx_inventory.TabIndex = 2;
            tbx_inventory.TextChanged += tbx_inventory_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 32);
            label3.Name = "label3";
            label3.Size = new Size(108, 32);
            label3.TabIndex = 0;
            label3.Text = "Amount:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pictureBox2);
            groupBox1.Controls.Add(tbx_search);
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            groupBox1.Location = new Point(8, 99);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(325, 102);
            groupBox1.TabIndex = 41;
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
            tbx_search.Cursor = Cursors.IBeam;
            tbx_search.Location = new Point(12, 34);
            tbx_search.Name = "tbx_search";
            tbx_search.Size = new Size(245, 39);
            tbx_search.TabIndex = 0;
            tbx_search.TextChanged += tbx_search_TextChanged;
            // 
            // btn_all
            // 
            btn_all.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_all.BackColor = Color.DarkSlateGray;
            btn_all.Cursor = Cursors.Hand;
            btn_all.FlatStyle = FlatStyle.Flat;
            btn_all.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold);
            btn_all.ForeColor = Color.Pink;
            btn_all.Location = new Point(8, 48);
            btn_all.Name = "btn_all";
            btn_all.Size = new Size(82, 33);
            btn_all.TabIndex = 39;
            btn_all.Text = "All";
            btn_all.UseVisualStyleBackColor = false;
            btn_all.Click += btn_all_Click;
            // 
            // btn_jacket
            // 
            btn_jacket.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_jacket.BackColor = SystemColors.ControlLightLight;
            btn_jacket.Cursor = Cursors.Hand;
            btn_jacket.FlatStyle = FlatStyle.Flat;
            btn_jacket.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold);
            btn_jacket.Location = new Point(331, 48);
            btn_jacket.Name = "btn_jacket";
            btn_jacket.Size = new Size(75, 33);
            btn_jacket.TabIndex = 38;
            btn_jacket.Text = "Jacket";
            btn_jacket.UseVisualStyleBackColor = false;
            btn_jacket.Click += btn_jacket_Click;
            // 
            // btn_bag
            // 
            btn_bag.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_bag.BackColor = SystemColors.ControlLightLight;
            btn_bag.Cursor = Cursors.Hand;
            btn_bag.FlatStyle = FlatStyle.Flat;
            btn_bag.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold);
            btn_bag.ForeColor = Color.Black;
            btn_bag.Location = new Point(252, 48);
            btn_bag.Name = "btn_bag";
            btn_bag.Size = new Size(63, 33);
            btn_bag.TabIndex = 37;
            btn_bag.Text = "Bag";
            btn_bag.UseVisualStyleBackColor = false;
            btn_bag.Click += btn_bag_Click;
            // 
            // btn_newcollection
            // 
            btn_newcollection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_newcollection.BackColor = SystemColors.ControlLightLight;
            btn_newcollection.Cursor = Cursors.Hand;
            btn_newcollection.FlatStyle = FlatStyle.Flat;
            btn_newcollection.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold);
            btn_newcollection.ForeColor = SystemColors.ActiveCaptionText;
            btn_newcollection.Location = new Point(100, 48);
            btn_newcollection.Name = "btn_newcollection";
            btn_newcollection.Size = new Size(139, 33);
            btn_newcollection.TabIndex = 36;
            btn_newcollection.Text = "New Collection";
            btn_newcollection.UseVisualStyleBackColor = false;
            btn_newcollection.Click += btn_newcollection_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(368, 50);
            label1.TabIndex = 35;
            label1.Text = "MANAGE PRODUCT";
            // 
            // pnl_control
            // 
            pnl_control.BackColor = SystemColors.ButtonHighlight;
            pnl_control.Controls.Add(panel1);
            pnl_control.Controls.Add(progressBar1);
            pnl_control.Controls.Add(btn_addnewproduct);
            pnl_control.Controls.Add(llbl_addnewproduct);
            pnl_control.Controls.Add(lbl_page);
            pnl_control.Controls.Add(btn_next);
            pnl_control.Controls.Add(btn_previous);
            pnl_control.Controls.Add(pnl_product);
            pnl_control.Location = new Point(3, 3);
            pnl_control.Name = "pnl_control";
            pnl_control.Size = new Size(1525, 780);
            pnl_control.TabIndex = 22;
            // 
            // btn_addnewproduct
            // 
            btn_addnewproduct.Image = (Image)resources.GetObject("btn_addnewproduct.Image");
            btn_addnewproduct.Location = new Point(489, 19);
            btn_addnewproduct.Name = "btn_addnewproduct";
            btn_addnewproduct.Size = new Size(34, 28);
            btn_addnewproduct.TabIndex = 35;
            btn_addnewproduct.UseVisualStyleBackColor = true;
            btn_addnewproduct.Click += llbl_addnewproduct_LinkClicked;
            // 
            // llbl_addnewproduct
            // 
            llbl_addnewproduct.AutoSize = true;
            llbl_addnewproduct.Cursor = Cursors.Hand;
            llbl_addnewproduct.DisabledLinkColor = Color.Black;
            llbl_addnewproduct.LinkColor = Color.Black;
            llbl_addnewproduct.Location = new Point(529, 23);
            llbl_addnewproduct.Name = "llbl_addnewproduct";
            llbl_addnewproduct.Size = new Size(198, 32);
            llbl_addnewproduct.TabIndex = 20;
            llbl_addnewproduct.TabStop = true;
            llbl_addnewproduct.Text = "Add new product";
            llbl_addnewproduct.VisitedLinkColor = Color.Black;
            llbl_addnewproduct.Click += llbl_addnewproduct_LinkClicked;
            // 
            // lbl_page
            // 
            lbl_page.AutoSize = true;
            lbl_page.Location = new Point(990, 744);
            lbl_page.Name = "lbl_page";
            lbl_page.Size = new Size(29, 32);
            lbl_page.TabIndex = 33;
            lbl_page.Text = "...";
            // 
            // btn_next
            // 
            btn_next.Cursor = Cursors.Hand;
            btn_next.Location = new Point(1079, 740);
            btn_next.Name = "btn_next";
            btn_next.Size = new Size(106, 29);
            btn_next.TabIndex = 32;
            btn_next.Text = "Next";
            btn_next.UseVisualStyleBackColor = true;
            btn_next.Click += btn_next_Click;
            // 
            // btn_previous
            // 
            btn_previous.Cursor = Cursors.Hand;
            btn_previous.Location = new Point(878, 740);
            btn_previous.Name = "btn_previous";
            btn_previous.Size = new Size(106, 29);
            btn_previous.TabIndex = 31;
            btn_previous.Text = "Previous";
            btn_previous.UseVisualStyleBackColor = true;
            btn_previous.Click += btn_previous_Click;
            // 
            // pnl_product
            // 
            pnl_product.Location = new Point(469, 42);
            pnl_product.Name = "pnl_product";
            pnl_product.Size = new Size(1033, 675);
            pnl_product.TabIndex = 30;
            // 
            // ManageProductControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            Controls.Add(pnl_control);
            Name = "ManageProductControl";
            Size = new Size(1528, 789);
            Load += ManageProductControl_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            pnl_control.ResumeLayout(false);
            pnl_control.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.ComponentModel.BackgroundWorker loadWorker;
        private ProgressBar progressBar1;
        private Panel panel1;
        private Button btn_reset;
        private GroupBox groupBox3;
        private Label lbl_priceFilter;
        private Label label10;
        private Label label9;
        private Label label11;
        private Label label8;
        private HScrollBar scrb_price;
        private GroupBox groupBox2;
        private TextBox tbx_inventory;
        private Label label3;
        private GroupBox groupBox1;
        private PictureBox pictureBox2;
        private TextBox tbx_search;
        private Button btn_all;
        private Button btn_jacket;
        private Button btn_bag;
        private Button btn_newcollection;
        private Label label1;
        private Panel pnl_control;
        private Button btn_addnewproduct;
        private LinkLabel llbl_addnewproduct;
        private Label lbl_page;
        private Button btn_next;
        private Button btn_previous;
        private Panel pnl_product;
    }
}

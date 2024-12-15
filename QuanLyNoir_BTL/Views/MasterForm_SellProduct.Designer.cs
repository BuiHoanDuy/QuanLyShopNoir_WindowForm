namespace QuanLyNoir_BTL.Views
{
    partial class MasterForm_SellProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterForm_SellProduct));
            lbl_name = new Label();
            btn_signout = new Button();
            panel1 = new Panel();
            btn_reset = new Button();
            lbl_datetime = new Label();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            label6 = new Label();
            tbx_search = new TextBox();
            pnl_nav = new Panel();
            btn_all = new Button();
            btn_jacket = new Button();
            btn_bag = new Button();
            btn_newcollection = new Button();
            pnl_side = new Panel();
            btn_checkout = new Button();
            pnl_body = new Panel();
            pnl_product = new FlowLayoutPanel();
            lbl_page = new Label();
            btn_previous = new Button();
            btn_next = new Button();
            loadWorker = new System.ComponentModel.BackgroundWorker();
            progressBar1 = new ProgressBar();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            pnl_nav.SuspendLayout();
            pnl_side.SuspendLayout();
            pnl_body.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_name
            // 
            lbl_name.AutoSize = true;
            lbl_name.Location = new Point(1540, 28);
            lbl_name.Name = "lbl_name";
            lbl_name.Size = new Size(47, 20);
            lbl_name.TabIndex = 20;
            lbl_name.Text = "name";
            // 
            // btn_signout
            // 
            btn_signout.BackColor = Color.FromArgb(0, 64, 0);
            btn_signout.Cursor = Cursors.Hand;
            btn_signout.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_signout.ForeColor = Color.White;
            btn_signout.Location = new Point(1414, 23);
            btn_signout.Name = "btn_signout";
            btn_signout.Size = new Size(120, 31);
            btn_signout.TabIndex = 21;
            btn_signout.Text = "Sign out";
            btn_signout.UseVisualStyleBackColor = false;
            btn_signout.Click += btn_signout_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(btn_reset);
            panel1.Controls.Add(lbl_datetime);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(tbx_search);
            panel1.Controls.Add(btn_signout);
            panel1.Controls.Add(lbl_name);
            panel1.Location = new Point(-3, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1715, 76);
            panel1.TabIndex = 22;
            // 
            // btn_reset
            // 
            btn_reset.Location = new Point(869, 23);
            btn_reset.Name = "btn_reset";
            btn_reset.Size = new Size(94, 29);
            btn_reset.TabIndex = 27;
            btn_reset.Text = "Reset";
            btn_reset.UseVisualStyleBackColor = true;
            btn_reset.Click += btn_reset_Click;
            // 
            // lbl_datetime
            // 
            lbl_datetime.AutoSize = true;
            lbl_datetime.Font = new Font("Arial Narrow", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_datetime.Location = new Point(1063, 26);
            lbl_datetime.Name = "lbl_datetime";
            lbl_datetime.Size = new Size(129, 22);
            lbl_datetime.TabIndex = 26;
            lbl_datetime.Text = "Tuesday, 1 1 2024";
            // 
            // label1
            // 
            label1.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(1007, 27);
            label1.Name = "label1";
            label1.Size = new Size(62, 25);
            label1.TabIndex = 25;
            label1.Text = "Date:";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(828, 25);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(35, 27);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 24;
            pictureBox2.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("STLiti", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 134);
            label6.Location = new Point(66, 23);
            label6.Name = "label6";
            label6.Size = new Size(75, 35);
            label6.TabIndex = 23;
            label6.Text = "Noir";
            // 
            // tbx_search
            // 
            tbx_search.Cursor = Cursors.IBeam;
            tbx_search.Location = new Point(201, 25);
            tbx_search.Name = "tbx_search";
            tbx_search.Size = new Size(621, 27);
            tbx_search.TabIndex = 23;
            tbx_search.TextChanged += tbx_search_TextChanged;
            // 
            // pnl_nav
            // 
            pnl_nav.BackColor = SystemColors.ControlLightLight;
            pnl_nav.Controls.Add(btn_all);
            pnl_nav.Controls.Add(btn_jacket);
            pnl_nav.Controls.Add(btn_bag);
            pnl_nav.Controls.Add(btn_newcollection);
            pnl_nav.Location = new Point(12, 90);
            pnl_nav.Name = "pnl_nav";
            pnl_nav.Size = new Size(1241, 93);
            pnl_nav.TabIndex = 23;
            // 
            // btn_all
            // 
            btn_all.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_all.BackColor = Color.DarkSlateGray;
            btn_all.Cursor = Cursors.Hand;
            btn_all.FlatStyle = FlatStyle.Flat;
            btn_all.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_all.ForeColor = Color.Pink;
            btn_all.Location = new Point(51, 28);
            btn_all.Name = "btn_all";
            btn_all.Size = new Size(194, 33);
            btn_all.TabIndex = 43;
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
            btn_jacket.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            btn_jacket.Location = new Point(461, 28);
            btn_jacket.Name = "btn_jacket";
            btn_jacket.Size = new Size(187, 33);
            btn_jacket.TabIndex = 42;
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
            btn_bag.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            btn_bag.ForeColor = Color.Black;
            btn_bag.Location = new Point(662, 28);
            btn_bag.Name = "btn_bag";
            btn_bag.Size = new Size(187, 33);
            btn_bag.TabIndex = 41;
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
            btn_newcollection.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            btn_newcollection.ForeColor = SystemColors.ActiveCaptionText;
            btn_newcollection.Location = new Point(255, 28);
            btn_newcollection.Name = "btn_newcollection";
            btn_newcollection.Size = new Size(194, 33);
            btn_newcollection.TabIndex = 40;
            btn_newcollection.Text = "New Collection";
            btn_newcollection.UseVisualStyleBackColor = false;
            btn_newcollection.Click += btn_newcollection_Click;
            // 
            // pnl_side
            // 
            pnl_side.BackColor = SystemColors.ControlLightLight;
            pnl_side.Controls.Add(btn_checkout);
            pnl_side.Location = new Point(1259, 90);
            pnl_side.Name = "pnl_side";
            pnl_side.Size = new Size(440, 821);
            pnl_side.TabIndex = 24;
            // 
            // btn_checkout
            // 
            btn_checkout.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_checkout.BackColor = Color.DarkSlateGray;
            btn_checkout.Cursor = Cursors.Hand;
            btn_checkout.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_checkout.ForeColor = Color.AliceBlue;
            btn_checkout.Location = new Point(22, 767);
            btn_checkout.Name = "btn_checkout";
            btn_checkout.Size = new Size(393, 51);
            btn_checkout.TabIndex = 45;
            btn_checkout.Text = "CHECKOUT";
            btn_checkout.UseVisualStyleBackColor = false;
            // 
            // pnl_body
            // 
            pnl_body.BackColor = SystemColors.ControlLightLight;
            pnl_body.Controls.Add(pnl_product);
            pnl_body.Controls.Add(lbl_page);
            pnl_body.Controls.Add(btn_previous);
            pnl_body.Controls.Add(btn_next);
            pnl_body.Location = new Point(12, 189);
            pnl_body.Name = "pnl_body";
            pnl_body.Size = new Size(1241, 722);
            pnl_body.TabIndex = 25;
            // 
            // pnl_product
            // 
            pnl_product.Location = new Point(3, 3);
            pnl_product.Name = "pnl_product";
            pnl_product.Size = new Size(1235, 674);
            pnl_product.TabIndex = 47;
            // 
            // lbl_page
            // 
            lbl_page.AutoSize = true;
            lbl_page.Location = new Point(563, 687);
            lbl_page.Name = "lbl_page";
            lbl_page.Size = new Size(21, 20);
            lbl_page.TabIndex = 46;
            lbl_page.Text = "...";
            // 
            // btn_previous
            // 
            btn_previous.Cursor = Cursors.Hand;
            btn_previous.Location = new Point(451, 683);
            btn_previous.Name = "btn_previous";
            btn_previous.Size = new Size(106, 29);
            btn_previous.TabIndex = 44;
            btn_previous.Text = "Previous";
            btn_previous.UseVisualStyleBackColor = true;
            btn_previous.Click += btn_previous_Click;
            // 
            // btn_next
            // 
            btn_next.Cursor = Cursors.Hand;
            btn_next.Location = new Point(652, 683);
            btn_next.Name = "btn_next";
            btn_next.Size = new Size(106, 29);
            btn_next.TabIndex = 45;
            btn_next.Text = "Next";
            btn_next.UseVisualStyleBackColor = true;
            btn_next.Click += btn_next_Click;
            // 
            // loadWorker
            // 
            loadWorker.WorkerReportsProgress = true;
            loadWorker.DoWork += loadWorker_DoWork;
            loadWorker.ProgressChanged += loadWorker_ProgressChanged;
            loadWorker.RunWorkerCompleted += loadWorker_RunWorkerCompleted;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(-3, 70);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(1712, 10);
            progressBar1.TabIndex = 26;
            // 
            // MasterForm_SellProduct
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1708, 923);
            Controls.Add(progressBar1);
            Controls.Add(pnl_body);
            Controls.Add(pnl_side);
            Controls.Add(pnl_nav);
            Controls.Add(panel1);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            Name = "MasterForm_SellProduct";
            Text = "MasterForm_SellProduct";
            FormClosing += MasterForm_SellProduct_FormClosing;
            Load += MasterForm_SellProduct_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            pnl_nav.ResumeLayout(false);
            pnl_side.ResumeLayout(false);
            pnl_body.ResumeLayout(false);
            pnl_body.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lbl_name;
        private Button btn_signout;
        private Panel panel1;
        private Label label6;
        private Label label1;
        private PictureBox pictureBox2;
        private TextBox tbx_search;
        private Label lbl_datetime;
        private Panel pnl_nav;
        private Panel pnl_side;
        private Button btn_all;
        private Button btn_jacket;
        private Button btn_bag;
        private Button btn_newcollection;
        private Panel pnl_body;
        private Button btn_checkout;
        private System.ComponentModel.BackgroundWorker loadWorker;
        private ProgressBar progressBar1;
        private Label lbl_page;
        private Button btn_previous;
        private Button btn_next;
        private FlowLayoutPanel pnl_product;
        private Button btn_reset;
    }
}
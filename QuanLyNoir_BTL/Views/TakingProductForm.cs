using QuanLyNoir_BTL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNoir_BTL.Views
{
    public partial class TakingProductForm : Form
    {
        public ProductInfomation product { get; private set; }  = new ProductInfomation();
        public int amount { get; private set; }

        public TakingProductForm(ProductInfomation product)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.product = new ProductInfomation
            {
                Id = product.Id,
                TotalInventory = product.TotalInventory,
                ColorName = product.ColorName,
                ImageUrl = product.ImageUrl,
                ColorCode = product.ColorCode,
                ProductId = product.ProductId,
                Size = product.Size,
                ProdName = product.ProdName,
                Price = product.Price,
                Wid = product.Wid,
                Hei = product.Hei,
                Type = product.Type,
            };
        }

        private void TakingProductForm_Load(object sender, EventArgs e)
        {
            LoadProductData();
            checkAvailableSize();
            if (product.TotalInventory <= 0)
            {
                lbl_amount.Text = "0";
                amount = 0;
            }
        }
        private async Task LoadProductData() // load data cho edit
        {
            // Cập nhật giao diện trên UI thread
            Invoke((MethodInvoker)(() =>
            {
                // Cập nhật thông tin ProductColorSize
                lbl_inventory.Text = product.TotalInventory.ToString();

                // Cập nhật hình ảnh
                if (product.ImageUrl != null)
                {
                    pictureBox1.Image = Image.FromFile(product.ImageUrl);
                }
                else
                {
                    pictureBox1.Image = null; // Hoặc hình ảnh mặc định
                }

                // Cập nhật thông tin Product
                if (product != null)
                {
                    lbl_name.Text = product.ProdName;
                    lbl_price.Text = product.Price.ToString();
                    lbl_tempAmount.Text = lbl_amount.Text;
                    lbl_inventory.Text = lbl_inventory.Text;
                    tbx_colorNote.Text = product.ColorName;
                    pnl_colorBox.BackColor = ColorTranslator.FromHtml(product.ColorCode);
                    lbl_total.Text = (float.Parse(lbl_amount.Text) * float.Parse(lbl_price.Text)).ToString();
                    amount = int.Parse(lbl_amount.Text);
                }
            }));
        }
        private void checkAvailableSize()
        {
            string size = product.Size.ToString();
            string[] elements = size.Split(new string[] { ", " }, StringSplitOptions.None);
            if (elements.Count() > 0)
            {
                btn_none.Enabled = false;
            }
            foreach (string element in elements)
            {
                enableButtonName(element);
            }
        }
        private void enableButtonName(string sizeName)
        {
            switch (sizeName)
            {
                case "S": 
                    btn_s.Enabled = true;
                    resetSizeOfProductColor(btn_s);
                    break;
                case "M":
                    btn_m.Enabled = true;
                    resetSizeOfProductColor(btn_m);
                    break;
                case "L":
                    btn_l.Enabled = true;
                    resetSizeOfProductColor(btn_l);
                    break;
                case "XL":
                    btn_xl.Enabled = true;
                    resetSizeOfProductColor(btn_xl);
                    break;
            }
        }
        private void btn_down_Click(object sender, EventArgs e)
        {
            int count = int.Parse(lbl_amount.Text);
            if (count > 0)
            {
                lbl_amount.Text = (count - 1).ToString();
                LoadProductData();
            }
        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            int count = int.Parse(lbl_amount.Text);
            if (count < product.TotalInventory)
            {
                lbl_amount.Text = (int.Parse(lbl_amount.Text) + 1).ToString();
                LoadProductData();
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            lbl_amount.Text = "1";
            lbl_tempAmount.Text = lbl_amount.Text;
            lbl_total.Text = lbl_price.Text;

            resetSizeOfProductColor(btn_none);
        }
        private async void resetSizeOfProductColor(System.Windows.Forms.Button sizeButton)
        {
            btn_none.BackColor = Color.White;
            btn_s.BackColor = Color.White;
            btn_m.BackColor = Color.White;
            btn_l.BackColor = Color.White;
            btn_xl.BackColor = Color.White;

            btn_none.ForeColor = Color.Black;
            btn_s.ForeColor = Color.Black;
            btn_m.ForeColor = Color.Black;
            btn_l.ForeColor = Color.Black;
            btn_xl.ForeColor = Color.Black;

            sizeButton.ForeColor = Color.AliceBlue;
            sizeButton.BackColor = Color.DarkSeaGreen;

            // Gán giá trị của enum dựa trên nút đã chọn

            if (sizeButton.Text == btn_none.Text) { product.Size = null; }
            else
            {
                product.Size = sizeButton.Text;
            }
        }

        private void btn_none_Click(object sender, EventArgs e)
        {
            resetSizeOfProductColor(btn_none);
        }

        private void btn_s_Click(object sender, EventArgs e)
        {
            resetSizeOfProductColor(btn_s);
        }

        private void btn_m_Click(object sender, EventArgs e)
        {
            resetSizeOfProductColor(btn_m);
        }

        private void btn_l_Click(object sender, EventArgs e)
        {
            resetSizeOfProductColor(btn_l);
        }

        private void btn_xl_Click(object sender, EventArgs e)
        {
            resetSizeOfProductColor(btn_xl);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; // Đặt kết quả là OK
            this.Close();
        }
    }
}

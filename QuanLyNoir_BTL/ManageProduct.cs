using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNoir_BTL
{
    public partial class ManageProduct : Form
    {
        public ManageProduct()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            hScrollBar1.Height = 20;
        }

        private void btn_newcollection_Click(object sender, EventArgs e)
        {

        }
        private void Createpnl_product(string name, string inventory, decimal price, string size, string color, string material, string imagePath)
        {
            PictureBox pictureBox = new PictureBox
            {
                ImageLocation = imagePath,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 100,
                Height = 100
            };

            Label lblName = new Label { Text = name, AutoSize = true };
            Label lblInventory = new Label { Text = $"Inventory: {inventory}", AutoSize = true };
            Label lblPrice = new Label { Text = $"Price: ${price}", AutoSize = true };
            Label lblSize = new Label { Text = $"Size: {size}", AutoSize = true };
            Label lblColor = new Label { Text = $"Color: {color}", AutoSize = true };
            Label lblMaterial = new Label { Text = $"Material: {material}", AutoSize = true };

            pnl_product.Controls.Add(pictureBox);
            pnl_product.Controls.Add(lblName);
            pnl_product.Controls.Add(lblInventory);
            pnl_product.Controls.Add(lblPrice);
            pnl_product.Controls.Add(lblSize);
            pnl_product.Controls.Add(lblColor);
            pnl_product.Controls.Add(lblMaterial);

            // Đặt vị trí cho các điều khiển
            lblName.Location = new Point(10, 110);
            lblInventory.Location = new Point(10, 130);
            lblPrice.Location = new Point(10, 150);
            lblSize.Location = new Point(10, 170);
            lblColor.Location = new Point(10, 190);
            lblMaterial.Location = new Point(10, 210);
        }
    }
}

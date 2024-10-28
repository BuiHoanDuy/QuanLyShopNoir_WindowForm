using QuanLyNoir_BTL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNoir_BTL
{
    public partial class ManageProduct : Form
    {
        //ShopNoirTestContext dbContext = new ShopNoirTestContext();
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
        public void LoadProducts(Panel pnl_product)
        {
            // Xóa các control cũ
            pnl_product.Controls.Clear();
            using (var dbContext = new ShopNoirTestContext())
            {
                // Lấy danh sách sản phẩm từ cơ sở dữ liệu
                var productInformation = (from p in dbContext.Products.AsNoTracking()
                                          join pc in dbContext.ProductColors.AsNoTracking()
                                          on p.Id equals pc.ProductId
                                          select new
                                          {
                                              ProductId = p.Id,
                                              ProductName = p.ProdName,
                                              p.Price,
                                              p.Wid,
                                              p.Hei,
                                              ProductInventory = pc.Inventory,
                                              ProductColorCode = pc.ColorCode,
                                              ProductColorName = pc.ColorName,
                                              p.ProdDesc,
                                              ProductImageUrl = pc.ImageUrl
                                          }).ToList();

                int x = 10, y = 10; // Tọa độ ban đầu cho sản phẩm đầu tiên
                const int padding = 10; // Khoảng cách giữa các sản phẩm

                foreach (var product in productInformation)
                {
                    // Tạo Panel cho từng sản phẩm
                    Panel productPanel = new Panel
                    {
                        Width = 200,
                        Height = 300,
                        BorderStyle = BorderStyle.FixedSingle,
                        Location = new Point(x, y),
                        Margin = new Padding(padding)
                    };

                    // Tạo Label cho tên sản phẩm
                    Label lblName = new Label
                    {
                        Text = product.ProductName,
                        Font = new Font("Arial", 12, FontStyle.Bold),
                        Location = new Point(10, 10),
                        AutoSize = true
                    };

                    // Tạo PictureBox cho ảnh sản phẩm
                    //PictureBox picImage = new PictureBox
                    //{
                    //    Size = new Size(100, 100),
                    //    Location = new Point(50, 40),
                    //    SizeMode = PictureBoxSizeMode.StretchImage
                    //};
                    //if (product.ProductImageUrl != null)
                    //{
                    //    using (MemoryStream ms = new MemoryStream(product.ProductImageUrl))
                    //    {
                    //        picImage.Image = Image.FromStream(ms);
                    //    }
                    //}

                    // Tạo các Label cho các thông tin khác
                    Label lblPrice = new Label
                    {
                        Text = $"Price: ${product.Price}",
                        Location = new Point(10, 150),
                        AutoSize = true
                    };

                    Label lblSize = new Label
                    {
                        Text = $"Size: {product.Wid} x {product.Hei}",
                        Location = new Point(10, 180),
                        AutoSize = true
                    };

                    Label lblColor = new Label
                    {
                        Text = $"Color: {product.ProductColorName}",
                        Location = new Point(10, 210),
                        AutoSize = true
                    };

                    Label lblInventory = new Label
                    {
                        Text = $"Inventory: {product.ProductInventory} items",
                        Location = new Point(10, 240),
                        AutoSize = true
                    };

                    // Thêm các control vào panel sản phẩm
                    productPanel.Controls.Add(lblName);
        //            productPanel.Controls.Add(picImage);
                    productPanel.Controls.Add(lblPrice);
                    productPanel.Controls.Add(lblSize);
                    productPanel.Controls.Add(lblColor);
                    productPanel.Controls.Add(lblInventory);

                    // Thêm panel sản phẩm vào pnl_product
                    pnl_product.Controls.Add(productPanel);

                    // Cập nhật vị trí cho sản phẩm tiếp theo
                    x += productPanel.Width + padding;
                    if (x + productPanel.Width > pnl_product.Width) // Khi đạt giới hạn chiều rộng của panel chính
                    {
                        x = 10; // Reset lại x
                        y += productPanel.Height + padding; // Tăng y để tạo hàng mới
                    }
                }
            }
        }


        private void ManageProduct_Load(object sender, EventArgs e)
        {
            LoadProducts(pnl_product);
        }
    }
}

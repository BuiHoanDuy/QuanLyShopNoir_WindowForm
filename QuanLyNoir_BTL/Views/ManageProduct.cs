using Microsoft.EntityFrameworkCore;
using QuanLyNoir_BTL.Models;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNoir_BTL
{
    public partial class ManageProduct : Form
    {
        private readonly ShopNoirTestContext _dbContext = new ShopNoirTestContext();
        private int currentPage = 1;
        private const int PageSize = 8; // Số lượng bản ghi nhỏ hơn để tối ưu hóa
        private int totalRecords;

        public ManageProduct()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            scrb_price.Height = 20;
        }

        private async void ManageProduct_Load(object sender, EventArgs e)
        {
            await LoadProductsAsync(pnl_product);
            lbl_priceFilter.Text = $"Giá: ${scrb_price.Value}";
        }

        private async Task LoadProductsAsync(Panel pnl_product)
        {
            try
            {
                totalRecords = await _dbContext.ProductColors.CountAsync();
                lbl_page.Text = $"Trang {currentPage} / {Math.Ceiling((double)totalRecords / PageSize)}";

                pnl_product.Controls.Clear();

                var productInformation = await _dbContext.Products
                    .Include(p => p.ProductColors) // Eager load liên kết
                    .Select(p => new
                    {
                        p.Id,
                        p.ProdName,
                        p.Price,
                        p.Wid,
                        p.Hei,
                        ColorInfo = p.ProductColors.Select(pc => new
                        {
                            pc.Inventory,
                            pc.ColorName,
                            pc.ImageUrl
                        }).FirstOrDefault() // Lấy thông tin màu đầu tiên
                    })
                    .AsNoTracking()
                    .Skip((currentPage - 1) * PageSize)
                    .Take(PageSize)
                    .ToListAsync();

                int x = 10, y = 10;
                const int padding = 10;

                foreach (var product in productInformation)
                {
                    var productPanel = CreateProductPanel(product, x, y);
                    pnl_product.Controls.Add(productPanel);

                    x += productPanel.Width + padding;
                    if (x + productPanel.Width > pnl_product.Width)
                    {
                        x = 10;
                        y += productPanel.Height + padding;
                    }
                }

                btn_previous.Enabled = currentPage > 1;
                btn_next.Enabled = currentPage < Math.Ceiling((double)totalRecords / PageSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private Panel CreateProductPanel(dynamic product, int x, int y)
        {
            Panel productPanel = new Panel
            {
                Width = 200,
                Height = 300,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(x, y),
                Margin = new Padding(10)
            };

            Label lblName = new Label
            {
                Text = product.ProdName,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };

            PictureBox picImage = new PictureBox
            {
                Size = new Size(100, 100),
                Location = new Point(50, 40),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            if (product.ColorInfo?.ImageUrl != null)
            {
                // Giả sử ColorInfo.ImageUrl là một byte[]
                using (MemoryStream ms = new MemoryStream(product.ColorInfo.ImageUrl))
                {
                    picImage.Image = Image.FromStream(ms);
                }
            }

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
                Text = $"Color: {product.ColorInfo?.ColorName}",
                Location = new Point(10, 210),
                AutoSize = true
            };

            Label lblInventory = new Label
            {
                Text = $"Inventory: {product.ColorInfo?.Inventory} items",
                Location = new Point(10, 240),
                AutoSize = true
            };

            productPanel.Controls.Add(lblName);
            productPanel.Controls.Add(picImage);
            productPanel.Controls.Add(lblPrice);
            productPanel.Controls.Add(lblSize);
            productPanel.Controls.Add(lblColor);
            productPanel.Controls.Add(lblInventory);

            return productPanel;
        }

        private async void btn_previous_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                await LoadProductsAsync(pnl_product);
            }
        }

        private async void btn_next_Click(object sender, EventArgs e)
        {
            if (currentPage < Math.Ceiling((double)totalRecords / PageSize))
            {
                currentPage++;
                await LoadProductsAsync(pnl_product);
            }
        }

        private void scrb_price_Scroll(object sender, ScrollEventArgs e)
        {
            lbl_priceFilter.Text = $"Giá: ${scrb_price.Value}"; // Cập nhật lbl_priceFilter với giá hiện tại
        }
    }
}

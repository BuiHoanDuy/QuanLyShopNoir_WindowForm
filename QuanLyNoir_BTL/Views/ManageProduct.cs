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
        private const int PageSize = 8; // Giữ số lượng bản ghi trên mỗi trang là 6
        private int totalRecords;

        private string currentType = null; // Loại sản phẩm hiện tại (null nghĩa là không lọc theo loại)


        private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        private const int TimerInterval = 500; // Thời gian chờ 500ms
        public ManageProduct()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            scrb_price.Height = 20;

            // Cấu hình Timer
            _timer.Interval = TimerInterval; // Thay đổi thời gian nếu cần
            _timer.Tick += Timer_Tick; // Đăng ký sự kiện
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Dừng Timer
            _timer.Stop();

            // Gọi lại LoadProductsAsync để tải lại sản phẩm
            LoadProductsAsync(pnl_product).ConfigureAwait(false);
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
                // Lấy giá trị từ các trường
                string searchTerm = tbx_search.Text.Trim().ToLower();
                int inventoryThreshold = string.IsNullOrEmpty(tbx_inventory.Text) ? int.MaxValue : int.Parse(tbx_inventory.Text);
                decimal priceLimit = scrb_price.Value;

                totalRecords = await _dbContext.ProductColors.CountAsync();
                lbl_page.Text = $"Trang {currentPage} / {Math.Ceiling((double)totalRecords / PageSize)}";

                pnl_product.Controls.Clear();

                // Truy vấn sản phẩm với bộ lọc theo loại sản phẩm hiện tại
                var productQuery = _dbContext.Products
                    .Include(p => p.ProductColors)
                    .Where(p => p.ProdName.ToLower().Contains(searchTerm)
                                && p.ProductColors.Any(pc => pc.Inventory < inventoryThreshold && p.Price < priceLimit));

                if (!string.IsNullOrEmpty(currentType))
                {
                    // Nếu currentType không rỗng, thêm điều kiện lọc theo loại sản phẩm
                    productQuery = productQuery.Where(p => p.Type == currentType);
                }

                var productInformation = await productQuery
                    .OrderByDescending(p => p.Price) // Sắp xếp theo giá giảm dần
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
                            pc.ImageUrl,
                            pc.ColorCode
                        }).FirstOrDefault()
                    })
                    .AsNoTracking()
                    .Skip((currentPage - 1) * PageSize)
                    .Take(PageSize)
                    .ToListAsync();

                int x = 10, y = 10;
                const int padding = 20; // Tăng khoảng cách giữa các ô sản phẩm

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
                Width = 220,
                Height = 320, // Tăng chiều cao để chứa thêm nút tùy chọn
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
                Size = new Size(160, 160),
                Location = new Point(30, 40),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            if (product.ColorInfo?.ImageUrl != null)
            {
                using (MemoryStream ms = new MemoryStream(product.ColorInfo.ImageUrl))
                {
                    picImage.Image = Image.FromStream(ms);
                }
            }

            Label lblPrice = new Label
            {
                Text = $"Price: ${product.Price}",
                Location = new Point(10, 210),
                AutoSize = true
            };

            Label lblSize = new Label
            {
                Text = $"Size: {product.Wid} x {product.Hei}",
                Location = new Point(10, 240),
                AutoSize = true
            };

            Panel colorPanel = new Panel
            {
                Size = new Size(20, 20),
                Location = new Point(120, 270),
                BorderStyle = BorderStyle.FixedSingle
            };

            if (product.ColorInfo?.ColorCode != null)
            {
                colorPanel.BackColor = ColorTranslator.FromHtml(product.ColorInfo.ColorCode);
            }

            Label lblColor = new Label
            {
                Text = $"Color: {product.ColorInfo?.ColorName}",
                Location = new Point(10, 270),
                AutoSize = true
            };

            Label lblInventory = new Label
            {
                Text = $"Inventory: {product.ColorInfo?.Inventory} items",
                Location = new Point(10, 300),
                AutoSize = true
            };

            // Thêm nút tùy chọn
            Button btnOptions = new Button
            {
                Text = "Option",
                Location = new Point(130, 5),
                AutoSize = true
            };

            // Tạo context menu
            ContextMenuStrip optionsMenu = new ContextMenuStrip();
            optionsMenu.Items.Add("Sửa thông tin").Click += (s, e) => EditProduct(product.Id);
            optionsMenu.Items.Add("Xóa sản phẩm").Click += (s, e) => DeleteProduct(product.Id);

            // Gán context menu cho nút
            btnOptions.Click += (s, e) => optionsMenu.Show(btnOptions, new Point(0, btnOptions.Height));

            productPanel.Controls.Add(lblName);
            productPanel.Controls.Add(picImage);
            productPanel.Controls.Add(lblPrice);
            productPanel.Controls.Add(lblSize);
            productPanel.Controls.Add(colorPanel);
            productPanel.Controls.Add(lblColor);
            productPanel.Controls.Add(lblInventory);
            productPanel.Controls.Add(btnOptions);

            return productPanel;
        }

        private void EditProduct(int productColorId)
        {
            // Xử lý logic sửa thông tin sản phẩm
            var productColor = _dbContext.ProductColors.FirstOrDefault(pc => pc.Id == productColorId);
            if (productColor != null)
            {
                // Hiển thị form chỉnh sửa và cập nhật sản phẩm
                // (Cần tạo form chỉnh sửa và hiển thị tại đây)
            }
        }

        private async void DeleteProduct(int productColorId)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                var productColor = await _dbContext.ProductColors.FindAsync(productColorId);
                if (productColor != null)
                {
                    _dbContext.ProductColors.Remove(productColor);
                    await _dbContext.SaveChangesAsync();
                    await LoadProductsAsync(pnl_product);
                }
            }
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
            lbl_priceFilter.Text = $"Giá: ${scrb_price.Value}";

            _timer.Stop();
            currentPage = 1;
            _timer.Start();
        }


        private async void tbx_search_TextChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            await LoadProductsAsync(pnl_product);
        }

        private async void tbx_inventory_TextChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            await LoadProductsAsync(pnl_product);
        }

        private void btn_filternow_Click(object sender, EventArgs e)
        {
            _timer.Stop();
            currentPage = 1;
            tbx_inventory.Clear();
            tbx_search.Clear();
            scrb_price.Value = 1000;
            _timer.Start();
        }

        private void resetButtonTypeFilter()
        {
            btn_newcollection.ForeColor = Color.Black;
            btn_newcollection.BackColor = SystemColors.Control;

            btn_bag.ForeColor = Color.Black;
            btn_bag.BackColor = SystemColors.Control;

            btn_jacket.ForeColor = Color.Black;
            btn_jacket.BackColor = SystemColors.Control;

            btn_voucher.ForeColor = Color.Black;
            btn_voucher.BackColor = SystemColors.Control;
        }
        private async void btn_bag_Click(object sender, EventArgs e)
        {
            resetButtonTypeFilter();
            btn_bag.ForeColor = Color.Pink;
            btn_bag.BackColor = Color.DarkSlateGray;
            //currentType = "bag"; // Đặt loại sản phẩm là 'bag'
            currentType = "Type B"; // Đặt loại sản phẩm là 'bag'
            currentPage = 1; // Quay lại trang đầu
            await LoadProductsAsync(pnl_product);
        }

        private async void btn_jacket_Click(object sender, EventArgs e)
        {
            resetButtonTypeFilter();
            btn_jacket.ForeColor = Color.Pink;
            btn_jacket.BackColor = Color.DarkSlateGray;
            //currentType = "jacket"; // Đặt loại sản phẩm là 'jacket'
            currentType = "Type A"; // Đặt loại sản phẩm là 'jacket'
            currentPage = 1; // Quay lại trang đầu
            await LoadProductsAsync(pnl_product);
        }

        private async void btn_newcollection_Click(object sender, EventArgs e)
        {
            resetButtonTypeFilter();
            btn_newcollection.ForeColor = Color.Pink;
            btn_newcollection.BackColor = Color.DarkSlateGray;
            currentType = null; // select tất cả các sản phẩm
            currentPage = 1; // Quay lại trang đầu
            await LoadProductsAsync(pnl_product);
        }

        private async void btn_voucher_Click(object sender, EventArgs e)
        {
            resetButtonTypeFilter();
            btn_voucher.ForeColor = Color.Pink;
            btn_voucher.BackColor = Color.DarkSlateGray;
            currentType = "voucher"; // Đặt loại sản phẩm là 'voucher'
            currentPage = 1; // Quay lại trang đầu
            await LoadProductsAsync(pnl_product);
        }

    }
}

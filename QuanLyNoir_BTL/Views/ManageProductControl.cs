using QuanLyNoir_BTL.Models;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;

namespace QuanLyNoir_BTL.Views
{
    public partial class ManageProductControl : UserControl
    {
        //private readonly ShopNoirContext _dbContext = new ShopNoirContext();
        private int currentPage = 1;
        private const int PageSize = 8; // Giữ số lượng bản ghi trên mỗi trang là 6
        private int totalRecords;

        private string currentType = null; // Loại sản phẩm hiện tại (null nghĩa là không lọc theo loại)

        private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        private string selectedSize = null;
        private const int TimerInterval = 500; // Thời gian chờ 500ms
        public ManageProductControl()
        {
            InitializeComponent();
            this.AutoSize = false;
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
            if (!loadWorker.IsBusy)
            {
                loadWorker.RunWorkerAsync();
            }
        }
        private void ManageProductControl_Load(object sender, EventArgs e)
        {
            lbl_priceFilter.Text = $"Price: ${scrb_price.Value}";
            if (!loadWorker.IsBusy)
            {
                loadWorker.RunWorkerAsync();
            }
        }
        private async Task LoadProductsAsync(Panel pnl_product)
        {
            using (var _dbContext = new ShopNoirContext())
            {
                try
                {
                    // Lấy giá trị từ các trường
                    string searchTerm = tbx_search.Text.Trim().ToLower();
                    int inventoryThreshold = string.IsNullOrEmpty(tbx_inventory.Text) ? int.MaxValue : int.Parse(tbx_inventory.Text);
                    decimal priceLimit = scrb_price.Value;

                    totalRecords = await _dbContext.ProductColors.CountAsync();
                    lbl_page.Text = $"Page {currentPage} / {Math.Ceiling((double)totalRecords / PageSize)}";

                    pnl_product.Controls.Clear();

                    //Truy vấn lấy tất cả các product color và size 
                    var productColorQuery = _dbContext.ProductColors
                        .Include(p => p.Product)
                        .Where(pc => pc.Inventory < inventoryThreshold
                        && pc.Product.ProdName.ToLower().Contains(searchTerm)
                        && pc.Product.Price < priceLimit);

                    if (!string.IsNullOrEmpty(currentType))
                    {
                        // Nếu currentType không rỗng, thêm điều kiện lọc theo loại sản phẩm
                        //productQuery = productQuery.Where(p => p.Type == currentType);
                        productColorQuery = productColorQuery.Where(pc => pc.Product.Type == currentType);
                    }

                    var productInformation = await productColorQuery
                        .OrderByDescending(pc => pc.Product.ProdName) // Sắp xếp theo giá giảm dần
                        .Select(pc => new
                        {
                            pc.Id,
                            pc.Inventory,
                            pc.ColorName,
                            pc.ImageUrl,
                            pc.ColorCode,
                            pc.ProductId,
                            pc.Size,
                            pc.Product.ProdName,
                            pc.Product.Price,
                            pc.Product.Width,
                            pc.Product.Height,
                            pc.Product.Type,
                        })
                        .AsNoTracking()
                        .Skip((currentPage - 1) * PageSize)
                        .Take(PageSize)
                        .ToListAsync();

                    int x = 10, y = 10;
                    const int padding = 20; // Tăng khoảng cách giữa các ô sản phẩm


                    if (productInformation.Count <= 0)
                    {
                        MessageBox.Show("Hi");
                        Label lbl_empty = new Label
                        {
                            Text = "Empty",
                            Font = new Font("Arial", 30, FontStyle.Bold),
                            ForeColor = Color.Red,
                            Location = new Point(40, 40),
                            AutoSize = true
                        };
                        pnl_product.Controls.Add(lbl_empty);
                    }
                    else
                    {
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
                    }

                    btn_previous.Enabled = currentPage > 1;
                    btn_next.Enabled = currentPage < Math.Ceiling((double)totalRecords / PageSize);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }
        private Panel CreateProductPanel(dynamic product, int x, int y)
        {
            Panel productPanel = new Panel
            {
                Width = 220,
                Height = 320,
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

            if (product.ImageUrl != null)
            {
                using (MemoryStream ms = new MemoryStream(product.ImageUrl))
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
                Location = new Point(10, 240),
                AutoSize = true
            };

            if (product.Wid == 0 && product.Hei == 0 && product.Size != null)
            {
                lblSize.Text = $"Size: {product.Size}";
            }
            else if ((product.Wid != 0 || product.Hei != 0) && product.Size == null)
            {
                lblSize.Text = $"Size: {product.Wid} x {product.Hei}";
            }
            else
            {
                lblSize.Text = $"Size: {product.Size} ({product.Wid} x {product.Hei})";
            }

            Panel colorPanel = new Panel
            {
                Size = new Size(20, 20),
                Location = new Point(120, 270),
                BorderStyle = BorderStyle.FixedSingle
            };

            if (product.ColorCode != null)
            {
                colorPanel.BackColor = ColorTranslator.FromHtml(product.ColorCode);
            }

            Label lblColor = new Label
            {
                Text = $"Color: {product.ColorName}",
                Location = new Point(10, 270),
                AutoSize = true
            };

            Label lblInventory = new Label
            {
                Text = $"Inventory: {product.Inventory} items",
                Location = new Point(10, 300),
                AutoSize = true
            };

            // Thêm nút tùy chọn
            System.Windows.Forms.Button btnOptions = new System.Windows.Forms.Button
            {
                Text = "Option",
                Location = new Point(130, 5),
                AutoSize = true
            };

            // Tạo context menu
            ContextMenuStrip optionsMenu = new ContextMenuStrip();
            optionsMenu.Items.Add("Edit").Click += (s, e) => EditProduct(product.Id);
            optionsMenu.Items.Add("Delete").Click += (s, e) => DeleteProduct(product.Id);
            optionsMenu.Items.Add("Add Color").Click += (s, e) => AddColorToProduct(product.ProductId);
            optionsMenu.Items.Add("Add Size").Click += (s, e) => AddSizeToProduct(product.Id);
            optionsMenu.Items.Add("Find").Click += (s, e) => FindWithProductName(product.ProdName);


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

        private void FindWithProductName(dynamic prodName)
        {
            tbx_search.Text = prodName;
        }

        private void AddColorToProduct(Guid productId)
        {
            using (var _dbContext = new ShopNoirContext())
            {
                // Tìm sản phẩm theo productColorId
                var product = _dbContext.Products
                .FirstOrDefault(p => p.Id == productId);

                if (product != null)
                {
                    // Tạo và hiển thị form AddNewProduct
                    AddNewProduct AddNewColorForm = new AddNewProduct(productId, 'C');
                    AddNewColorForm.ShowDialog(); // Hiển thị như một dialog để chờ người dùng đóng form này
                    if (!loadWorker.IsBusy)
                    {
                        loadWorker.RunWorkerAsync();
                    }
                }
                else
                {
                    MessageBox.Show("Don't find product.", productId.ToString());
                }
            }
        }
        private void AddSizeToProduct(Guid productColorId)
        {
            using (var _dbContext = new ShopNoirContext())
            {
                // Tìm sản phẩm theo productColorId
                var productColor = _dbContext.ProductColors
                .Include(pc => pc.Product) // Bao gồm thông tin sản phẩm
                .FirstOrDefault(pc => pc.Id == productColorId);

                if (productColor != null)
                {
                    // Tạo và hiển thị form AddNewProduct
                    AddNewProduct AddNewColorForm = new AddNewProduct(productColor.Id, 'S');
                    AddNewColorForm.ShowDialog(); // Hiển thị như một dialog để chờ người dùng đóng form này
                    if (!loadWorker.IsBusy)
                    {
                        loadWorker.RunWorkerAsync();
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm để chỉnh sửa.", productColorId.ToString());
                }
            }
        }
        private void EditProduct(Guid productColorId)
        {
            using (var _dbContext = new ShopNoirContext())
            {
                // Tìm sản phẩm theo productColorId
                var productColor = _dbContext.ProductColors
                .Include(pc => pc.Product) // Bao gồm thông tin sản phẩm
                .FirstOrDefault(pc => pc.Id == productColorId);

                if (productColor != null)
                {
                    // Tạo và hiển thị form AddNewProduct
                    AddNewProduct editForm = new AddNewProduct(false, productColor.Id);
                    editForm.ShowDialog(); // Hiển thị như một dialog để chờ người dùng đóng form này
                    if (!loadWorker.IsBusy)
                    {
                        loadWorker.RunWorkerAsync();
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm để chỉnh sửa.", productColorId.ToString());
                }
            }
        }

        private void DeleteProduct(Guid productColorId)
        {
            using (var _dbContext = new ShopNoirContext())
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    // Retrieve the ProductColor entry to delete
                    var productColor = _dbContext.ProductColors
                        .FirstOrDefault(pc => pc.Id == productColorId);

                    if (productColor != null)
                    {
                        // Remove the ProductColor entry only
                        _dbContext.ProductColors.Remove(productColor);
                        _dbContext.SaveChanges();

                        // Refresh the product list in the UI
                        if (!loadWorker.IsBusy)
                        {
                            loadWorker.RunWorkerAsync();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private async void btn_previous_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                if (!loadWorker.IsBusy)
                {
                    currentPage--;
                    loadWorker.RunWorkerAsync();
                }
            }
        }

        private async void btn_next_Click(object sender, EventArgs e)
        {
            if (currentPage < Math.Ceiling((double)totalRecords / PageSize))
            {
                if (!loadWorker.IsBusy)
                {
                    currentPage++;
                    loadWorker.RunWorkerAsync();
                }
            }
        }

        private async void scrb_price_Scroll(object sender, ScrollEventArgs e)
        {
            lbl_priceFilter.Text = $"Price: ${scrb_price.Value}";
            _timer.Stop();
            await Task.Delay(TimerInterval); // Delay before restarting to avoid rapid calls
            currentPage = 1;
            _timer.Start();
        }


        private async void tbx_search_TextChanged(object sender, EventArgs e)
        {
            _timer.Stop();
            currentPage = 1;
            currentPage = 1;
            _timer.Start();
        }

        private async void tbx_inventory_TextChanged(object sender, EventArgs e)
        {
            _timer.Stop();
            currentPage = 1;
            currentPage = 1;
            _timer.Start();
        }
        private void btn_reset_Click(object sender, EventArgs e)
        {
            _timer.Stop();
            currentPage = 1;
            tbx_inventory.Clear();
            tbx_search.Clear();
            scrb_price.Value = 1000;
            resetSizeOfProductColor(btn_all);
            selectedSize = null;
            currentType = null;
            resetButtonTypeFilter();
            btn_allSize.ForeColor = Color.Pink;
            btn_allSize.BackColor = Color.DarkSlateGray;
            _timer.Start();
        }

        private void resetButtonTypeFilter()
        {
            btn_newcollection.ForeColor = Color.Black;
            btn_newcollection.BackColor = SystemColors.ControlLightLight;

            btn_bag.ForeColor = Color.Black;
            btn_bag.BackColor = SystemColors.ControlLightLight;

            btn_jacket.ForeColor = Color.Black;
            btn_jacket.BackColor = SystemColors.ControlLightLight;

            btn_all.ForeColor = Color.Black;
            btn_all.BackColor = SystemColors.ControlLightLight;
        }
        private async void btn_bag_Click(object sender, EventArgs e)
        {
            resetButtonTypeFilter();
            btn_bag.ForeColor = Color.Pink;
            btn_bag.BackColor = Color.DarkSlateGray;
            currentType = "Bag"; // Đặt loại sản phẩm là 'bag'
            currentPage = 1; // Quay lại trang đầu
            if (!loadWorker.IsBusy)
            {
                loadWorker.RunWorkerAsync();
            }
        }

        private async void btn_jacket_Click(object sender, EventArgs e)
        {
            resetButtonTypeFilter();
            btn_jacket.ForeColor = Color.Pink;
            btn_jacket.BackColor = Color.DarkSlateGray;
            currentType = "Jacket"; // Đặt loại sản phẩm là 'jacket'
            currentPage = 1; // Quay lại trang đầu
            if (!loadWorker.IsBusy)
            {
                loadWorker.RunWorkerAsync();
            }
        }

        private async void btn_newcollection_Click(object sender, EventArgs e)
        {
            resetButtonTypeFilter();
            btn_newcollection.ForeColor = Color.Pink;
            btn_newcollection.BackColor = Color.DarkSlateGray;
            currentType = "New Collection"; // select tất cả các sản phẩm
            currentPage = 1; // Quay lại trang đầu
            if (!loadWorker.IsBusy)
            {
                loadWorker.RunWorkerAsync();
            }
        }

        private async void btn_all_Click(object sender, EventArgs e)
        {
            resetButtonTypeFilter();
            btn_all.ForeColor = Color.Pink;
            btn_all.BackColor = Color.DarkSlateGray;
            currentType = null; // Đặt loại sản phẩm là 'null' => chon tat ca
            currentPage = 1; // Quay lại trang đầu
            if (!loadWorker.IsBusy)
            {
                loadWorker.RunWorkerAsync();
            }
        }
        private void llbl_addnewproduct_LinkClicked(object sender, EventArgs e)
        {
            using (var _dbContext = new ShopNoirContext())
            {
                AddNewProduct newForm = new AddNewProduct(true, Guid.NewGuid());
                newForm.ShowDialog(); // Hiển thị như một dialog để chờ người dùng đóng form này
                if (!loadWorker.IsBusy)
                {
                    loadWorker.RunWorkerAsync();
                }
            }
        }

        private async Task<List<ProductInfomation>> FetchProducts()
        {
            using (var _dbContext = new ShopNoirContext())
            {
                // Lấy giá trị từ các trường
                string searchTerm = tbx_search.Text.Trim().ToLower();
                int inventoryThreshold = string.IsNullOrEmpty(tbx_inventory.Text) ? int.MaxValue : int.Parse(tbx_inventory.Text);
                decimal priceLimit = scrb_price.Value;

                //Truy vấn lấy tất cả các product color và size 
                var productColorQuery = _dbContext.ProductColors
                    .Include(p => p.Product)
                    .Where(pc => pc.Inventory < inventoryThreshold
                    && pc.Product.ProdName.ToLower().Contains(searchTerm)
                    && pc.Product.Price < priceLimit);

                if (!string.IsNullOrEmpty(currentType))
                {
                    // Nếu currentType không rỗng, thêm điều kiện lọc theo loại sản phẩm
                    //productQuery = productQuery.Where(p => p.Type == currentType);
                    productColorQuery = productColorQuery.Where(pc => pc.Product.Type == currentType);
                }
                if (!string.IsNullOrEmpty(selectedSize))
                {
                    // Nếu currentType không rỗng, thêm điều kiện lọc theo loại sản phẩm
                    //productQuery = productQuery.Where(p => p.Type == currentType);
                    productColorQuery = productColorQuery.Where(pc => pc.Size == selectedSize);
                }

                totalRecords = productColorQuery.Count();
                if (lbl_page.InvokeRequired)
                {
                    lbl_page.Invoke((MethodInvoker)delegate
                    {
                        lbl_page.Text = $"Page {currentPage} / {Math.Ceiling((double)totalRecords / PageSize)}";
                        btn_previous.Enabled = currentPage > 1;
                        btn_next.Enabled = currentPage < Math.Ceiling((double)totalRecords / PageSize);
                    });
                }
                else
                {
                    lbl_page.Text = $"Page {currentPage} / {Math.Ceiling((double)totalRecords / PageSize)}";
                    btn_previous.Enabled = currentPage > 1;
                    btn_next.Enabled = currentPage < Math.Ceiling((double)totalRecords / PageSize);
                }
                return await productColorQuery
                    .OrderByDescending(pc => pc.Product.ProdName) // Sắp xếp theo giá giảm dần
                    .Select(pc => new ProductInfomation
                    {
                        Id = pc.Id,
                        Inventory = pc.Inventory,
                        ColorName = pc.ColorName,
                        ImageUrl = pc.ImageUrl,
                        ColorCode = pc.ColorCode,
                        ProductId = pc.ProductId,
                        Size = pc.Size,
                        ProdName = pc.Product.ProdName,
                        Price = pc.Product.Price,
                        Wid = (decimal)pc.Product.Width,
                        Hei = (decimal)pc.Product.Height,
                        Type = pc.Product.Type,
                    })
                    .AsNoTracking()
                    .Skip((currentPage - 1) * PageSize)
                    .Take(PageSize)
                    .ToListAsync();
            }
        }

        private void loadWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            // Cập nhật giá trị ProgressBar
            progressBar1.Value = e.ProgressPercentage;
        }

        private void loadWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            // Ẩn ProgressBar khi hoàn thành
            progressBar1.Visible = false;

            // Kiểm tra lỗi hoặc huỷ bỏ
            if (e.Cancelled)
            {
                MessageBox.Show("Tải dữ liệu bị hủy bỏ.");
                return;
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + e.Error.Message);
                return;
            }

        }

        private void loadWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // Cập nhật ProgressBar.visible từ DoWork
            this.Invoke((MethodInvoker)delegate
            {
                progressBar1.Visible = true;
                pnl_product.Controls.Clear();
            });

            try
            {
                // Fetch products asynchronously
                var productInformation = FetchProducts().Result; // Await FetchProducts method
                int progress = 0;

                int x = 10, y = 10;
                const int padding = 20;

                foreach (var product in productInformation)
                {
                    var productPanel = CreateProductPanel(product, x, y);
                    this.Invoke((MethodInvoker)delegate
                    {
                        pnl_product.Controls.Add(productPanel);
                    });

                    x += productPanel.Width + padding;
                    if (x + productPanel.Width > pnl_product.Width)
                    {
                        x = 10;
                        y += productPanel.Height + padding;
                    }
                    progress++;

                    // Báo cáo tiến độ
                    int percentComplete = (int)((double)progress / productInformation.Count * 100);
                    loadWorker.ReportProgress(percentComplete);
                }
            }
            catch (Exception ex)
            {
                //Do nothing =))
            }
        }

        private void resetSizeOfProductColor(System.Windows.Forms.Button sizeButton)
        {
            btn_allSize.BackColor = Color.White;
            btn_xs.BackColor = Color.White;
            btn_s.BackColor = Color.White;
            btn_m.BackColor = Color.White;
            btn_l.BackColor = Color.White;
            btn_xl.BackColor = Color.White;
            btn_xxl.BackColor = Color.White;
            btn_xxxl.BackColor = Color.White;

            btn_allSize.ForeColor = Color.Black;
            btn_xs.ForeColor = Color.Black;
            btn_s.ForeColor = Color.Black;
            btn_m.ForeColor = Color.Black;
            btn_l.ForeColor = Color.Black;
            btn_xl.ForeColor = Color.Black;
            btn_xxl.ForeColor = Color.Black;
            btn_xxxl.ForeColor = Color.Black;

            sizeButton.ForeColor = Color.AliceBlue;
            sizeButton.BackColor = Color.DarkSeaGreen;

            // Gán giá trị của enum dựa trên nút đã chọn
            selectedSize = sizeButton.Text;
        }

        private void btn_xs_Click(object sender, EventArgs e)
        {
            resetSizeOfProductColor(btn_xs);
            if (!loadWorker.IsBusy)
            {
                loadWorker.RunWorkerAsync();
            }
        }

        private void btn_s_Click(object sender, EventArgs e)
        {
            resetSizeOfProductColor(btn_s);
            if (!loadWorker.IsBusy)
            {
                loadWorker.RunWorkerAsync();
            }
        }

        private void btn_m_Click(object sender, EventArgs e)
        {
            resetSizeOfProductColor(btn_m);
            if (!loadWorker.IsBusy)
            {
                loadWorker.RunWorkerAsync();
            }
        }

        private void btn_l_Click(object sender, EventArgs e)
        {
            resetSizeOfProductColor(btn_l);
            if (!loadWorker.IsBusy)
            {
                loadWorker.RunWorkerAsync();
            }
        }

        private void btn_xl_Click(object sender, EventArgs e)
        {
            resetSizeOfProductColor(btn_xl);
            if (!loadWorker.IsBusy)
            {
                loadWorker.RunWorkerAsync();
            }
        }

        private void btn_xxl_Click(object sender, EventArgs e)
        {
            resetSizeOfProductColor(btn_xxl);
            if (!loadWorker.IsBusy)
            {
                loadWorker.RunWorkerAsync();
            }
        }

        private void btn_3xl_Click(object sender, EventArgs e)
        {
            resetSizeOfProductColor(btn_xxxl);
            if (!loadWorker.IsBusy)
            {
                loadWorker.RunWorkerAsync();
            }
        }

        private void btn_allSize_Click(object sender, EventArgs e)
        {
            resetSizeOfProductColor(btn_all);
            selectedSize = null;
            if (!loadWorker.IsBusy)
            {
                loadWorker.RunWorkerAsync();
            }
        }
    }
}

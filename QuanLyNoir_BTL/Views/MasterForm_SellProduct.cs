using Microsoft.EntityFrameworkCore;
using QuanLyNoir_BTL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyNoir_BTL.Views
{
    public partial class MasterForm_SellProduct : Form
    {
        private List<KeyValuePair<ProductInfomation, int>> cartList = new List<KeyValuePair<ProductInfomation, int>>();
        private decimal totalMoney = 0; // Tổng số tiền cảu hóa đơn
        private string currentType = null;
        private int currentPage = 1;
        private const int PageSize = 10; // Giữ số lượng bản ghi trên mỗi trang là 8
        private int totalRecords;
        private Guid staffId;

        private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        private const int TimerInterval = 500; // Thời gian chờ 500ms
        public MasterForm_SellProduct(Guid userId, string username)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            lbl_name.Text = username;
            staffId = userId;
            lbl_datetime.Text = DateTime.Now.ToLongDateString();

            // Cấu hình Timer
            _timer.Interval = TimerInterval; // Thay đổi thời gian nếu cần
            _timer.Tick += Timer_Tick; // Đăng ký sự kiện
            this.AutoSize = false;
        }

        private void MasterForm_SellProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // Phần code Logic và truy vấn
        private async Task<List<ProductInfomation>> FetchProducts()
        {
            using (var _dbContext = new ShopNoirContext())
            {
                // Lấy giá trị từ các trường
                string searchTerm = tbx_search.Text.Trim().ToLower();
                //Truy vấn lấy tất cả các product color và size 
                IQueryable<ProductColor> productColorQuery = _dbContext.ProductColors;

                if (searchTerm != "")
                {
                    productColorQuery = productColorQuery
                    .Where(pc => EF.Functions.Like(pc.Product.ProdName, $"%{searchTerm}%"));
                }

                if (!string.IsNullOrEmpty(currentType))
                {
                    // Nếu currentType không rỗng, thêm điều kiện lọc theo loại sản phẩm
                    productColorQuery = productColorQuery.Where(pc => pc.Product.Type == currentType);
                }
                // Cập nhật phân trang trong luồng khác
                await UpdatePaginationAsync(productColorQuery);

                return await productColorQuery
                    .OrderBy(p => p.Product.ProdName)
                    .Select(pc => new ProductInfomation
                    {
                        Id = pc.Id,
                        TotalInventory = pc.ProductColorSizes.Sum(pcs => pcs.Inventory),
                        ColorName = pc.ColorName,
                        ImageUrl = pc.ImageUrl,
                        ColorCode = pc.ColorCode,
                        ProductId = pc.ProductId,
                        Size = string.Join(", ", pc.ProductColorSizes.Select(pcs => pcs.SizeId)),
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
                if (productInformation.Count <= 0)
                {
                    Label lbl_empty = new Label
                    {
                        Text = "Empty",
                        Font = new Font("Arial", 20, FontStyle.Bold),
                        ForeColor = Color.Gray,
                        Location = new Point(450, 280),
                        AutoSize = true
                    };
                    this.Invoke((MethodInvoker)delegate
                    {
                        pnl_product.Controls.Add(lbl_empty);
                    });
                }
                else
                {
                    foreach (var product in productInformation)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            AddProductToFlowLayout(product, pnl_product);
                        });

                        progress++;

                        // Báo cáo tiến độ
                        int percentComplete = (int)((double)progress / productInformation.Count * 100);
                        loadWorker.ReportProgress(percentComplete);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        // Phần code để cập nhật giao diện, hiệu ứng, click chuột, ... : 
        private void btn_previous_Click(object sender, EventArgs e)
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
        private async Task UpdatePaginationAsync(IQueryable<ProductColor> productColorQuery)
        {
            totalRecords = await productColorQuery.CountAsync(); // Đếm số lượng bản ghi

            // Cập nhật giao diện trên luồng giao diện chính (UI thread)
            Invoke((MethodInvoker)delegate
            {
                lbl_page.Text = $"Page {currentPage} / {Math.Ceiling((double)totalRecords / PageSize)}";
                btn_previous.Enabled = currentPage > 1;
                btn_next.Enabled = currentPage < Math.Ceiling((double)totalRecords / PageSize);
            });
        }
        private void btn_next_Click(object sender, EventArgs e)
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
        private void tbx_search_TextChanged(object sender, EventArgs e)
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
            tbx_search.Clear();
            currentType = null;
            updateEffectClickedButton(btn_all);
            _timer.Start();
        }
        private void btn_signout_Click(object sender, EventArgs e)
        {
            SignIn signInForm = new SignIn();
            signInForm.Show();
            this.Hide(); // Ẩn form đăng nhập
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
        private void updateEffectClickedButton(System.Windows.Forms.Button btn)
        {
            resetButtonTypeFilter();
            btn.BackColor = Color.DarkSlateGray;
            btn.ForeColor = Color.Pink;
        }
        private void btn_bag_Click(object sender, EventArgs e)
        {
            resetButtonTypeFilter();
            updateEffectClickedButton(btn_bag);
            currentType = "Bag"; // Đặt loại sản phẩm là 'bag'
            currentPage = 1; // Quay lại trang đầu
            if (!loadWorker.IsBusy)
            {
                loadWorker.RunWorkerAsync();
            }
        }

        private void btn_jacket_Click(object sender, EventArgs e)
        {
            updateEffectClickedButton(btn_jacket);
            currentType = "Jacket"; // Đặt loại sản phẩm là 'jacket'
            currentPage = 1; // Quay lại trang đầu
            if (!loadWorker.IsBusy)
            {
                loadWorker.RunWorkerAsync();
            }
        }

        private void btn_newcollection_Click(object sender, EventArgs e)
        {
            updateEffectClickedButton(btn_newcollection);
            currentType = "New Collection"; // select tất cả các sản phẩm
            currentPage = 1; // Quay lại trang đầu
            if (!loadWorker.IsBusy)
            {
                loadWorker.RunWorkerAsync();
            }
        }

        private void btn_all_Click(object sender, EventArgs e)
        {
            updateEffectClickedButton(btn_all);
            currentType = null; // Đặt loại sản phẩm là 'null' => chon tat ca
            currentPage = 1; // Quay lại trang đầu
            if (!loadWorker.IsBusy)
            {
                loadWorker.RunWorkerAsync();
            }
        }

        // Phần code cài đặt cấu hình:
        private void AddProductToFlowLayout(dynamic product, FlowLayoutPanel flowLayoutPanel)
        {
            // Tạo panel sản phẩm
            Panel productPanel = new Panel
            {
                Width = 220,
                Height = 320,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10)
            };

            // Tên sản phẩm
            Label lblName = new Label
            {
                Text = product.ProdName,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };

            // Hình ảnh sản phẩm
            PictureBox picImage = new PictureBox
            {
                Size = new System.Drawing.Size(160, 160),
                Location = new Point(30, 40),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            if (!string.IsNullOrEmpty(product.ImageUrl) && File.Exists(product.ImageUrl))
            {
                // Tải hình ảnh sản phẩm trong background
                Task.Run(() =>
                {
                    try
                    {
                        var image = Image.FromFile(product.ImageUrl);
                        picImage.Image = image;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi tải hình ảnh: {ex.Message}");
                    }
                });
            }

            // Giá sản phẩm
            Label lblPrice = new Label
            {
                Text = $"Price: ${product.Price:F2}",
                Location = new Point(10, 210),
                AutoSize = true
            };

            // Kích thước sản phẩm
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

            // Màu sản phẩm
            Panel colorPanel = new Panel
            {
                Size = new System.Drawing.Size(20, 20),
                Location = new Point(15, 270),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = product.ColorCode != null ? ColorTranslator.FromHtml(product.ColorCode) : Color.Transparent
            };

            Label lblColor = new Label
            {
                Text = $"Color: {product.ColorName}",
                Location = new Point(40, 270),
                AutoSize = true
            };

            // Tồn kho
            Label lblInventory = new Label
            {
                Text = $"Inventory: {product.TotalInventory} items",
                Location = new Point(10, 300),
                AutoSize = true
            };

            // Gán sự kiện nhấn chuột trái vào panel để hiển thị TakingProductForm
            productPanel.MouseClick += (s, e) =>
            {
                if (e.Button == MouseButtons.Left) // Chỉ xử lý khi nhấn chuột trái
                {
                    if (product.TotalInventory <= 0)
                    {
                        MessageBox.Show("This product is sold out!!");
                    }
                    else
                    {
                        // Tạo và hiển thị form TakingProductForm
                        TakingProductForm form = new TakingProductForm(product);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            Task.Run(() => AddProductToCart(new KeyValuePair<ProductInfomation, int>(form.product, form.amount)));
                        }
                    }

                }
            };

            // Thêm các control vào panel
            productPanel.Controls.Add(lblName);
            productPanel.Controls.Add(picImage);
            productPanel.Controls.Add(lblPrice);
            productPanel.Controls.Add(lblSize);
            productPanel.Controls.Add(colorPanel);
            productPanel.Controls.Add(lblColor);
            productPanel.Controls.Add(lblInventory);
            productPanel.Cursor = Cursors.Hand;
            // Thêm panel sản phẩm vào FlowLayoutPanel
            flowLayoutPanel.Controls.Add(productPanel);
        }
        private void AddProductToCart(KeyValuePair<ProductInfomation, int> productPair)
        {
            ProductInfomation product = productPair.Key;
            totalMoney += product.Price * productPair.Value;
            cartList.Add(productPair);
            // Tạo panel sản phẩm
            Panel productPanel = new Panel
            {
                Width = 400,
                Height = 100,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            // Tên sản phẩm
            Label lblName = new Label
            {
                Text = product.ProdName + " x" + productPair.Value.ToString(),
                Font = new Font("Arial", 11, FontStyle.Bold),
                Location = new Point(100, 10),
                AutoSize = true
            };

            // Hình ảnh sản phẩm
            PictureBox picImage = new PictureBox
            {
                Size = new System.Drawing.Size(100, 100),
                Location = new Point(0, 0),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            if (!string.IsNullOrEmpty(product.ImageUrl) && File.Exists(product.ImageUrl))
            {
                // Tải hình ảnh sản phẩm trong background
                Task.Run(() =>
                {
                    try
                    {
                        var image = Image.FromFile(product.ImageUrl);
                        picImage.Image = image;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi tải hình ảnh: {ex.Message}");
                    }
                });
            }

            // Giá sản phẩm
            Label lblPrice = new Label
            {
                Text = $"Price: ${product.Price:F2} x{productPair.Value} = {product.Price * productPair.Value}",
                Location = new Point(100, 40),
                AutoSize = true
            };

            // Kích thước sản phẩm
            Label lblSize = new Label
            {
                Location = new Point(130, 70),
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

            // Màu sản phẩm
            Panel colorPanel = new Panel
            {
                Size = new System.Drawing.Size(20, 20),
                Location = new Point(100, 70),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = product.ColorCode != null ? ColorTranslator.FromHtml(product.ColorCode) : Color.Transparent
            };

            Button kickButton = new Button
            {
                Size = new System.Drawing.Size(30, 30),
                Location = new Point(370, 0),
                Text = "X",

            };

            kickButton.Click += (s, e) =>
            {
                // Xóa panel chứa nút kickButton
                flpnl_cart.Controls.Remove(productPanel);

                // Cập nhật lại tổng tiền
                totalMoney -= product.Price * productPair.Value;
                cartList.Remove(productPair);

                // Cập nhật giao diện hiển thị tổng tiền
                lbl_totalMoney.Text = "Total Money: " + totalMoney.ToString("F2") + "$";
            };

            // Thêm các control vào panel
            productPanel.Controls.Add(lblName);
            productPanel.Controls.Add(picImage);
            productPanel.Controls.Add(lblPrice);
            productPanel.Controls.Add(lblSize);
            productPanel.Controls.Add(colorPanel);
            productPanel.Controls.Add(kickButton);
            kickButton.BringToFront();
            this.Invoke((MethodInvoker)delegate
            {
                // Thêm panel sản phẩm vào FlowLayoutPanel
                flpnl_cart.Controls.Add(productPanel);
                lbl_totalMoney.Text = "Total Money: " + totalMoney.ToString() + "$";
            });
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

        private void MasterForm_SellProduct_Load(object sender, EventArgs e)
        {
            if (!loadWorker.IsBusy)
            {
                loadWorker.RunWorkerAsync();
            }
        }

        private void btn_checkout_Click(object sender, EventArgs e)
        {
            ConfirmForm confirmForm = new ConfirmForm(cartList, totalMoney, staffId);
            if (confirmForm.ShowDialog() == DialogResult.OK)
            {
                flpnl_cart.Controls.Clear();
                lbl_totalMoney.Text = "Total Money: ";
            }
            //cartList.Clear();
        }
    }
}

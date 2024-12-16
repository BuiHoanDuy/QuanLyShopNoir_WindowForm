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

namespace QuanLyNoir_BTL.Views
{
    public partial class ConfirmForm : Form
    {
        private List<KeyValuePair<ProductInfomation, int>> cartList;
        decimal totalBill; Guid staffId;
        decimal newTotalBill; // Giá trị của bill sau khi áp dụng voucher
        public ConfirmForm(List<KeyValuePair<ProductInfomation, int>> cartList, decimal totalBill, Guid staffId)
        {
            InitializeComponent();
            this.cartList = cartList;
            this.totalBill = totalBill;
            this.staffId = staffId;
            newTotalBill = totalBill;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        public async Task SaveInvoiceAsync()
        {
            // 1. Tạo đối tượng hóa đơn mới
            var invoice = new Invoice
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                Total = newTotalBill,  // Tính tổng hóa đơn
                PaymentMethod = cbbx_paymentMethod.Text,
                CreatedBy = staffId,  // ID của người tạo hóa đơn (ví dụ, người dùng đang đăng nhập)
            };

            // 2. Thêm các chi tiết hóa đơn (InvoiceDetail)
            using (var _context = new ShopNoirContext())
            {
                foreach (var item in cartList)
                {
                    var productInfo = item.Key;
                    var quantity = item.Value;

                    // Tìm ProductColorSize dựa trên ProductId và Size
                    var productColorSize = await _context.ProductColorSizes
                        .FirstOrDefaultAsync(pcs => pcs.ProductColorId == productInfo.Id && pcs.SizeId == productInfo.Size);

                    if (productColorSize != null)
                    {
                        var invoiceDetail = new InvoiceDetail
                        {
                            InvoiceId = invoice.Id,  // Liên kết với hóa đơn
                            ProductColorSizeId = productColorSize.Id,
                            Amount = quantity,
                            Price = quantity * productInfo.Price  // Giá của sản phẩm
                        };

                        invoice.InvoiceDetails.Add(invoiceDetail);  // Thêm vào danh sách InvoiceDetails
                    }
                }

                // 3. Lưu hóa đơn vào cơ sở dữ liệu
                _context.Invoices.Add(invoice);
                await _context.SaveChangesAsync();  // Lưu hóa đơn và các chi tiết hóa đơn vào database
            }
        }

        public async Task UpdateProductStockAsync()
        {
            using (var _context = new ShopNoirContext())
            {
                foreach (var item in cartList)
                {
                    var productInfo = item.Key;
                    var quantity = item.Value;

                    // Tìm ProductColorSize tương ứng
                    var productColorSize = await _context.ProductColorSizes
                        .FirstOrDefaultAsync(pcs => pcs.ProductColorId == productInfo.Id && pcs.SizeId == productInfo.Size);

                    if (productColorSize != null)
                    {
                        // Giảm số lượng tồn kho
                        productColorSize.Inventory -= quantity;
                    }
                }

                // Lưu thay đổi vào cơ sở dữ liệu
                await _context.SaveChangesAsync();
            }
        }

        private void ConfirmForm_Load(object sender, EventArgs e)
        {
            lbl_totalBill.Text = $"Total Bill: {totalBill}$";
            VoucherLoad();
            foreach (var item in cartList)
            {
                AddProductToCart(item);
            }
            cbbx_moneyReceive.SelectedIndex = 0;
            cbbx_paymentMethod.SelectedIndex = 0;
        }
        private void AddProductToCart(KeyValuePair<ProductInfomation, int> productPair)
        {
            ProductInfomation product = productPair.Key;
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

            // Thêm các control vào panel
            productPanel.Controls.Add(lblName);
            productPanel.Controls.Add(picImage);
            productPanel.Controls.Add(lblPrice);
            productPanel.Controls.Add(lblSize);
            productPanel.Controls.Add(colorPanel);
            this.Invoke((MethodInvoker)delegate
            {
                // Thêm panel sản phẩm vào FlowLayoutPanel
                flpnl_cart.Controls.Add(productPanel);
            });
        }
        private void VoucherLoad()
        {
            using (var _context = new ShopNoirContext())
            {
                List<Voucher> voucherList = _context.Vouchers
                    .Where(v => v.StartDate < DateOnly.FromDateTime(DateTime.Today)
                    && v.EndDate > DateOnly.FromDateTime(DateTime.Today)
                    && v.Status == true
                    && v.UsedCount <= v.MaxUsage
                    )
                    .ToList();
                // Thêm từng voucher vào ComboBox
                foreach (var voucher in voucherList)
                {
                    cbbx_voucher.Items.Add(voucher.Code); // Hoặc bất kỳ thuộc tính nào bạn muốn hiển thị
                }
            }
        }

        private void cbbx_paymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbx_paymentMethod.SelectedIndex == 0)
            {
                cbbx_moneyReceive.Enabled = true;
                tbx_refund.Text = (newTotalBill - decimal.Parse(cbbx_moneyReceive.Text) == null ? 0 : decimal.Parse(cbbx_moneyReceive.Text)).ToString();
            }
            else
            {
                cbbx_moneyReceive.Enabled = false;
                tbx_refund.Text = string.Empty;
            }
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            Checkout();
            DialogResult = DialogResult.OK;
            this.Close();
        }
        public async void Checkout()
        {
            // Lưu đơn hàng và chi tiết hóa đơn
            await SaveInvoiceAsync();

            // Cập nhật tồn kho
            await UpdateProductStockAsync();

            MessageBox.Show("Successfully!!!");
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void cbbx_voucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadVoucher(cbbx_voucher.Text);
        }
        private async Task LoadVoucher(string VoucherCode)
        {
            using (var _context = new ShopNoirContext())
            {
                Voucher voucher = await _context.Vouchers
                .FirstOrDefaultAsync(v => v.StartDate < DateOnly.FromDateTime(DateTime.Today)
                && v.EndDate > DateOnly.FromDateTime(DateTime.Today)
                && v.Status == true
                && v.UsedCount <= v.MaxUsage
                && v.Code.Equals(VoucherCode)
                );
                if (totalBill < voucher.MinOrderValue)
                {
                    MessageBox.Show("The current bill's value is less than the minimum one to use!!", "Error");
                    return;
                }
                this.Invoke((MethodInvoker)delegate
                {
                    if (voucher.DiscountType == "P")
                    {
                        newTotalBill = totalBill * (1 - voucher.DiscountValue);
                        lbl_totalBill.Text = $"Total Bill: {totalBill}$ - {totalBill * voucher.DiscountValue}$ = {newTotalBill}$";
                    }
                    else
                    {
                        newTotalBill = totalBill - voucher.DiscountValue;
                        lbl_totalBill.Text = $"Total Bill: {totalBill}$ - {voucher.DiscountValue}$ = {newTotalBill}$";
                    }
                });
                return;
            }
        }

        private void cbbx_moneyReceive_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}

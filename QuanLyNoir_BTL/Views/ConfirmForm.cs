using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using QuanLyNoir_BTL.Models;
using System.Data;



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
            if (cartList == null || !cartList.Any())
            {
                MessageBox.Show("The cart is empty!", "Error");
                return;
            }

            if (string.IsNullOrEmpty(cbbx_paymentMethod.Text))
            {
                MessageBox.Show("Please select a payment method!", "Error");
                return;
            }

            var voucherId = await getVoucherIdForSave(cbbx_voucher.Text);
            var invoice = new Invoice
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                Total = newTotalBill,
                PaymentMethod = cbbx_paymentMethod.Text,
                CreatedBy = staffId,
            };
            if (voucherId != Guid.Empty)
            {
                invoice.VoucherId = voucherId;
            }
            try
            {
                using (var _context = new ShopNoirContext())
                {
                    _context.ChangeTracker.Clear(); // Xóa trạng thái theo dõi
                    var productColorSizes = await _context.ProductColorSizes
                        .Where(pcs => cartList.Select(c => c.Key.Id).Contains(pcs.ProductColorId))
                        .ToListAsync();

                    foreach (var item in cartList)
                    {
                        var productInfo = item.Key;
                        var quantity = item.Value;

                        var productColorSize = productColorSizes
                            .FirstOrDefault(pcs => pcs.ProductColorId == productInfo.Id && pcs.SizeId == productInfo.Size);

                        if (productColorSize != null)
                        {
                            if (!invoice.InvoiceDetails.Any(d => d.ProductColorSizeId == productColorSize.Id))
                            {
                                var invoiceDetail = new InvoiceDetail
                                {
                                    InvoiceId = invoice.Id,
                                    ProductColorSizeId = productColorSize.Id,
                                    Amount = quantity,
                                    Price = quantity * productInfo.Price
                                };

                                invoice.InvoiceDetails.Add(invoiceDetail);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"ProductColorSize not found for product {productInfo.Id} and size {productInfo.Size}", "Error");
                            cartList.Clear();
                            totalBill = 0;
                            return;
                        }
                    }

                    _context.Invoices.Add(invoice);
                    await _context.SaveChangesAsync();

                    MessageBox.Show("Invoice saved successfully!", "Success");
                }
        }
            catch (Exception ex)
            {
                cartList.Clear();
                totalBill = 0;
                MessageBox.Show($"Error saving invoice: {ex.Message}", "Error");
            }
}
        public async Task<Guid> getVoucherIdForSave(string voucherCode)
        {
            using (var _context = new ShopNoirContext())
            {
                Voucher voucher = await _context.Vouchers
                .FirstOrDefaultAsync(v => v.StartDate <= DateOnly.FromDateTime(DateTime.Today)
                && v.EndDate >= DateOnly.FromDateTime(DateTime.Today)
                && v.Status == true
                && v.UsedCount <= v.MaxUsage
                && v.Code.Equals(voucherCode)
                );
                if (voucher == null)
                {
                    return Guid.Empty;
                }
                return voucher.Id;
            }
        }

        public async Task UpdateVoucherUsage(string voucherCode)
        {
            using (var _context = new ShopNoirContext())
            {
                Voucher voucher = await _context.Vouchers
                .FirstOrDefaultAsync(v => v.StartDate < DateOnly.FromDateTime(DateTime.Today)
                && v.EndDate > DateOnly.FromDateTime(DateTime.Today)
                && v.Status == true
                && v.UsedCount <= v.MaxUsage
                && v.Code.Equals(voucherCode)
                );
                if (voucher == null)
                {
                    return;
                }

                voucher.UsedCount += 1;
                // Lưu thay đổi vào cơ sở dữ liệu
                await _context.SaveChangesAsync();
                return;
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
                    .Where(v => v.StartDate <= DateOnly.FromDateTime(DateTime.Today)
                    && v.EndDate >= DateOnly.FromDateTime(DateTime.Today)
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

            // Cập nhật số lựng đã sử dụng của voucher
            await UpdateVoucherUsage(cbbx_voucher.Text);
            cartList.Clear();
            totalBill = 0;
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
                .FirstOrDefaultAsync(v => v.StartDate <= DateOnly.FromDateTime(DateTime.Today)
                && v.EndDate >= DateOnly.FromDateTime(DateTime.Today)
                && v.Status == true
                && v.UsedCount <= v.MaxUsage
                && v.Code.Equals(VoucherCode)
                );
                if (voucher == null)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        newTotalBill = totalBill;
                        lbl_totalBill.Text = $"Total Bill: {totalBill}$";
                        cbbx_voucher.ForeColor = Color.Black;
                        cbbx_voucher.Font = new Font("Segoe UI Semibold", 9, FontStyle.Regular);
                    });
                    return;
                }
                this.Invoke((MethodInvoker)delegate
                {
                    cbbx_voucher.ForeColor = Color.Red;
                    cbbx_voucher.Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
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
                if (voucher.MinOrderValue.HasValue && totalBill < voucher.MinOrderValue)
                {
                    MessageBox.Show("The current bill's value is less than the minimum one to use!!");
                    return;
                }
                return;
            }
        }


        private void cbbx_moneyReceive_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tbx_refund.Text = (decimal.Parse(cbbx_moneyReceive.Text) == null ? 0 : (decimal.Parse(cbbx_moneyReceive.Text) - newTotalBill)).ToString();
            }
            catch (Exception ex)
            {
                tbx_refund.Text = "0";
            }

        }

        private void ConfirmForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}

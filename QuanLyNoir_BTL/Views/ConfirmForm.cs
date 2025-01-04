using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using QuanLyNoir_BTL.Models;
using System.Data;
using System.Drawing.Printing;
using System.Reflection.Metadata;
using System.Windows.Documents;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using PdfiumViewer;
using System.IO;
using System.Drawing.Printing;
using System.Diagnostics;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Layout.Properties;
using iText.Kernel.Colors;
using PdfDocument = iText.Kernel.Pdf.PdfDocument;
using Document = iText.Layout.Document;
using Paragraph = iText.Layout.Element.Paragraph;
using Color = System.Drawing.Color;

namespace QuanLyNoir_BTL.Views
{
    public partial class ConfirmForm : Form
    {
        private List<KeyValuePair<ProductInfomation, int>> cartList;
        decimal totalBill; Guid staffId;
        decimal newTotalBill; // Giá trị của bill sau khi áp dụng voucher
        Guid customerId; //Dùng để cập nhật lại Khách hàng
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

            var voucher = await getVoucherForSave(cbbx_voucher.Text);

            var invoice = new Invoice
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                Total = newTotalBill,
                PaymentMethod = cbbx_paymentMethod.Text,
                CreatedBy = staffId,
            };

            // Xử lý khách hàng
            var cusPhone = tbx_phoneCus.Text;
            var cusName = tbx_nameCus.Text;
            var cusEmail = tbx_emailCus.Text;

            if (!string.IsNullOrEmpty(cusPhone))
            {
                using (var _context = new ShopNoirContext())
                {
                    // Tìm khách hàng theo số điện thoại
                    var existingCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.Phone == cusPhone);

                    if (existingCustomer != null)
                    {
                        // Cập nhật thông tin nếu cần
                        if (!string.IsNullOrEmpty(cusName) && cusName != existingCustomer.Name)
                        {
                            existingCustomer.Name = cusName;
                        }

                        if (!string.IsNullOrEmpty(cusEmail) && cusEmail != existingCustomer.Email)
                        {
                            existingCustomer.Email = cusEmail;
                        }

                        await _context.SaveChangesAsync();
                        invoice.CustomerId = existingCustomer.Id; // Gán ID khách hàng vào hóa đơn
                    }
                    else
                    {
                        // Thêm khách hàng mới nếu không tồn tại
                        var newCustomer = new Customer
                        {
                            Id = Guid.NewGuid(),
                            Name = cusName,
                            Phone = cusPhone,
                            Email = cusEmail,
                        };

                        _context.Customers.Add(newCustomer);
                        await _context.SaveChangesAsync();
                        invoice.CustomerId = newCustomer.Id; // Gán ID khách hàng vào hóa đơn
                    }
                }
            }

            if (voucher != null)
            {
                invoice.VoucherId = voucher.Id;
            }

            try
            {
                using (var _context = new ShopNoirContext())
                {
                    _context.ChangeTracker.Clear(); // Xóa trạng thái theo dõi

                    var productColorSizes = await _context.ProductColorSizes
                        .Where(pcs => cartList.Select(c => c.Key.Id).Contains(pcs.ProductColorId))
                        .Include(pcs => pcs.ProductColor)
                        .ThenInclude(pc => pc.Product)
                        .Include(pcs => pcs.Size)
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
                                    Price = quantity * productInfo.Price,
                                    ProductColorSize = productColorSize,
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

                    if (voucher != null)
                    {
                        invoice.Voucher = voucher;
                    }

                    MessageBox.Show("Invoice saved successfully!", "Success");

                    // Generate the PDF for the invoice
                    var pdfFilePath = GenerateInvoicePdf(invoice);

                    // Optionally, print the PDF after generation
                    OpenPdfWithDefaultViewer(pdfFilePath);
                }
            }
            catch (Exception ex)
            {
                cartList.Clear();
                totalBill = 0;
                MessageBox.Show($"Error saving invoice: {ex.Message}", "Error");
            }
        }

        public void loadCustomer()
        {
            Task.Run(() =>
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (String.IsNullOrEmpty(tbx_phoneCus.Text))
                    {
                        tbx_nameCus.Enabled = false;
                        tbx_emailCus.Enabled = false;
                    }
                    else
                    {
                        using (var _context = new ShopNoirContext())
                        {
                            var customer = _context.Customers.FirstOrDefault(c => c.Phone.Equals(tbx_phoneCus.Text));
                            if (customer != null)
                            {
                                tbx_nameCus.Text = customer.Name;
                                tbx_emailCus.Text = customer.Email;
                                customerId = customer.Id;

                                tbx_nameCus.Enabled = false;
                                tbx_emailCus.Enabled = false;
                            } else
                            {
                                tbx_nameCus.Enabled = true;
                                tbx_emailCus.Enabled = true;
                                customerId = Guid.Empty;
                            }
                        }
                    }
                });
            });
        }
    
        public async Task<Voucher> getVoucherForSave(string voucherCode)
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
                    return null;
                }
                return voucher;
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
                        var image = System.Drawing.Image.FromFile(product.ImageUrl);
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

                if (voucher.MinOrderValue.HasValue && totalBill < voucher.MinOrderValue)
                {
                    MessageBox.Show("The current bill's value is less than the minimum one to use!!");
                    this.Invoke((MethodInvoker)delegate
                    {
                        newTotalBill = totalBill;
                        lbl_totalBill.Text = $"Total Bill: {totalBill}$";
                        cbbx_voucher.Text = "";
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

        // Method to fetch customer information
        private Customer GetCustomerInfo(Guid? customerId)
        {
            using (var _context = new ShopNoirContext())
            {
                // Retrieve the customer by Id
                var customer = _context.Customers
                    .FirstOrDefault(c => c.Id == customerId);

                if (customer != null)
                {
                    return customer;
                }

                return null;
            }
        }



        // Method to fetch product details based on the ProductColorSizeId
        private string GetProductDetails(Guid productColorSizeId)
        {
            using (var _context = new ShopNoirContext())
            {
                // Retrieve the product and size details
                var productColorSize = _context.ProductColorSizes
                    .Include(pcs => pcs.ProductColor)  // Assuming ProductColor contains the product info (name)
                     .ThenInclude(pc => pc.Product)
                    .Include(pcs => pcs.Size)          // Assuming Size contains the size info
                    .FirstOrDefault(pcs => pcs.Id == productColorSizeId);

                if (productColorSize != null)
                {
                    // Get the product's name and the size, then return them
                    var productName = productColorSize.ProductColor.Product.ProdName;
                    var size = productColorSize.Size.SizeName;
                    var price = productColorSize.ProductColor.Product.Price;

                    return $"{productName} - {size} - {price:C}";
                }

                return "Product details not found";
            }
        }


        private string GenerateInvoicePdf(Invoice invoice)
        {
            var pdfFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"Invoice_{invoice.Id}.pdf");

            // Create a document object
            using (var fs = new FileStream(pdfFilePath, FileMode.Create))
            {
                var writer = new PdfWriter(fs);
                var pdf = new iText.Kernel.Pdf.PdfDocument(writer);
                var document = new iText.Layout.Document(pdf);



                // Add title with large font
                AddTitle(document);

                // Customer Info
                var customer = invoice.CustomerId != null ? GetCustomerInfo(invoice.CustomerId) : null;





                // Add invoice summary
                AddInvoiceSummary(document, invoice);
                // Add customer information
                AddCustomerInfo(document, customer);

                // Add product details table
                // Invoice Details (loop through items in the cart)
                AddProductDetailsTable(document, invoice.InvoiceDetails);


                // Add payment details

                document.Close();
            }

            return pdfFilePath;
        }

        // Open the PDF with the default PDF viewer
        static void OpenPdfWithDefaultViewer(string pdfPath)
        {
            try
            {
                // Start the process using the default program for PDF files
                Process.Start(new ProcessStartInfo
                {
                    FileName = pdfPath,
                    UseShellExecute = true  // This ensures that the default program opens the file
                });
                Console.WriteLine("PDF opened with default viewer.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error opening PDF: {ex.Message}");
            }
        }

        static void AddTitle(Document document)
        {
            // Define title style (large, bold font)
            PdfFont titleFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            Paragraph title = new Paragraph("Noir Shop - Invoice")
                .SetFont(titleFont)
                .SetFontSize(24)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontColor(ColorConstants.DARK_GRAY)
                .SetMarginBottom(20);  // Add space below the title

            document.Add(title);
        }

        static void AddCustomerInfo(Document document, Customer customer)
        {
            if (customer == null || (customer.Name == "Unknown" && customer.Email == "Unknown" && customer.Phone == "Unknown"))
            {
                return;
            }
            // Define body font style
            PdfFont bodyFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            // Customer information section
            Paragraph customerInfoTitle = new Paragraph("Customer Information")
                .SetFont(bodyFont)
                .SetFontSize(14)
                .SetMarginTop(10);

            document.Add(customerInfoTitle);

            Paragraph customerName = new Paragraph($"Customer Name: {customer.Name}")
                .SetFont(bodyFont)
                .SetFontSize(12)
                .SetMarginBottom(5);

            Paragraph customerEmail = new Paragraph($"Email: {customer.Email}")
                .SetFont(bodyFont)
                .SetFontSize(12)
                .SetMarginBottom(5);

            Paragraph customerPhone = new Paragraph($"Phone: {customer.Phone}")
                .SetFont(bodyFont)
                .SetFontSize(12)
                .SetMarginBottom(5);


            document.Add(customerName);
            document.Add(customerEmail);
            document.Add(customerPhone);
        }

        static void AddProductDetailsTable(Document document, ICollection<InvoiceDetail> invoiceDetails)
        {
            // Define the header for the product details table
            string[] header = { "Item Description", "Quantity", "Unit Price", "Subtotal" };

            // Create the table with the number of columns equal to the header length
            iText.Layout.Element.Table table = new iText.Layout.Element.Table(header.Length, true);

            // Add table headers
            foreach (var column in header)
            {
                table.AddHeaderCell(new Cell().Add(new Paragraph(column)
                    .SetFontSize(12)
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                    .SetTextAlignment(TextAlignment.CENTER)));
            }

            // Add data to the table using the invoiceDetails collection
            foreach (var detail in invoiceDetails)
            {
                // Add the item description (product name)
                table.AddCell(new Cell().Add(new Paragraph(detail.ProductColorSize.ProductColor.Product.ProdName)
                    .SetFontSize(10)
                    .SetTextAlignment(TextAlignment.LEFT)));

                // Add the quantity
                table.AddCell(new Cell().Add(new Paragraph(detail.Amount.ToString())
                    .SetFontSize(10)
                    .SetTextAlignment(TextAlignment.CENTER)));

                // Add the unit price
                table.AddCell(new Cell().Add(new Paragraph($"${detail.Price.ToString("0.00")}")
                    .SetFontSize(10)
                    .SetTextAlignment(TextAlignment.CENTER)));

                // Add the subtotal (Quantity * UnitPrice)
                table.AddCell(new Cell().Add(new Paragraph($"${(detail.Amount * detail.Price).ToString("0.00")}")
                    .SetFontSize(10)
                    .SetTextAlignment(TextAlignment.CENTER)));
            }

            // Add the table to the document
            document.Add(table);
        }

        static void AddInvoiceSummary(Document document, Invoice invoice)
        {
            // Define summary details
            PdfFont bodyFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            // Add Summary Title
            Paragraph summaryTitle = new Paragraph("Invoice Summary")
                .SetFont(bodyFont)
                .SetFontSize(14)
                .SetMarginTop(15);

            document.Add(summaryTitle);

            // Add summary details (Subtotal, Shipping, Discount, Tax, Total)

            // Add content to the document (Invoice details)
            document.Add(new iText.Layout.Element.Paragraph());
            document.Add(new iText.Layout.Element.Paragraph());
            string[] summaryData = {
                $"Invoice ID: {invoice.Id.ToString().Substring(0, 8)}",
                $"Date: {invoice.CreatedAt}",
                $"Total: ${invoice.Total}",
                invoice.VoucherId != null ?  $"Discount: -${invoice.Voucher.DiscountValue} {invoice.Voucher.DiscountType}" : "",
                $"Tax (10%): ${(double)(invoice.Total - (invoice.VoucherId != null ?  invoice.Voucher.DiscountValue : 0) )* 0.1}",
                $"Total after tax: ${(double)(invoice.Total - (invoice.VoucherId != null ?  invoice.Voucher.DiscountValue : 0) )* 0.9}",
                $"Payment Method: {invoice.PaymentMethod}",

            };
            foreach (var line in summaryData)
            {
                document.Add(new Paragraph(line)
                    .SetFont(bodyFont)
                    .SetFontSize(12)
                    .SetMarginBottom(5));
            }
        }

        private void tbx_phoneCus_TextChanged(object sender, EventArgs e)
        {
            loadCustomer();
        }
    }
}

using QuanLyNoir_BTL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net; // Thêm namespace này để tải ảnh từ URL
namespace QuanLyNoir_BTL.Views
{
    public partial class RevenueDetail : Form
    {
        public RevenueDetail(Guid invoiceId, string total, string revenue, string name, string date)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            lbl_name.Text = "Created by: " + name;
            lbl_total.Text = "Total: " + total;
            lbl_revenue.Text = "Revenue: " + revenue;
            lbl_date.Text = "Created At : " + date;
            using (var _dbContext = new ShopNoirContext())
            {
                var invoiceDetails = _dbContext.InvoiceDetails
                    .AsNoTracking()
                    .Where(id => id.InvoiceId == invoiceId)
                    .Select(id => new
                    {
                        ProductName = id.Product.ProdName,
                        Price = id.Product.Price,
                        Amount = id.Amount,
                        Type = id.Product.Type,
                        Color = id.Product.ProductColors.FirstOrDefault().ColorName,
                        Image = id.Product.ProductColors.FirstOrDefault().ImageUrl, // Lấy đường dẫn ảnh
                        Size = id.Product.ProductColors
                                        .FirstOrDefault()
                                        .ProductColorSizes
                                        .FirstOrDefault().Size.SizeName,
                    })
                    .ToList();

                // Gán dữ liệu vào DataGridView
                dtgv_invoiceDetail.DataSource = invoiceDetails;

                // Thay đổi cột ProductImage thành cột ảnh
                AddImageColumn();
            }
        }

        // Hàm để thay đổi cột ProductImage thành cột hiển thị ảnh
        private void AddImageColumn()
        {
            if (dtgv_invoiceDetail.Columns["Image"] != null)
            {
                // Tạo một cột kiểu DataGridViewImageColumn
                var imageColumn = new DataGridViewImageColumn
                {
                    Name = "ProductImageColumn",
                    HeaderText = "Image",
                    ImageLayout = DataGridViewImageCellLayout.Zoom // Hiển thị ảnh với kích thước phù hợp
                };

                // Thêm cột ảnh vào DataGridView
                dtgv_invoiceDetail.Columns.Add(imageColumn);

                // Duyệt qua từng hàng và gán ảnh vào cột
                foreach (DataGridViewRow row in dtgv_invoiceDetail.Rows)
                {
                    string imageUrl = row.Cells["Image"].Value?.ToString();
                    if (!string.IsNullOrEmpty(imageUrl))
                    {
                        try
                        {
                            // Tải ảnh từ URL
                            using (WebClient client = new WebClient())
                            {
                                byte[] imageBytes = client.DownloadData(imageUrl);
                                using (var ms = new System.IO.MemoryStream(imageBytes))
                                {
                                    Image image = Image.FromStream(ms);
                                    row.Cells["ProductImageColumn"].Value = image; // Gán ảnh vào cột
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            // Xử lý nếu URL không hợp lệ
                            Console.WriteLine("Error loading image: " + ex.Message);
                        }
                    }
                }
                // Ẩn cột đường dẫn ảnh gốc
                dtgv_invoiceDetail.Columns["Image"].Visible = false;
            }
        }
    }
}

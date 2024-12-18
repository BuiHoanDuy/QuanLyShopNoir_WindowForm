using Microsoft.EntityFrameworkCore;
using QuanLyNoir_BTL.Models;
using System.Data;
using System.Net;

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
                // Truy vấn InvoiceDetails với các liên kết đầy đủ
                var invoiceDetails = _dbContext.InvoiceDetails
                    .AsNoTracking()
                    .Where(id => id.InvoiceId == invoiceId)
                    .Select(id => new
                    {
                        ProductName = id.ProductColorSize.ProductColor.Product.ProdName,
                        Price = id.ProductColorSize.ProductColor.Product.Price,
                        Amount = id.Amount,
                        Type = id.ProductColorSize.ProductColor.Product.Type,
                        Color = id.ProductColorSize.ProductColor.ColorName,
                        Size = id.ProductColorSize.Size.SizeName,
                    })
                    .ToList();

                // Gán dữ liệu vào DataGridView
                dtgv_invoiceDetail.DataSource = invoiceDetails;
            }
        }
    }
}

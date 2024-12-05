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
    public partial class RevenueDetail : Form
    {
        public RevenueDetail(Guid invoiceId)
        {
            InitializeComponent();
            using (var _dbContext = new ShopNoirContext())
            {
                var invoiceDetails = _dbContext.InvoiceDetails
                    .AsNoTracking()
                    .Where(id => id.InvoiceId == invoiceId)
                    .Select(id => new
                    {
                        InvoiceDate = id.Invoice.CreatedAt,
                        ProductName = id.Product.ProdName,
                        ProductPrice = id.Product.Price,
                        Amount = id.Amount,
                        ProductType = id.Product.Type,
                        ProductColor = id.Product.ProductColors.FirstOrDefault().ColorName,
                        ProductImage = id.Product.ProductColors.FirstOrDefault().ImageUrl,
                        SizeName = id.Product.ProductColors
                                        .FirstOrDefault()
                                        .ProductColorSizes
                                        .FirstOrDefault().Size.SizeName,
                    })
                    .ToList();

                dtgv_invoiceDetail.DataSource = invoiceDetails;
            }

        }
    }
}

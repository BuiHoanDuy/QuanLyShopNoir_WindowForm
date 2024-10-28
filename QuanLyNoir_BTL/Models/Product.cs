using System;
using System.Collections.Generic;

namespace QuanLyNoir_BTL.Models;

public partial class Product
{
    public Guid Id { get; set; }

    public string ProdName { get; set; } = null!;

    public string? ProdDesc { get; set; }

    public decimal Price { get; set; }

    public decimal Wid { get; set; }

    public decimal Hei { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<CustomerReview> CustomerReviews { get; set; } = new List<CustomerReview>();

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

    public virtual ICollection<ProductColor> ProductColors { get; set; } = new List<ProductColor>();
}

using System;
using System.Collections.Generic;

namespace QuanLyNoir_BTL.Models;

public partial class Invoice
{
    public Guid Id { get; set; }

    public Guid AccountId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public decimal Total { get; set; }

    public int Status { get; set; }

    public int? CheckoutMethod { get; set; }

    public int? ShippingMethod { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
}

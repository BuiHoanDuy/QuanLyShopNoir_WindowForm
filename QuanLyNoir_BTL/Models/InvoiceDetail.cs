using System;
using System.Collections.Generic;

namespace QuanLyNoir_BTL.Models;

public partial class InvoiceDetail
{
    public Guid InvoiceId { get; set; }

    public Guid ProductId { get; set; }

    public int Amount { get; set; }

    public decimal Price { get; set; }

    public virtual Invoice Invoice { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}

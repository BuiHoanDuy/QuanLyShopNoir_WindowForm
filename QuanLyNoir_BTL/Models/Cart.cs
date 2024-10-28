using System;
using System.Collections.Generic;

namespace QuanLyNoir_BTL.Models;

public partial class Cart
{
    public Guid Id { get; set; }

    public Guid AccountId { get; set; }

    public Guid ProductId { get; set; }

    public int Quantity { get; set; }

    public DateTime? AddedAt { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}

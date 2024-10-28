using System;
using System.Collections.Generic;

namespace QuanLyNoir_BTL.Models;

public partial class CustomerReview
{
    public Guid Id { get; set; }

    public Guid? AccountId { get; set; }

    public Guid? ProductId { get; set; }

    public string? Content { get; set; }

    public int Vote { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Product? Product { get; set; }
}

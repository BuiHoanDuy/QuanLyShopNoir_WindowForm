using System;
using System.Collections.Generic;

namespace QuanLyNoir_BTL.Models;

public partial class ContactHistory
{
    public Guid Id { get; set; }

    public Guid AccountId { get; set; }

    public string? ContactDetails { get; set; }

    public DateTime? ContactDate { get; set; }

    public virtual Account Account { get; set; } = null!;
}

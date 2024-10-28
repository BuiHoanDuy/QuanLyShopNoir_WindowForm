using System;
using System.Collections.Generic;

namespace QuanLyNoir_BTL.Models;

public partial class UserAddress
{
    public Guid Id { get; set; }

    public Guid? AccountId { get; set; }

    public string Address { get; set; } = null!;

    public virtual Account? Account { get; set; }
}

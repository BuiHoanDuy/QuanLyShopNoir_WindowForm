using System;
using System.Collections.Generic;

namespace QuanLyNoir_BTL.Models;

public partial class ProductColor
{
    public int Id { get; set; }

    public Guid? ProductId { get; set; }

    public string ColorName { get; set; } = null!;

    public string ColorCode { get; set; } = null!;

    public int Inventory { get; set; }

    public int Total { get; set; }

    public int Size { get; set; }

    public byte[]? ImageUrl { get; set; }

    public virtual Product? Product { get; set; }
}

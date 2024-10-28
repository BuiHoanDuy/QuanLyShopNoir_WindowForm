using System;
using System.Collections.Generic;

namespace QuanLyNoir_BTL.Models;

public partial class Account
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public bool Role { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<ContactHistory> ContactHistories { get; set; } = new List<ContactHistory>();

    public virtual ICollection<CustomerReview> CustomerReviews { get; set; } = new List<CustomerReview>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();
}

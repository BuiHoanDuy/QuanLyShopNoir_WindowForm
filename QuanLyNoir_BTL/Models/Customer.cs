using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNoir_BTL.Models;
public partial class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    [NotMapped]
    public decimal PurchasedAmount { get; set; } // Tổng số tiền đã mua

}
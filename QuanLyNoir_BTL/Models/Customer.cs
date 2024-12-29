﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace QuanLyNoir_BTL.Models;
public partial class Customer
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }



    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNoir_BTL.Models
{
    public partial class ProductColorView
    {
        public Guid ProductId { get; set; }
        public string ProdName { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public decimal Wid { get; set; }
        public decimal Hei { get; set; }
        public int ProductColorId { get; set; }
        public int Inventory { get; set; }
        public string ColorName { get; set; }
        public byte[] ImageUrl { get; set; }
        public string ColorCode { get; set; }
    }
}

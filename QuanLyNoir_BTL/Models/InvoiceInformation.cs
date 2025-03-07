﻿namespace QuanLyNoir_BTL.Models
{
    public class InvoiceInformation
    {
        public Guid Id { get; set; } //Id của Invoice
        public DateTime? CreatedAt { get; set; } // Ngày tạo
        public int Amount { get; set; } // Số lượng sản phẩm bán ra
        public string PaymentMethod { get; set; } // Phương thức thanh toán
        public decimal Total { get; set; } // Tổng tiền thu được
        public int TaxRate { get; set; } = 10; // Thuế suất (%)

        // Tính thuế: Total * TaxRate / 100
        public decimal Tax => Total * TaxRate / 100;

        // Doanh thu sau thuế: Total - Tax
        public decimal Revenue => Total - Tax;

        public string CreateBy { get; set; } // Tên nhân viên tạo hóa đơn
        public string Voucher {  get; set; } // voucher
        public string Custumer {  get; set; } // KH
    }
}

using Microsoft.VisualBasic.ApplicationServices;
using QuanLyNoir_BTL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Dynamic.Core;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace QuanLyNoir_BTL.Views
{
    public partial class ManageCustomer : UserControl
    {
        private int currentPage = 1; // Trang hiện tại
        private int pageSize = 10; // Số lượng bản ghi mỗi trang
        private int totalRecords; // Tổng số bản ghi
        private Guid _Id;
        private Guid currentAccountId;

        public ManageCustomer()
        {
            InitializeComponent();
            cbbx_cot.Items.Add("Name");
            cbbx_cot.Items.Add("PurchasedAmount"); // Tổng số tiền đã mua hàng
            cbbx_cot.SelectedIndex = 1; // Chọn mặc định

            // Thêm các tùy chọn cho ComboBox cbbx_sapxep
            cbbx_sapxep.Items.Add("ASC");
            cbbx_sapxep.Items.Add("DESC");
            cbbx_sapxep.SelectedIndex = 1; // Chọn mặc định


            cbbx_sodong.Items.Add(10);
            cbbx_sodong.Items.Add(20);
            cbbx_sodong.Items.Add(50);
            cbbx_sodong.Items.Add(100);
            cbbx_sodong.SelectedIndex = 0;

            dtgv_customerList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn column in dtgv_customerList.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

        }
        private void ManageCustomer_Load(object sender, EventArgs e)
        {
            LoadDataIntoDataGridBox();
            dtgv_customerList.EnableHeadersVisualStyles = false; // Bắt buộc để thay đổi kiểu
            dtgv_customerList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DarkSlateGray; // Màu nền
            dtgv_customerList.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Pink; // Màu chữ
            dtgv_customerList.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold); // Font chữ
        }
        private void LoadDataIntoDataGridBox()
        {
            using (var _context = new ShopNoirContext())
            {
                try
                {
                    // Tính tổng số bản ghi
                    totalRecords = _context.Customers
                        .Where(c => c.Name.Contains(tbx_timkiem.Text.Trim())
                                    || c.Phone.Contains(tbx_timkiem.Text.Trim()))
                        .Count();

                    lbl_trang.Text = $"Page {currentPage} / {Math.Ceiling((double)totalRecords / pageSize)}";

                    // Lấy cột sắp xếp
                    var sortColumn = cbbx_cot.SelectedItem?.ToString() switch
                    {
                        "Name" => "Name",
                        "PurchasedAmount" => "PurchasedAmount",
                        _ => "PurchasedAmount" // Giá trị mặc định
                    };

                    string sortOrder = cbbx_sapxep.SelectedItem?.ToString().Equals("ASC") == true ? "asc" : "desc";

                    // Truy vấn dữ liệu
                    var customers = _context.Customers
                        .Where(c => (c.Name.Contains(tbx_timkiem.Text.Trim())
                                  || c.Phone.Contains(tbx_timkiem.Text.Trim()))
                                  && c.Invoices.Any()) // Lọc khách hàng có hóa đơn
                        .Select(c => new
                        {
                            c.Phone,
                            c.Name,
                            PurchasedAmount = c.Invoices.Sum(i => i.Total), // Tính tổng tiền mua
                            c.Email,
                            c.Id,
                        })
                        .OrderBy($"{sortColumn} {sortOrder}")
                        .Skip((currentPage - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

                    // Gán dữ liệu vào DataGridView
                    dtgv_customerList.DataSource = customers;
                    dtgv_customerList.Columns["Id"].Visible = false;
                    // Kích hoạt hoặc vô hiệu hóa nút điều hướng
                    btn_trangtruoc.Enabled = currentPage > 1;
                    btn_trangsau.Enabled = currentPage < Math.Ceiling((double)totalRecords / pageSize);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }

        private void btn_trangtruoc_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadDataIntoDataGridBox(); // Tải lại dữ liệu cho trang trước
            }
        }
        private void btn_trangsau_Click(object sender, EventArgs e)
        {
            if (currentPage < Math.Ceiling((double)totalRecords / pageSize))
            {
                currentPage++;
                LoadDataIntoDataGridBox(); // Tải lại dữ liệu cho trang tiếp theo
            }
        }

        private void cbbx_sodong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbx_sodong.SelectedItem != null)
            {
                pageSize = (int)cbbx_sodong.SelectedItem; // Lấy giá trị từ ComboBox
                currentPage = 1; // Reset về trang đầu tiên khi thay đổi số dòng
                LoadDataIntoDataGridBox(); // Tải lại dữ liệu
            }
        }
        private void tbx_timkiem_TextChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadDataIntoDataGridBox();
        }

        private void cbbx_sapxep_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataIntoDataGridBox(); // Tải lại dữ liệu khi thay đổi sắp xếp
        }

        private void cbbx_cot_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataIntoDataGridBox(); // Tải lại dữ liệu khi thay đổi cột
        }
        private void dtgv_customerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgv_customerList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgv_customerList.MultiSelect = false;
            if (e.RowIndex >= 0) // Kiểm tra xem có dòng nào được chọn không
            {
                // Chọn cả dòng chứa ô được nhấp
                dtgv_customerList.Rows[e.RowIndex].Selected = true;

                DataGridViewRow row = dtgv_customerList.Rows[e.RowIndex];

                // Hiển thị dữ liệu từ DataGridView lên các TextBox
                _Id = (Guid)row.Cells["Id"].Value;
                showCustomerDetail(row.Cells["Name"].Value.ToString());
            }
        }
       
        private void showCustomerDetail(string name)
        {
            using (var db = new ShopNoirContext())
            {
                var customerInvoices = db.Invoices.Where(i => i.CustomerId == _Id)
                    .Select(i => new
                    {
                        i.CreatedAt,
                        i.Total,
                        i.Voucher.Code,
                        i.PaymentMethod,
                        i.CreatedByNavigation.Name,
                    }).ToList();

                dtgv_detail.DataSource = customerInvoices;
                dtgv_detail.Columns["Name"].HeaderText = "Created By";
                dtgv_detail.Columns["Code"].HeaderText = "Voucher";
                 lbl_detail.Text =  $"Purchase history's customer: {name}";
            }
        }
    }
}

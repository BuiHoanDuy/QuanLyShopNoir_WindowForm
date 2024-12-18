using Microsoft.EntityFrameworkCore;
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

namespace QuanLyNoir_BTL.Views
{
    enum FILTER {daily, monthly, yearly};
    public partial class ManageOrderControl : UserControl
    {
        FILTER FILTER;
        public ManageOrderControl()
        {
            InitializeComponent();
            FILTER = new FILTER();
            FILTER = FILTER.daily;
            Load_data();
        }

        private void ManageOrderControl_Load(object sender, EventArgs e)
        {

        }

        private void Load_data()
        {
            init_comboBox();
            load_dataGridView();
        }

        private int init_comboBoxYear()
        {
            // Lấy năm hiện tại
            int currentYear = DateTime.Now.Year;

            // Tạo danh sách các năm từ 2023 đến năm hiện tại
            List<int> years = Enumerable.Range(2024, currentYear - 2024 + 1).ToList();

            // Gán danh sách năm vào ComboBox
            cbbx_year.DataSource = years;

            // Tuỳ chỉnh nếu cần
            cbbx_year.DropDownStyle = ComboBoxStyle.DropDownList; // Chỉ cho phép chọn, không nhập
            cbbx_year.SelectedItem = currentYear;
            //cbbx_year.SelectedItem = currentYear;
            return currentYear;
        }

        private void init_comboBoxMonth()
        {
            // Lấy năm hiện tại
            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;

            // Tạo danh sách các năm từ 2023 đến năm hiện tại
            List<int> months;
            if ((int)cbbx_year.SelectedValue < currentYear)
                months = Enumerable.Range(1, 12).ToList();
            else
                months = Enumerable.Range(1, currentMonth).ToList();

            // Gán danh sách năm vào ComboBox
            cbbx_month.DataSource = months;

            // Tuỳ chỉnh nếu cần
            cbbx_month.DropDownStyle = ComboBoxStyle.DropDownList; // Chỉ cho phép chọn, không nhập
            cbbx_month.SelectedItem = currentMonth;
        }

        private void init_comboBox()
        {
            #region load comboBox năm


            #endregion

            init_comboBoxYear();

            #region load comboBox tháng
            init_comboBoxMonth();

            #endregion
        }

        private void load_dataGridView()
        {
            int year = (int)cbbx_year.SelectedValue;

            using (var context = new ShopNoirContext())
            {

                IQueryable<Invoice> invoiceQuery = context.Invoices;

                if(FILTER == FILTER.daily)
                {
                    invoiceQuery = invoiceQuery
                    .Where(i => i.CreatedAt == dateTimePicker.Value);
                }

                if(FILTER == FILTER.monthly)
                {
                    invoiceQuery = invoiceQuery
                    .Where(i => i.CreatedAt.Value.Year == (int)cbbx_year.SelectedValue
                             && i.CreatedAt.Value.Month == (int)cbbx_month.SelectedValue);
                }

                if(FILTER == FILTER.yearly)
                {
                    invoiceQuery = invoiceQuery
                    .Where(i => i.CreatedAt.Value.Year == (int)cbbx_year.SelectedValue);
                }




                // Lấy dữ liệu bằng LINQ
                //var invoiceData = from invoices in context.Invoices
                //                  join accounts in context.Accounts
                //                  on invoices.CreatedBy equals accounts.Id
                //                  where invoices.CreatedAt.Value.Year == year
                //                  select new
                //                  {
                //                      InvoiceId = invoices.Id,
                //                      EmployeeName = accounts.Name,
                //                      CreatedAt = invoices.CreatedAt,
                //                      Total = invoices.Total
                //                  };

                var invoiceData = from invoices in invoiceQuery
                                  join accounts in context.Accounts
                                  on invoices.CreatedBy equals accounts.Id
                                  select new
                                  {
                                      InvoiceId = invoices.Id,
                                      EmployeeName = accounts.Name,
                                      CreatedAt = invoices.CreatedAt,
                                      Total = invoices.Total
                                  };

                // Gán dữ liệu vào DataGridView
                dataGridView_Order.DataSource = invoiceData.ToList();

                // Thiết lập AutoSizeColumnsMode để dãn các cột
                dataGridView_Order.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Tuỳ chỉnh tên tiêu đề cột (nếu cần)
                dataGridView_Order.Columns["InvoiceId"].HeaderText = "Mã Đơn Hàng";
                dataGridView_Order.Columns["EmployeeName"].HeaderText = "Tên Nhân Viên";
                dataGridView_Order.Columns["CreatedAt"].HeaderText = "Ngày Tạo";
                dataGridView_Order.Columns["Total"].HeaderText = "Tổng Tiền";

                // Căn giữa chữ trong các ô
                DataGridViewCellStyle cellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter, // Căn giữa ngang và dọc
                    WrapMode = DataGridViewTriState.True                   // Bật chế độ xuống dòng nếu nội dung dài
                };
                dataGridView_Order.DefaultCellStyle = cellStyle;

                // Căn giữa tiêu đề cột
                dataGridView_Order.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void dataGridView_Order_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbbx_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_dataGridView();
            init_comboBoxMonth();

        }


        private void linkLable_clickedEffect(LinkLabel llbl)
        {
            llbl_daily.LinkColor = System.Drawing.Color.DimGray;
            llbl_monthly.LinkColor = System.Drawing.Color.DimGray;
            llbl_yearly.LinkColor = System.Drawing.Color.DimGray;
            llbl.LinkColor = System.Drawing.Color.Black;
        }

        private void llbl_daily_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dateTimePicker.Enabled = true;
            cbbx_month.Enabled = false;
            cbbx_year.Enabled = false;
            linkLable_clickedEffect(llbl_daily);

        }

        private void llbl_monthly_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dateTimePicker.Enabled = false;
            cbbx_month.Enabled = true;
            cbbx_year.Enabled = true;
            linkLable_clickedEffect(llbl_monthly);
        }

        private void llbl_yearly_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cbbx_month.Enabled = false;
            dateTimePicker.Enabled = false;
            cbbx_year.Enabled = true;
            linkLable_clickedEffect(llbl_yearly);
        }
    }
}

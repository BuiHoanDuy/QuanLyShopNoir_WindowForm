using iText.Kernel.Pdf;
using iTextSharp.text;
using iTextSharp.text.pdf;
using QuanLyNoir_BTL.Models;
using System.Data;
using System.Linq.Dynamic.Core;
using PageSize = iTextSharp.text.PageSize;
using Path = System.IO.Path;


namespace QuanLyNoir_BTL.Views
{
    public partial class ManageVoucherControl : UserControl
    {
        private int currentPage = 1; // Trang hiện tại
        private int pageSize = 10; // Số lượng bản ghi mỗi trang
        private int totalRecords; // Tổng số bản ghi

        private string status_radioButtonCheck_text = "";
        private string type_radioButtonCheck_text = "";
        public ManageVoucherControl()
        {
            InitializeComponent();
            dtgv_voucherlist.MultiSelect = false;
            cbbx_cot.Items.Add("Code");
            cbbx_cot.Items.Add("Discount Type");
            cbbx_cot.Items.Add("Discount Value");
            cbbx_cot.Items.Add("Start Date");
            cbbx_cot.Items.Add("End Date");
            cbbx_cot.Items.Add("Max Usage");
            cbbx_cot.Items.Add("Usage Count");
            cbbx_cot.Items.Add("Minimum Order Value");
            cbbx_cot.Items.Add("Status");
            cbbx_cot.SelectedIndex = 0; // Chọn mặc định

            // Thêm các tùy chọn cho ComboBox cbbx_sapxep
            cbbx_sapxep.Items.Add("ASC");
            cbbx_sapxep.Items.Add("DESC");
            cbbx_sapxep.SelectedIndex = 0; // Chọn mặc định

            cbbx_sodong.Items.Add(10);
            cbbx_sodong.Items.Add(20);
            cbbx_sodong.Items.Add(50);
            cbbx_sodong.Items.Add(100);
            cbbx_sodong.SelectedIndex = 0;

            dtpk_start.Format = DateTimePickerFormat.Custom;
            dtpk_start.CustomFormat = "dd/MM/yyyy"; // Or any other format you prefer
            dtpk_end.Format = DateTimePickerFormat.Custom;
            dtpk_end.CustomFormat = "dd/MM/yyyy"; // Or any other format you prefer

            dtgv_voucherlist.Columns["StartDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgv_voucherlist.Columns["EndDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dtgv_voucherlist.EnableHeadersVisualStyles = false; // Bắt buộc để thay đổi kiểu
            dtgv_voucherlist.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DarkSlateGray; // Màu nền
            dtgv_voucherlist.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Pink; // Màu chữ
            dtgv_voucherlist.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 10, FontStyle.Regular); // Font chữ

            dtgv_voucherlist.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void ManageVoucherControl_Load(object sender, EventArgs e)
        {
            LoadDataIntoDataGridBox();

        }

        private void LoadDataIntoDataGridBox()
        {
            using (var _context = new ShopNoirContext())
            {
                // Get the selected start and end dates from DateTimePickers
                DateOnly startDate = DateOnly.FromDateTime(dtpk_start.Value.Date); // Get date only from start date picker
                DateOnly endDate = DateOnly.FromDateTime(dtpk_end.Value.Date);     // Get date only from end date picker

                try
                {
                    totalRecords = _context.Vouchers.Count();
                    lbl_trang.Text = $"Page {currentPage} / {Math.Ceiling((double)totalRecords / pageSize)}";

                    var sortColumn = cbbx_cot.SelectedItem.ToString() switch
                    {
                        "Code" => "Code",
                        "Discount Type" => "DiscountType",
                        "Discount Value" => "DiscountValue",
                        "Start Date" => "StartDate",
                        "End Date" => "EndDate",
                        "Max Usage" => "MaxUsage",
                        "Usage Count" => "UsedCount",
                        "Minimum Order Value" => "MinOrderValue",
                        _ => "Code" // Default to sorting by Code
                    };

                    string sortOrder = cbbx_sapxep.SelectedItem?.ToString() == "ASC" ? "asc" : "desc";

                    string keyword = cbbx_find.Text.Trim();

                    var vouchersQuery = _context.Vouchers.AsQueryable();

                    // Apply filters based on RadioButton selections
                    if (!string.IsNullOrEmpty(status_radioButtonCheck_text))
                    {
                        bool status = bool.Parse(status_radioButtonCheck_text);
                        DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);

                        if(status == true)
                        {

                        vouchersQuery = vouchersQuery.Where(vc => vc.StartDate <= currentDate &&
                                                                  vc.EndDate >= currentDate);
                        } else
                        {
                            vouchersQuery = vouchersQuery.Where(vc => vc.StartDate >= currentDate ||
                                                               vc.EndDate <= currentDate);
                        }
                    }

                    if (type_radioButtonCheck_text != "")
                    {
                        vouchersQuery = vouchersQuery.Where(vc => vc.DiscountType == type_radioButtonCheck_text);
                    }

                    // Filter by date range from DateTimePickers
                    // Lọc các voucher có ngày bắt đầu nằm trong khoảng người dùng chọn
                    vouchersQuery = vouchersQuery.Where(vc => vc.StartDate >= startDate && vc.StartDate <= endDate && vc.Status == true);

                    // Filter by keyword if provided
                    vouchersQuery = vouchersQuery.Where(vc => vc.Code.Contains(keyword));

                    // Apply sorting and pagination
                    vouchersQuery = vouchersQuery
                        .OrderBy($"{sortColumn} {sortOrder}")
                        .Skip((currentPage - 1) * pageSize)
                        .Take(pageSize);

                    // Set data to DataGridView
                    dtgv_voucherlist.DataSource = vouchersQuery.ToList();

                    dtgv_voucherlist.Columns["Id"].Visible = false;
                    dtgv_voucherlist.Columns["Invoices"].Visible = false;
                    dtgv_voucherlist.Columns["Status"].Visible = false;

                    btn_trangtruoc.Enabled = currentPage > 1;
                    btn_trangsau.Enabled = currentPage < Math.Ceiling((double)totalRecords / pageSize);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
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
        private void cbbx_find_TextChanged(object sender, EventArgs e)
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

        private void rdbtn_Status_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender as RadioButton).Checked) return;

            status_radioButtonCheck_text = rdbtn_status_activated.Checked ? "True" :
                                           rdbtn_status_inactive.Checked ? "False" : "";

            currentPage = 1; // Reset to the first page after filtering
            LoadDataIntoDataGridBox(); // Reload data with new filters
        }

        private void rdbtn_Type_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender as RadioButton).Checked) return;

            type_radioButtonCheck_text = rdbtn_type_percentage.Checked ? "P" :
                                         rdbtn_type_fixed.Checked ? "F" : "";

            currentPage = 1; // Reset to the first page after filtering
            LoadDataIntoDataGridBox(); // Reload data with new filters
        }

        private void dtpk_start_ValueChanged(object sender, EventArgs e)
        {
            LoadDataIntoDataGridBox(); // Reload data with new filters
        }

        private void dtpk_end_ValueChanged(object sender, EventArgs e)
        {
            LoadDataIntoDataGridBox(); // Reload data with new filters
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            dtpk_start.Value = new DateTime(2000, 1, 1);
            dtpk_end.Value = new DateTime(3000, 1, 1);
            rdbtn_status_all.Checked = true;
            rdbtn_type_all.Checked = true;
            cbbx_find.Text = "";
        }

        private void btn_today_Click(object sender, EventArgs e)
        {
            dtpk_end.Value = DateTime.Now;
        }

        private void btn_today_startday_Click(object sender, EventArgs e)
        {
            dtpk_start.Value = DateTime.Now;
        }

        private void btn_addNewVoucher_Click(object sender, EventArgs e)
        {
            AddNewVoucher addNewVoucher = new AddNewVoucher();
            addNewVoucher.ShowDialog();
            addNewVoucher.Focus();
            LoadDataIntoDataGridBox();
        }

        private void dtgv_voucherlist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgv_voucherlist.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            btn_edit.Enabled = true;
            btn_delete.Enabled = true;
            btn_print.Enabled = true;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào đang được chọn
            if (dtgv_voucherlist.SelectedRows.Count > 0)
            {
                // Xác nhận xóa
                DialogResult result = MessageBox.Show("Do you want to delete this voucher?", "Delete voucher", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    var voucherId = (Guid)dtgv_voucherlist.SelectedRows[0].Cells["Id"].Value;
                    using (var _context = new ShopNoirContext())
                    {
                        // Tìm voucher cần xóa bằng LINQ
                        var voucher = _context.Vouchers.FirstOrDefault(v => v.Id == voucherId);

                        if (voucher != null)
                        {
                            try
                            {
                                // Xóa voucher khỏi DbContext
                                voucher.Status = false;

                                // Lưu thay đổi vào cơ sở dữ liệu
                                _context.SaveChanges();
                                MessageBox.Show("Voucher has been deleted!");

                                LoadDataIntoDataGridBox();
                                btn_edit.Enabled = false;
                                btn_delete.Enabled = false;
                            }
                            catch
                            {
                                MessageBox.Show("Voucher could not be deleted!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Voucher not found to delete!");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please choose a voucher to delete!");
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dtgv_voucherlist.SelectedRows.Count > 0) // Kiểm tra xem có dòng nào được chọn không
            {
                // Lấy dòng đã chọn
                DataGridViewRow row = dtgv_voucherlist.SelectedRows[0];

                // Hiển thị dữ liệu từ DataGridView lên các TextBox
                Guid _Id = (Guid)row.Cells["Id"].Value; // Lấy Id của voucher

                string voucherCode = row.Cells["Code"].Value.ToString(); // Voucher code
                bool discountType = row.Cells["DiscountType"].Value.ToString() == "P" ? true : false;
                string discountValue = row.Cells["DiscountValue"].Value.ToString(); // Discount value (string)
                DateTime startDay = ((DateOnly)row.Cells["StartDate"].Value).ToDateTime(TimeOnly.MinValue); // Convert DateOnly to DateTime
                DateTime endDay = ((DateOnly)row.Cells["EndDate"].Value).ToDateTime(TimeOnly.MinValue); // Convert DateOnly to DateTime
                string maxUsage = row.Cells["MaxUsage"].Value?.ToString() ?? string.Empty;
                string minimumOrderValue = row.Cells["MinOrderValue"].Value?.ToString() ?? string.Empty; // Minimum order value (nullable string)
                bool status = (bool)row.Cells["Status"].Value == true ? true : false;

                AddNewVoucher addNewVoucher = new AddNewVoucher(_Id, voucherCode, discountType, discountValue, status, minimumOrderValue, maxUsage, startDay, endDay);
                addNewVoucher.ShowDialog();
            }
            LoadDataIntoDataGridBox();
        }


        private void btn_print_Click(object sender, EventArgs e)
        {
            if (dtgv_voucherlist.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Do you want to print this voucher?", "Print voucher", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Lấy dòng đã chọn
                    DataGridViewRow row = dtgv_voucherlist.SelectedRows[0];

                    // Lấy dữ liệu từ DataGridView
                    string voucherCode = row.Cells["Code"].Value.ToString();
                    string discountType = row.Cells["DiscountType"].Value.ToString() == "P" ? "Percentage" : "Fixed Amount";
                    string discountValue = row.Cells["DiscountValue"].Value.ToString();
                    string startDay = ((DateOnly)row.Cells["StartDate"].Value).ToDateTime(TimeOnly.MinValue).ToShortDateString();
                    string endDay = ((DateOnly)row.Cells["EndDate"].Value).ToDateTime(TimeOnly.MinValue).ToShortDateString();
                    string minOrderValue = row.Cells["MinOrderValue"].Value?.ToString() ?? "None";

                    // Đường dẫn lưu file PDF
                    string outputPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Voucher.pdf");

                    try
                    {
                        // Tạo file PDF
                        using (FileStream fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            Document pdfDoc = new Document(PageSize.A4, 50, 50, 25, 25);
                            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, fs); // Đảm bảo PdfWriter được nhận diện
                            pdfDoc.Open();

                            // Thêm tiêu đề
                            var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20, BaseColor.BLACK);
                            var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK);

                            pdfDoc.Add(new Paragraph("Voucher Details", titleFont));
                            pdfDoc.Add(new Paragraph("--------------------------------------------------\n"));

                            // Thêm thông tin voucher
                            pdfDoc.Add(new Paragraph($"Voucher Code: {voucherCode}", normalFont));
                            if (discountType.Equals("Percentage"))
                            {
                                pdfDoc.Add(new Paragraph($"Discount Value: {float.Parse(discountValue)*100}%", normalFont));  
                            }else
                            {
                                pdfDoc.Add(new Paragraph($"Discount Value: {float.Parse(discountValue)} $", normalFont));
                            }

                            pdfDoc.Add(new Paragraph($"Minimum Order Value: {minOrderValue} $", normalFont));

                            pdfDoc.Add(new Paragraph("--------------------------------------------------\n"));

                            pdfDoc.Add(new Paragraph($"Start Date: {startDay}", normalFont));
                            pdfDoc.Add(new Paragraph($"End Date: {endDay}", normalFont));

                            pdfDoc.Add(new Paragraph("\nThank you for using our services!", normalFont));

                            pdfDoc.Close();
                            writer.Close();
                        }

                        // Thông báo thành công
                        MessageBox.Show($"Voucher PDF has been saved to {outputPath}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while generating the PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a voucher from the list to print.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

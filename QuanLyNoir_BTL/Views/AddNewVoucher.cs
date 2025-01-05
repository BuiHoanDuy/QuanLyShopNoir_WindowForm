using QuanLyNoir_BTL.Models;
using System.Data;

namespace QuanLyNoir_BTL.Views
{
    public partial class AddNewVoucher : Form
    {
        private Guid _Id;
        public AddNewVoucher()
        {
            InitializeComponent();
            this.Text = "Add New Voucher";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Focus();

            dtpk_startday.Format = DateTimePickerFormat.Custom;
            dtpk_startday.CustomFormat = "dd/MM/yyyy"; // Or any other format you prefer
            dtpk_endday.Format = DateTimePickerFormat.Custom;
            dtpk_endday.CustomFormat = "dd/MM/yyyy"; // Or any other format you prefer
            cbbx_dayOrMonth.SelectedIndex = 1;

            dtpk_endday.Enabled = false;
            dtpk_startday.Value = DateTime.Now;

            btn_update.Visible = false;
            btn_save.Visible = true;
        }

        public AddNewVoucher(Guid Id, string voucherCode, bool discountType, string discountValue, bool status,
            string minimumOrderValue, string maxUsage, DateTime startDay, DateTime endDay)
        {
            InitializeComponent();
            this.Text = "Edit Voucher";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Focus();

            dtpk_startday.Format = DateTimePickerFormat.Custom;
            dtpk_startday.CustomFormat = "dd/MM/yyyy"; // Or any other format you prefer
            dtpk_endday.Format = DateTimePickerFormat.Custom;
            dtpk_endday.CustomFormat = "dd/MM/yyyy"; // Or any other format you prefer
            cbbx_dayOrMonth.SelectedIndex = 1;

            ntbx_validityPeriod.Enabled = false;
            cbbx_dayOrMonth.Enabled = false;
            rdbtn_fixedDay.Checked = true;

            _Id = Id;
            tbx_voucherCode.Text = voucherCode;
            if (discountType) rdbtn_percentage.Checked = true;
            else rdbtn_fixed.Checked = true;
            tbx_discountValue.Text = discountValue;
            if (status) rdbtn_activated.Checked = true;
            else rdbtn_unactivated.Checked = true;
            tbx_minOrderValue.Text = minimumOrderValue;
            ntbx_maxUsage.Text = maxUsage;
            dtpk_startday.Value = startDay; // Use TimeOnly.MinValue to set the time part to 00:00:00
            dtpk_endday.Value = endDay;     // Same for endDay

            btn_save.Visible = false;
            btn_update.Visible = true;
        }

        private void btn_random_Click(object sender, EventArgs e)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            tbx_voucherCode.Text = new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[(new Random()).Next(s.Length)]).ToArray());
        }

        private void rdbtn_fixedDay_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtn_fixedDay.Checked)
            {
                dtpk_endday.Enabled = true; // Bật DateTimePicker cho "Fixed day"
                ntbx_validityPeriod.Enabled = false; // Tắt NumericUpDown cho "Validity period"
                cbbx_dayOrMonth.Enabled = false;
            }
        }

        private void rdbtn_validityPeriod_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtn_validityPeriod.Checked)
            {
                dtpk_endday.Enabled = false; // Bật DateTimePicker cho "Fixed day"
                ntbx_validityPeriod.Enabled = true; // Tắt NumericUpDown cho "Validity period"
                cbbx_dayOrMonth.Enabled = true;
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            tbx_voucherCode.Text = "";
            tbx_discountValue.Text = "0";
            tbx_minOrderValue.Text = "0";
            ntbx_maxUsage.Text = "0";
            dtpk_startday.Value = DateTime.Now;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!Validate()) return;
            try
            {
                // Tạo đối tượng voucher mới
                Voucher newVoucher = new Voucher
                {
                    Id = Guid.NewGuid(),
                    Code = tbx_voucherCode.Text,
                    DiscountType = rdbtn_percentage.Checked ? "P" : "F",
                    DiscountValue = decimal.Parse(tbx_discountValue.Text),
                    StartDate = DateOnly.FromDateTime(dtpk_startday.Value),
                    MaxUsage = int.Parse(ntbx_maxUsage.Value.ToString()),
                    UsedCount = 0, // Khởi tạo với giá trị 0 nếu là voucher mới
                    MinOrderValue = string.IsNullOrEmpty(tbx_minOrderValue.Text) ? null : (decimal?)decimal.Parse(tbx_minOrderValue.Text),
                    Status = rdbtn_activated.Checked
                };

                // Kiểm tra End Date
                if (rdbtn_fixedDay.Checked)
                {
                    newVoucher.EndDate = DateOnly.FromDateTime(dtpk_endday.Value);
                }
                else if (rdbtn_validityPeriod.Checked)
                {
                    int periodValue = (int)ntbx_validityPeriod.Value;
                    DateTime endDate = dtpk_startday.Value;

                    // Thêm khoảng thời gian theo lựa chọn
                    switch (cbbx_dayOrMonth.SelectedItem.ToString())
                    {
                        case "Day":
                            endDate = endDate.AddDays(periodValue);
                            break;
                        case "Month":
                            endDate = endDate.AddMonths(periodValue);
                            break;
                    }
                    newVoucher.EndDate = DateOnly.FromDateTime(endDate);
                }

                // Thêm vào database
                using (var context = new ShopNoirContext())
                {
                    context.Vouchers.Add(newVoucher);
                    context.SaveChanges();
                }

                MessageBox.Show("Voucher đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có voucher sử dụng mã này", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool Validate()
        {
            // Validate dữ liệu
            if (string.IsNullOrWhiteSpace(tbx_voucherCode.Text))
            {
                MessageBox.Show("Vui lòng nhập mã voucher.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbx_voucherCode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(tbx_discountValue.Text) || !decimal.TryParse(tbx_discountValue.Text, out decimal discountValue) || discountValue <= 0)
            {
                MessageBox.Show("Vui lòng nhập giá trị giảm giá hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbx_discountValue.Focus();
                return false;
            }

            if (rdbtn_percentage.Checked)
            {
                if (decimal.Parse(tbx_discountValue.Text) >= 1)
                {
                    MessageBox.Show("Giá trị của Voucher không thể lớn hơn 1 (100%)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbx_discountValue.Focus();
                    return false;
                }
            }

            if (rdbtn_fixedDay.Checked && dtpk_endday.Value <= dtpk_startday.Value)
            {
                MessageBox.Show("Ngày kết thúc (Fixed day) phải lớn hơn ngày bắt đầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpk_endday.Focus();
                return false;
            }

            if (rdbtn_validityPeriod.Checked && ntbx_validityPeriod.Value <= 0)
            {
                MessageBox.Show("Thời gian hiệu lực phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ntbx_validityPeriod.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(tbx_minOrderValue.Text) && (!decimal.TryParse(tbx_minOrderValue.Text, out decimal minOrderValue) || minOrderValue < 0))
            {
                MessageBox.Show("Vui lòng nhập giá trị đơn hàng tối thiểu hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbx_minOrderValue.Focus();
                return false;
            }

            if (ntbx_maxUsage.Value <= 0)
            {
                MessageBox.Show("Số lần sử dụng tối đa phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ntbx_maxUsage.Focus();
                return false;
            }
            return true;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (!Validate()) return;
            using (var _context = new ShopNoirContext())
            {
                // Tìm Province cần cập nhật trong cơ sở dữ liệu
                var voucher = _context.Vouchers.FirstOrDefault(p => p.Id.Equals(_Id));

                if (voucher != null)
                {
                    {
                        voucher.Code = tbx_voucherCode.Text;
                        voucher.DiscountType = rdbtn_percentage.Checked ? "P" : "F";
                        voucher.DiscountValue = decimal.Parse(tbx_discountValue.Text);
                        voucher.StartDate = DateOnly.FromDateTime(dtpk_startday.Value);
                        voucher.MaxUsage = Convert.ToInt32(ntbx_maxUsage.Value);
                        voucher.UsedCount = 0;
                        voucher.MinOrderValue = string.IsNullOrEmpty(tbx_minOrderValue.Text) ? null : (decimal?)decimal.Parse(tbx_minOrderValue.Text);
                        voucher.Status = rdbtn_activated.Checked;

                        // Lưu thay đổi vào cơ sở dữ liệu
                        _context.SaveChanges();

                        // Thông báo thành công
                        MessageBox.Show("Update successfully!!");
                    }
                }
                else
                {
                    MessageBox.Show("Don't find account to update");
                }
                this.Close();
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using QuanLyNoir_BTL.Models;
using System.Data;
using System.Linq.Dynamic.Core;
using System.Windows.Forms;

namespace QuanLyNoir_BTL.Views
{
    public partial class ManageAccountControl : UserControl
    {
        private int currentPage = 1; // Trang hiện tại
        private int pageSize = 10; // Số lượng bản ghi mỗi trang
        private int totalRecords; // Tổng số bản ghi
        private Guid _Id;
        public ManageAccountControl()
        {
            InitializeComponent();
            cbbx_cot.Items.Add("Id");
            cbbx_cot.Items.Add("Name");
            cbbx_cot.Items.Add("Username");
            cbbx_cot.Items.Add("Role");
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

            btn_update.Enabled = false;
            btn_delete.Enabled = false;

            dtgv_accountList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn column in dtgv_accountList.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void ManageAccountControl_Load(object sender, EventArgs e)
        {
            LoadDataIntoDataGridBox();
            dtgv_accountList.EnableHeadersVisualStyles = false; // Bắt buộc để thay đổi kiểu
            dtgv_accountList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DarkSlateGray; // Màu nền
            dtgv_accountList.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Pink; // Màu chữ
            dtgv_accountList.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold); // Font chữ
        }
        private void LoadDataIntoDataGridBox()
        {
            using (var _context = new ShopNoirContext())
            {
                try
                {
                    // Tính tổng số bản ghi
                    totalRecords = _context.Accounts.Where(ac => ac.Status == true).Count();
                    lbl_trang.Text = $"Page {currentPage} / {Math.Ceiling((double)totalRecords / pageSize)}";

                    var sortColumn = cbbx_cot.SelectedItem.ToString() switch
                    {
                        "Name" => "name",
                        "Username" => "username",
                        "Role" => "role",
                        _ => "username" // Giá trị mặc định
                    };
                    string sortOrder = (cbbx_sapxep.SelectedItem != null &&
                        cbbx_sapxep.SelectedItem.ToString().Equals("ASC")) ? "asc" : "desc";


                    // Lấy từ khóa tìm kiếm từ TextBox
                    string keyword = tbx_timkiem.Text.Trim();

                    // Truy vấn dữ liệu cho trang hiện tại
                    var accounts = _context.Accounts
                        .Where(ac => (ac.Name.Contains(keyword)
                        || ac.Username.Contains(keyword)) && ac.Status == true)
                        .OrderBy($"{sortColumn} {sortOrder}") // Đảm bảo sắp xếp trước khi phân trang
                        .Skip((currentPage - 1) * pageSize) // Bỏ qua bản ghi trước đó
                        .Take(pageSize) // Lấy số bản ghi theo pageSize
                        .ToList();

                    // Gán dữ liệu vào DataGridView
                    dtgv_accountList.DataSource = accounts;

                    dtgv_accountList.Columns["Invoices"].Visible = false;
                    dtgv_accountList.Columns["Status"].Visible = false;
                    dtgv_accountList.Columns["Id"].Visible = false;
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

        private void btn_create_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các TextBox
            string name = tbx_name.Text.Trim();
            string username = tbx_username.Text.Trim();
            string password = tbx_password.Text.Trim();
            string phone = tbx_phone.Text.Trim();
            string role = cbbx_role.Text.Trim();

            // Kiểm tra dữ liệu nhập vào

            // Kiểm tra dữ liệu nhập vào
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("All fields are required!");
                return;
            }

            // Kiểm tra username đã tồn tại
            using (var _dbContext = new ShopNoirContext())
            {
                if (_dbContext.Accounts.Any(u => u.Username == username))
                {
                    MessageBox.Show("Username already exists!");
                    return;
                }
            }
            // Kiểm tra mật khẩu không chứa khoảng trắng
            if (password.Contains(" "))
            {
                MessageBox.Show("Password cannot contain spaces!");
                return;
            }

            // Kiểm tra số điện thoại Việt Nam
            if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^0\d{9}$"))
            {
                MessageBox.Show("Phone number must start with 0 and be 10 digits long!");
                return;
            }

            // Tạo đối tượng khách hàng mới
            var newAccount = new Account
            {
                Name = name,
                Username = username,
                Password = password,
                PhoneNumber = phone,
                Role = role.Equals("Admin") ? true : false, // true : admin, false: staff
                Status = true
            };

            using (var _context = new ShopNoirContext())
            {
                // Thêm khách hàng mới vào DbContext
                _context.Accounts.Add(newAccount);

                // Lưu thay đổi vào cơ sở dữ liệu
                _context.SaveChangesAsync();

                MessageBox.Show("Create new account sucessfully!!");

                // Xóa dữ liệu nhập trên form
                resetInformation();

                // Tải lại dữ liệu hiển thị trên DataGridView
                LoadDataIntoDataGridBox();
            }
        }
        private void dtgv_accountList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgv_accountList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgv_accountList.MultiSelect = false;
            if (e.RowIndex >= 0) // Kiểm tra xem có dòng nào được chọn không
            {
                // Chọn cả dòng chứa ô được nhấp
                dtgv_accountList.Rows[e.RowIndex].Selected = true;

                DataGridViewRow row = dtgv_accountList.Rows[e.RowIndex];

                // Hiển thị dữ liệu từ DataGridView lên các TextBox
                _Id = (Guid)row.Cells["Id"].Value;
                tbx_name.Text = row.Cells["Name"].Value.ToString();
                tbx_username.Text = row.Cells["Username"].Value.ToString();
                tbx_password.Text = row.Cells["Password"].Value.ToString();
                tbx_phone.Text = row.Cells["PhoneNumber"].Value.ToString();
                cbbx_role.Text = ((bool)row.Cells["Role"].Value == true) ? "Admin" : "Staff";
                //cbbx_role.Text = row.Cells["Role"].Value.ToString();

                btn_update.Enabled = true;
                btn_delete.Enabled = true;
                btn_create.Enabled = false;
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các TextBox
            string name = tbx_name.Text.Trim();
            string username = tbx_username.Text.Trim();
            string password = tbx_password.Text.Trim();
            string phone = tbx_phone.Text.Trim();
            string role = cbbx_role.Text.Trim();

            // Kiểm tra dữ liệu nhập vào
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Username, password, role is required!!");
                return;
            }
            using (var _context = new ShopNoirContext())
            {
                // Tìm Province cần cập nhật trong cơ sở dữ liệu
                var Account = _context.Accounts.FirstOrDefault(p => p.Id.Equals(_Id));

                if (Account != null)
                {
                    {
                        Account.Name = name;
                        Account.Username = username;
                        Account.Password = password;
                        Account.PhoneNumber = phone;
                        Account.Role = role.Equals("Admin") ? true : false; // true : admin, false: staff

                        // Lưu thay đổi vào cơ sở dữ liệu
                        _context.SaveChanges();

                        // Thông báo thành công
                        MessageBox.Show("Update successfully!!");

                        // Làm mới DataGridView
                        LoadDataIntoDataGridBox();
                    }
                }
                else
                {
                    MessageBox.Show("Don't find account to update");
                }
            }
        }
        private void btn_reset_Click(object sender, EventArgs e)
        {
            resetInformation();
            dtgv_accountList.ClearSelection();
            btn_create.Enabled = true;
            btn_delete.Enabled = false;
            btn_update.Enabled = false;
        }
        private void resetInformation()
        {
            tbx_name.Clear();
            tbx_username.Clear();
            tbx_password.Clear();
            tbx_phone.Clear();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào đang được chọn
            if (dtgv_accountList.SelectedRows.Count > 0)
            {
                // Xác nhận xóa
                DialogResult result = MessageBox.Show("Do you want to deactivate this account?", "Deactivate account", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    var accountId = (Guid)dtgv_accountList.SelectedRows[0].Cells["Id"].Value;
                    using (var _context = new ShopNoirContext())
                    {
                        // Chuyển Status thành 0 để đánh dấu tài khoản là "đã xóa"
                        int rowsAffected = _context.Database.ExecuteSqlRaw("UPDATE Accounts SET Status = 0 WHERE Id = {0}", accountId);

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Tài khoản đã được chuyển sang trạng thái không hoạt động!");

                            LoadDataIntoDataGridBox();
                            btn_update.Enabled = false;
                            btn_delete.Enabled = false;
                            btn_create.Enabled = true;
                            resetInformation();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy tài khoản để cập nhật.");
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản để cập nhật.");
            }
        }
        }
    }

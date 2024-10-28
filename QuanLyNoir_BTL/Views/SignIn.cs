using QuanLyNoir_BTL.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyNoir_BTL
{
    public partial class SignIn : Form
    {
        private readonly ShopNoirTestContext _dbContext = new ShopNoirTestContext();
        public SignIn()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_signin.MouseEnter += btn_signin_MouseEnter;
            btn_signin.MouseLeave += btn_signin_MouseLeave;

            LoginForm_Load(null, null);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btn_signin_Click(object sender, EventArgs e)
        {

            string username = tbx_username.Text;
            string password = tbx_password.Text;

            // Kiểm tra thông tin đăng nhập từ cơ sở dữ liệu
            var user = _dbContext.Accounts.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                // Đăng nhập thành công
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xử lý Remember Me
                if (chbx_rememberme.Checked)
                {
                    // Lưu thông tin đăng nhập vào cài đặt của ứng dụng (hoặc file config)
                    Settings.Default.username = username;
                    Settings.Default.password = password;
                    Settings.Default.Save();
                }
                else
                {
                    // Xóa thông tin lưu nếu không chọn Remember Me
                    Settings.Default.username = "";
                    Settings.Default.password = "";
                    Settings.Default.Save();
                }
            }
            else
            {
                // Đăng nhập thất bại
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Kiểm tra và tải thông tin Remember Me nếu có
            if (!string.IsNullOrEmpty(Settings.Default.username) && !string.IsNullOrEmpty(Settings.Default.password))
            {
                tbx_username.Text = Settings.Default.username;
                tbx_password.Text = Settings.Default.password;
                chbx_rememberme.Checked = true; // Đánh dấu Remember Me nếu đã lưu thông tin
            }
        }

        private void btn_forgotpassword_Click(object sender, EventArgs e)
        {
            // Chuyển hướng tới trang đặt lại mật khẩu hoặc xử lý quên mật khẩu tại đây
            MessageBox.Show("Vui lòng liên hệ quản trị viên để đặt lại mật khẩu.", "Quên mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_signin_MouseEnter(object sender, EventArgs e)
        {
            // Đổi màu nền và màu chữ khi di chuột vào nút
            btn_signin.BackColor = Color.White; // Đổi màu nền thành màu xanh (hoặc màu bạn muốn)
            btn_signin.ForeColor = Color.Black; // Đổi màu chữ thành màu trắng (hoặc màu bạn muốn)
        }

        private void btn_signin_MouseLeave(object sender, EventArgs e)
        {
            // Khôi phục màu nền và màu chữ khi rời khỏi nút
            btn_signin.BackColor = Color.DarkOliveGreen; // Đặt lại màu nền mặc định
            btn_signin.ForeColor = SystemColors.Control; // Đặt lại màu chữ mặc định
        }

    }
}

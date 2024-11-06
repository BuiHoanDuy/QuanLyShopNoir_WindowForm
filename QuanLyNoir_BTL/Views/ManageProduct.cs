using QuanLyNoir_BTL.Models;
using QuanLyNoir_BTL.Views;
using System.Windows.Forms;

namespace QuanLyNoir_BTL
{
    public partial class ManageProduct : Form
    {
        private readonly ShopNoirTestContext _dbContext = new ShopNoirTestContext();
        private int currentPage = 1;
        private const int PageSize = 8; // Giữ số lượng bản ghi trên mỗi trang là 6
        private int totalRecords;

        private string currentType = null; // Loại sản phẩm hiện tại (null nghĩa là không lọc theo loại)

        ManageProductControl manageProductControl = new ManageProductControl();

        private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        private const int TimerInterval = 500; // Thời gian chờ 500ms
        public ManageProduct(string username)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            lbl_name.Text = username;

            pnl_control.Controls.Clear();  // Xóa các UserControl hiện tại
            pnl_control.Controls.Add(manageProductControl);
        }
        private void ManageProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); // Đóng toàn bộ ứng dụng nếu người dùng chọn "Yes"
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SignIn signInForm = new SignIn();
            signInForm.Show();
            this.Hide(); // Ẩn form đăng nhập
        }

        private void btn_manageproduct_Click(object sender, EventArgs e)
        {
            pnl_control.Controls.Clear();  // Xóa các UserControl hiện tại
            pnl_control.Controls.Add(manageProductControl);
        }
    }
}
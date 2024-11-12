using QuanLyNoir_BTL.Models;
using QuanLyNoir_BTL.Views;
using System.ComponentModel;
using System.Windows.Forms;

namespace QuanLyNoir_BTL
{
    public partial class MenuForm : Form
    {
        private readonly ShopNoirContext _dbContext = new ShopNoirContext();
        private int currentPage = 1;
        private const int PageSize = 8; // Giữ số lượng bản ghi trên mỗi trang là 6
        private int totalRecords;

        private string currentType = null; // Loại sản phẩm hiện tại (null nghĩa là không lọc theo loại)

        // Khai báo các đối tượng nhưng chưa khởi tạo
        private ManageProductControl manageProductControl;
        private ManageAccountControl manageAccountControl;
        private ManageVoucherControl voucherControl;

        private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        private const int TimerInterval = 500; // Thời gian chờ 500ms
        public MenuForm(string username)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            lbl_name.Text = username;

            backgroundWorker1.RunWorkerAsync();
        }
        private void ManageProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); // Đóng toàn bộ ứng dụng nếu người dùng chọn "Yes"
        }

        private void updateEffectClickedButton(Button btn)
        {
            btn_manageAccount.BackColor = Color.White;
            btn_manageVoucher.BackColor = Color.White;
            btn_manageproduct.BackColor = Color.White;
            btn_manageOrder.BackColor = Color.White;
            btn_analyseRevenue.BackColor = Color.White;

            btn_manageAccount.ForeColor = Color.Black;
            btn_manageVoucher.ForeColor = Color.Black;
            btn_manageproduct.ForeColor = Color.Black;
            btn_manageOrder.ForeColor = Color.Black;
            btn_analyseRevenue.ForeColor = Color.Black;

            btn.BackColor = Color.FromArgb(0, 64, 0);
            btn.ForeColor = Color.FromArgb(255, 128, 255);
        }

        private void btn_signout_Click(object sender, EventArgs e)
        {
            SignIn signInForm = new SignIn();
            signInForm.Show();
            this.Hide(); // Ẩn form đăng nhập
        }
        private void btn_manageproduct_Click(object sender, EventArgs e)
        {
            updateEffectClickedButton(btn_manageproduct);
            pnl_control.Controls.Clear();  // Xóa các UserControl hiện tại
            pnl_control.Controls.Add(manageProductControl);
        }

        private void btn_manageAccount_Click(object sender, EventArgs e)
        {
            updateEffectClickedButton(btn_manageAccount);
            pnl_control.Controls.Clear();  // Xóa các UserControl hiện tại
            pnl_control.Controls.Add(manageAccountControl);
        }
        private void btn_manageVoucher_Click(object sender, EventArgs e)
        {
            updateEffectClickedButton(btn_manageVoucher);
            pnl_control.Controls.Clear();
            pnl_control.Controls.Add(voucherControl);
        }

        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Khởi tạo các đối tượng trong BackgroundWorker
            manageProductControl = new ManageProductControl();
            manageAccountControl = new ManageAccountControl();
            voucherControl = new ManageVoucherControl();
        }

        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Hiển thị control quản lý sản phẩm sau khi hoàn tất khởi tạo
            pnl_control.Controls.Clear();
            pnl_control.Controls.Add(manageProductControl);
        }
    }
}
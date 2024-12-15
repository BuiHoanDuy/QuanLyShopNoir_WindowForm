using QuanLyNoir_BTL.Models;
using QuanLyNoir_BTL.Views;
using System.ComponentModel;
using System.Windows.Forms;

namespace QuanLyNoir_BTL
{
    public partial class MenuForm : Form
    {
        // Khai báo các đối tượng nhưng chưa khởi tạo
        private Lazy<ManageProductControl> manageProductControl = new Lazy<ManageProductControl>(() => new ManageProductControl());
        private Lazy<ManageAccountControl> manageAccountControl = new Lazy<ManageAccountControl>(() => new ManageAccountControl());
        private Lazy<ManageVoucherControl> manageVoucherControl = new Lazy<ManageVoucherControl>(() => new ManageVoucherControl());
        private Lazy<AnalyseRevenueControl> revenueControl = new Lazy<AnalyseRevenueControl>(() => new AnalyseRevenueControl());
        private Lazy<ManageOrderControl> manageOrderControl = new Lazy<ManageOrderControl>(() => new ManageOrderControl());
        public MenuForm(string username)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            lbl_name.Text = username;
        }
        private void ManageProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); // Đóng toàn bộ ứng dụng nếu người dùng chọn "Yes"
        }
        private void ShowControl(UserControl control)
        {
            foreach (Control c in pnl_control.Controls)
            {
                c.Visible = false; // Ẩn tất cả các UserControl
            }
            control.Visible = true; // Hiển thị UserControl cần thiết
            control.BringToFront();
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
            this.Text = "Manage Product";
            updateEffectClickedButton(btn_manageproduct);
            if (!pnl_control.Controls.Contains(manageProductControl.Value))
            {
                pnl_control.Controls.Add(manageProductControl.Value);
            }

            ShowControl(manageProductControl.Value);
        }

        private void btn_manageAccount_Click(object sender, EventArgs e)
        {
            this.Text = "Manage Account";
            updateEffectClickedButton(btn_manageAccount);
            if (!pnl_control.Controls.Contains(manageAccountControl.Value))
            {
                pnl_control.Controls.Add(manageAccountControl.Value);
            }

            ShowControl(manageAccountControl.Value);
        }
        private void btn_manageVoucher_Click(object sender, EventArgs e)
        {
            this.Text = "Manage Voucher";
            updateEffectClickedButton(btn_manageVoucher);
            if (!pnl_control.Controls.Contains(manageVoucherControl.Value))
            {
                pnl_control.Controls.Add(manageVoucherControl.Value);
            }

            ShowControl(manageVoucherControl.Value);
        }

        private void btn_manageOrder_Click(object sender, EventArgs e)
        {
            this.Text = "Manage Order";
            updateEffectClickedButton(btn_manageOrder);
            if (!pnl_control.Controls.Contains(manageOrderControl.Value))
            {
                pnl_control.Controls.Add(manageOrderControl.Value);
            }

            ShowControl(manageOrderControl.Value);
        }

        private void btn_analyseRevenue_Click(object sender, EventArgs e)
        {
            this.Text = "Analyse Revenue";
            updateEffectClickedButton(btn_analyseRevenue);
            if (!pnl_control.Controls.Contains(revenueControl.Value))
            {
                pnl_control.Controls.Add(revenueControl.Value);
            }

            ShowControl(revenueControl.Value);
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            if (!pnl_control.Controls.Contains(manageProductControl.Value))
            {
                pnl_control.Controls.Add(manageProductControl.Value);
            }

            ShowControl(manageProductControl.Value);
        }

        private void pnl_control_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
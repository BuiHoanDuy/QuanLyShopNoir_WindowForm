using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyNoir_BTL.Views
{
    public partial class MasterForm_SellProduct : Form
    {
        private string currentType;
        private int currentPage;

        public MasterForm_SellProduct(string username)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            lbl_name.Text = username;
            lbl_datetime.Text = DateTime.Now.ToLongDateString();
        }

        private void MasterForm_SellProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // Phần code Logic và truy vấn



        // Phần code để cập nhật giao diện, hiệu ứng, click chuột, ... : 
        private void btn_signout_Click(object sender, EventArgs e)
        {
            SignIn signInForm = new SignIn();
            signInForm.Show();
            this.Hide(); // Ẩn form đăng nhập
        }
        private void resetButtonTypeFilter()
        {
            btn_newcollection.ForeColor = Color.Black;
            btn_newcollection.BackColor = SystemColors.ControlLightLight;

            btn_bag.ForeColor = Color.Black;
            btn_bag.BackColor = SystemColors.ControlLightLight;

            btn_jacket.ForeColor = Color.Black;
            btn_jacket.BackColor = SystemColors.ControlLightLight;

            btn_all.ForeColor = Color.Black;
            btn_all.BackColor = SystemColors.ControlLightLight;
        }
        private void updateEffectClickedButton(System.Windows.Forms.Button btn)
        {
            resetButtonTypeFilter();
            btn.BackColor = Color.DarkSlateGray;
            btn.ForeColor = Color.Pink;
        }
        private void btn_bag_Click(object sender, EventArgs e)
        {
            resetButtonTypeFilter();
            updateEffectClickedButton(btn_bag);
            currentType = "Bag"; // Đặt loại sản phẩm là 'bag'
            currentPage = 1; // Quay lại trang đầu
        }

        private void btn_jacket_Click(object sender, EventArgs e)
        {
            updateEffectClickedButton(btn_jacket);
            currentType = "Jacket"; // Đặt loại sản phẩm là 'jacket'
            currentPage = 1; // Quay lại trang đầu
        }

        private void btn_newcollection_Click(object sender, EventArgs e)
        {
            updateEffectClickedButton(btn_newcollection);
            currentType = "New Collection"; // select tất cả các sản phẩm
            currentPage = 1; // Quay lại trang đầu
        }

        private void btn_all_Click(object sender, EventArgs e)
        {
            updateEffectClickedButton(btn_all);
            currentType = null; // Đặt loại sản phẩm là 'null' => chon tat ca
            currentPage = 1; // Quay lại trang đầu
        }


    }
}

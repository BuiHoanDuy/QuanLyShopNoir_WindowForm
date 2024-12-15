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
    public partial class TakingProductForm : Form
    {
        private ProductInfomation product;
        public TakingProductForm(ProductInfomation product)
        {
            InitializeComponent();
            this.product = product;
        }

        private void TakingProductForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            int count = int.Parse(lbl_amount.Text);
            if (count > 0)
            {
                lbl_amount.Text = (count - 1).ToString();
            }
        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            lbl_amount.Text = (int.Parse(lbl_amount.Text) + 1).ToString();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {

        }
    }
}

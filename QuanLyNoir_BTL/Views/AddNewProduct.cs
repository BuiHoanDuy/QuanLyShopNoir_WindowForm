using QuanLyNoir_BTL.Enums;
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
using QuanLyNoir_BTL.Enums;
using System.Data.Entity;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyNoir_BTL.Views
{
    public partial class AddNewProduct : Form
    {
        private readonly ShopNoirTestContext _dbContext; // Reference to database context
        private int currentProductColorId = -1; // Store product ID if updating an existing product
        private Guid currentProductId;
        private ProductSize? selectedSize = null;

        private string colorName = "Color name";

        //isNew: True -> Add New Item, False -> Update
        public AddNewProduct(ShopNoirTestContext dbContext, bool isNew, int productColorId)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _dbContext = dbContext;
            currentProductColorId = productColorId;

            btn_addcolor.Visible = false;

            SetupBackgroundWorker();
            SetupPlaceholder();
            if (isNew)
            {
                btn_update.Visible = false;
                btn_addtostore.Visible = true;
            }
            else
            {
                btn_update.Visible = true;
                btn_addtostore.Visible = false;
            }

            //       SetupPlaceholder();

            if (!isNew)
            {
                LoadProductData(currentProductColorId);
            }
        }
        public AddNewProduct(ShopNoirTestContext dbContext, Guid productId)
        {
            InitializeComponent();
            _dbContext = dbContext;
            currentProductId = productId;

            SetupBackgroundWorker();
            SetupPlaceholder();

            tbx_name.Enabled = false;
            cbbx_type.Enabled = false;
            tbx_width.Enabled = false;
            tbx_height.Enabled = false;

            btn_update.Visible = false;
            btn_addtostore.Visible = false;
            btn_addcolor.Visible = true;

            LoadProductData(currentProductId);
        }
        private void LoadProductData(int productColorId)
        {
            var color = _dbContext.ProductColors.FirstOrDefault(c => c.Id == productColorId);
            if (color != null)
            {
                tbx_colorNote.Text = color.ColorName;
                lbl_colorCode.Text = color.ColorCode;
                pnl_colorBox.BackColor = ColorTranslator.FromHtml(color.ColorCode);
                tbx_inventory.Text = color.Inventory.ToString();
                pictureBox1.Image = ByteArrayToImage(color.ImageUrl);
                var product = _dbContext.Products.FirstOrDefault(p => p.Id == color.ProductId);
                if (product != null)
                {
                    tbx_name.Text = product.ProdName;
                    tbx_material.Text = product.ProdDesc;
                    tbx_price.Text = product.Price.ToString();
                    tbx_width.Text = product.Wid.ToString();
                    tbx_height.Text = product.Hei.ToString();
                    cbbx_type.Text = product.Type;
                }
            }
        }
        private void LoadProductData(Guid productId)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                tbx_name.Text = product.ProdName;
                tbx_material.Text = product.ProdDesc;
                tbx_price.Text = product.Price.ToString();
                tbx_width.Text = product.Wid.ToString();
                tbx_height.Text = product.Hei.ToString();
                cbbx_type.Text = product.Type;
            }
        }
        private async Task ValidateAndSaveProductAsync(bool isNew, bool isAddColor)
        {
            // Call the appropriate function based on isNew flag

            if (isAddColor == true) await AddNewColorAsync();
            else
            {
                if (isNew)
                {
                    await AddNewProductAndColorAsync();
                }
                else
                {
                    await UpdateProductAndColorAsync();
                }
            }
        }

        private async Task AddNewColorAsync()
        {
            int.TryParse(tbx_inventory.Text, out int inventory);
            decimal.TryParse(tbx_price.Text, out decimal price);

            var productColor = new ProductColor
            {
                ProductId = currentProductId,
                ColorName = tbx_colorNote.Text,
                ColorCode = lbl_colorCode.Text,
                Inventory = inventory,
                Total = inventory,
                Size = (int)selectedSize.Value,
                ImageUrl = ImageToByteArray(pictureBox1.Image)
            };
            _dbContext.ProductColors.Add(productColor);

            await _dbContext.SaveChangesAsync();
        }
        private async Task AddNewProductAndColorAsync()
        {
            decimal.TryParse(tbx_width.Text, out decimal width);
            decimal.TryParse(tbx_height.Text, out decimal height);
            int.TryParse(tbx_inventory.Text, out int inventory);
            decimal.TryParse(tbx_price.Text, out decimal price);

            Product product = null;

            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    product = new Product
                    {
                        Id = Guid.NewGuid(),
                        ProdName = tbx_name.Text,
                        ProdDesc = tbx_material.Text,
                        Price = price,
                        Wid = width,
                        Hei = height,
                        Type = cbbx_type.Text
                    };
                });
            }
            else
            {
                product = new Product
                {
                    Id = Guid.NewGuid(),
                    ProdName = tbx_name.Text,
                    ProdDesc = tbx_material.Text,
                    Price = price,
                    Wid = width,
                    Hei = height,
                    Type = cbbx_type.Text
                };
            }

            _dbContext.Products.Add(product);


            var productColor = new ProductColor
            {
                ProductId = product.Id,
                ColorName = tbx_colorNote.Text,
                ColorCode = lbl_colorCode.Text,
                Inventory = inventory,
                Total = inventory,
                Size = (int)selectedSize.Value,
                ImageUrl = ImageToByteArray(pictureBox1.Image)
            };
            _dbContext.ProductColors.Add(productColor);

            await _dbContext.SaveChangesAsync();
        }

        private async Task UpdateProductAndColorAsync()
        {
            var productColor = _dbContext.ProductColors.FirstOrDefault(c => c.Id == currentProductColorId);
            if (productColor == null) return;

            decimal.TryParse(tbx_width.Text, out decimal width);
            decimal.TryParse(tbx_height.Text, out decimal height);
            int.TryParse(tbx_inventory.Text, out int inventory);
            decimal.TryParse(tbx_price.Text, out decimal price);

            productColor.ColorName = tbx_colorNote.Text;
            productColor.ColorCode = lbl_colorCode.Text;
            productColor.Inventory = inventory;
            productColor.Total = inventory;
            productColor.Size = (int)selectedSize.Value;
            productColor.ImageUrl = ImageToByteArray(pictureBox1.Image);

            var product = _dbContext.Products.FirstOrDefault(p => p.Id == productColor.ProductId);
            if (product != null)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        product.ProdName = tbx_name.Text;
                        product.ProdDesc = tbx_material.Text;
                        product.Price = price;
                        product.Wid = width;
                        product.Hei = height;
                        product.Type = cbbx_type.Text;
                    });
                }
                else
                {
                    product.ProdName = tbx_name.Text;
                    product.ProdDesc = tbx_material.Text;
                    product.Price = price;
                    product.Wid = width;
                    product.Hei = height;
                    product.Type = cbbx_type.Text;
                }
            }

            await _dbContext.SaveChangesAsync();
        }


        // Phương thức để xóa các dấu *
        private void ClearValidationMarks()
        {
            lbl_name.ForeColor = Color.Black;
            lbl_type.ForeColor = Color.Black;
            lbl_inventory.ForeColor = Color.Black;
            lbl_price.ForeColor = Color.Black;
            lbl_material.ForeColor = Color.Black;
            lbl_width.ForeColor = Color.Black;
            lbl_height.ForeColor = Color.Black;
            lbl_size.ForeColor = Color.Black;

            lbl_name.Text = "";
            lbl_type.Text = "";
            lbl_inventory.Text = "";
            lbl_price.Text = "";
            lbl_material.Text = "";
            lbl_width.Text = "";
            lbl_height.Text = "";
            lbl_size.Text = "";
            lbl_color.Text = "";
        }

        // Phương thức để hiển thị dấu *
        private void ShowValidationMark(Label label, string message)
        {
            label.ForeColor = Color.Red;
            label.Text = "*"; // Hoặc bất kỳ văn bản nào khác để thông báo lỗi
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        private void btn_reset_Click(object sender, EventArgs e)
        {
            // Đặt lại các trường nhập liệu
            tbx_name.Text = string.Empty;
            cbbx_type.Text = string.Empty;
            cbbx_type.SelectedIndex = -1; // Đặt lại ComboBox nếu cần
            tbx_colorNote.Text = "Color Name"; // Đặt lại placeholder
            tbx_colorNote.ForeColor = Color.Gray; // Đặt lại màu sắc cho placeholder
            lbl_colorCode.Text = "#FFFFFF"; // Màu mặc định
            pnl_colorBox.BackColor = Color.Transparent;

            tbx_inventory.Text = string.Empty;
            tbx_price.Text = string.Empty;
            tbx_material.Text = string.Empty;
            tbx_width.Text = string.Empty;
            tbx_height.Text = string.Empty;

            // Đặt lại hình ảnh trong PictureBox
            pictureBox1.Image = null; // Hoặc hình ảnh mặc định nếu cần
        }

        private void btn_addtostore_Click(object sender, EventArgs e)
        {
            StartBackgroundOperation(true, false);
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            StartBackgroundOperation(false, false);
        }
        private void btn_addcolor_Click(object sender, EventArgs e)
        {
            StartBackgroundOperation(true, true);
        }
        private void StartBackgroundOperation(bool isNew, bool isAddColor)
        {
            ClearValidationMarks();

            // Perform validations
            if (string.IsNullOrWhiteSpace(tbx_name.Text))
            {
                ShowValidationMark(lbl_name, "Vui lòng nhập tên sản phẩm!");
                return;
            }

            if (string.IsNullOrWhiteSpace(cbbx_type.Text))
            {
                ShowValidationMark(lbl_type, "Vui lòng chọn loại sản phẩm!");
                return;
            }

            if (string.IsNullOrWhiteSpace(tbx_width.Text) || !decimal.TryParse(tbx_width.Text, out decimal width) || width <= 0)
            {
                ShowValidationMark(lbl_width, "Vui lòng nhập chiều rộng hợp lệ (phải là số dương)!");
                return;
            }

            if (string.IsNullOrWhiteSpace(tbx_height.Text) || !decimal.TryParse(tbx_height.Text, out decimal height) || height <= 0)
            {
                ShowValidationMark(lbl_height, "Vui lòng nhập chiều cao hợp lệ (phải là số dương)!");
                return;
            }

            if (selectedSize == null)
            {
                ShowValidationMark(lbl_size, "Vui lòng chọn kích thước cho sản phẩm!");
                return;
            }

            if (string.IsNullOrWhiteSpace(lbl_colorCode.Text))
            {
                ShowValidationMark(lbl_color, "Vui lòng chọn màu sắc!");
                return;
            }

            if (string.IsNullOrWhiteSpace(tbx_inventory.Text) || !int.TryParse(tbx_inventory.Text, out int inventory) || inventory < 0)
            {
                ShowValidationMark(lbl_inventory, "Vui lòng nhập số lượng tồn kho hợp lệ (phải là số không âm)!");
                return;
            }

            if (string.IsNullOrWhiteSpace(tbx_price.Text) || !decimal.TryParse(tbx_price.Text, out decimal price) || price < 0)
            {
                ShowValidationMark(lbl_price, "Vui lòng nhập giá sản phẩm hợp lệ (phải là số không âm)!");
                return;
            }

            if (string.IsNullOrWhiteSpace(tbx_material.Text))
            {
                ShowValidationMark(lbl_material, "Vui lòng nhập thông tin về vật liệu sản phẩm!");
                return;
            }
            progressBar1.Style = ProgressBarStyle.Marquee; // Show indeterminate progress
            progressBar1.Visible = true;

            var operationArgs = new { IsNew = isNew, IsAddColor = isAddColor };
            bgWorker.RunWorkerAsync(operationArgs);
        }
        private async void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            dynamic args = e.Argument;
            bool isNew = args.IsNew;
            bool isAddColor = args.IsAddColor;
            await ValidateAndSaveProductAsync(isNew, isAddColor);
        }
        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Visible = false; // Hide progress bar when done
            MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        private Image ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null) return null;
            using (var ms = new MemoryStream(byteArray))
            {
                Image img = Image.FromStream(ms);
                return new Bitmap(img); // Tạo bản sao để không phụ thuộc vào MemoryStream
            }
        }
        private byte[] ImageToByteArray(Image image)
        {
            try
            {
                if (image == null)
                {
                    // Return null or an empty byte array, depending on your requirements

                    return null;
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Save as PNG or desired format
                    return ms.ToArray();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi tải ảnh");
                return null;
            }
        }

        private void SetupBackgroundWorker()
        {
            bgWorker = new BackgroundWorker();
            bgWorker.DoWork += BgWorker_DoWork;
            bgWorker.RunWorkerCompleted += BgWorker_RunWorkerCompleted;
            bgWorker.WorkerReportsProgress = false;
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            // Kiểm tra nếu dữ liệu là tệp
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy; // Hiển thị biểu tượng chấp nhận kéo thả
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            // Lấy đường dẫn tệp từ dữ liệu thả vào
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            // Kiểm tra xem có phải là tệp hình ảnh không, rồi hiển thị trong PictureBox
            if (files.Length > 0 && (files[0].EndsWith(".jpg") || files[0].EndsWith(".png") || files[0].EndsWith(".jpeg")))
            {
                pictureBox1.Image = Image.FromFile(files[0]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Tuỳ chọn hiển thị ảnh
            }
            else
            {
                MessageBox.Show("Vui lòng thả vào một tệp hình ảnh hợp lệ.");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void resetSizeOfProductColor(System.Windows.Forms.Button sizeButton)
        {
            btn_xs.BackColor = Color.White;
            btn_s.BackColor = Color.White;
            btn_m.BackColor = Color.White;
            btn_l.BackColor = Color.White;
            btn_xl.BackColor = Color.White;
            btn_xxl.BackColor = Color.White;
            btn_xxxl.BackColor = Color.White;

            btn_xs.ForeColor = Color.Black;
            btn_s.ForeColor = Color.Black;
            btn_m.ForeColor = Color.Black;
            btn_l.ForeColor = Color.Black;
            btn_xl.ForeColor = Color.Black;
            btn_xxl.ForeColor = Color.Black;
            btn_xxxl.ForeColor = Color.Black;

            sizeButton.ForeColor = Color.AliceBlue;
            sizeButton.BackColor = Color.DarkSeaGreen;

            // Gán giá trị của enum dựa trên nút đã chọn
            if (Enum.TryParse(sizeButton.Text, out ProductSize size))
            {
                selectedSize = size;
            }
        }

        private void btn_xs_Click(object sender, EventArgs e)
        {
            resetSizeOfProductColor(btn_xs);
        }

        private void btn_s_Click(object sender, EventArgs e)
        {
            resetSizeOfProductColor(btn_s);
        }

        private void btn_m_Click(object sender, EventArgs e)
        {
            resetSizeOfProductColor(btn_m);
        }

        private void btn_l_Click(object sender, EventArgs e)
        {
            resetSizeOfProductColor(btn_l);
        }

        private void btn_xl_Click(object sender, EventArgs e)
        {
            resetSizeOfProductColor(btn_xl);
        }

        private void btn_xxl_Click(object sender, EventArgs e)
        {
            resetSizeOfProductColor(btn_xxl);
        }

        private void btn_3xl_Click(object sender, EventArgs e)
        {
            resetSizeOfProductColor(btn_xxxl);
        }

        private void btn_choosecolor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.AllowFullOpen = true;
                colorDialog.FullOpen = true;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy mã hex từ màu đã chọn
                    Color selectedColor = colorDialog.Color;
                    pnl_colorBox.BackColor = selectedColor;

                    // Chuyển đổi màu sang mã hex
                    lbl_colorCode.Text = $"#{selectedColor.R:X2}{selectedColor.G:X2}{selectedColor.B:X2}";

                    // Lấy tên màu
                    colorName = GetColorName(selectedColor);
                    tbx_colorNote.Text = colorName;
                }
            }
        }

        private string GetColorName(Color color)
        {
            // Kiểm tra xem có tên màu nào đã được định nghĩa không
            string name = color.Name;

            // Nếu tên màu là "Color [R,G,B]" (khi không có tên định nghĩa), trả về "Unknown"
            return name == "Color [0, 0, 0]" ? "Unknown Color" : name;
        }


        private void SetupPlaceholder()
        {
            tbx_colorNote.Text = colorName;
            tbx_colorNote.ForeColor = Color.Gray; // Màu sắc cho placeholder

            // Thêm sự kiện cho TextBox
            tbx_colorNote.Enter += RemovePlaceholder;
            tbx_colorNote.Leave += SetPlaceholder;
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (tbx_colorNote.Text == colorName)
            {
                tbx_colorNote.Text = "";
                tbx_colorNote.ForeColor = Color.Black; // Màu chữ khi nhập
            }
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbx_colorNote.Text))
            {
                tbx_colorNote.Text = colorName;
                tbx_colorNote.ForeColor = Color.Gray; // Màu sắc cho placeholder
            }
        }
    }
}

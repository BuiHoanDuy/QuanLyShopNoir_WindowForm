using Microsoft.EntityFrameworkCore;
using QuanLyNoir_BTL.Models;
using QuanLyNoir_BTL.Utils;
using System.ComponentModel;
using System.IO;


namespace QuanLyNoir_BTL.Views
{
    public partial class AddNewProduct : Form
    {
        private Guid currentProductColorId = Guid.Empty; // Store product ID if updating an existing product
        private Guid currentProductId = Guid.Empty;
        private string currentSize = null;

        private string colorName = "Color name";
        private string imageURL;
        private Image image;

        private bool reload;
        //isNew: True -> Add New Item, False -> Update
        public AddNewProduct(bool isNew, Guid productColorId) //Chinh sua hoac them moi
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            currentProductColorId = productColorId;

            btn_addcolor.Visible = false;
            this.Focus();
            SetupBackgroundWorker();
            SetupPlaceholder();
            reload = !isNew;
            if (isNew)
            {
                this.Text = "Add New Product";
                lbl_formName.Text = "Add New Product";
                btn_update.Visible = false;
                btn_addtostore.Visible = true;
                cbbx_type.SelectedIndex = 0;
            }
            else
            {
                this.Text = "Edit Product";
                lbl_formName.Text = "Edit Product";
                btn_update.Visible = true;
                btn_addtostore.Visible = false;

                LoadProductData(currentProductColorId);
            }
        }
        public AddNewProduct(Guid productId, char Choice) //C: color, S: size, D: detail
        {
            InitializeComponent();
            currentProductId = productId;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Add New Color";
            lbl_formName.Text = "Add New Color";
            this.Focus();
            SetupBackgroundWorker();
            SetupPlaceholder();

            tbx_name.Enabled = false;
            cbbx_type.Enabled = false;
            tbx_width.Enabled = false;
            tbx_height.Enabled = false;
            tbx_material.Enabled = false;

            btn_update.Visible = false;
            btn_addtostore.Visible = false;
            btn_addcolor.Visible = true;

            if (Choice == 'C') LoadProductDataForAddColor(currentProductId);
            if (Choice == 'S')
            {
                this.Text = "Add New Size";
                lbl_formName.Text = "Add New Size";
                pictureBox1.Enabled = false;
                LoadProductData(currentProductId);
                using (var _dbContext = new ShopNoirContext())
                {
                    var color = _dbContext.ProductColors.FirstOrDefault(c => c.Id == productId);
                    tbx_inventory.Clear();
                    tbx_height.Enabled = true;
                    tbx_width.Enabled = true;
                    if (color != null)
                    {
                        var product = _dbContext.Products.FirstOrDefault(p => p.Id == color.ProductId);
                        if (product != null)
                        {
                            currentProductId = product.Id;
                        }
                    }
                }
            }
        }
        private async Task LoadProductData(Guid productColorId) // load data cho edit
        {
            ProductColor color;
            Product product;
            ProductColorSize productColorSize;
            string imageUrl = null;

            // Tải dữ liệu trên luồng khác
            using (var _dbContext = new ShopNoirContext())
            {
                color = await _dbContext.ProductColors.FindAsync(productColorId);
                if (color == null) return;

                productColorSize = await _dbContext.ProductColorSizes
                    .FirstOrDefaultAsync(pcs => pcs.ProductColorId == color.Id && pcs.SizeId == currentSize);

                product = await _dbContext.Products.FindAsync(color.ProductId);

                // Kiểm tra đường dẫn hình ảnh (không cần truy cập UI thread)
                if (!string.IsNullOrEmpty(color.ImageUrl) && File.Exists(color.ImageUrl))
                {
                    imageUrl = color.ImageUrl;
                }
            }

            // Cập nhật giao diện trên UI thread
            Invoke((MethodInvoker)(() =>
            {
                // Cập nhật thông tin ProductColor
                tbx_colorNote.Text = color.ColorName;
                lbl_colorCode.Text = color.ColorCode;
                pnl_colorBox.BackColor = ColorTranslator.FromHtml(color.ColorCode);

                // Cập nhật thông tin ProductColorSize
                tbx_inventory.Text = productColorSize != null ? productColorSize.Inventory.ToString() : "0";

                // Cập nhật hình ảnh
                if (imageUrl != null)
                {
                    imageURL = imageUrl;
                    pictureBox1.Image = Image.FromFile(imageURL);
                }
                else
                {
                    pictureBox1.Image = null; // Hoặc hình ảnh mặc định
                }

                // Cập nhật thông tin Product
                if (product != null)
                {
                    tbx_name.Text = product.ProdName;
                    tbx_material.Text = product.ProdDesc;
                    tbx_price.Text = product.Price.ToString();
                    tbx_width.Text = product.Width.ToString();
                    tbx_height.Text = product.Height.ToString();
                    cbbx_type.Text = product.Type;
                }
            }));
        }

        private void LoadProductDataForAddColor(Guid productId) //them mau moi
        {
            using (var _dbContext = new ShopNoirContext())
            {
                var product = _dbContext.Products.FirstOrDefault(p => p.Id == productId);
                if (product != null)
                {
                    tbx_name.Text = product.ProdName;
                    tbx_material.Text = product.ProdDesc;
                    tbx_price.Text = product.Price.ToString();
                    tbx_width.Text = product.Width.ToString();
                    tbx_height.Text = product.Height.ToString();
                    cbbx_type.Text = product.Type;
                }
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
            // Chuyển giá trị từ textbox sang kiểu dữ liệu phù hợp
            int.TryParse(tbx_inventory.Text, out int inventory);
            decimal.TryParse(tbx_price.Text, out decimal price);

            using (var _dbContext = new ShopNoirContext())
            {
                // Kiểm tra xem sản phẩm cùng màu và kích thước đã tồn tại chưa
                var existingProductColorSize = _dbContext.ProductColorSizes
                    .Include(pcs => pcs.ProductColor)
                    .FirstOrDefault(pcs =>
                        pcs.ProductColor.ProductId == currentProductId && // currentProductId là Id của sản phẩm hiện tại
                        pcs.ProductColor.ColorCode == lbl_colorCode.Text &&
                        pcs.SizeId == currentSize);

                if (existingProductColorSize != null)
                {
                    // Nếu đã tồn tại, cộng thêm inventory
                    existingProductColorSize.Inventory += inventory;
                }
                else
                {
                    // Kiểm tra sản phẩm có tồn tại chưa trước khi tạo ProductColor mới
                    var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == currentProductId);
                    if (product == null)
                    {
                        MessageBox.Show("Sản phẩm không tồn tại.");
                        return; // Dừng nếu sản phẩm không tồn tại
                    }

                    // Thêm sản phẩm mới nếu chưa có
                    var productColor = new ProductColor
                    {
                        ProductId = currentProductId, // Lấy Id sản phẩm hiện tại
                        ColorName = tbx_colorNote.Text,
                        ColorCode = lbl_colorCode.Text,
                        ImageUrl = imageURL,
                    };

                    _dbContext.ProductColors.Add(productColor);
                    await _dbContext.SaveChangesAsync(); // Lưu để lấy Id cho ProductColor

                    // Thêm thông tin ProductColorSize với kích thước và tồn kho
                    var productColorSize = new ProductColorSize
                    {
                        ProductColorId = productColor.Id,
                        SizeId = currentSize,
                        Inventory = inventory,
                    };

                    _dbContext.ProductColorSizes.Add(productColorSize);
                }

                // Lưu tất cả thay đổi vào database
                await _dbContext.SaveChangesAsync();
            }
        }

        private async Task AddNewProductAndColorAsync() // thêm sản phẩm mới
        {
            decimal.TryParse(tbx_width.Text, out decimal width);
            decimal.TryParse(tbx_height.Text, out decimal height);
            int.TryParse(tbx_inventory.Text, out int inventory);
            decimal.TryParse(tbx_price.Text, out decimal price);

            Product product = new Product();
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    product.ProdName = tbx_name.Text;
                    product.ProdDesc = tbx_material.Text;
                    product.Price = price;
                    product.Width = width;
                    product.Height = height;
                    product.Type = cbbx_type.Text;
                });
            }
            else
            {
                product.ProdName = tbx_name.Text;
                product.ProdDesc = tbx_material.Text;
                product.Price = price;
                product.Width = width;
                product.Height = height;
                product.Type = cbbx_type.Text;
            }

            using (var _dbContext = new ShopNoirContext())
            {
                // Kiểm tra sản phẩm có tồn tại chưa (dựa trên ProdName và Type)
                var existingProduct = await _dbContext.Products
                    .FirstOrDefaultAsync(p => p.ProdName == product.ProdName && p.Type == product.Type);

                if (existingProduct == null)
                {
                    // Nếu sản phẩm chưa tồn tại, thêm mới
                    _dbContext.Products.Add(product);
                    await _dbContext.SaveChangesAsync(); // Lưu Product để đảm bảo Product.Id đã tồn tại
                }
                else
                {
                    // Nếu sản phẩm đã tồn tại, sử dụng Id của sản phẩm đó
                    product = existingProduct;
                }

                // Kiểm tra ProductColor (màu sắc sản phẩm) đã tồn tại chưa
                var existingProductColor = await _dbContext.ProductColors
                    .FirstOrDefaultAsync(pc => pc.ProductId == product.Id && pc.ColorCode == lbl_colorCode.Text);

                ProductColor productColor;
                if (existingProductColor == null)
                {
                    // Nếu chưa tồn tại, thêm ProductColor mới
                    productColor = new ProductColor
                    {
                        Id = Guid.NewGuid(),
                        ProductId = product.Id,
                        ColorName = tbx_colorNote.Text.Trim(),
                        ColorCode = lbl_colorCode.Text.Trim(),
                        ImageUrl = imageURL
                    };
                    _dbContext.ProductColors.Add(productColor);
                    await _dbContext.SaveChangesAsync(); // Lưu để lấy ProductColor.Id
                }
                else
                {
                    productColor = existingProductColor;
                }

                // Kiểm tra ProductColorSize đã tồn tại chưa
                var existingProductColorSize = await _dbContext.ProductColorSizes
                    .FirstOrDefaultAsync(pcs => pcs.ProductColorId == productColor.Id && pcs.SizeId == currentSize);

                if (existingProductColorSize != null)
                {
                    // Nếu đã tồn tại, cộng thêm số lượng inventory
                    existingProductColorSize.Inventory += inventory;
                }
                else
                {
                    // Nếu chưa tồn tại, thêm ProductColorSize mới
                    var productColorSize = new ProductColorSize
                    {
                        Id = Guid.NewGuid(),
                        ProductColorId = productColor.Id,
                        SizeId = currentSize,
                        Inventory = inventory
                    };
                    _dbContext.ProductColorSizes.Add(productColorSize);
                }

                // Lưu tất cả thay đổi vào database
                await _dbContext.SaveChangesAsync();
            }
        }


        private async Task UpdateProductAndColorAsync() // update / edit
        {
            using (var _dbContext = new ShopNoirContext())
            {
                var productColor = await _dbContext.ProductColors.FirstOrDefaultAsync(c => c.Id == currentProductColorId);
                if (productColor == null) return;

                decimal.TryParse(tbx_width.Text, out decimal width);
                decimal.TryParse(tbx_height.Text, out decimal height);
                int.TryParse(tbx_inventory.Text, out int inventory);
                decimal.TryParse(tbx_price.Text, out decimal price);

                // Cập nhật thông tin màu sắc
                productColor.ColorName = tbx_colorNote.Text;
                productColor.ColorCode = lbl_colorCode.Text;
                productColor.ImageUrl = imageURL;

                // Truy vấn hoặc tạo mới ProductColorSize
                var productColorSize = await _dbContext.ProductColorSizes
                    .FirstOrDefaultAsync(pcs => pcs.ProductColorId == productColor.Id && pcs.SizeId == currentSize);

                if (productColorSize != null)
                {
                    // Cập nhật nếu đã tồn tại
                    productColorSize.Inventory = inventory;
                }
                else
                {
                    // Nếu không tồn tại, tạo mới ProductColorSize
                    productColorSize = new ProductColorSize
                    {
                        ProductColorId = productColor.Id,
                        SizeId = currentSize,
                        Inventory = inventory
                    };
                    _dbContext.ProductColorSizes.Add(productColorSize);
                }

                // Cập nhật thông tin sản phẩm
                var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == productColor.ProductId);
                if (product != null)
                {
                    // Kiểm tra nếu đang chạy trên luồng phụ
                    if (this.InvokeRequired)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            product.ProdName = tbx_name.Text;
                            product.ProdDesc = tbx_material.Text;
                            product.Price = price;
                            product.Width = width;
                            product.Height = height;
                            product.Type = cbbx_type.Text;
                        });
                    }
                    else
                    {
                        product.ProdName = tbx_name.Text;
                        product.ProdDesc = tbx_material.Text;
                        product.Price = price;
                        product.Width = width;
                        product.Height = height;
                        product.Type = cbbx_type.Text;
                    }
                }

                // Lưu thay đổi
                await _dbContext.SaveChangesAsync();
            }
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
            if (currentSize == null)
            {
                ShowValidationMark(lbl_size, "Vui lòng chọn size sản phẩm");
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

        private async void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            // Lấy đường dẫn tệp từ dữ liệu thả vào
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            // Kiểm tra xem có phải là tệp hình ảnh không, rồi hiển thị trong PictureBox
            if (files.Length > 0 && (files[0].EndsWith(".jpg") || files[0].EndsWith(".png") || files[0].EndsWith(".jpeg")))
            {
                // Upload hình ảnh lên Azure Blob Storage
                AzureUploader uploader = new();
                string fileName = Path.GetFileName(imageURL);

                // Upload và lấy URL công khai từ Azure
                imageURL = await uploader.UploadImageAsync(Image.FromFile(imageURL), fileName);
                pictureBox1.Image = Image.FromFile(imageURL);
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
                    imageURL = ofd.FileName;
                    pictureBox1.Image = Image.FromFile(imageURL);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private async void resetSizeOfProductColor(System.Windows.Forms.Button sizeButton)
        {
            btn_none.BackColor = Color.White;
            btn_s.BackColor = Color.White;
            btn_m.BackColor = Color.White;
            btn_l.BackColor = Color.White;
            btn_xl.BackColor = Color.White;

            btn_none.ForeColor = Color.Black;
            btn_s.ForeColor = Color.Black;
            btn_m.ForeColor = Color.Black;
            btn_l.ForeColor = Color.Black;
            btn_xl.ForeColor = Color.Black;

            sizeButton.ForeColor = Color.AliceBlue;
            sizeButton.BackColor = Color.DarkSeaGreen;

            // Gán giá trị của enum dựa trên nút đã chọn

            if (sizeButton.Text == btn_none.Text) { currentSize = null; }
            else
            {
                currentSize = sizeButton.Text;
            }
            if (reload) await LoadProductData(currentProductColorId);

        }

        private void btn_none_Click(object sender, EventArgs e)
        {
            resetSizeOfProductColor(btn_none);
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

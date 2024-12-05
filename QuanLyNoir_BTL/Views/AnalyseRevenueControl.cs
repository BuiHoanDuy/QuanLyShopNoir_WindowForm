using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.EntityFrameworkCore;
using QuanLyNoir_BTL.Models;
using System.Windows.Media;
using System.Linq.Dynamic.Core;
using OfficeOpenXml;
using Timer = System.Windows.Forms.Timer;

namespace QuanLyNoir_BTL.Views
{
    public partial class AnalyseRevenueControl : UserControl
    {
        private string xTitle;
        private int year = 2024; // Năm mặc định
        private int month = 4;  // Tháng mặc định
        private string typeFilter = "monthly"; // Bộ lọc ban đầu ("monthly" hoặc "daily")
        private bool typeReport = true; //1; Chart, 0: dataGridView
        private int currentPage = 1; // Trang hiện tại
        private int pageSize = 14; // Số lượng bản ghi mỗi trang
        private int totalRecords; // Tổng số bản ghi

        // Khai báo ToolTip và Timer
        private ToolTip cellToolTip = new ToolTip();
        private Timer hoverTimer = new Timer();
        private Point cursorPosition; // Lưu vị trí con trỏ chuột
        public AnalyseRevenueControl()
        {
            InitializeComponent();
        }

        private async void LoadChartData(LiveCharts.WinForms.CartesianChart chart, string typeFilter)
        {
            List<string> labels = null;
            List<decimal> revenues = null;

            if (typeReport)
            {
                await Task.Run(async () =>
                {
                    SafeSetComboBoxValues();
                    if (typeFilter == "monthly")
                    {
                        xTitle = "Months in Year";
                        labels = GetMonthLabels();
                        revenues = await GetRevenueDataAsync(year, null);
                        GetTotalRevenueAndTotalOrdersAsync(year, null);
                    }
                    else
                    {
                        SafeSetComboBoxValues();
                        xTitle = "Days in Month";
                        labels = GetDayLabels(year, month);
                        revenues = await GetRevenueDataAsync(year, month);
                        GetTotalRevenueAndTotalOrdersAsync(year, month);
                    }
                });
                // Cập nhật biểu đồ
                UpdateChart(chart, labels, revenues);
            }
            else
            {
                SafeSetComboBoxValues();
                // Chạy song song việc tải dữ liệu bảng
                await Task.Run(() => LoadDataIntoDataGridBox());
            }
        }
        private void SafeSetComboBoxValues()
        {
            if (cbbx_year.InvokeRequired)
            {
                cbbx_year.Invoke(new Action(() => year = int.Parse(cbbx_year.Text)));
            }
            else
            {
                year = int.Parse(cbbx_year.Text);
            }
            if (cbbx_month.Enabled)
            {
                if (cbbx_month.InvokeRequired)
                {
                    cbbx_month.Invoke(new Action(() => month = int.Parse(cbbx_month.Text)));
                }
                else
                {
                    month = int.Parse(cbbx_month.Text);
                }
            }
        }

        private async void LoadDataIntoDataGridBox()
        {
            var invoiceData = await Task.Run(() => FetchInvoiceDataAsync());
            UpdateDataGridView(invoiceData); // Cập nhật trên luồng chính
        }
        private void UpdateChart(LiveCharts.WinForms.CartesianChart chart, List<string> labels, List<decimal> revenues)
        {
            var gradientBrush = new LinearGradientBrush
            {
                StartPoint = new System.Windows.Point(0, 0),
                EndPoint = new System.Windows.Point(0, 1),
                GradientStops = new GradientStopCollection
                {
                    new GradientStop(Colors.LightBlue, 0.0),
                    new GradientStop(Colors.SkyBlue, 0.5),
                    new GradientStop(Colors.SteelBlue, 1.0)
                }
            };

            chart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Revenue Report",
                    Values = new ChartValues<decimal>(revenues),
                    LineSmoothness = 0.7,
                    Fill = gradientBrush,
                    Stroke = new SolidColorBrush(Colors.SteelBlue),
                    PointGeometry = null
                }
            };

            chart.AxisX.Clear();
            chart.AxisX.Add(new Axis
            {
                Title = xTitle,
                Labels = labels,
                Separator = new Separator { Step = 1, StrokeThickness = 1 }
            });

            chart.AxisY.Clear();
            chart.AxisY.Add(new Axis
            {
                Title = "Revenue ($)",
                LabelFormatter = value => value.ToString("C0"),
                Separator = new Separator { StrokeThickness = 1 }
            });

            chart.LegendLocation = LegendLocation.Right;
        }


        private async Task<List<decimal>> GetRevenueDataAsync(int year, int? month)
        {
            using (var context = new ShopNoirContext())
            {
                if (month.HasValue)
                {
                    // Lấy doanh thu theo ngày
                    int daysInMonth = DateTime.DaysInMonth(year, month.Value);
                    var revenuePerDay = new decimal[daysInMonth];

                    var dailyRevenue = await context.Invoices
                        .AsNoTracking()
                        .Where(invoice => invoice.CreatedAt.HasValue
                                          && invoice.CreatedAt.Value.Year == year
                                          && invoice.CreatedAt.Value.Month == month.Value)
                        .GroupBy(invoice => invoice.CreatedAt.Value.Day)
                        .Select(g => new { Day = g.Key, Total = g.Sum(invoice => invoice.Total) })
                        .ToListAsync();

                    foreach (var revenue in dailyRevenue)
                    {
                        revenuePerDay[revenue.Day - 1] = revenue.Total;
                    }

                    return revenuePerDay.ToList();
                }
                else
                {
                    // Lấy doanh thu theo tháng
                    var revenuePerMonth = new decimal[12];

                    var monthlyRevenue = await context.Invoices
                        .AsNoTracking()
                        .Where(invoice => invoice.CreatedAt.HasValue && invoice.CreatedAt.Value.Year == year)
                        .GroupBy(invoice => invoice.CreatedAt.Value.Month)
                        .Select(g => new { Month = g.Key, Total = g.Sum(invoice => invoice.Total) })
                        .ToListAsync();

                    foreach (var revenue in monthlyRevenue)
                    {
                        revenuePerMonth[revenue.Month - 1] = revenue.Total;
                    }

                    return revenuePerMonth.ToList();
                }
            }
        }
        private async void GetTotalRevenueAndTotalOrdersAsync(int year, int? month)
        {
            decimal totalRevenue = 0;
            int totalOrders = 0;

            // Chạy truy vấn trên luồng khác
            await Task.Run(async () =>
            {
                using (var context = new ShopNoirContext())
                {
                    if (month.HasValue)
                    {
                        var result = await context.Invoices
                            .AsNoTracking()
                            .Where(invoice => invoice.CreatedAt.HasValue
                                              && invoice.CreatedAt.Value.Year == year
                                              && invoice.CreatedAt.Value.Month == month)
                            .GroupBy(_ => 1)
                            .Select(g => new
                            {
                                TotalRevenue = g.Sum(invoice => invoice.Total),
                                TotalOrders = g.Count()
                            })
                            .FirstOrDefaultAsync();

                        totalRevenue = result?.TotalRevenue ?? 0;
                        totalOrders = result?.TotalOrders ?? 0;
                    }
                    else
                    {
                        var result = await context.Invoices
                            .AsNoTracking()
                            .Where(invoice => invoice.CreatedAt.HasValue
                                              && invoice.CreatedAt.Value.Year == year)
                            .GroupBy(_ => 1)
                            .Select(g => new
                            {
                                TotalRevenue = g.Sum(invoice => invoice.Total),
                                TotalOrders = g.Count()
                            })
                            .FirstOrDefaultAsync();

                        totalRevenue = result?.TotalRevenue ?? 0;
                        totalOrders = result?.TotalOrders ?? 0;
                    }
                }
            });
            // Cập nhật giao diện trên luồng chính
            this.Invoke((MethodInvoker)delegate
            {
                lbl_totalRevenue.Text = $"{((double)totalRevenue * 0.9):C}";
                lbl_totalOrder.Text = $"{totalOrders} orders";
            });
        }


        private List<string> GetMonthLabels()
        {
            return new List<string> { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        }

        private List<string> GetDayLabels(int year, int month)
        {
            int daysInMonth = DateTime.DaysInMonth(year, month);
            return Enumerable.Range(1, daysInMonth).Select(day => day.ToString()).ToList();
        }

        private void llbl_daily_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            typeFilter = "daily";
            cbbx_month.Enabled = true;
            LoadChartData(cartesianChart1, typeFilter);
            linkLable_clickedEffect(llbl_daily);
        }

        private void llbl_monthly_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            typeFilter = "monthly";
            cbbx_month.Enabled = false;
            LoadChartData(cartesianChart1, typeFilter);
            linkLable_clickedEffect(llbl_monthly);

        }

        private void linkLable_clickedEffect(LinkLabel llbl)
        {
            llbl_daily.LinkColor = System.Drawing.Color.DimGray;
            llbl_monthly.LinkColor = System.Drawing.Color.DimGray;
            llbl.LinkColor = System.Drawing.Color.Black;
        }

        private void AnalyseRevenueControl_Load(object sender, EventArgs e)
        {
            // Tạo danh sách năm từ 2000 đến năm hiện tại
            int currentYear = DateTime.Now.Year;
            cbbx_year.Items.AddRange(Enumerable.Range(2000, currentYear - 1999).Cast<object>().ToArray());
            cbbx_year.SelectedItem = currentYear; // Chọn năm hiện tại

            // Tạo danh sách tháng (1 đến 12)
            cbbx_month.Items.AddRange(new string[]
            {
            "1", "2", "3", "4", "5", "6",
            "7", "8", "9", "10", "11", "12"
            });
            cbbx_month.SelectedIndex = DateTime.Now.Month - 1; // Chọn tháng hiện tại

            dataGridView1.EnableHeadersVisualStyles = false; // Bắt buộc để thay đổi kiểu
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DarkSlateGray; // Màu nền
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Pink; // Màu chữ
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold); // Font chữ

            // Cấu hình Timer
            hoverTimer.Interval = 500; // 0.5 giây
            hoverTimer.Tick += HoverTimer_Tick;

            // Tắt ToolTip theo mặc định
            cellToolTip.Active = false;
        }

        private void cbbx_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadChartData(cartesianChart1, typeFilter);
        }

        private void cbbx_month_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadChartData(cartesianChart1, typeFilter);
        }

        private void btn_detail_Click(object sender, EventArgs e)
        {
            typeReport = false;
            updateReportEffect();
        }

        private void btn_chart_Click(object sender, EventArgs e)
        {
            typeReport = true;
            updateReportEffect();
        }
        private void updateReportEffect()
        {
            if (typeReport)
            {
                btn_chart.Hide();
                btn_detail.Show();
                dataGridView1.Hide();
                cartesianChart1.Show();
                lbl_trang.Hide();
                btn_trangsau.Hide();
                btn_trangtruoc.Hide();
                lbl_nameOfReport.Text = "Revenue Chart";
            }
            else
            {
                btn_chart.Show();
                btn_detail.Hide();
                dataGridView1.Show();
                cartesianChart1.Hide();
                lbl_trang.Show();
                btn_trangsau.Show();
                btn_trangtruoc.Show();
                lbl_nameOfReport.Text = "Revenue Detail";
            }
            LoadChartData(cartesianChart1, typeFilter);
        }
        private async Task<List<InvoiceInformation>> FetchInvoiceDataAsync()
        {
            using (var context = new ShopNoirContext())
            {
                IQueryable<Invoice> query;

                // Xác định truy vấn dựa trên bộ lọc
                if (typeFilter == "monthly")
                {
                    query = context.Invoices
                        .Where(invoice => invoice.CreatedAt.HasValue
                                          && invoice.CreatedAt.Value.Year == year);
                }
                else
                {
                    query = context.Invoices
                        .Where(invoice => invoice.CreatedAt.HasValue
                                          && invoice.CreatedAt.Value.Year == year
                                          && invoice.CreatedAt.Value.Month == month);
                }

                // Tính tổng số bản ghi
                totalRecords = await query.CountAsync();

                // Cập nhật thông tin trang lên giao diện
                lbl_trang.Invoke((Action)(() =>
                {
                    lbl_trang.Text = $"Page {currentPage} / {Math.Ceiling((double)totalRecords / pageSize)}";
                }));

                // Thực hiện truy vấn với phân trang
                var data = await query
                    .OrderByDescending(invoice => invoice.CreatedAt)
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize) // Giới hạn số lượng bản ghi mỗi trang
                    .Select(invoiceInfo => new InvoiceInformation
                    {
                        Id = invoiceInfo.Id,
                        CreatedAt = invoiceInfo.CreatedAt,
                        Total = invoiceInfo.Total,
                        PaymentMethod = invoiceInfo.PaymentMethod,
                        Amount = invoiceInfo.InvoiceDetails.Sum(d => d.Amount), // Tổng số lượng sản phẩm
                        Name = invoiceInfo.CreatedByNavigation.Name,
                    })
                    .AsNoTracking()
                    .ToListAsync();

                // Kích hoạt hoặc vô hiệu hóa nút điều hướng
                btn_trangtruoc.Invoke((Action)(() => btn_trangtruoc.Enabled = currentPage > 1));
                btn_trangsau.Invoke((Action)(() => btn_trangsau.Enabled = currentPage < Math.Ceiling((double)totalRecords / pageSize)));

                return data;
            }
        }
        private void UpdateDataGridView(List<InvoiceInformation> data)
        {
            this.Invoke((MethodInvoker)delegate
            {
                dataGridView1.DataSource = data;
                // Ẩn cột Id nếu không muốn hiển thị
                if (dataGridView1.Columns["Id"] != null)
                {
                    dataGridView1.Columns["Id"].Visible = false;
                }
            });
        }

        private void btn_trangsau_Click(object sender, EventArgs e)
        {
            if (currentPage < Math.Ceiling((double)totalRecords / pageSize))
            {
                currentPage++;
                LoadDataIntoDataGridBox(); // Tải lại dữ liệu cho trang tiếp theo
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

        private async void btn_printReport_Click(object sender, EventArgs e)
        {
            // Dữ liệu cần in
            List<InvoiceInformation> allData;
            using (var context = new ShopNoirContext())
            {
                IQueryable<Invoice> query;

                // Xác định truy vấn dựa trên bộ lọc
                if (typeFilter == "monthly")
                {
                    query = context.Invoices
                        .Where(invoice => invoice.CreatedAt.HasValue
                                          && invoice.CreatedAt.Value.Year == year);
                }
                else
                {
                    query = context.Invoices
                        .Where(invoice => invoice.CreatedAt.HasValue
                                          && invoice.CreatedAt.Value.Year == year
                                          && invoice.CreatedAt.Value.Month == month);
                }
                allData = await query
               .OrderByDescending(invoice => invoice.CreatedAt)
               .Select(invoiceInfo => new InvoiceInformation
               {
                   CreatedAt = invoiceInfo.CreatedAt,
                   Total = invoiceInfo.Total,
                   PaymentMethod = invoiceInfo.PaymentMethod,
                   Amount = invoiceInfo.InvoiceDetails.Sum(d => d.Amount), // Tổng số lượng sản phẩm
                   Name = invoiceInfo.CreatedByNavigation.Name,
               })
               .AsNoTracking()
               .ToListAsync();
            }

            // Xuất sang Excel
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Thêm dòng này
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Save Report",
                FileName = $"RevenueReport_{DateTime.Now:yyyyMMdd}.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var package = new OfficeOpenXml.ExcelPackage())
                    {
                        // Thêm worksheet dữ liệu
                        var dataSheet = package.Workbook.Worksheets.Add("Data");
                        dataSheet.Cells["A1"].Value = "Created At";
                        dataSheet.Cells["B1"].Value = "Amount";
                        dataSheet.Cells["C1"].Value = "Total";
                        dataSheet.Cells["D1"].Value = "Tax rate";
                        dataSheet.Cells["E1"].Value = "Tax";
                        dataSheet.Cells["F1"].Value = "Revenue";
                        dataSheet.Cells["G1"].Value = "Payment Method";
                        dataSheet.Cells["H1"].Value = "Created By";

                        // Thêm dữ liệu
                        for (int i = 0; i < allData.Count; i++)
                        {
                            var row = i + 2;
                            dataSheet.Cells[row, 1].Value = allData[i].CreatedAt?.ToString("yyyy-MM-dd");
                            dataSheet.Cells[row, 2].Value = allData[i].Amount;
                            dataSheet.Cells[row, 3].Value = allData[i].Total;
                            dataSheet.Cells[row, 4].Value = allData[i].TaxRate;
                            dataSheet.Cells[row, 5].Value = allData[i].Tax;
                            dataSheet.Cells[row, 6].Value = allData[i].Revenue;
                            dataSheet.Cells[row, 7].Value = allData[i].PaymentMethod;
                            dataSheet.Cells[row, 8].Value = allData[i].Name;
                        }

                        // Thêm worksheet biểu đồ
                        var chartSheet = package.Workbook.Worksheets.Add("Chart");
                        var chart = chartSheet.Drawings.AddChart("RevenueChart", OfficeOpenXml.Drawing.Chart.eChartType.Line);
                        chart.Title.Text = "Revenue Report";

                        // Thêm dữ liệu biểu đồ
                        var revenueData = await GetRevenueDataAsync(year, typeFilter == "daily" ? month : (int?)null);
                        var labels = typeFilter == "daily" ? GetDayLabels(year, month) : GetMonthLabels();

                        // Gán dữ liệu biểu đồ
                        var labelRange = chartSheet.Cells[1, 1, labels.Count, 1];
                        var revenueRange = chartSheet.Cells[1, 2, revenueData.Count, 2];
                        labelRange.LoadFromCollection(labels);
                        revenueRange.LoadFromCollection(revenueData);

                        chart.Series.Add(revenueRange, labelRange);
                        chart.SetPosition(1, 0, 4, 0); // Đặt vị trí cho biểu đồ
                        chart.SetSize(800, 400); // Đặt kích thước cho biểu đồ

                        // Lưu tệp
                        var filePath = saveFileDialog.FileName;
                        await package.SaveAsAsync(new FileInfo(filePath));
                        MessageBox.Show("Report exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error while exporting: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Đảm bảo ô hợp lệ
            {
                // Lưu vị trí con trỏ chuột hiện tại
                cursorPosition = Cursor.Position;

                // Khởi động Timer
                hoverTimer.Stop(); // Đảm bảo không bị trùng lặp
                hoverTimer.Start();
            }
        }

        // Sự kiện khi Timer đạt đến 1 giây
        private void HoverTimer_Tick(object sender, EventArgs e)
        {
            // Dừng Timer để không lặp lại
            hoverTimer.Stop();

            // Hiển thị ToolTip tại vị trí con trỏ
            cellToolTip.Active = true;
            cellToolTip.Show("Double click to see detail", this, PointToClient(cursorPosition));
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            // Ẩn ToolTip và dừng Timer
            hoverTimer.Stop();
            cellToolTip.Hide(this);
            cellToolTip.Active = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo dòng được chọn hợp lệ
            {
                // Lấy dữ liệu dòng hiện tại
                var row = dataGridView1.Rows[e.RowIndex];

                // Lấy giá trị Id từ dòng
                var invoiceId = row.Cells["Id"].Value;
                if (invoiceId != null)
                {
                    Guid selectedInvoiceId = Guid.Parse(invoiceId.ToString());
                    RevenueDetail revenueDetail = new RevenueDetail(selectedInvoiceId);
                    revenueDetail.Show();
                }
            }
        }
    }
}

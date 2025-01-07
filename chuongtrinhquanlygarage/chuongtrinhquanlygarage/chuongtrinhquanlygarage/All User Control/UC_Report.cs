using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using chuongtrinhquanlygarage.Database.Repository;
using chuongtrinhquanlygarage.Database;

namespace chuongtrinhquanlygarage.All_User_Control
{
    public partial class UC_Report : UserControl
    {
        private readonly OrderRepository orderRepo = new OrderRepository(new DatabaseContext());
        public UC_Report()
        {
            InitializeComponent();
        }

        private async Task LoadRevenueChart(int year)
        {
            try
            {
                List<Double> monthlyRevenues = await Task.Run(() => orderRepo.GetRevenueByYear(year));

                // Clear existing chart data
                revenueChart.Series.Clear();
                revenueChart.ChartAreas.Clear();

                var chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea
                {
                    AxisX =
                    {
                        Title = "Tháng",
                        Interval = 1,
                        TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Bold) // Set larger font size for X-axis title
                    },
                    AxisY =
                    {
                        Title = "Doanh Thu (Triệu)",
                        Interval = 5,
                        Maximum = 30,
                        Minimum = 0,
                        LabelStyle = { Format = "{0}" },
                        TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Bold) // Set larger font size for Y-axis title
                    }
                };
                revenueChart.ChartAreas.Add(chartArea);

                var series = new System.Windows.Forms.DataVisualization.Charting.Series("Doanh Thu")
                {
                    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column,
                    IsValueShownAsLabel = true
                };

                series.Font = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Regular);

                for (int i = 0; i < 12; i++)
                {
                    series.Points.AddXY($"Tháng {i + 1}", Math.Round(monthlyRevenues[i]/1000000.0, 3));
                }

                revenueChart.Series.Add(series);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the revenue chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadCustomerChart(int year)
        {
            try
            {
                List<int> monthlyCustomer = await Task.Run(() => orderRepo.GetQuantityCustomerOfMonth(year));

                customerChart.Series.Clear();
                customerChart.ChartAreas.Clear();

                var chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea
                {
                    AxisX =
                    {
                        Title = "Tháng",
                        Interval = 1,
                        TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Bold) // Set larger font size for X-axis title
                    },
                    AxisY =
                    {
                        Title = "Số lượng",
                        Interval = 5,
                        Maximum = 30,
                        Minimum = 0,
                        LabelStyle = { Format = "{0}" },
                        TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Bold) // Set larger font size for Y-axis title
                    }
                };
                customerChart.ChartAreas.Add(chartArea);

                var series = new System.Windows.Forms.DataVisualization.Charting.Series("Số lượng")
                {
                    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column,
                    IsValueShownAsLabel = true
                };

                series.Font = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Regular);

                for (int i = 0; i < 12; i++)
                {
                    series.Points.AddXY($"Tháng {i + 1}", monthlyCustomer[i]);
                }

                customerChart.Series.Add(series);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the customer chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadTop5PartChart(int year, int quarter)
        {
            try
            {
                var topParts = await Task.Run(() => orderRepo.GetTop5PartsSell(year, quarter));

                // Clear existing chart data
                partChart.Series.Clear();
                partChart.ChartAreas.Clear();

                if(topParts.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu phụ tùng nào được bán trong quý này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea
                {
                    AxisX =
                    {
                        Title = "Tên phụ tùng",
                        TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Bold),
                        Interval = 1
                    },
                    AxisY =
                    {
                        Title = "Số lượng",
                        Interval = 5,
                        Maximum = 30,
                        Minimum = 0,
                        LabelStyle = { Format = "{0}" },
                        TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Bold)
                    }
                };
                partChart.ChartAreas.Add(chartArea);

                var series = new System.Windows.Forms.DataVisualization.Charting.Series("Số lượng")
                {
                    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar,
                    IsValueShownAsLabel = true,
                    Font = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Regular)
                };

                foreach (var part in topParts)
                {
                    int totalQuantity = part.Value.Sum(p => p.Quantity);

                    series.Points.AddXY(part.Value[0].PartName, totalQuantity);
                }

                partChart.Series.Add(series);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the top 5 part chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void txtYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int year = Convert.ToInt32(txtYear.Text);
                titleChart.Text = $"Biểu đồ doanh thu của năm {year}";
                await LoadRevenueChart(year);
                LoadRevenueBoard(year);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the revenue chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void txtCustomerYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int year = Convert.ToInt32(txtCustomerYear.Text);
                labelCustomerChart.Text = $"Biểu đồ số lượng khách hàng sử dụng dịch vụ của năm {year}";
                await LoadCustomerChart(year);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the customer chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2) {
                txtCustomerYear.SelectedItem = DateTime.Now.Year.ToString();
            }
            else if (tabControl1.SelectedTab == tabPage3)
            {

                txtQuarter.SelectedItem = "1";
                txtPartYear.SelectedItem = DateTime.Now.Year.ToString();
                await LoadTop5PartChart(DateTime.Now.Year, 1);
            }
        }

        private void UC_Report_Load(object sender, EventArgs e)
        {
            txtYear.SelectedItem = DateTime.Now.Year.ToString();
        }
        private async void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int year = Convert.ToInt32(txtPartYear.Text);
                int quarter = Convert.ToInt32(txtQuarter.Text);
                titlePart.Text = $"Biểu đồ Top 5 phụ tùng bán chạy nhất năm {year} - Quý {quarter}";
                await LoadTop5PartChart(year, quarter);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the top 5 part chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRevenue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void LoadRevenueBoard(int year)
        {
            try {
                double total = 0;
                List<Double> monthlyRevenues = await Task.Run(() => orderRepo.GetRevenueByYear(year));
                dgvRevenue.Rows.Clear();
                for (int i = 0; i < 12; i++)
                {
                    total += monthlyRevenues[i];
                    dgvRevenue.Rows.Add(i+1, monthlyRevenues[i].ToString("N0"));
                }
                txtTotal.Text = total.ToString("N0");

            } catch(Exception ex) {
                MessageBox.Show($"An error occurred while loading the revenue board: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

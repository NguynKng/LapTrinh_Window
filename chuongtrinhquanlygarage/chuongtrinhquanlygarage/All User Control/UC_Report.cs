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
                // Fetch monthly revenue data for the year
                List<Double> monthlyRevenues = await Task.Run(() => orderRepo.GetRevenueByYear(year));

                // Clear existing chart data
                revenueChart.Series.Clear();
                revenueChart.ChartAreas.Clear();

                // Configure chart area
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
                        Interval = 5, // Set Y-axis interval
                        Maximum = 30, // Set Y-axis maximum value
                        Minimum = 0,  // Set Y-axis minimum value
                        LabelStyle = { Format = "{0}" }, // Display values as integers
                        TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Bold) // Set larger font size for Y-axis title
                    }
                };
                revenueChart.ChartAreas.Add(chartArea);

                // Create and populate the series
                var series = new System.Windows.Forms.DataVisualization.Charting.Series("Doanh Thu")
                {
                    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column,
                    IsValueShownAsLabel = true
                };

                series.Font = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Regular);

                for (int i = 0; i < 12; i++)
                {
                    // Use the already scaled values
                    series.Points.AddXY($"Tháng {i + 1}", monthlyRevenues[i]);
                }

                // Add the series to the chart
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
                // Fetch monthly revenue data for the year
                List<int> monthlyCustomer = await Task.Run(() => orderRepo.GetQuantityCustomerOfMonth(year));

                // Clear existing chart data
                customerChart.Series.Clear();
                customerChart.ChartAreas.Clear();

                // Configure chart area
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
                        Interval = 5, // Set Y-axis interval
                        Maximum = 30, // Set Y-axis maximum value
                        Minimum = 0,  // Set Y-axis minimum value
                        LabelStyle = { Format = "{0}" }, // Display values as integers
                        TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Bold) // Set larger font size for Y-axis title
                    }
                };
                customerChart.ChartAreas.Add(chartArea);

                // Create and populate the series
                var series = new System.Windows.Forms.DataVisualization.Charting.Series("Số lượng")
                {
                    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column,
                    IsValueShownAsLabel = true
                };

                series.Font = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Regular);

                for (int i = 0; i < 12; i++)
                {
                    // Use the already scaled values
                    series.Points.AddXY($"Tháng {i + 1}", monthlyCustomer[i]);
                }

                // Add the series to the chart
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
                // Fetch top 5 parts sold for the year (you should adjust GetTop5PartsSell to return this data)
                var topParts = await Task.Run(() => orderRepo.GetTop5PartsSell(year, quarter));

                // Clear existing chart data
                partChart.Series.Clear();
                partChart.ChartAreas.Clear();

                if(topParts.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu phụ tùng nào được bán trong quý này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Configure chart area
                var chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea
                {
                    AxisX =
                    {
                        Title = "Tên phụ tùng",  // Change to display part names
                        TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Bold),
                        Interval = 1
                    },
                    AxisY =
                    {
                        Title = "Số lượng",
                        Interval = 5, // Set Y-axis interval
                        Maximum = 30, // Set Y-axis maximum value, you may adjust it based on the data
                        Minimum = 0,  // Set Y-axis minimum value
                        LabelStyle = { Format = "{0}" }, // Display values as integers
                        TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Bold)
                    }
                };
                partChart.ChartAreas.Add(chartArea);

                // Create and populate the series for the Bar Chart
                var series = new System.Windows.Forms.DataVisualization.Charting.Series("Số lượng")
                {
                    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar,  // Set Bar chart
                    IsValueShownAsLabel = true,
                    Font = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Regular)
                };

                // Add data points for top parts (partName and quantity sold)
                foreach (var part in topParts)
                {
                    // Sum quantities for each part and add data points to the chart
                    int totalQuantity = part.Value.Sum(p => p.Quantity);

                    // Add part name as X value, and total quantity sold as Y value
                    series.Points.AddXY(part.Value[0].PartName, totalQuantity);   // Sum quantities for each part
                }

                // Add the series to the chart
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
                //labelCustomerChart.Text = $"Biểu đồ số lượng khách hàng sử dụng dịch vụ của năm {year}";
                titlePart.Text = $"Biểu đồ Top 5 phụ tùng bán chạy nhất năm {year} - Quý {quarter}";
                await LoadTop5PartChart(year, quarter);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the top 5 part chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

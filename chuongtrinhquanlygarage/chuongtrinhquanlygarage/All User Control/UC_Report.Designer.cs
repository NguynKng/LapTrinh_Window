﻿namespace chuongtrinhquanlygarage.All_User_Control
{
    partial class UC_Report
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtYear = new Guna.UI2.WinForms.Guna2ComboBox();
            this.titleChart = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.revenueChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtCustomerYear = new Guna.UI2.WinForms.Guna2ComboBox();
            this.labelCustomerChart = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.customerChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.titlePart = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.submitBtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtQuarter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtPartYear = new Guna.UI2.WinForms.Guna2ComboBox();
            this.partChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.revenueChart)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerChart)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partChart)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(15, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(310, 38);
            this.label8.TabIndex = 18;
            this.label8.Text = "Báo Cáo Thống Kê";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(22, 71);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1975, 779);
            this.tabControl1.TabIndex = 19;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.guna2HtmlLabel2);
            this.tabPage1.Controls.Add(this.txtYear);
            this.tabPage1.Controls.Add(this.titleChart);
            this.tabPage1.Controls.Add(this.revenueChart);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1967, 746);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thống Kê Doanh Thu";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(1349, 35);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(44, 27);
            this.guna2HtmlLabel2.TabIndex = 3;
            this.guna2HtmlLabel2.Text = "Năm";
            // 
            // txtYear
            // 
            this.txtYear.BackColor = System.Drawing.Color.Transparent;
            this.txtYear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtYear.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtYear.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.txtYear.ItemHeight = 30;
            this.txtYear.Items.AddRange(new object[] {
            "2023",
            "2024",
            "2025"});
            this.txtYear.Location = new System.Drawing.Point(1406, 27);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(177, 36);
            this.txtYear.TabIndex = 2;
            this.txtYear.SelectedIndexChanged += new System.EventHandler(this.txtYear_SelectedIndexChanged);
            // 
            // titleChart
            // 
            this.titleChart.BackColor = System.Drawing.Color.Transparent;
            this.titleChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleChart.Location = new System.Drawing.Point(653, 16);
            this.titleChart.Name = "titleChart";
            this.titleChart.Size = new System.Drawing.Size(443, 38);
            this.titleChart.TabIndex = 1;
            this.titleChart.Text = "Biểu đồ doanh thu của năm 2024";
            // 
            // revenueChart
            // 
            chartArea11.Name = "ChartArea1";
            this.revenueChart.ChartAreas.Add(chartArea11);
            legend11.Name = "Legend1";
            this.revenueChart.Legends.Add(legend11);
            this.revenueChart.Location = new System.Drawing.Point(6, 69);
            this.revenueChart.Name = "revenueChart";
            this.revenueChart.Size = new System.Drawing.Size(1936, 640);
            this.revenueChart.TabIndex = 0;
            this.revenueChart.Text = "chart1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.guna2HtmlLabel3);
            this.tabPage2.Controls.Add(this.txtCustomerYear);
            this.tabPage2.Controls.Add(this.labelCustomerChart);
            this.tabPage2.Controls.Add(this.customerChart);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1967, 746);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Thống Kê Khách Hàng";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(1349, 35);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(44, 27);
            this.guna2HtmlLabel3.TabIndex = 5;
            this.guna2HtmlLabel3.Text = "Năm";
            // 
            // txtCustomerYear
            // 
            this.txtCustomerYear.BackColor = System.Drawing.Color.Transparent;
            this.txtCustomerYear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtCustomerYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtCustomerYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtCustomerYear.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCustomerYear.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCustomerYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCustomerYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.txtCustomerYear.ItemHeight = 30;
            this.txtCustomerYear.Items.AddRange(new object[] {
            "2023",
            "2024",
            "2025"});
            this.txtCustomerYear.Location = new System.Drawing.Point(1406, 27);
            this.txtCustomerYear.Name = "txtCustomerYear";
            this.txtCustomerYear.Size = new System.Drawing.Size(177, 36);
            this.txtCustomerYear.TabIndex = 4;
            this.txtCustomerYear.SelectedIndexChanged += new System.EventHandler(this.txtCustomerYear_SelectedIndexChanged);
            // 
            // labelCustomerChart
            // 
            this.labelCustomerChart.BackColor = System.Drawing.Color.Transparent;
            this.labelCustomerChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCustomerChart.Location = new System.Drawing.Point(394, 24);
            this.labelCustomerChart.Name = "labelCustomerChart";
            this.labelCustomerChart.Size = new System.Drawing.Size(807, 38);
            this.labelCustomerChart.TabIndex = 2;
            this.labelCustomerChart.Text = "Biểu đồ số lượng khách hàng sử dụng dịch vụ của năm 2024";
            // 
            // customerChart
            // 
            chartArea12.Name = "ChartArea1";
            this.customerChart.ChartAreas.Add(chartArea12);
            legend12.Name = "Legend1";
            this.customerChart.Legends.Add(legend12);
            this.customerChart.Location = new System.Drawing.Point(6, 69);
            this.customerChart.Name = "customerChart";
            series8.ChartArea = "ChartArea1";
            series8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series8.Legend = "Legend1";
            series8.Name = "Series2";
            this.customerChart.Series.Add(series8);
            this.customerChart.Size = new System.Drawing.Size(1936, 640);
            this.customerChart.TabIndex = 0;
            this.customerChart.Text = "chart4";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.titlePart);
            this.tabPage3.Controls.Add(this.submitBtn);
            this.tabPage3.Controls.Add(this.guna2HtmlLabel4);
            this.tabPage3.Controls.Add(this.txtQuarter);
            this.tabPage3.Controls.Add(this.guna2HtmlLabel1);
            this.tabPage3.Controls.Add(this.txtPartYear);
            this.tabPage3.Controls.Add(this.partChart);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1967, 746);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Thống Kê Phụ Tùng";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // titlePart
            // 
            this.titlePart.BackColor = System.Drawing.Color.Transparent;
            this.titlePart.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titlePart.Location = new System.Drawing.Point(332, 25);
            this.titlePart.Name = "titlePart";
            this.titlePart.Size = new System.Drawing.Size(756, 38);
            this.titlePart.TabIndex = 11;
            this.titlePart.Text = "Biểu đồ Top 5 phụ tùng bán chạy nhất năm 2024 - Quý 1";
            // 
            // submitBtn
            // 
            this.submitBtn.BorderRadius = 20;
            this.submitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.submitBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.submitBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.submitBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.submitBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.submitBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.submitBtn.ForeColor = System.Drawing.Color.White;
            this.submitBtn.Location = new System.Drawing.Point(1741, 25);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(131, 38);
            this.submitBtn.TabIndex = 10;
            this.submitBtn.Text = "Xem";
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(1297, 29);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(40, 27);
            this.guna2HtmlLabel4.TabIndex = 9;
            this.guna2HtmlLabel4.Text = "Quý";
            // 
            // txtQuarter
            // 
            this.txtQuarter.BackColor = System.Drawing.Color.Transparent;
            this.txtQuarter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtQuarter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtQuarter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtQuarter.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtQuarter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtQuarter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtQuarter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.txtQuarter.ItemHeight = 30;
            this.txtQuarter.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.txtQuarter.Location = new System.Drawing.Point(1353, 25);
            this.txtQuarter.Name = "txtQuarter";
            this.txtQuarter.Size = new System.Drawing.Size(96, 36);
            this.txtQuarter.TabIndex = 8;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(1467, 29);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(44, 27);
            this.guna2HtmlLabel1.TabIndex = 7;
            this.guna2HtmlLabel1.Text = "Năm";
            // 
            // txtPartYear
            // 
            this.txtPartYear.BackColor = System.Drawing.Color.Transparent;
            this.txtPartYear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtPartYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtPartYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtPartYear.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPartYear.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPartYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPartYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.txtPartYear.ItemHeight = 30;
            this.txtPartYear.Items.AddRange(new object[] {
            "2023",
            "2024",
            "2025"});
            this.txtPartYear.Location = new System.Drawing.Point(1524, 25);
            this.txtPartYear.Name = "txtPartYear";
            this.txtPartYear.Size = new System.Drawing.Size(177, 36);
            this.txtPartYear.TabIndex = 6;
            // 
            // partChart
            // 
            chartArea10.Name = "ChartArea1";
            this.partChart.ChartAreas.Add(chartArea10);
            legend10.Name = "Legend1";
            this.partChart.Legends.Add(legend10);
            this.partChart.Location = new System.Drawing.Point(6, 69);
            this.partChart.Name = "partChart";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series7.Legend = "Legend1";
            series7.Name = "Series2";
            this.partChart.Series.Add(series7);
            this.partChart.Size = new System.Drawing.Size(1936, 640);
            this.partChart.TabIndex = 1;
            this.partChart.Text = "chart4";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 30;
            this.guna2Elipse1.TargetControl = this;
            // 
            // UC_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label8);
            this.Name = "UC_Report";
            this.Size = new System.Drawing.Size(2293, 970);
            this.Load += new System.EventHandler(this.UC_Report_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.revenueChart)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerChart)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataVisualization.Charting.Chart revenueChart;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.DataVisualization.Charting.Chart customerChart;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2ComboBox txtYear;
        private Guna.UI2.WinForms.Guna2HtmlLabel titleChart;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2ComboBox txtCustomerYear;
        private Guna.UI2.WinForms.Guna2HtmlLabel labelCustomerChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart partChart;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2ComboBox txtPartYear;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2ComboBox txtQuarter;
        private Guna.UI2.WinForms.Guna2Button submitBtn;
        private Guna.UI2.WinForms.Guna2HtmlLabel titlePart;
    }
}
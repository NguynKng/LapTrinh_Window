namespace chuongtrinhquanlygarage.All_User_Control
{
    partial class UC_Pay
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
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCusID = new System.Windows.Forms.TextBox();
            this.radioTransfer = new System.Windows.Forms.RadioButton();
            this.radioCash = new System.Windows.Forms.RadioButton();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtTotal = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnPay = new Guna.UI2.WinForms.Guna2Button();
            this.dateCheckOut = new System.Windows.Forms.DateTimePicker();
            this.dateCheckIn = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbSort = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtSearchByName = new Guna.UI2.WinForms.Guna2TextBox();
            this.listViewInvoice = new System.Windows.Forms.ListView();
            this.invoiceIDCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rpOrderID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cusNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.empName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.methodCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.totCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkinCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkoutCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewOrder = new System.Windows.Forms.ListView();
            this.orderIDCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.licensePlateCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.createdAtCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.totalCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewInvoiceBtn = new Guna.UI2.WinForms.Guna2Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(16, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(213, 39);
            this.label8.TabIndex = 19;
            this.label8.Text = "Thanh Toán";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtOrderID);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCusID);
            this.groupBox1.Controls.Add(this.radioTransfer);
            this.groupBox1.Controls.Add(this.radioCash);
            this.groupBox1.Controls.Add(this.guna2HtmlLabel1);
            this.groupBox1.Controls.Add(this.txtTotal);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.btnPay);
            this.groupBox1.Controls.Add(this.dateCheckOut);
            this.groupBox1.Controls.Add(this.dateCheckIn);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(23, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(806, 475);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(126, 18);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 23);
            this.label7.TabIndex = 96;
            this.label7.Text = "Mã đơn:";
            // 
            // txtOrderID
            // 
            this.txtOrderID.Enabled = false;
            this.txtOrderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderID.Location = new System.Drawing.Point(257, 13);
            this.txtOrderID.Margin = new System.Windows.Forms.Padding(4);
            this.txtOrderID.Multiline = true;
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.ReadOnly = true;
            this.txtOrderID.Size = new System.Drawing.Size(514, 37);
            this.txtOrderID.TabIndex = 95;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(73, 77);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 23);
            this.label6.TabIndex = 91;
            this.label6.Text = "Mã khách hàng:";
            // 
            // txtCusID
            // 
            this.txtCusID.Enabled = false;
            this.txtCusID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCusID.Location = new System.Drawing.Point(257, 64);
            this.txtCusID.Margin = new System.Windows.Forms.Padding(4);
            this.txtCusID.Multiline = true;
            this.txtCusID.Name = "txtCusID";
            this.txtCusID.ReadOnly = true;
            this.txtCusID.Size = new System.Drawing.Size(514, 37);
            this.txtCusID.TabIndex = 90;
            // 
            // radioTransfer
            // 
            this.radioTransfer.AutoSize = true;
            this.radioTransfer.Enabled = false;
            this.radioTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioTransfer.Location = new System.Drawing.Point(574, 285);
            this.radioTransfer.Name = "radioTransfer";
            this.radioTransfer.Size = new System.Drawing.Size(161, 29);
            this.radioTransfer.TabIndex = 89;
            this.radioTransfer.TabStop = true;
            this.radioTransfer.Text = "Chuyển khoản";
            this.radioTransfer.UseVisualStyleBackColor = true;
            // 
            // radioCash
            // 
            this.radioCash.AutoSize = true;
            this.radioCash.Enabled = false;
            this.radioCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioCash.Location = new System.Drawing.Point(334, 285);
            this.radioCash.Name = "radioCash";
            this.radioCash.Size = new System.Drawing.Size(109, 29);
            this.radioCash.TabIndex = 88;
            this.radioCash.TabStop = true;
            this.radioCash.Text = "Tiền mặt";
            this.radioCash.UseVisualStyleBackColor = true;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(730, 411);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(53, 31);
            this.guna2HtmlLabel1.TabIndex = 87;
            this.guna2HtmlLabel1.Text = "VND";
            // 
            // txtTotal
            // 
            this.txtTotal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTotal.DefaultText = "";
            this.txtTotal.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTotal.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTotal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotal.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotal.Enabled = false;
            this.txtTotal.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.Color.Green;
            this.txtTotal.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTotal.Location = new System.Drawing.Point(440, 380);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(5);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.PasswordChar = '\0';
            this.txtTotal.PlaceholderText = "";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.SelectedText = "";
            this.txtTotal.Size = new System.Drawing.Size(285, 62);
            this.txtTotal.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtTotal.TabIndex = 85;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(665, 347);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 28);
            this.label5.TabIndex = 84;
            this.label5.Text = "Tổng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(68, 291);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 23);
            this.label1.TabIndex = 81;
            this.label1.Text = "Phương thức thanh toán";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(137, 134);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 23);
            this.label3.TabIndex = 64;
            this.label3.Text = "Họ tên:";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(257, 123);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(514, 37);
            this.txtName.TabIndex = 66;
            // 
            // btnPay
            // 
            this.btnPay.BorderRadius = 18;
            this.btnPay.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.btnPay.BorderThickness = 1;
            this.btnPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPay.Enabled = false;
            this.btnPay.FillColor = System.Drawing.Color.White;
            this.btnPay.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.ForeColor = System.Drawing.Color.Black;
            this.btnPay.Location = new System.Drawing.Point(99, 378);
            this.btnPay.Margin = new System.Windows.Forms.Padding(4);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(218, 64);
            this.btnPay.TabIndex = 78;
            this.btnPay.Text = "Hiện và thêm";
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // dateCheckOut
            // 
            this.dateCheckOut.Enabled = false;
            this.dateCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateCheckOut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateCheckOut.Location = new System.Drawing.Point(257, 233);
            this.dateCheckOut.Margin = new System.Windows.Forms.Padding(4);
            this.dateCheckOut.Name = "dateCheckOut";
            this.dateCheckOut.Size = new System.Drawing.Size(514, 30);
            this.dateCheckOut.TabIndex = 76;
            // 
            // dateCheckIn
            // 
            this.dateCheckIn.Enabled = false;
            this.dateCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateCheckIn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateCheckIn.Location = new System.Drawing.Point(257, 185);
            this.dateCheckIn.Margin = new System.Windows.Forms.Padding(4);
            this.dateCheckIn.Name = "dateCheckIn";
            this.dateCheckIn.Size = new System.Drawing.Size(514, 30);
            this.dateCheckIn.TabIndex = 77;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(84, 192);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 23);
            this.label9.TabIndex = 72;
            this.label9.Text = "Ngày checkin:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(72, 233);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 23);
            this.label4.TabIndex = 71;
            this.label4.Text = "Ngày checkout:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbSort);
            this.groupBox2.Controls.Add(this.txtSearchByName);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(860, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(838, 100);
            this.groupBox2.TabIndex = 68;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lọc Hóa Đơn";
            // 
            // cmbSort
            // 
            this.cmbSort.BackColor = System.Drawing.Color.Transparent;
            this.cmbSort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbSort.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbSort.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbSort.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSort.ForeColor = System.Drawing.Color.Black;
            this.cmbSort.ItemHeight = 30;
            this.cmbSort.Items.AddRange(new object[] {
            "Mặc định",
            "Tên A-Z",
            "Tên Z-A",
            "Trị giá ↑",
            "Trị giá ↓",
            "Ngày gần nhất"});
            this.cmbSort.Location = new System.Drawing.Point(564, 42);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(256, 36);
            this.cmbSort.TabIndex = 71;
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.cmbSort_SelectedIndexChanged);
            // 
            // txtSearchByName
            // 
            this.txtSearchByName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchByName.DefaultText = "";
            this.txtSearchByName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchByName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchByName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchByName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchByName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchByName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchByName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchByName.Location = new System.Drawing.Point(43, 42);
            this.txtSearchByName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearchByName.Name = "txtSearchByName";
            this.txtSearchByName.PasswordChar = '\0';
            this.txtSearchByName.PlaceholderText = "Tìm khách hàng";
            this.txtSearchByName.SelectedText = "";
            this.txtSearchByName.Size = new System.Drawing.Size(476, 44);
            this.txtSearchByName.TabIndex = 70;
            this.txtSearchByName.TextChanged += new System.EventHandler(this.txtSearchByName_TextChanged);
            // 
            // listViewInvoice
            // 
            this.listViewInvoice.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.invoiceIDCol,
            this.rpOrderID,
            this.cusNameCol,
            this.empName,
            this.methodCol,
            this.totCol,
            this.checkinCol,
            this.checkoutCol});
            this.listViewInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewInvoice.FullRowSelect = true;
            this.listViewInvoice.HideSelection = false;
            this.listViewInvoice.Location = new System.Drawing.Point(860, 162);
            this.listViewInvoice.Name = "listViewInvoice";
            this.listViewInvoice.Size = new System.Drawing.Size(1139, 352);
            this.listViewInvoice.TabIndex = 69;
            this.listViewInvoice.UseCompatibleStateImageBehavior = false;
            this.listViewInvoice.View = System.Windows.Forms.View.Details;
            this.listViewInvoice.SelectedIndexChanged += new System.EventHandler(this.listViewInvoice_SelectedIndexChanged);
            // 
            // invoiceIDCol
            // 
            this.invoiceIDCol.Text = "Mã hoá đơn";
            this.invoiceIDCol.Width = 150;
            // 
            // rpOrderID
            // 
            this.rpOrderID.Text = "Mã đơn";
            this.rpOrderID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rpOrderID.Width = 150;
            // 
            // cusNameCol
            // 
            this.cusNameCol.Text = "Khách hàng";
            this.cusNameCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cusNameCol.Width = 200;
            // 
            // empName
            // 
            this.empName.Text = "Phụ trách";
            this.empName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.empName.Width = 200;
            // 
            // methodCol
            // 
            this.methodCol.Text = "Thanh toán";
            this.methodCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.methodCol.Width = 150;
            // 
            // totCol
            // 
            this.totCol.Text = "Tổng tiền";
            this.totCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.totCol.Width = 150;
            // 
            // checkinCol
            // 
            this.checkinCol.Text = "Ngày nhận";
            this.checkinCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.checkinCol.Width = 100;
            // 
            // checkoutCol
            // 
            this.checkoutCol.Text = "Ngày trả";
            this.checkoutCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.checkoutCol.Width = 100;
            // 
            // listViewOrder
            // 
            this.listViewOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.orderIDCol,
            this.licensePlateCol,
            this.createdAtCol,
            this.totalCol});
            this.listViewOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewOrder.FullRowSelect = true;
            this.listViewOrder.HideSelection = false;
            this.listViewOrder.Location = new System.Drawing.Point(860, 539);
            this.listViewOrder.Name = "listViewOrder";
            this.listViewOrder.Size = new System.Drawing.Size(1139, 352);
            this.listViewOrder.TabIndex = 70;
            this.listViewOrder.UseCompatibleStateImageBehavior = false;
            this.listViewOrder.View = System.Windows.Forms.View.Details;
            this.listViewOrder.SelectedIndexChanged += new System.EventHandler(this.listViewOrder_SelectedIndexChanged);
            // 
            // orderIDCol
            // 
            this.orderIDCol.Text = "Mã đơn";
            this.orderIDCol.Width = 200;
            // 
            // licensePlateCol
            // 
            this.licensePlateCol.Text = "Biển số";
            this.licensePlateCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.licensePlateCol.Width = 200;
            // 
            // createdAtCol
            // 
            this.createdAtCol.Text = "Ngày tạo";
            this.createdAtCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.createdAtCol.Width = 200;
            // 
            // totalCol
            // 
            this.totalCol.Text = "Tổng";
            this.totalCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.totalCol.Width = 200;
            // 
            // viewInvoiceBtn
            // 
            this.viewInvoiceBtn.BorderRadius = 18;
            this.viewInvoiceBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.viewInvoiceBtn.BorderThickness = 1;
            this.viewInvoiceBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.viewInvoiceBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.viewInvoiceBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.viewInvoiceBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.viewInvoiceBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.viewInvoiceBtn.Enabled = false;
            this.viewInvoiceBtn.FillColor = System.Drawing.Color.White;
            this.viewInvoiceBtn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewInvoiceBtn.ForeColor = System.Drawing.Color.Black;
            this.viewInvoiceBtn.Location = new System.Drawing.Point(1781, 65);
            this.viewInvoiceBtn.Margin = new System.Windows.Forms.Padding(4);
            this.viewInvoiceBtn.Name = "viewInvoiceBtn";
            this.viewInvoiceBtn.Size = new System.Drawing.Size(218, 64);
            this.viewInvoiceBtn.TabIndex = 79;
            this.viewInvoiceBtn.Text = "Xem hóa đơn";
            this.viewInvoiceBtn.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // UC_Pay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.viewInvoiceBtn);
            this.Controls.Add(this.listViewOrder);
            this.Controls.Add(this.listViewInvoice);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Name = "UC_Pay";
            this.Size = new System.Drawing.Size(2293, 970);
            this.Load += new System.EventHandler(this.UC_Pay_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private Guna.UI2.WinForms.Guna2Button btnPay;
        private System.Windows.Forms.DateTimePicker dateCheckOut;
        private System.Windows.Forms.DateTimePicker dateCheckIn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchByName;
        private System.Windows.Forms.ListView listViewInvoice;
        private System.Windows.Forms.ListView listViewOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2TextBox txtTotal;
        private System.Windows.Forms.RadioButton radioTransfer;
        private System.Windows.Forms.RadioButton radioCash;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCusID;
        private System.Windows.Forms.ColumnHeader orderIDCol;
        private System.Windows.Forms.ColumnHeader licensePlateCol;
        private System.Windows.Forms.ColumnHeader createdAtCol;
        private System.Windows.Forms.ColumnHeader totalCol;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.ColumnHeader invoiceIDCol;
        private System.Windows.Forms.ColumnHeader rpOrderID;
        private System.Windows.Forms.ColumnHeader cusNameCol;
        private System.Windows.Forms.ColumnHeader empName;
        private System.Windows.Forms.ColumnHeader methodCol;
        private System.Windows.Forms.ColumnHeader totCol;
        private System.Windows.Forms.ColumnHeader checkinCol;
        private System.Windows.Forms.ColumnHeader checkoutCol;
        private Guna.UI2.WinForms.Guna2ComboBox cmbSort;
        private Guna.UI2.WinForms.Guna2Button viewInvoiceBtn;
    }
}

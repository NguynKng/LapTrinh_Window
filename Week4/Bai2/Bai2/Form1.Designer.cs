namespace Bai2
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.delBtn = new System.Windows.Forms.Button();
            this.addEditBtn = new System.Windows.Forms.Button();
            this.nuRadio = new System.Windows.Forms.RadioButton();
            this.namRadio = new System.Windows.Forms.RadioButton();
            this.majorTxt = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.diemTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mssvTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mssvCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sexCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gradeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.facultyCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.quantityMaleTxt = new System.Windows.Forms.TextBox();
            this.quantityFemaleTxt = new System.Windows.Forms.TextBox();
            this.trackDelete = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.mssvTrackCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameTrackCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sexTrackCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gradeTrackCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.facultyTrackCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(255, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(509, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản Lý Thông Tin Sinh Viên";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.delBtn);
            this.groupBox1.Controls.Add(this.addEditBtn);
            this.groupBox1.Controls.Add(this.nuRadio);
            this.groupBox1.Controls.Add(this.namRadio);
            this.groupBox1.Controls.Add(this.majorTxt);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.diemTxt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nameTxt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.mssvTxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(81, 101);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(475, 321);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Sinh Viên";
            // 
            // delBtn
            // 
            this.delBtn.Location = new System.Drawing.Point(293, 270);
            this.delBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(100, 28);
            this.delBtn.TabIndex = 12;
            this.delBtn.Text = "Xoá";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // addEditBtn
            // 
            this.addEditBtn.Location = new System.Drawing.Point(109, 270);
            this.addEditBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addEditBtn.Name = "addEditBtn";
            this.addEditBtn.Size = new System.Drawing.Size(100, 28);
            this.addEditBtn.TabIndex = 11;
            this.addEditBtn.Text = "Thêm / Sửa";
            this.addEditBtn.UseVisualStyleBackColor = true;
            this.addEditBtn.Click += new System.EventHandler(this.addEditBtn_Click);
            // 
            // nuRadio
            // 
            this.nuRadio.AutoSize = true;
            this.nuRadio.Location = new System.Drawing.Point(255, 127);
            this.nuRadio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nuRadio.Name = "nuRadio";
            this.nuRadio.Size = new System.Drawing.Size(45, 20);
            this.nuRadio.TabIndex = 10;
            this.nuRadio.TabStop = true;
            this.nuRadio.Text = "Nữ";
            this.nuRadio.UseVisualStyleBackColor = true;
            // 
            // namRadio
            // 
            this.namRadio.AutoSize = true;
            this.namRadio.Location = new System.Drawing.Point(161, 127);
            this.namRadio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.namRadio.Name = "namRadio";
            this.namRadio.Size = new System.Drawing.Size(57, 20);
            this.namRadio.TabIndex = 9;
            this.namRadio.TabStop = true;
            this.namRadio.Text = "Nam";
            this.namRadio.UseVisualStyleBackColor = true;
            // 
            // majorTxt
            // 
            this.majorTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.majorTxt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.majorTxt.FormattingEnabled = true;
            this.majorTxt.Items.AddRange(new object[] {
            "QTKD",
            "CNTT",
            "NNA"});
            this.majorTxt.Location = new System.Drawing.Point(161, 219);
            this.majorTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.majorTxt.Name = "majorTxt";
            this.majorTxt.Size = new System.Drawing.Size(160, 24);
            this.majorTxt.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 225);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Chuyên Ngành:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 129);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Giới tính:";
            // 
            // diemTxt
            // 
            this.diemTxt.Location = new System.Drawing.Point(161, 174);
            this.diemTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.diemTxt.Name = "diemTxt";
            this.diemTxt.Size = new System.Drawing.Size(161, 22);
            this.diemTxt.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 174);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Điểm TB:";
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(161, 84);
            this.nameTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(304, 22);
            this.nameTxt.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Họ Tên:";
            // 
            // mssvTxt
            // 
            this.mssvTxt.Location = new System.Drawing.Point(161, 36);
            this.mssvTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mssvTxt.Name = "mssvTxt";
            this.mssvTxt.Size = new System.Drawing.Size(161, 22);
            this.mssvTxt.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "MSSV:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mssvCol,
            this.nameCol,
            this.sexCol,
            this.gradeCol,
            this.facultyCol});
            this.dataGridView1.Location = new System.Drawing.Point(581, 101);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(491, 368);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // mssvCol
            // 
            this.mssvCol.HeaderText = "MSSV";
            this.mssvCol.MinimumWidth = 6;
            this.mssvCol.Name = "mssvCol";
            this.mssvCol.ReadOnly = true;
            this.mssvCol.Width = 125;
            // 
            // nameCol
            // 
            this.nameCol.HeaderText = "Họ Tên";
            this.nameCol.MinimumWidth = 6;
            this.nameCol.Name = "nameCol";
            this.nameCol.ReadOnly = true;
            this.nameCol.Width = 125;
            // 
            // sexCol
            // 
            this.sexCol.HeaderText = "Giới Tính";
            this.sexCol.MinimumWidth = 6;
            this.sexCol.Name = "sexCol";
            this.sexCol.ReadOnly = true;
            this.sexCol.Width = 125;
            // 
            // gradeCol
            // 
            this.gradeCol.HeaderText = "ĐTB";
            this.gradeCol.MinimumWidth = 6;
            this.gradeCol.Name = "gradeCol";
            this.gradeCol.ReadOnly = true;
            this.gradeCol.Width = 125;
            // 
            // facultyCol
            // 
            this.facultyCol.HeaderText = "Khoa";
            this.facultyCol.MinimumWidth = 6;
            this.facultyCol.Name = "facultyCol";
            this.facultyCol.ReadOnly = true;
            this.facultyCol.Width = 125;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(647, 489);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 20);
            this.label7.TabIndex = 3;
            this.label7.Text = "Nam";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(825, 489);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "Nữ";
            // 
            // quantityMaleTxt
            // 
            this.quantityMaleTxt.Location = new System.Drawing.Point(703, 489);
            this.quantityMaleTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.quantityMaleTxt.Name = "quantityMaleTxt";
            this.quantityMaleTxt.ReadOnly = true;
            this.quantityMaleTxt.Size = new System.Drawing.Size(97, 22);
            this.quantityMaleTxt.TabIndex = 5;
            // 
            // quantityFemaleTxt
            // 
            this.quantityFemaleTxt.Location = new System.Drawing.Point(865, 487);
            this.quantityFemaleTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.quantityFemaleTxt.Name = "quantityFemaleTxt";
            this.quantityFemaleTxt.ReadOnly = true;
            this.quantityFemaleTxt.Size = new System.Drawing.Size(109, 22);
            this.quantityFemaleTxt.TabIndex = 6;
            // 
            // trackDelete
            // 
            this.trackDelete.AutoSize = true;
            this.trackDelete.Location = new System.Drawing.Point(187, 465);
            this.trackDelete.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.trackDelete.Name = "trackDelete";
            this.trackDelete.Size = new System.Drawing.Size(0, 16);
            this.trackDelete.TabIndex = 7;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mssvTrackCol,
            this.nameTrackCol,
            this.sexTrackCol,
            this.gradeTrackCol,
            this.facultyTrackCol,
            this.timeCol});
            this.dataGridView2.Location = new System.Drawing.Point(81, 480);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(467, 153);
            this.dataGridView2.TabIndex = 8;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // mssvTrackCol
            // 
            this.mssvTrackCol.HeaderText = "MSSV";
            this.mssvTrackCol.MinimumWidth = 6;
            this.mssvTrackCol.Name = "mssvTrackCol";
            this.mssvTrackCol.Width = 125;
            // 
            // nameTrackCol
            // 
            this.nameTrackCol.HeaderText = "Tên";
            this.nameTrackCol.MinimumWidth = 6;
            this.nameTrackCol.Name = "nameTrackCol";
            this.nameTrackCol.Width = 125;
            // 
            // sexTrackCol
            // 
            this.sexTrackCol.HeaderText = "Giới tính";
            this.sexTrackCol.MinimumWidth = 6;
            this.sexTrackCol.Name = "sexTrackCol";
            this.sexTrackCol.Width = 125;
            // 
            // gradeTrackCol
            // 
            this.gradeTrackCol.HeaderText = "Điểm";
            this.gradeTrackCol.MinimumWidth = 6;
            this.gradeTrackCol.Name = "gradeTrackCol";
            this.gradeTrackCol.Width = 125;
            // 
            // facultyTrackCol
            // 
            this.facultyTrackCol.HeaderText = "Khoa";
            this.facultyTrackCol.MinimumWidth = 6;
            this.facultyTrackCol.Name = "facultyTrackCol";
            this.facultyTrackCol.Width = 125;
            // 
            // timeCol
            // 
            this.timeCol.HeaderText = "Ngày giờ";
            this.timeCol.MinimumWidth = 6;
            this.timeCol.Name = "timeCol";
            this.timeCol.Width = 125;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(78, 453);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 16);
            this.label9.TabIndex = 9;
            this.label9.Text = "Lịch sử xoá";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 646);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.trackDelete);
            this.Controls.Add(this.quantityFemaleTxt);
            this.Controls.Add(this.quantityMaleTxt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Quản Lý Thông Tin Sinh Viên";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox diemTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox mssvTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Button addEditBtn;
        private System.Windows.Forms.RadioButton nuRadio;
        private System.Windows.Forms.RadioButton namRadio;
        private System.Windows.Forms.ComboBox majorTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn mssvCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn sexCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn gradeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn facultyCol;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox quantityMaleTxt;
        private System.Windows.Forms.TextBox quantityFemaleTxt;
        private System.Windows.Forms.Label trackDelete;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn mssvTrackCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameTrackCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn sexTrackCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn gradeTrackCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn facultyTrackCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeCol;
        private System.Windows.Forms.Label label9;
    }
}


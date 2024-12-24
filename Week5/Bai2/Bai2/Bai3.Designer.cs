namespace Bai2
{
    partial class Bai3
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lsvNhanVien = new System.Windows.Forms.ListView();
            this.empIDCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.birthCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addressCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.phoneCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.degreeCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.exitBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbDegree = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBirth = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lsvNhanVien);
            this.groupBox2.Location = new System.Drawing.Point(58, 348);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(702, 200);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin chung";
            // 
            // lsvNhanVien
            // 
            this.lsvNhanVien.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.empIDCol,
            this.nameCol,
            this.birthCol,
            this.addressCol,
            this.phoneCol,
            this.degreeCol});
            this.lsvNhanVien.FullRowSelect = true;
            this.lsvNhanVien.HideSelection = false;
            this.lsvNhanVien.Location = new System.Drawing.Point(18, 31);
            this.lsvNhanVien.Name = "lsvNhanVien";
            this.lsvNhanVien.Size = new System.Drawing.Size(671, 145);
            this.lsvNhanVien.TabIndex = 0;
            this.lsvNhanVien.UseCompatibleStateImageBehavior = false;
            this.lsvNhanVien.View = System.Windows.Forms.View.Details;
            this.lsvNhanVien.SelectedIndexChanged += new System.EventHandler(this.lsvNhanVien_SelectedIndexChanged);
            // 
            // empIDCol
            // 
            this.empIDCol.Text = "Mã";
            this.empIDCol.Width = 100;
            // 
            // nameCol
            // 
            this.nameCol.Text = "Họ tên";
            this.nameCol.Width = 150;
            // 
            // birthCol
            // 
            this.birthCol.Text = "Ngày sinh";
            this.birthCol.Width = 150;
            // 
            // addressCol
            // 
            this.addressCol.Text = "Địa chỉ";
            this.addressCol.Width = 150;
            // 
            // phoneCol
            // 
            this.phoneCol.Text = "SDT";
            this.phoneCol.Width = 100;
            // 
            // degreeCol
            // 
            this.degreeCol.Text = "Bằng cấp";
            this.degreeCol.Width = 100;
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(672, 306);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(75, 36);
            this.exitBtn.TabIndex = 12;
            this.exitBtn.Text = "Thoát";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(432, 306);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(75, 36);
            this.editBtn.TabIndex = 11;
            this.editBtn.Text = "Sửa";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // delBtn
            // 
            this.delBtn.Location = new System.Drawing.Point(351, 306);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(75, 36);
            this.delBtn.TabIndex = 10;
            this.delBtn.Text = "Xoá";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(270, 306);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 36);
            this.addBtn.TabIndex = 9;
            this.addBtn.Text = "Thêm";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbDegree);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtBirth);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Location = new System.Drawing.Point(58, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(702, 176);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chi tiết";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(366, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Bằng cấp";
            // 
            // cmbDegree
            // 
            this.cmbDegree.FormattingEnabled = true;
            this.cmbDegree.Location = new System.Drawing.Point(443, 80);
            this.cmbDegree.Name = "cmbDegree";
            this.cmbDegree.Size = new System.Drawing.Size(234, 24);
            this.cmbDegree.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Địa chỉ";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(104, 139);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(234, 22);
            this.txtAddress.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(365, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Điện thoại";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(443, 30);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(234, 22);
            this.txtPhone.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ngày sinh";
            // 
            // txtBirth
            // 
            this.txtBirth.Location = new System.Drawing.Point(104, 84);
            this.txtBirth.Name = "txtBirth";
            this.txtBirth.Size = new System.Drawing.Size(234, 22);
            this.txtBirth.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ tên";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(104, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(234, 22);
            this.txtName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(236, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "DANH MỤC NHÂN VIÊN";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Enabled = false;
            this.cancelBtn.Location = new System.Drawing.Point(594, 306);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 36);
            this.cancelBtn.TabIndex = 14;
            this.cancelBtn.Text = "Huỷ";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Enabled = false;
            this.saveBtn.Location = new System.Drawing.Point(513, 306);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 36);
            this.saveBtn.TabIndex = 15;
            this.saveBtn.Text = "Lưu";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // Bai3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 573);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "Bai3";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Bai3_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lsvNhanVien;
        private System.Windows.Forms.ColumnHeader nameCol;
        private System.Windows.Forms.ColumnHeader birthCol;
        private System.Windows.Forms.ColumnHeader phoneCol;
        private System.Windows.Forms.ColumnHeader addressCol;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker txtBirth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbDegree;
        private System.Windows.Forms.ColumnHeader empIDCol;
        private System.Windows.Forms.ColumnHeader degreeCol;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
    }
}
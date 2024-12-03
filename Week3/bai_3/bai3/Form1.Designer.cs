namespace bai3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label11 = new Label();
            textBox2 = new TextBox();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            numericUpDown1 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(166, 19);
            label1.Name = "label1";
            label1.Size = new Size(261, 32);
            label1.TabIndex = 0;
            label1.Text = "Dental Payment Form";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(69, 92);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 1;
            label2.Text = "Tên khách hàng";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(192, 92);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(248, 23);
            textBox1.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(346, 141);
            label6.Name = "label6";
            label6.Size = new Size(53, 15);
            label6.TabIndex = 6;
            label6.Text = "100.000đ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(337, 183);
            label7.Name = "label7";
            label7.Size = new Size(62, 15);
            label7.TabIndex = 7;
            label7.Text = "1.200.000đ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(346, 233);
            label8.Name = "label8";
            label8.Size = new Size(53, 15);
            label8.TabIndex = 8;
            label8.Text = "200.000đ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(311, 279);
            label9.Name = "label9";
            label9.Size = new Size(82, 15);
            label9.TabIndex = 9;
            label9.Text = "80.000đ / 1 cái";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(225, 326);
            label11.Name = "label11";
            label11.Size = new Size(75, 21);
            label11.TabIndex = 11;
            label11.Text = "Tổng tiền";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(315, 324);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(125, 23);
            textBox2.TabIndex = 12;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(69, 141);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(66, 19);
            checkBox1.TabIndex = 13;
            checkBox1.Text = "Cạo vôi";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(69, 184);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(75, 19);
            checkBox2.TabIndex = 14;
            checkBox2.Text = "Tẩy trắng";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(69, 230);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(109, 19);
            checkBox3.TabIndex = 15;
            checkBox3.Text = "Chụp hình răng";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(69, 279);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 16;
            label3.Text = "Trám răng";
            // 
            // button1
            // 
            button1.Location = new Point(69, 393);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 19;
            button1.Text = "Thoát";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(365, 393);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 20;
            button2.Text = "Tính tiền";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(144, 277);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(56, 23);
            numericUpDown1.TabIndex = 21;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(523, 450);
            Controls.Add(numericUpDown1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(textBox2);
            Controls.Add(label11);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label11;
        private TextBox textBox2;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private Label label3;
        private Button button1;
        private Button button2;
        private NumericUpDown numericUpDown1;
    }
}

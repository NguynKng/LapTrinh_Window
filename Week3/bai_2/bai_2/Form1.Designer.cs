namespace bai_2
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            groupBox1 = new GroupBox();
            listBox2 = new ListBox();
            groupBox2 = new GroupBox();
            listBox1 = new ListBox();
            button6 = new Button();
            button7 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(128, 9);
            label1.Margin = new Padding(1, 0, 1, 0);
            label1.Name = "label1";
            label1.Size = new Size(322, 37);
            label1.TabIndex = 0;
            label1.Text = "DANH SACH SINH VIEN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 81);
            label2.Margin = new Padding(1, 0, 1, 0);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 1;
            label2.Text = "Họ và tên:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(128, 81);
            textBox1.Margin = new Padding(1);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(166, 27);
            textBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(325, 76);
            button1.Margin = new Padding(1);
            button1.Name = "button1";
            button1.Size = new Size(88, 28);
            button1.TabIndex = 5;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(272, 189);
            button2.Margin = new Padding(1);
            button2.Name = "button2";
            button2.Size = new Size(48, 28);
            button2.TabIndex = 6;
            button2.Text = ">";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(272, 323);
            button3.Margin = new Padding(1);
            button3.Name = "button3";
            button3.Size = new Size(48, 28);
            button3.TabIndex = 7;
            button3.Text = "<";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(272, 241);
            button4.Margin = new Padding(1);
            button4.Name = "button4";
            button4.Size = new Size(48, 28);
            button4.TabIndex = 8;
            button4.Text = ">>";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(272, 372);
            button5.Margin = new Padding(1);
            button5.Name = "button5";
            button5.Size = new Size(48, 28);
            button5.TabIndex = 9;
            button5.Text = "<<";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listBox2);
            groupBox1.Location = new Point(349, 135);
            groupBox1.Margin = new Padding(1);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(1);
            groupBox1.Size = new Size(206, 280);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Lớp B";
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(16, 35);
            listBox2.Margin = new Padding(3, 4, 3, 4);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(164, 244);
            listBox2.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(listBox1);
            groupBox2.Location = new Point(40, 139);
            groupBox2.Margin = new Padding(1);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(1);
            groupBox2.Size = new Size(197, 271);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Lớp A";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(16, 27);
            listBox1.Margin = new Padding(3, 4, 3, 4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(164, 244);
            listBox1.TabIndex = 0;
            // 
            // button6
            // 
            button6.Location = new Point(87, 436);
            button6.Margin = new Padding(1);
            button6.Name = "button6";
            button6.Size = new Size(88, 28);
            button6.TabIndex = 12;
            button6.Text = "Xóa";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(408, 436);
            button7.Margin = new Padding(1);
            button7.Name = "button7";
            button7.Size = new Size(88, 28);
            button7.TabIndex = 13;
            button7.Text = "Kết thúc";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(555, 512);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button button6;
        private Button button7;
        private ListBox listBox2;
        private ListBox listBox1;
    }
}

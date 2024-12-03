namespace Bai1
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
            label3 = new Label();
            label4 = new Label();
            sodauTxt = new TextBox();
            socuoiTxt = new TextBox();
            ketquaTxt = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(236, 9);
            label1.Name = "label1";
            label1.Size = new Size(349, 50);
            label1.TabIndex = 0;
            label1.Text = "TÍNH TỔNG DÃY SỐ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(141, 120);
            label2.Name = "label2";
            label2.Size = new Size(89, 31);
            label2.TabIndex = 1;
            label2.Text = "Số đầu:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(508, 120);
            label3.Name = "label3";
            label3.Size = new Size(93, 31);
            label3.TabIndex = 2;
            label3.Text = "Số cuối:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(141, 239);
            label4.Name = "label4";
            label4.Size = new Size(117, 38);
            label4.TabIndex = 3;
            label4.Text = "Kết quả:";
            // 
            // sodauTxt
            // 
            sodauTxt.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sodauTxt.Location = new Point(236, 113);
            sodauTxt.Name = "sodauTxt";
            sodauTxt.Size = new Size(125, 38);
            sodauTxt.TabIndex = 4;
            sodauTxt.TextChanged += textBox1_TextChanged;
            // 
            // socuoiTxt
            // 
            socuoiTxt.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            socuoiTxt.Location = new Point(607, 117);
            socuoiTxt.Name = "socuoiTxt";
            socuoiTxt.Size = new Size(125, 38);
            socuoiTxt.TabIndex = 5;
            // 
            // ketquaTxt
            // 
            ketquaTxt.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ketquaTxt.Location = new Point(264, 241);
            ketquaTxt.Name = "ketquaTxt";
            ketquaTxt.Size = new Size(125, 38);
            ketquaTxt.TabIndex = 6;
            // 
            // button1
            // 
            button1.Location = new Point(236, 356);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 7;
            button1.Text = "Tính";
            button1.UseVisualStyleBackColor = true;
            button1.Click += tinhBtn;
            // 
            // button2
            // 
            button2.Location = new Point(425, 356);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 8;
            button2.Text = "Tiếp";
            button2.UseVisualStyleBackColor = true;
            button2.Click += tiepBtn;
            // 
            // button3
            // 
            button3.Location = new Point(607, 356);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 9;
            button3.Text = "Thoát";
            button3.UseVisualStyleBackColor = true;
            button3.Click += exitBtn;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(ketquaTxt);
            Controls.Add(socuoiTxt);
            Controls.Add(sodauTxt);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox sodauTxt;
        private TextBox socuoiTxt;
        private TextBox ketquaTxt;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}

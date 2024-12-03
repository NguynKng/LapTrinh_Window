namespace Bai1
{
    partial class Form2
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            aTxt = new TextBox();
            bTxt = new TextBox();
            ketquaTxt = new TextBox();
            nghiemTxt = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(208, 9);
            label1.Name = "label1";
            label1.Size = new Size(363, 38);
            label1.TabIndex = 0;
            label1.Text = "GIẢI PHƯƠNG TRÌNH BẬC 1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(146, 82);
            label2.Name = "label2";
            label2.Size = new Size(34, 31);
            label2.TabIndex = 1;
            label2.Text = "A:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(146, 154);
            label3.Name = "label3";
            label3.Size = new Size(32, 31);
            label3.TabIndex = 2;
            label3.Text = "B:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(83, 231);
            label4.Name = "label4";
            label4.Size = new Size(97, 31);
            label4.TabIndex = 3;
            label4.Text = "Kết quả:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(79, 286);
            label5.Name = "label5";
            label5.Size = new Size(101, 31);
            label5.TabIndex = 4;
            label5.Text = "Nghiệm:";
            // 
            // button1
            // 
            button1.Location = new Point(240, 377);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 5;
            button1.Text = "Tính";
            button1.UseVisualStyleBackColor = true;
            button1.Click += TinhBtn;
            // 
            // button2
            // 
            button2.Location = new Point(425, 377);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 6;
            button2.Text = "Tiếp";
            button2.UseVisualStyleBackColor = true;
            button2.Click += TiepBtn;
            // 
            // button3
            // 
            button3.Location = new Point(617, 377);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 7;
            button3.Text = "Thoát";
            button3.UseVisualStyleBackColor = true;
            button3.Click += ThoatBtn;
            // 
            // aTxt
            // 
            aTxt.Location = new Point(209, 88);
            aTxt.Name = "aTxt";
            aTxt.Size = new Size(310, 27);
            aTxt.TabIndex = 8;
            // 
            // bTxt
            // 
            bTxt.Location = new Point(209, 158);
            bTxt.Name = "bTxt";
            bTxt.Size = new Size(310, 27);
            bTxt.TabIndex = 9;
            // 
            // ketquaTxt
            // 
            ketquaTxt.Location = new Point(209, 237);
            ketquaTxt.Name = "ketquaTxt";
            ketquaTxt.Size = new Size(310, 27);
            ketquaTxt.TabIndex = 10;
            // 
            // nghiemTxt
            // 
            nghiemTxt.Location = new Point(209, 290);
            nghiemTxt.Name = "nghiemTxt";
            nghiemTxt.Size = new Size(310, 27);
            nghiemTxt.TabIndex = 11;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(nghiemTxt);
            Controls.Add(ketquaTxt);
            Controls.Add(bTxt);
            Controls.Add(aTxt);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox aTxt;
        private TextBox bTxt;
        private TextBox ketquaTxt;
        private TextBox nghiemTxt;
    }
}
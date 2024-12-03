namespace Week1
{
    partial class Form5
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
            button3 = new Button();
            button1 = new Button();
            ketquaTxt = new TextBox();
            socuoiTxt = new TextBox();
            sodauTxt = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Location = new Point(526, 384);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 19;
            button3.Text = "Thoát";
            button3.UseVisualStyleBackColor = true;
            button3.Click += exitBtn;
            // 
            // button1
            // 
            button1.Location = new Point(200, 384);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 17;
            button1.Text = "Tính";
            button1.UseVisualStyleBackColor = true;
            button1.Click += findBtn;
            // 
            // ketquaTxt
            // 
            ketquaTxt.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ketquaTxt.Location = new Point(228, 269);
            ketquaTxt.Name = "ketquaTxt";
            ketquaTxt.Size = new Size(125, 38);
            ketquaTxt.TabIndex = 16;
            // 
            // socuoiTxt
            // 
            socuoiTxt.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            socuoiTxt.Location = new Point(571, 145);
            socuoiTxt.Name = "socuoiTxt";
            socuoiTxt.Size = new Size(125, 38);
            socuoiTxt.TabIndex = 15;
            // 
            // sodauTxt
            // 
            sodauTxt.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sodauTxt.Location = new Point(200, 141);
            sodauTxt.Name = "sodauTxt";
            sodauTxt.Size = new Size(125, 38);
            sodauTxt.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(105, 267);
            label4.Name = "label4";
            label4.Size = new Size(117, 38);
            label4.TabIndex = 13;
            label4.Text = "Kết quả:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(472, 148);
            label3.Name = "label3";
            label3.Size = new Size(93, 31);
            label3.TabIndex = 12;
            label3.Text = "Số cuối:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(105, 148);
            label2.Name = "label2";
            label2.Size = new Size(89, 31);
            label2.TabIndex = 11;
            label2.Text = "Số đầu:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(200, 37);
            label1.Name = "label1";
            label1.Size = new Size(349, 50);
            label1.TabIndex = 10;
            label1.Text = "TÍNH TỔNG DÃY SỐ";
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(ketquaTxt);
            Controls.Add(socuoiTxt);
            Controls.Add(sodauTxt);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form5";
            Text = "Form5";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button3;
        private Button button1;
        private TextBox ketquaTxt;
        private TextBox socuoiTxt;
        private TextBox sodauTxt;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}
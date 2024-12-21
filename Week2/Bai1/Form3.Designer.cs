namespace Week1
{
    partial class Form3
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
            number_txt = new TextBox();
            result_txt = new TextBox();
            findBtn = new Button();
            nextBtn = new Button();
            exitBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(317, 28);
            label1.Name = "label1";
            label1.Size = new Size(175, 38);
            label1.TabIndex = 0;
            label1.Text = "TÌM SỐ ĐẢO";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(141, 105);
            label2.Name = "label2";
            label2.Size = new Size(104, 31);
            label2.TabIndex = 1;
            label2.Text = "Nhập số:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(141, 200);
            label3.Name = "label3";
            label3.Size = new Size(97, 31);
            label3.TabIndex = 2;
            label3.Text = "Kết quả:";
            // 
            // number_txt
            // 
            number_txt.Location = new Point(271, 109);
            number_txt.Name = "number_txt";
            number_txt.Size = new Size(238, 27);
            number_txt.TabIndex = 3;
            // 
            // result_txt
            // 
            result_txt.Location = new Point(271, 206);
            result_txt.Name = "result_txt";
            result_txt.Size = new Size(238, 27);
            result_txt.TabIndex = 4;
            // 
            // findBtn
            // 
            findBtn.Location = new Point(225, 337);
            findBtn.Name = "findBtn";
            findBtn.Size = new Size(94, 29);
            findBtn.TabIndex = 5;
            findBtn.Text = "Tìm";
            findBtn.UseVisualStyleBackColor = true;
            findBtn.Click += findClick;
            // 
            // nextBtn
            // 
            nextBtn.Location = new Point(386, 337);
            nextBtn.Name = "nextBtn";
            nextBtn.Size = new Size(94, 29);
            nextBtn.TabIndex = 7;
            nextBtn.Text = "Tiếp";
            nextBtn.UseVisualStyleBackColor = true;
            nextBtn.Click += nextClick;
            // 
            // exitBtn
            // 
            exitBtn.Location = new Point(548, 334);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(125, 34);
            exitBtn.TabIndex = 8;
            exitBtn.Text = "Thoát";
            exitBtn.UseVisualStyleBackColor = true;
            exitBtn.Click += exitClick;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 479);
            Controls.Add(exitBtn);
            Controls.Add(nextBtn);
            Controls.Add(findBtn);
            Controls.Add(result_txt);
            Controls.Add(number_txt);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox number_txt;
        private TextBox result_txt;
        private Button findBtn;
        private Button nextBtn;
        private Button exitBtn;
    }
}
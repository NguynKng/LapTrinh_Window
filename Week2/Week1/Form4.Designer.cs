namespace Week1
{
    partial class Form4
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            number_txt = new TextBox();
            list_txt = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(164, 24);
            label1.Name = "label1";
            label1.Size = new Size(478, 38);
            label1.TabIndex = 0;
            label1.Text = "LIỆT KÊ SỐ NGUYÊN TỐ NHỎ HƠN N";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(138, 114);
            label2.Name = "label2";
            label2.Size = new Size(98, 31);
            label2.TabIndex = 1;
            label2.Text = "Nhập N:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(138, 189);
            label3.Name = "label3";
            label3.Size = new Size(189, 31);
            label3.TabIndex = 2;
            label3.Text = "Danh sách số NT:";
            // 
            // button1
            // 
            button1.Location = new Point(224, 313);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 3;
            button1.Text = "Tìm";
            button1.UseVisualStyleBackColor = true;
            button1.Click += findBtn;
            // 
            // button2
            // 
            button2.Location = new Point(426, 313);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 4;
            button2.Text = "Tiếp";
            button2.UseVisualStyleBackColor = true;
            button2.Click += nextBtn;
            // 
            // button3
            // 
            button3.Location = new Point(629, 313);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 5;
            button3.Text = "Thoát";
            button3.UseVisualStyleBackColor = true;
            button3.Click += exitBtn;
            // 
            // number_txt
            // 
            number_txt.Location = new Point(265, 120);
            number_txt.Name = "number_txt";
            number_txt.Size = new Size(211, 27);
            number_txt.TabIndex = 6;
            // 
            // list_txt
            // 
            list_txt.Location = new Point(342, 193);
            list_txt.Name = "list_txt";
            list_txt.Size = new Size(335, 27);
            list_txt.TabIndex = 7;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(list_txt);
            Controls.Add(number_txt);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form4";
            Text = "Form4";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox number_txt;
        private TextBox list_txt;
    }
}
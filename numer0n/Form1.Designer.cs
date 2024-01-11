namespace numer0n
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
            label5 = new Label();
            label6 = new Label();
            textBox1 = new TextBox();
            label7 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label8 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.Font = new Font("Yu Gothic UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(35, 30);
            label1.Name = "label1";
            label1.Size = new Size(91, 107);
            label1.TabIndex = 0;
            // 
            // label2
            // 
            label2.BackColor = Color.White;
            label2.Font = new Font("Yu Gothic UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(233, 30);
            label2.Name = "label2";
            label2.Size = new Size(91, 107);
            label2.TabIndex = 1;
            // 
            // label3
            // 
            label3.BackColor = Color.White;
            label3.Font = new Font("Yu Gothic UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(451, 30);
            label3.Name = "label3";
            label3.Size = new Size(91, 107);
            label3.TabIndex = 2;
            // 
            // label4
            // 
            label4.BackColor = Color.White;
            label4.Font = new Font("Yu Gothic UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(35, 260);
            label4.Name = "label4";
            label4.Size = new Size(91, 107);
            label4.TabIndex = 3;
            // 
            // label5
            // 
            label5.BackColor = Color.White;
            label5.Font = new Font("Yu Gothic UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(233, 260);
            label5.Name = "label5";
            label5.Size = new Size(91, 107);
            label5.TabIndex = 4;
            // 
            // label6
            // 
            label6.BackColor = Color.White;
            label6.Font = new Font("Yu Gothic UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ActiveCaptionText;
            label6.Location = new Point(451, 260);
            label6.Name = "label6";
            label6.Size = new Size(91, 107);
            label6.TabIndex = 5;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.ForeColor = SystemColors.InactiveCaptionText;
            textBox1.Location = new Point(58, 401);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.MaxLength = 3;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(189, 20);
            textBox1.TabIndex = 6;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.ControlAdded += textBox1_ControlAdded;
            textBox1.ControlRemoved += textBox1_ControlRemoved;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // label7
            // 
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Location = new Point(58, 484);
            label7.Name = "label7";
            label7.Size = new Size(450, 163);
            label7.TabIndex = 7;
            label7.MouseDown += label7_MouseDown;
            label7.MouseUp += label7_MouseUp;
            // 
            // button1
            // 
            button1.Font = new Font("Yu Gothic UI", 28.2F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(346, 384);
            button1.Name = "button1";
            button1.Size = new Size(162, 74);
            button1.TabIndex = 8;
            button1.Text = "call";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(414, 484);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 9;
            button2.Text = "up";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(414, 618);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 10;
            button3.Text = "down";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label8
            // 
            label8.Location = new Point(35, 151);
            label8.Name = "label8";
            label8.Size = new Size(165, 92);
            label8.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 689);
            Controls.Add(label8);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label7);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBox1;
        private Label label7;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label8;
    }
}
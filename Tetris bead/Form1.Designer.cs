namespace Tetris_bead
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(393, 120);
            button1.Name = "button1";
            button1.Size = new Size(156, 56);
            button1.TabIndex = 1;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(486, 467);
            button2.Name = "button2";
            button2.Size = new Size(156, 56);
            button2.TabIndex = 2;
            button2.Text = "jobb";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button3_Click;
            // 
            // button3
            // 
            button3.Location = new Point(324, 467);
            button3.Name = "button3";
            button3.Size = new Size(156, 56);
            button3.TabIndex = 3;
            button3.Text = "bal";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(393, 405);
            button4.Name = "button4";
            button4.Size = new Size(156, 56);
            button4.TabIndex = 4;
            button4.Text = "fel";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button3_Click;
            // 
            // button5
            // 
            button5.Location = new Point(393, 529);
            button5.Name = "button5";
            button5.Size = new Size(156, 56);
            button5.TabIndex = 5;
            button5.Text = "le";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button3_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(300, 600);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(654, 600);
            Controls.Add(pictureBox1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            KeyPreview = true;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Label label1;
        private PictureBox pictureBox1;
    }
}
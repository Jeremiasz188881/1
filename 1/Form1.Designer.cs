namespace _1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            start = new Button();
            wyjscie = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            czas = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            textBox1 = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // start
            // 
            start.Image = (Image)resources.GetObject("start.Image");
            start.Location = new Point(530, 175);
            start.Name = "start";
            start.Size = new Size(199, 64);
            start.TabIndex = 0;
            start.UseVisualStyleBackColor = true;
            start.Click += button1_Click;
            // 
            // wyjscie
            // 
            wyjscie.BackgroundImage = (Image)resources.GetObject("wyjscie.BackgroundImage");
            wyjscie.Location = new Point(-2, -5);
            wyjscie.Name = "wyjscie";
            wyjscie.Size = new Size(177, 69);
            wyjscie.TabIndex = 1;
            wyjscie.UseVisualStyleBackColor = true;
            wyjscie.Click += button2_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // czas
            // 
            czas.AutoSize = true;
            czas.Location = new Point(1196, 1);
            czas.Name = "czas";
            czas.Size = new Size(0, 20);
            czas.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.HotTrack;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Yu Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.Location = new Point(148, 275);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(985, 116);
            textBox1.TabIndex = 3;
            textBox1.Text = "Połącz wszystkie kwadraty, których wynik działania matematycznego jest taki sam. \r\n                                         Ścieżki nie mogą się przecinać. \r\n ";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(207, 339);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1091, 492);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(1262, 977);
            Controls.Add(pictureBox1);
            Controls.Add(textBox1);
            Controls.Add(czas);
            Controls.Add(wyjscie);
            Controls.Add(start);
            Name = "Form1";
            Text = "Gra Matematyczna";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button start;
        private Button wyjscie;
        private System.Windows.Forms.Timer timer1;
        private Label czas;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TextBox textBox1;
        private PictureBox pictureBox1;
    }
}
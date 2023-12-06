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
            start = new Button();
            wyjscie = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            czas = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            SuspendLayout();
            // 
            // start
            // 
            start.Location = new Point(463, 155);
            start.Name = "start";
            start.Size = new Size(273, 122);
            start.TabIndex = 0;
            start.Text = "Start";
            start.UseVisualStyleBackColor = true;
            start.Click += button1_Click;
            // 
            // wyjscie
            // 
            wyjscie.Location = new Point(1, 1);
            wyjscie.Name = "wyjscie";
            wyjscie.Size = new Size(111, 51);
            wyjscie.TabIndex = 1;
            wyjscie.Text = "Wyjście";
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
            czas.Size = new Size(39, 20);
            czas.TabIndex = 2;
            czas.Text = "Czas";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 977);
            Controls.Add(czas);
            Controls.Add(wyjscie);
            Controls.Add(start);
            Name = "Form1";
            Text = "Form1";
            
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button start;
        private Button wyjscie;
        private System.Windows.Forms.Timer timer1;
        private Label czas;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
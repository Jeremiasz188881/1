using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace _1
{
    public partial class Form1 : Form
    {
        private int elapsedSeconds = 0;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private DateTime startTime;
        private SquareGenerator squareGenerator = new SquareGenerator();
        private List<SquareGenerator.SquareInfo> squares;

        public Form1()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer.Interval = 1000; // Interwa� czasowy w milisekundach (tutaj 1 sekunda)
            timer.Tick += timer1_Tick;
        }

        private void UpdateTimerLabel()
        {
            // Oblicz up�ywaj�cy czas
            TimeSpan elapsedTime = DateTime.Now - startTime;

            // Przekszta�� elapsedSeconds na format hh:mm:ss
            string formattedTime = elapsedTime.ToString(@"hh\:mm\:ss");

            // Wy�wietl czas w kontrolce Label
            czas.Text = formattedTime;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            elapsedSeconds++;
            UpdateTimerLabel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numberOfSquares = 7;
            int size = 150;

            squares = squareGenerator.GeneratePredefinedSquares(size, ClientSize);

            // Dodaj to, aby od�wie�y� formularz i wywo�a� OnPaint
            Invalidate();

            start.Visible = false;

            // Ustaw czas pocz�tkowy
            startTime = DateTime.Now;

            // Uruchom Timer
            timer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Zatrzymaj Timer
            timer.Stop();
            czas.Visible = false;
            // Wy�wietl czas w MessageBox
            ShowTimeInMessageBox();
            Application.Exit();
        }

        private void ShowTimeInMessageBox()
        {
            // Przekszta�� elapsedSeconds na format hh:mm:ss
            TimeSpan elapsedTime = DateTime.Now - startTime;
            string formattedTime = elapsedTime.ToString(@"hh\:mm\:ss");

            // Wy�wietl czas w MessageBox
            MessageBox.Show("Aktualny czas: " + formattedTime, "Czas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

       
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Rysuj obrysy kwadrat�w na formularzu
            if (squares != null)
            {
                foreach (var squareInfo in squares)
                {
                    e.Graphics.DrawRectangle(Pens.Black, squareInfo.Rectangle);

                    // Rysuj dzia�anie matematyczne wewn�trz kwadratu
                    string displayText = $"{squareInfo.MathOperation}";
                    DrawTextInCenter(e.Graphics, squareInfo.Rectangle, displayText);
                }
            }
        }

        private void DrawTextInCenter(Graphics g, Rectangle rectangle, string text)
        {
            StringFormat stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            g.DrawString(text, Font, Brushes.Black, rectangle, stringFormat);
        }
    }
}

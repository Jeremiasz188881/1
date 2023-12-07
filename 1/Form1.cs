using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace _1
{
    public partial class Form1 : Form
    {
        private int elapsedSeconds = 0;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private DateTime startTime;
        private SquareGenerator squareGenerator = new SquareGenerator();
        private List<SquareGenerator.SquareInfo> squares;
        private SquareController squareController;
        private SoundPlayer soundPlayer;

        public Form1()
        {
            InitializeComponent();
            InitializeTimer();
            squareController = new SquareController(this, squares);
            this.Paint += MainForm_Paint;
            this.MouseClick += MainForm_MouseClick;
            this.KeyDown += Form1_KeyDown;
            InitializeSoundPlayer();

        }

        private void InitializeTimer()
        {
            timer.Interval = 1000; // Interwa³ czasowy w milisekundach (tutaj 1 sekunda)
            timer.Tick += timer1_Tick;
        }

        private void UpdateTimerLabel()
        {
            // Oblicz up³ywaj¹cy czas
            TimeSpan elapsedTime = DateTime.Now - startTime;

            // Przekszta³æ elapsedSeconds na format hh:mm:ss
            string formattedTime = elapsedTime.ToString(@"hh\:mm\:ss");

            // Wyœwietl czas w kontrolce Label
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

            Invalidate();

            start.Visible = false;
            textBox1.Visible = false;
            pictureBox1.Visible = false;

            startTime = DateTime.Now;

            PlayButtonClickSound();

            timer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            timer.Stop();
            czas.Visible = false;
          
            ShowTimeInMessageBox();
            Application.Exit();
        }

        private void ShowTimeInMessageBox()
        {
           
            TimeSpan elapsedTime = DateTime.Now - startTime;
            string formattedTime = elapsedTime.ToString(@"hh\:mm\:ss");

           
            MessageBox.Show("Aktualny czas: " + formattedTime, "Czas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            
            if (squares != null)
            {
                foreach (var squareInfo in squares)
                {
                    e.Graphics.DrawRectangle(Pens.Black, squareInfo.Rectangle);

                    
                    string displayText = $"{squareInfo.MathOperation}";
                    DrawTextInCenter(e.Graphics, squareInfo.Rectangle, displayText);
                }
            }

            squareController.DrawLine(e.Graphics);
        }


        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            if (squares != null)
            {
                foreach (SquareGenerator.SquareInfo squareInfo in squares)
                {
                    e.Graphics.DrawRectangle(Pens.Black, squareInfo.Rectangle);
                }
            }

            squareController.DrawLine(e.Graphics);
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
        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            squareController.HandleMouseClick(e.Location);
            Invalidate();  
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            squareController.HandleKeyDown(e.KeyCode);
        }

        private void InitializeSoundPlayer()
        {
            
            soundPlayer = new SoundPlayer("czesc.wav");
        }
        private void PlayButtonClickSound()
        {
            if (soundPlayer != null)
            {
                soundPlayer.Play();
            }
        }

    }
}

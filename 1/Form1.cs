namespace _1
{
    public partial class Form1 : Form
    {

        private int elapsedSeconds = 0;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private DateTime startTime;
        private SquareGenerator squareGenerator = new SquareGenerator();
        private List<Rectangle> squares;


        public Form1()
        {
            InitializeComponent();
            InitializeTimer();
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
            int numberOfSquares = 10; // Iloœæ kwadratów do wygenerowania
            int size = 150; // Rozmiar kwadratu

            squares = squareGenerator.GenerateRandomSquares(numberOfSquares, size, ClientSize);

            Refresh(); // Odœwie¿ formularz, aby narysowaæ kwadraty
            start.Visible = false;

            // Ustaw czas pocz¹tkowy
            startTime = DateTime.Now;

            // Uruchom Timer
            timer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Zatrzymaj Timer
            timer.Stop();
            czas.Visible = false;
            // Wyœwietl czas w MessageBox
            ShowTimeInMessageBox();
            Application.Exit();
        }

        private void ShowTimeInMessageBox()
        {
            // Przekszta³æ elapsedSeconds na format hh:mm:ss
            TimeSpan elapsedTime = DateTime.Now - startTime;
            string formattedTime = elapsedTime.ToString(@"hh\:mm\:ss");

            // Wyœwietl czas w MessageBox
            MessageBox.Show("Aktualny czas: " + formattedTime, "Czas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Rysuj obrysy kwadratów na formularzu
            if (squares != null)
            {
                foreach (Rectangle square in squares)
                {
                    e.Graphics.DrawRectangle(Pens.Black, square);
                }
            }
        }
    }
}
namespace Tetris_bead
{
    public partial class Form1 : Form
    {
        private Game g;
        private Graphics gp;
        private Pen pen;
        public Form1()
        {
            //g = new Game(picBox);
            InitializeComponent();
            pen = new Pen(Color.Red);
            pen.Width = 1;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            sender.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PictureBox pb = pictureBox1;
            Graphics gp = pb.CreateGraphics();
            g = new Game(gp);
            Thread thread = new Thread(new ThreadStart(g.Run));
            thread.Start();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            g.mozg(((Button)sender).Text);
        }


    }







}
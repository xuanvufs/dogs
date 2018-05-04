using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Animate
{
    public partial class Mush : Form
    {
        private const int WIDTH = 362;
        private const int HEIGHT = 74;
        private readonly int _minX;
        private readonly int _maxX;

        private readonly Rectangle _start;
        private readonly Rectangle _end;
        private readonly int _speed;

        public Mush(int speed = 3)
        {
            InitializeComponent();

            _speed = speed;
            _start = Screen.AllScreens.OrderBy(s => s.Bounds.X).First().WorkingArea;
            _end = Screen.AllScreens.OrderByDescending(s => s.Bounds.X).First().WorkingArea;

            _minX = _start.X;
            _maxX = _end.X;

            Width = WIDTH;
            Height = HEIGHT;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TopMost = true;

            Location = new Point(_minX - Width, (_start.Height + _start.Y) - HEIGHT);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var x = Location.X;
            var y = Location.Y;
            var maxX = _start.X + _start.Width;

            if ((x + WIDTH) < maxX)
                x += _speed;
            else if ((x + _speed) < maxX && dogs.Location.X < WIDTH)
                dogs.Location = new Point(dogs.Location.X + _speed, 0);
            else if (dogs.Location.X >= WIDTH)
            {
                x = _end.X;
                dogs.Location = new Point(-WIDTH, 0);
                y = _end.Height + _end.Y - HEIGHT;
            }
            else if (dogs.Location.X < 0)
            {
                var dx = dogs.Location.X + _speed < 0 ? dogs.Location.X + _speed : 0;
                dogs.Location = new Point(dx, 0);
            }
            else
            {
                x += _speed;
                if (x > (_end.X + _end.Width))
                {
                    TopMost = true;
                    x = _minX - Width;
                    y = _start.Height + _start.Y - HEIGHT;
                }
            }
            Location = new Point(x, y);
        }
    }
}

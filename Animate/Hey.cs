using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Animate
{
    public partial class Hey : Form
    {
        private const int WIDTH = 500;
        private const int HEIGHT = 364;

        private readonly int _x;
        private readonly int _y;

        public Hey()
        {
            InitializeComponent();

            var area = Screen.PrimaryScreen.WorkingArea;
            _x = area.X + area.Width - WIDTH;
            _y = area.Y + area.Height - HEIGHT;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TopMost = true;

            Location = new Point(_x, _y);
        }
    }
}

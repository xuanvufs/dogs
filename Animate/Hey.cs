using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Animate
{
    public partial class Hey : Form
    {
        private readonly int _x;
        private readonly int _y;

        public Hey()
        {
            InitializeComponent();

            var area = Screen.PrimaryScreen.WorkingArea;
            _x = area.X + area.Width - Width;
            _y = area.Y + area.Height - Height + 2;
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

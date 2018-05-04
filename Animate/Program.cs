using System;
using System.Windows.Forms;

namespace Animate
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form form;
            if (args.Length != 0 && int.TryParse(args[0], out int speed)) form = new Mush(speed);
            else if (args[0].Equals("hey", StringComparison.OrdinalIgnoreCase)) form = new Hey();
            else form = new Mush();

            Application.Run(form);
        }
    }
}
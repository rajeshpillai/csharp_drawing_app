using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPaint_CSharp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var form = new Board();


            form.WindowState = FormWindowState.Maximized;
            form.Opacity = 0.5;
            //form.TopMost = true;
            form.FormBorderStyle = FormBorderStyle.None;

            var form2 = new Board();
            form2.WindowState = FormWindowState.Normal;
            form2.Opacity = 1;
            form2.Width = 66;
            form2.ControlBox = false;
            form2.TopMost = false;
            //form2.TopMost = true;
            //form.Show();
            Application.Run(form);

        }
    }
}

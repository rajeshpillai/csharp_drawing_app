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

            //form.BackColor = Color.White;
            //form.TransparencyKey = form.BackColor;
            //form.Bounds = Screen.PrimaryScreen.Bounds;
            form.Opacity = 0.1;
            form.TopMost = true;
            //form.FormBorderStyle = FormBorderStyle.None;
            //form.Width = 66;

            Application.Run(form);
            
        }
    }
}

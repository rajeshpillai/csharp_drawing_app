using MyPaint_CSharp.Shapes;
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


            //form.WindowState = FormWindowState.Maximized;
            form.BackColor = Color.White;
            //form.TransparencyKey = SystemColors.Control;
            form.Opacity = 0.1;
            //form.TopMost = true;
            //form.FormBorderStyle = FormBorderStyle.None;

            ToolBox tool = new ToolBox();
            tool.Width = 600;
            tool.TopMost = true;
            

            //Application.Run(form);
            Application.Run(new MultiFormContext(form, tool));


        }
    }
}

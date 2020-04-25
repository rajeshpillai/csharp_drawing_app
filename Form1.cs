using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPaint_CSharp
{
    public partial class frmMyPaint : Form
    {
        string shape = "rectangle";
        bool startPaint = false;
        int x = 0;
        int y = 0;
        int ex = 0;
        int ey = 0;

        Graphics g;

        public frmMyPaint()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            g = canvas.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            shape = "rectangle";
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            startPaint = true;
            this.Text =   "Mouse Down at : " + e.X.ToString() + ", " + e.Y.ToString();
            if (shape == "rectangle")
            {
                SolidBrush sb = new SolidBrush(Color.Yellow);
                x = e.X;
                y = e.Y;

            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            lblFooter.Text = "Mouse Move at : " + e.X.ToString() + ", " + e.Y.ToString();

            if (startPaint && shape == "rectangle")
            {
                ex = e.X;
                ey = e.Y;

                canvas.Invalidate();
            } else
            {
                // Draw Line
                // Set Pen Back color and Line Width
                /*Pen p = new Pen(new SolidBrush(Color.Red), 2);

                // Draw line
                g.DrawLine(p, new Point(x ?? e.X, y ?? e.Y), new Point(e.X, e.Y));
                x = e.X;
                y = e.Y;*/
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            startPaint = false;
            x = -1;
            y = -1;
            shape = "";
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g.Clear(Color.White);
            SolidBrush sb = new SolidBrush(Color.Yellow);
            g.FillRectangle(sb, x, y, ex - x, ey - y);
        }

        private void frmMyPaint_Load(object sender, EventArgs e)
        {

        }
    }
}

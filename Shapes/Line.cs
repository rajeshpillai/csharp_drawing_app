using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint_CSharp.Shapes
{
    public class Line : Shape
    {
        public override void Paint(Graphics g)
        {
            Pen p = new Pen(new SolidBrush(this.ForeColor), 2);
            // Draw line
            g.DrawLine(p, new Point(StartPoint.X, StartPoint.Y), new Point(EndPoint.X, EndPoint.Y));
        }
    }
}

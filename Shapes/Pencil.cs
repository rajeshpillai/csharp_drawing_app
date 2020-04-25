using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint_CSharp.Shapes
{
    public class Pencil : Shape
    {
        public override void Paint(Graphics g)
        {
            Pen p = new Pen(new SolidBrush(this.ForeColor), 2);
            SolidBrush sb = new SolidBrush(this.ForeColor);

            var start = StartPoint;
            var prev = StartPoint;
            for(var i = 0; i < Points.Count-1; i++)
            {
                g.DrawLine(p, Points[i], Points[i+1]);
                //g.FillRectangle(sb,Points[i].X, Points[i].Y, 10,10);
            }

        }
    }
}

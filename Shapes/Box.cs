﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint_CSharp.Shapes
{
    public class Box : Shape
    {
        public override void Paint(Graphics g)
        {
            SolidBrush sb = new SolidBrush(this.ForeColor);

            g.FillRectangle(sb, StartPoint.X, StartPoint.Y, EndPoint.X, EndPoint.Y);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint_CSharp.Shapes
{
    public abstract class Shape
    {
        public Color ForeColor = Color.Black;
        public List<Point> Points = new List<Point>();  // Currently used by Pencil. Refactor required.

        public Point StartPoint = new Point(0, 0);
        public Point EndPoint = new Point(0, 0);

        public Boolean Dirty = false;

        abstract public void Paint(Graphics g);

    }
}

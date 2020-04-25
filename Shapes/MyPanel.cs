using System;
using System.Windows.Forms;

namespace MyPaint_CSharp.Shapes
{
    public class MyPanel : System.Windows.Forms.Panel
    {
        public MyPanel()
        {
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }
    }
}

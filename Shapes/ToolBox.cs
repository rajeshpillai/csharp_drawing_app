using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPaint_CSharp.Shapes
{
    public partial class ToolBox : Form
    {
        private HalloForm _hallo;
        public ToolBox()
        {
            InitializeComponent();

            _hallo = new HalloForm();

            //timer.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            this.Focus();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Point pt = Cursor.Position;
            //pt.Offset(-(_hallo.Width / 2), -(_hallo.Height / 2));
            _hallo.Location = pt;

            if (!_hallo.Visible)
            {
              //_hallo.Show();
            }


            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                g.DrawEllipse(Pens.Red, pt.X - 10, pt.Y - 10, 20, 20);

            }
        }
    }
}

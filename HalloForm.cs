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
    public partial class HalloForm : Form
    {
        public HalloForm()
        {
            InitializeComponent();
            TopMost = true;
            ShowInTaskbar = false;
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.LightGreen;
            TransparencyKey = Color.LightGreen;
            Width = 100;
            Height = 100;

            Paint += new PaintEventHandler(HalloForm_Paint);
        }

        void HalloForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(Pens.Black, (Width - 25) / 2, (Height - 25) / 2, 25, 25);
        }
    }
}

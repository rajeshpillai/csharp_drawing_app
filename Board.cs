using Gma.System.MouseKeyHook;
using MyPaint_CSharp.Shapes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPaint_CSharp
{
    /// <summary>
    /// Struct representing a point.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;

        public static implicit operator Point(POINT point)
        {
            return new Point(point.X, point.Y);
        }
    }
    public partial class Board : Form
    {



        bool isCapturing = false;

        string shape = "ellipse";
        bool startPaint = false;
        int x = 0;
        int y = 0;
        int px = 0;
        int py = 0;

        List<Shape> shapes = new List<Shape>();

        Shape currentShape = new Ellipse();
        Color fgColor = Color.Black;

        Color defaultFormBg;


        public MyPanel Canvas
        {
            get
            {
                return canvas;
            }

        }


        public Board()
        {
            InitializeComponent();
            //this.DoubleBuffered = true;   // This works only when drawing on form
            //this.SetStyle(ControlStyles.ResizeRedraw, true);

            defaultFormBg = this.TransparencyKey;

            ToTransparent();
            ToTopMost();
        
        }

        
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            startPaint = true;
            this.Text =   "Mouse Down at : " + e.X.ToString() + ", " + e.Y.ToString();
            x = e.X;
            y = e.Y;


            if (shape == "rectangle")
            {
                currentShape = new Box();
            } 
            else if (shape == "ellipse")
            {
                currentShape = new Ellipse();

            }
            else if (shape == "line")
            {
                currentShape = new Line();
            }
            else if (shape == "pencil")
            {
                currentShape = new Pencil();
            }

            currentShape.ForeColor = fgColor;

            currentShape.StartPoint = new Point(x, y);
            currentShape.EndPoint = new Point(e.X - x, e.Y - y);

            shapes.Add(currentShape);

        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            //lblFooter.Text = "Mouse Move at : " + e.X.ToString() + ", " + e.Y.ToString();
            px = e.X;
            py = e.Y;

            if (startPaint && shape != "")
            {

                if (shape == "line")
                {
                    currentShape.EndPoint = new Point(e.X , e.Y);
                } 
                else if (shape == "pencil")
                {
                    currentShape.Points.Add(new Point(e.X, e.Y));
                }
                else
                {
                    currentShape.EndPoint = new Point(e.X - x, e.Y - y);
                }

                canvas.Invalidate();
            } 
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            startPaint = false;
            
            x = -1;
            y = -1;
        }
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.CompositingMode = CompositingMode.SourceCopy;
            e.Graphics.CompositingQuality = CompositingQuality.GammaCorrected;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.Clear(this.BackColor);

            foreach (var s in shapes)
            {
                s.Paint(e.Graphics);   
            }
        }


        private void frmMyPaint_Resize(object sender, EventArgs e)
        {
            canvas.Invalidate();
        }

        private void btnBox_Click(object sender, EventArgs e)
        {
            shape = "rectangle";
        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {
            shape = "ellipse";
        }

        private void btnPen_Click(object sender, EventArgs e)
        {
            shape = "line";
        }

        private void btnPencil_Click(object sender, EventArgs e)
        {
            shape = "pencil";
        }

        private void btnColorDialog_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = true;
            colorDlg.AnyColor = true;
            colorDlg.SolidColorOnly = false;
            colorDlg.Color = Color.Red;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                fgColor = colorDlg.Color;
            }
           
        }

        private void Board_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMakeTop_Click(object sender, EventArgs e)
        {
            isCapturing = !isCapturing;
            if (isCapturing)
            {
                //form.BackColor = Color.White;
                //this.TransparencyKey = this.BackColor;
                //form.Bounds = Screen.PrimaryScreen.Bounds;
                //this.Opacity = 0.5;
                //this.Width = Screen.PrimaryScreen.Bounds.Width;
                //this.Height = Screen.PrimaryScreen.Bounds.Height;

                
                //drawing.Opacity = 0.1;
            } else
            {
                //this.TransparencyKey = defaultFormBg;
                //this.Opacity = 1;
                this.Width = 66;
            }

        }

        private void Board_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void Board_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
        }

        public void ToTransparent()
        {
            UInt32 dwExStyle = GetWindowLong(this.Handle, -20);
            SetWindowLong(this.Handle, -20, dwExStyle | 0x00080000);
            SetLayeredWindowAttributes(this.Handle, 0x00FFFFFF, 1, 0x2);
        }

        public void ToTopMost()
        {
            SetWindowPos(this.Handle, (IntPtr)(-1), 0, 0, 0, 0, 0x0002 | 0x0001 | 0x0020);
        }

        public void ToThrough()
        {
            UInt32 dwExStyle = GetWindowLong(this.Handle, -20);
            //SetWindowLong(this.Handle, -20, dwExStyle | 0x00080000);
            //SetWindowPos(this.Handle, (IntPtr)0, 0, 0, 0, 0, 0x0002 | 0x0001 | 0x0004 | 0x0010 | 0x0020);
            //SetLayeredWindowAttributes(this.Handle, 0x00FFFFFF, 1, 0x2);
            SetWindowLong(this.Handle, -20, dwExStyle | 0x00080000 | 0x00000020);
            //SetWindowPos(this.Handle, (IntPtr)(1), 0, 0, 0, 0, 0x0002 | 0x0001 | 0x0010 | 0x0020);
        }




        public const int GWL_EXSTYLE = -20;
        public const int WS_EX_LAYERED = 0x80000;
        public const int LWA_ALPHA = 0x2;
        public const int LWA_COLORKEY = 0x1;


        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        [DllImport("user32.dll", SetLastError = true)]
        static extern UInt32 GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, UInt32 dwNewLong);
        [DllImport("user32.dll")]
        public extern static bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);
        [DllImport("user32.dll", SetLastError = false)]
        static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern short GetKeyState(int keyCode);

        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);

    }
}

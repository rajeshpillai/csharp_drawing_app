using Gma.System.MouseKeyHook;
using MyPaint_CSharp.Shapes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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

        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("User32.dll")]
        public static extern void ReleaseDC(IntPtr hwnd, IntPtr dc);

        //

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);


        
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        [DllImport("GDI32.dll")]
        private static extern bool DeleteDC(int hdc);
        [DllImport("GDI32.dll")]
        private static extern bool DeleteObject(int hObject);
        [DllImport("GDI32.dll")]
        private static extern int SelectObject(int hdc, int hgdiobj);
        [DllImport("User32.dll")]
        private static extern int GetDesktopWindow();
        [DllImport("User32.dll")]
        private static extern int GetWindowDC(int hWnd);
        [DllImport("GDI32.dll")]
        private static extern int LineTo(int hdc, int x, int y);
        [DllImport("GDI32.dll")]
        private static extern int MoveToEx(int hdc, int x, int y, ref Point lppoint);
        [DllImport("GDI32.dll")]
        private static extern int CreatePen(int penstyle, int width, int color);
        //

        private IKeyboardMouseEvents m_Events;

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

            timer.Interval = 100;
            timer.Enabled = true;

            SubscribeGlobal();
        }

        private void SubscribeGlobal()
        {
            Unsubscribe();
            Subscribe(Hook.GlobalEvents());
        }

        private void Subscribe(IKeyboardMouseEvents events)
        {
            m_Events = events;

            m_Events.MouseUp += OnMouseUp;
            m_Events.MouseClick += OnMouseClick;
            m_Events.MouseMove += HookManager_MouseMove;
        }

        private void Unsubscribe()
        {
            if (m_Events == null) return;
            m_Events.MouseUp -= OnMouseUp;
            m_Events.MouseClick -= OnMouseClick;
            m_Events.MouseMove -= HookManager_MouseMove;
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            Log(string.Format("MouseUp \t\t {0}\n", e.Button));
        }

        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            Log(string.Format("MouseClick \t\t {0}\n", e.Button));
        }

        private void HookManager_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = string.Format("x={0}; y={1}", e.X, e.Y);
        }

        private void Log(string text)
        {
            if (IsDisposed) return;
            Debug.WriteLine(text);
        }

        // Code for allowing clicking through of the form
        protected override void WndProc(ref Message m)
        {
            const uint WM_NCHITTEST = 0x84;

            const int HTTRANSPARENT = -1;
            const int HTCLIENT = 1;
            const int HTCAPTION = 2;
            // ... or define an enum with all the values

            if (m.Msg == WM_NCHITTEST)
            {
                // If it's the message we want, handle it.
                if (true)   //todo
                {
                    // If we're drawing, we want to see mouse events like normal.
                    m.Result = new IntPtr(HTCLIENT);
                }
                else
                {
                    // Otherwise, we want to pass mouse events on to the desktop,
                    // as if we were not even here.
                    m.Result = new IntPtr(HTTRANSPARENT);
                }
                return;  // bail out because we've handled the message
            }

            // Otherwise, call the base class implementation for default processing.
            base.WndProc(ref m);
        }

        public static void DrawALine(int x1, int y1, int x2, int y2, int width, Color clr)
        {
            Point p = new Point();
            int hdcSrc = GetWindowDC(GetDesktopWindow());
            int newcolor = System.Drawing.ColorTranslator.ToWin32(clr);

            int newpen = CreatePen(0, width, newcolor);
            SelectObject(hdcSrc, newpen);
            MoveToEx(hdcSrc, x1, y1, ref p);
            LineTo(hdcSrc, x2, y2);
            DeleteDC(hdcSrc);
            DeleteObject(newpen);

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
            //g.Clear(Color.White);
            //e.Graphics.Clear(Color.White);
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
             IntPtr desktopPtr = GetDC(IntPtr.Zero);
             Graphics g = Graphics.FromHdc(desktopPtr);

             SolidBrush b = new SolidBrush(Color.Red);
             g.FillRectangle(b, new Rectangle(px, py, 10,10));

             g.Dispose();
             ReleaseDC(IntPtr.Zero, desktopPtr);


            // temp
            int x = Cursor.Position.X;
            int y = Cursor.Position.Y;

            POINT lpPoint;
            GetCursorPos(out lpPoint);
            // NOTE: If you need error handling
            // bool success = GetCursorPos(out lpPoint);
            // if (!success)

            lblFooter.Text = "Mouse Move at : " + lpPoint.X.ToString() + ", " + lpPoint.Y.ToString();


            DrawALine(px, py, x, y, 5, Color.Yellow);
            px = x;
            py = y;
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
                //this.Width = 66;
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
            if (Convert.ToBoolean(GetAsyncKeyState(Keys.Left)))
            {
                this.Text = "Left Button";
            }
            else
            {
                this.Text = "Other Button";
            }
        }
    }
}

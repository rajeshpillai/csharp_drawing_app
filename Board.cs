﻿using MyPaint_CSharp.Shapes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPaint_CSharp
{
    public partial class Board : Form
    {
        string shape = "ellipse";
        bool startPaint = false;
        int x = 0;
        int y = 0;
        int ex = 0;
        int ey = 0;

        List<Shape> shapes = new List<Shape>();

        Shape currentShape = new Ellipse();
        Color fgColor = Color.Black;


        public Board()
        {
            InitializeComponent();
            //this.DoubleBuffered = true;   // This works only when drawing on form
            //this.SetStyle(ControlStyles.ResizeRedraw, true);

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
            lblFooter.Text = "Mouse Move at : " + e.X.ToString() + ", " + e.Y.ToString();

            if (startPaint && shape != "")
            {
                ex = e.X;
                ey = e.Y;

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
            e.Graphics.Clear(Color.White);
            
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
            colorDlg.AllowFullOpen = false;
            colorDlg.AnyColor = true;
            colorDlg.SolidColorOnly = false;
            colorDlg.Color = Color.Red;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {

                fgColor = colorDlg.Color;
            }
        }
    }
}

using MyPaint_CSharp.Shapes;

namespace MyPaint_CSharp
{
    partial class Board
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Board));
            this.lblFooter = new System.Windows.Forms.Label();
            this.toolBox = new System.Windows.Forms.ToolStrip();
            this.btnMakeTop = new System.Windows.Forms.ToolStripButton();
            this.btnColorDialog = new System.Windows.Forms.ToolStripButton();
            this.btnPencil = new System.Windows.Forms.ToolStripButton();
            this.btnLine = new System.Windows.Forms.ToolStripButton();
            this.btnBox = new System.Windows.Forms.ToolStripButton();
            this.btnEllipse = new System.Windows.Forms.ToolStripButton();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.canvas = new MyPaint_CSharp.Shapes.MyPanel();
            this.toolBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFooter
            // 
            this.lblFooter.BackColor = System.Drawing.Color.Black;
            this.lblFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblFooter.ForeColor = System.Drawing.Color.White;
            this.lblFooter.Location = new System.Drawing.Point(0, 459);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(816, 23);
            this.lblFooter.TabIndex = 2;
            // 
            // toolBox
            // 
            this.toolBox.AutoSize = false;
            this.toolBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMakeTop,
            this.btnColorDialog,
            this.btnPencil,
            this.btnLine,
            this.btnBox,
            this.btnEllipse,
            this.btnExit});
            this.toolBox.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolBox.Location = new System.Drawing.Point(0, 0);
            this.toolBox.Name = "toolBox";
            this.toolBox.Size = new System.Drawing.Size(66, 459);
            this.toolBox.TabIndex = 3;
            this.toolBox.Text = "toolStrip1";
            // 
            // btnMakeTop
            // 
            this.btnMakeTop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnMakeTop.Image = ((System.Drawing.Image)(resources.GetObject("btnMakeTop.Image")));
            this.btnMakeTop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMakeTop.Name = "btnMakeTop";
            this.btnMakeTop.Size = new System.Drawing.Size(64, 19);
            this.btnMakeTop.Text = "Capture";
            this.btnMakeTop.Click += new System.EventHandler(this.btnMakeTop_Click);
            // 
            // btnColorDialog
            // 
            this.btnColorDialog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnColorDialog.Image = ((System.Drawing.Image)(resources.GetObject("btnColorDialog.Image")));
            this.btnColorDialog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnColorDialog.Name = "btnColorDialog";
            this.btnColorDialog.Size = new System.Drawing.Size(64, 19);
            this.btnColorDialog.Text = "Color";
            this.btnColorDialog.Click += new System.EventHandler(this.btnColorDialog_Click);
            // 
            // btnPencil
            // 
            this.btnPencil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPencil.Image = ((System.Drawing.Image)(resources.GetObject("btnPencil.Image")));
            this.btnPencil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPencil.Name = "btnPencil";
            this.btnPencil.Size = new System.Drawing.Size(64, 19);
            this.btnPencil.Text = "Pencil";
            this.btnPencil.Click += new System.EventHandler(this.btnPencil_Click);
            // 
            // btnLine
            // 
            this.btnLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnLine.Image = ((System.Drawing.Image)(resources.GetObject("btnLine.Image")));
            this.btnLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(64, 19);
            this.btnLine.Text = "Line";
            this.btnLine.Click += new System.EventHandler(this.btnPen_Click);
            // 
            // btnBox
            // 
            this.btnBox.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBox.Name = "btnBox";
            this.btnBox.Size = new System.Drawing.Size(64, 19);
            this.btnBox.Text = "Box";
            this.btnBox.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnBox.Click += new System.EventHandler(this.btnBox_Click);
            // 
            // btnEllipse
            // 
            this.btnEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEllipse.Image = ((System.Drawing.Image)(resources.GetObject("btnEllipse.Image")));
            this.btnEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEllipse.Name = "btnEllipse";
            this.btnEllipse.Size = new System.Drawing.Size(64, 19);
            this.btnEllipse.Text = "Ellipse";
            this.btnEllipse.Click += new System.EventHandler(this.btnEllipse_Click);
            // 
            // btnExit
            // 
            this.btnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(64, 19);
            this.btnExit.Text = "E&xit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // canvas
            // 
            this.canvas.AutoScroll = true;
            this.canvas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 0);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(816, 482);
            this.canvas.TabIndex = 0;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 482);
            this.Controls.Add(this.toolBox);
            this.Controls.Add(this.lblFooter);
            this.Controls.Add(this.canvas);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Board";
            this.Text = "MyPaint";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Board_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Board_FormClosed);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Board_Paint);
            this.Resize += new System.EventHandler(this.frmMyPaint_Resize);
            this.toolBox.ResumeLayout(false);
            this.toolBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.ToolStrip toolBox;
        private System.Windows.Forms.ToolStripButton btnBox;
        private System.Windows.Forms.ToolStripButton btnEllipse;
        private System.Windows.Forms.ToolStripButton btnLine;
        private System.Windows.Forms.ToolStripButton btnPencil;
        private MyPanel canvas;
        private System.Windows.Forms.ToolStripButton btnColorDialog;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripButton btnMakeTop;
        private System.Windows.Forms.Timer timer;
    }
}


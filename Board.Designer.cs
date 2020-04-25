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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Board));
            this.canvas = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.toolBox = new System.Windows.Forms.ToolStrip();
            this.btnBox = new System.Windows.Forms.ToolStripButton();
            this.btnEllipse = new System.Windows.Forms.ToolStripButton();
            this.toolBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.AutoScroll = true;
            this.canvas.AutoScrollMinSize = new System.Drawing.Size(0, 447);
            this.canvas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.btnBox,
            this.btnEllipse});
            this.toolBox.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolBox.Location = new System.Drawing.Point(0, 0);
            this.toolBox.Name = "toolBox";
            this.toolBox.Size = new System.Drawing.Size(66, 459);
            this.toolBox.TabIndex = 3;
            this.toolBox.Text = "toolStrip1";
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
            // Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 482);
            this.Controls.Add(this.toolBox);
            this.Controls.Add(this.lblFooter);
            this.Controls.Add(this.canvas);
            this.Name = "Board";
            this.Text = "MyPaint";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.frmMyPaint_Resize);
            this.toolBox.ResumeLayout(false);
            this.toolBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.ToolStrip toolBox;
        private System.Windows.Forms.ToolStripButton btnBox;
        private System.Windows.Forms.ToolStripButton btnEllipse;
    }
}


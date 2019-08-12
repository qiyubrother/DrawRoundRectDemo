using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawRoundRectDemo
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            ControlBox = false;
            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            TopMost = true;
            Text = string.Empty;
            //Opacity = 50;
            BackColor = Color.Black;
            TransparencyKey = System.Drawing.Color.Black;
            StartPosition = FormStartPosition.CenterScreen;
            btnCancel.Click += (o, ex) => Close();
        }

        private void Draw(Rectangle rectangle, Graphics g, int _radius)
        {
            //g.DrawPath(new Pen(Color.Blue), DrawRoundRect(rectangle.X, rectangle.Y, rectangle.Width - 2, rectangle.Height - 1, _radius));
            g.FillPath(new SolidBrush(Color.FromArgb(255, 245, 246, 251)), DrawRoundRect(rectangle.X, rectangle.Y, rectangle.Width - 2, rectangle.Height - 1, _radius));
        }
        public static GraphicsPath DrawRoundRect(int x, int y, int width, int height, int radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(x, y, radius, radius, 180, 90);
            gp.AddArc(width - radius, y, radius, radius, 270, 90);
            gp.AddArc(width - radius, height - radius, radius, radius, 0, 90);
            gp.AddArc(x, height - radius, radius, radius, 90, 90);
            gp.CloseAllFigures();
            return gp;
        }
        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;  //图片柔顺模式选择
            Draw(e.ClipRectangle, e.Graphics, 50);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            pnlMain.Invalidate();
        }
    }
}

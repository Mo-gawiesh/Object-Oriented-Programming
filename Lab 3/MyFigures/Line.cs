using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFigures
{
    public class Line: Figure
    {
        private int x1, y1;
        public Line(int x, int y, int x1, int y1)
        {
            if (x > pictureBox.Width || x < 0 || y > pictureBox.Height || y < 0 || x1 > pictureBox.Width || x1 < 0 || y1 > pictureBox.Height || y1 < 0)
            {
                MessageBox.Show("Точки должны помещаться на холст!");
            }
            else 
            {
                this.x = x;
                this.y = y;
                this.x1 = x1;
                this.y1 = y1;
            }
        }

        public override void Draw()
        {
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawLine(pen, x, y, x1, y1);
            pictureBox.Image = bitmap;
        }
    }
}

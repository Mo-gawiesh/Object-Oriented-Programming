using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFigures
{
    public class Robot : Figure
    {
        private Rectangle Body { get; set; }
        private Ellipse Head { get; set; }
        private Ellipse Left_eye { get; set; }
        private Ellipse Right_eye { get; set; }
        private Line Mouth { get; set; }
        private Line Left_hand { get; set; }
        private Line Right_hand { get; set; }
        private Line Left_leg { get; set; }
        private Line Right_leg { get; set; }
        private Line Left_antenn { get; set; }
        private Line Right_antenn { get; set; }
        static private int count = 0;

        public Robot() { }
        public Robot(int x, int y, int width, int height)
        {
            if (x < 0 || y < 0 || x + width > pictureBox.Width || y + height > pictureBox.Height)
            {
                MessageBox.Show("Фигура должна полностью помещаться на холст!");
            }
            else
            {
                this.x = x; this.y = y; this.width = width; this.height = width;
                Create_all();
                FList.RobotsList.Add(this);
                FList.figureList.Add(this);
                number = count;
                count++;
            }
        }

        private void Create_body()
        {
            Body = new Rectangle(x + width * 2/7, y + height * 3/10, width * 3/7, height * 1/2, false);
        }
        private void Create_head()
        {
            Head = new Ellipse(x + width * 13/35, y + height / 10, width * 9/35, height * 2/10, false);
        }
        private void Create_left_eye()
        {
            Left_eye = new Ellipse(x + width * 29 / 70, y + height / 6, width * 2/35, height * 1/25, false);
        }
        private void Create_right_eye()
        {
            Right_eye = new Ellipse(x + width * 37 / 70, y + height / 6, width * 2 / 35, height * 1 / 25, false);
        }
        private void  Create_mouth()
        {
            Mouth = new Line(x + width * 31 / 70, y + height / 4, x + width * 39 / 70, y + height / 4);
        }
        private void Create_left_hand()
        {
            Left_hand = new Line(x, y + height * 4/ 10, x + width * 2/7, y + height * 4/10);
        }
        private void Create_right_hand()
        {
            Right_hand = new Line(x + width * 5/7, y + height * 4 / 10, x + width, y + height * 4 / 10);
        }
        private void Create_left_leg()
        {
            Left_leg = new Line(x + width * 13 / 35, y + height * 8/10, x + width * 13 / 35, y + height);
        }
        private void Create_right_leg()
        {
            Right_leg = new Line(x + width * 22 / 35, y + height * 8 / 10, x + width * 22 / 35, y + height);
        }
        private void Create_left_antenn()
        {
            Left_antenn = new Line(x + width * 61 / 140, y, x + width * 61 / 140, Convert.ToInt32(y + height / 10 + height * (1-Math.Sqrt(3)/2)/10));
        }
        private void Create_right_antenn()
        {
            Right_antenn = new Line(x + width * 79 / 140, y, x + width * 79 / 140, Convert.ToInt32(y + height / 10 + height * (1 - Math.Sqrt(3) / 2) / 10));
        }

        private void Create_all()
        {
            Create_body();
            Create_head();
            Create_left_eye();
            Create_right_eye();
            Create_mouth();
            Create_left_hand();
            Create_right_hand();
            Create_left_leg();
            Create_right_leg();
            Create_left_antenn();
            Create_right_antenn();
        }
        public override void Draw()
        {
            Body.Draw(false);
            Head.Draw(false);
            Left_eye.Draw(false);
            Right_eye.Draw(false);
            Mouth.Draw();
            Left_hand.Draw();
            Right_hand.Draw();
            Left_leg.Draw();
            Right_leg.Draw();
            Left_antenn.Draw();
            Right_antenn.Draw();
            DrawText("Robot ", number, x + width * 2 / 7, y + height * 3 / 10, width * 3 / 7, height * 1 / 2);
        }
        public override void MoveTo(int dx, int dy)
        {
            if (x + dx < 0 || y + dy < 0 || x + dx + width > pictureBox.Width || y + dy + height > pictureBox.Height)
            {
                MessageBox.Show("Фигура должна полностью помещаться на холст!");
            }
            else
            {
                x += dx; y += dy;
                Create_all();
                DeleteF(this, false);
                Draw();
            }
        }

        public void ResizeRobot(int width, int height)
        {
            if (x < 0 || y < 0 || x > pictureBox.Width || y > pictureBox.Height)
            {
                MessageBox.Show("Фигура должна полностью помещаться на холст!");
            }
            else
            {
                this.width = width; this.height = height;
                Create_all();
                DeleteF(this, false);
                Draw();
            }

        }
    }
}

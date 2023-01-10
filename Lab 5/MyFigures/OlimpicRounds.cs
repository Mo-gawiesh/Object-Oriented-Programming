using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFigures
{
    public class OlimpicRounds : Figure
    {
        private Round round_1 { get; set; }
        private Round round_2 { get; set; }
        private Round round_3 { get; set; }
        private Round round_4 { get; set; }
        private Round round_5 { get; set; }
        private int radius { get; set; }
        private int space { get; set; }
        private static int count = 0;
        public OlimpicRounds() { }
        public OlimpicRounds(int x, int y, int width)
        {
            if (x < 0 || y < 0 || x + width > pictureBox.Width || y + width * 7/15 > pictureBox.Height)
            {
                MessageBox.Show("Фигура должна полностью помещаться на холст!");
            }
            else
            {
                this.x = x; this.y = y; this.width = width; height = width * 7 / 15;
                radius = width * 3 / 20;
                space = width / 30;
                Create_all();
                FList.OlimpicRoundsList.Add(this);
                FList.figureList.Add(this);
                number = count;
                count++;
            }
        }
        private void Create_round_1()
        {
            round_1 = new Round(x, y, radius, false);
        }
        private void Create_round_2()
        {
            round_2 = new Round(x + radius * 2 + space, y, radius, false);
        }
        private void Create_round_3()
        {
            round_3 = new Round(x + radius * 4 + space * 2, y, radius, false);
        }
        private void Create_round_4()
        {
            round_4 = new Round(x + radius * 11 / 10, y + radius + space / 2, radius, false);
        }
        private void Create_round_5()
        {
            round_5 = new Round(x + radius * 33 / 10 + space, y + radius + space / 2, radius, false);
        }
        private void Create_all()
        {
            Create_round_1();
            Create_round_2();
            Create_round_3();
            Create_round_4();
            Create_round_5();

        }
        public override void Draw()
        {
            round_1.Draw(Color.Blue);
            round_2.Draw(Color.Black);
            round_3.Draw(Color.Red);
            round_4.Draw(Color.Yellow);
            round_5.Draw(Color.Green);
            round_2.DrawText("", number, x + radius * 2 + space, y, radius*2, radius*2);
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

        public void ResizeOlimpicRounds(int width, int height)
        {
            if (x + width > pictureBox.Width || y + height > pictureBox.Height)
            {
                MessageBox.Show("Фигура должна полностью помещаться на холст!");
            }
            else
            {
                this.width = width; this.height = height;
                radius = width * 3 / 20;
                space = width / 30;
                Create_all();
                DeleteF(this, false);
                Draw();
            }

        }
    }
}

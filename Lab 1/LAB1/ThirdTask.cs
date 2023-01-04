using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB1
{
    public partial class ThirdTask : Form
    {
        public ThirdTask()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string aStr = textBox1.Text;
            string bStr = textBox2.Text;
            string cStr = textBox3.Text;

            try
            {
                double a = double.Parse(aStr);
                double b = double.Parse(bStr);
                double c = double.Parse(cStr);
                double d = b * b - 4 * a * c;
                if (d < 0)
                {
                    MessageBox.Show("Дискриминант меньше нуля. Корней нет.");
                }
                if (d == 0)
                {
                    double x = (-b / (2 * a));
                    MessageBox.Show("Дискриминант равен нулю. Корень равен " + x + ".");
                }
                if (d > 0)
                {
                    double x1 = ((-b - Math.Sqrt(d)) / (2 * a));
                    double x2 = ((-b + Math.Sqrt(d)) / (2 * a));
                    MessageBox.Show("Дискриминант равен " + d + ". Первый корень равен " + x1 + ". Второй корень равен " + x2 + ".");
                }
            }
            catch
            {
                MessageBox.Show("Пожалуйста, введите только действительные числа!");
            }
        }
    }
}

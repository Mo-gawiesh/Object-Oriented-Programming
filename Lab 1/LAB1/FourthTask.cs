using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB1
{

    public partial class FourthTask : Form
    {
        public FourthTask()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string xStr = textBox1.Text;
            string yStr = textBox2.Text;
            string zStr = textBox3.Text;

            try
            {
                double x = double.Parse(xStr);
                double y = double.Parse(yStr);
                double z = double.Parse(zStr);
                double l = 2 * Math.Max(x, z) - 3 * Math.Min(Math.Min(x, y), z);
                MessageBox.Show("Ответ: " + l);
            }
            catch
            {
                MessageBox.Show("Пожалуйста, введите только действительные числа!");
            }
        }
    }
}

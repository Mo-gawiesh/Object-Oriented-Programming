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
    public partial class FirstTask : Form
    {
        public FirstTask()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox1.Text, out var check)
                | !double.TryParse(textBox2.Text, out check))
            {
                MessageBox.Show("Вводите действительные числа!");
            }
            else
            {
                double a = double.Parse(textBox1.Text);
                double b = double.Parse(textBox2.Text);
                if (a <= b)
                {
                    textBox3.Text = "0";
                    textBox4.Text = textBox2.Text;
                }
                else
                {
                    textBox3.Text = textBox1.Text;
                    textBox4.Text = textBox2.Text;
                }
            }
        }
    }
}

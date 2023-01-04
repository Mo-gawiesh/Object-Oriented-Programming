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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                this.Hide();
                FirstTask firstTask = new FirstTask();
                firstTask.Show();
            } else if (radioButton2.Checked)
            {
                this.Hide();
                SecondTask secondTask = new SecondTask();
                secondTask.Show();
            } else if (radioButton4.Checked)
            {
                this.Hide();
                ThirdTask thirdTask = new ThirdTask();
                thirdTask.Show();
            } else if (radioButton5.Checked)
            {
                this.Hide();
                FourthTask fourthTask = new FourthTask();
                fourthTask.Show();
            } else
            {
                this.Hide();
                FifthTask fifthTask = new FifthTask();
                fifthTask.Show();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class FifthTask : Form
    {
        public FifthTask()
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
            dataGridView1.RowCount = 11;
            dataGridView1.ColumnCount = 11;

            dataGridView1.TopLeftHeaderCell.Value = "Матрица";
            Random rnd = new Random();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = rnd.Next(1, 99);
                    dataGridView1.Columns[j].Width = 25;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count <= 0 && dataGridView1.Columns.Count <= 0)
            {
                MessageBox.Show("Пожалуйста, заполните матрицу нажатием кнопки 'Заполнить матрицу'!");
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    int numOfMainDiag = (int)dataGridView1.Rows[i].Cells[i].Value;
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (i != j)
                        {
                            if ((int)dataGridView1.Rows[i].Cells[j].Value > numOfMainDiag)
                            {
                                dataGridView1.Rows[i].Cells[j].Value = 1;
                            }
                            else
                            {
                                dataGridView1.Rows[i].Cells[j].Value = 0;
                            }
                        }
                    }
                }
            }
        }
    }
}

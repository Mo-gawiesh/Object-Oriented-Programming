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

namespace LAB1
{
    public partial class SecondTask : Form
    {
        private List<List<int>> matrix;
        private List<List<int>> result;
        public SecondTask()
        {
            InitializeComponent();
            this.matrix = new List<List<int>>();
            this.result = new List<List<int>>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            // Проверка, что таблица существует
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Создайте таблицу!");
                return;
            }
            // Проверка на отсутствие пустых ячеек
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null)
                    {
                        MessageBox.Show("Заполните ячейки!");
                        return;
                    }
                }
            }
            if (matrix.Count != 0)
            {
                matrix.Clear();
            }
            if (result.Count != 0)
            {
                result.Clear();
            }
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                List<int> row = new List<int>();
                matrix.Add(row);
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    matrix[i].Add(Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value));
                }
            }
            for (int i = 0; i < matrix.Count; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    row.Add(0);
                }
                result.Add(row);
            }
            int count, check;

            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    count = 0;
                    check = 0;
                    for (int di = -1; di <= 1; di++)
                    {
                        {
                            for (int dj = -1; dj <= 1; dj++)
                            {
                                if (((i + di) >= 0) && ((i + di) < matrix.Count) && ((j + dj) >= 0) && ((j + dj) < matrix[i].Count))
                                {
                                    count++;
                                    if (matrix[i][j] > matrix[i + di][j + dj])
                                    {
                                        check++;
                                    }
                                }
                            }
                        }
                    }
                    if (check == count - 1)
                    {
                        result[i][j] = 1;
                    }
                }
            }
            SecondTask_1 answer = new SecondTask_1(this.result, button6);
            button6.Enabled = false;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out var check)
                | !int.TryParse(textBox2.Text, out check))
            {
                MessageBox.Show("Вводите целые числа больше 1!");
            }
            else
            {
                if (int.Parse(textBox1.Text) < 2
                    | int.Parse(textBox2.Text) < 2)
                {
                    MessageBox.Show("Вводите целые числа больше 1!");
                }
                else
                {
                    int row_num = int.Parse(textBox1.Text);
                    int col_num = int.Parse(textBox2.Text);
                    if (dataGridView1.Columns.Count < col_num)
                    {
                        for (int i = dataGridView1.Columns.Count; i < col_num; i++)
                        {
                            dataGridView1.Columns.Add($"Column{i + 1}", $"Столбец {i + 1}");
                        }
                    }
                    else if (dataGridView1.Columns.Count > col_num)
                    {
                        for (int i = dataGridView1.Columns.Count; i > col_num; i--)
                        {
                            dataGridView1.Columns.RemoveAt(i - 1);
                        }
                    }
                    dataGridView1.RowCount = row_num;
                }
            }
        }

        private void cell_value_validate(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!int.TryParse(e.FormattedValue.ToString(), out var check))
            {
                MessageBox.Show("Вводите целые числа, а не всякую ерунду!", "Ашипка");
                e.Cancel = true;
            }
        }

    }
}

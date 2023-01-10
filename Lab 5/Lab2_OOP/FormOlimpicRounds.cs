using MyFigures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3_OOP
{
    public partial class FormOlimpicRounds : Form
    {
        private Button but;
        public FormOlimpicRounds(Button but)
        {
            InitializeComponent();
            this.but = but;
            for (int i = 0; i < FList.OlimpicRoundsList.Count; i++)
            {
                figure_box.Items.Add(FList.OlimpicRoundsList[i]);
                figure_box.Items[i] = $"OlimpicRounds{FList.OlimpicRoundsList[i].number}";
            }
            buttonDelete.Enabled = false;
            Button_New_Cords.Enabled = false;
            Button_New_Size.Enabled = false;
        }
        private void FormOlimpicRounds_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            Close();
            but.Enabled = true;
        }

        private void Button_Draw_Click(object sender, EventArgs e)
        {
            if (int.TryParse(setX.Text, out int number) && int.TryParse(setY.Text, out number) &&
                int.TryParse(width.Text, out number) && int.TryParse(height.Text, out number))
            {
                int x = int.Parse(setX.Text);
                int y = int.Parse(setY.Text);
                int width_f = int.Parse(width.Text);
                int height_f = int.Parse(height.Text);
                if (!(width_f < 0 || height_f < 0))
                {
                    if (!(x < 0 || y < 0 || x + width_f > Figure.pictureBox.Width || y + height_f > Figure.pictureBox.Height))
                    {
                        OlimpicRounds OlimpicRound = new OlimpicRounds(x, y, width_f);
                        OlimpicRound.Draw();
                        figure_box.Items.Add(OlimpicRound);
                        figure_box.Items[figure_box.FindStringExact(OlimpicRound.ToString())] = $"OlimpicRound{OlimpicRound.number}";
                    }
                    else
                    {
                        MessageBox.Show("Фигура должна полностью помещаться на холст");
                    }
                }
                else
                {
                    MessageBox.Show("У фигуры должна быть положительная длина и высота");
                }
            }
            else
            {
                MessageBox.Show("Некорректный формат ввода");
            }
        }

        private void Button_New_Cords_Click(object sender, EventArgs e)
        {
            if (FList.OlimpicRoundsList[figure_box.SelectedIndex] != null)
            {
                OlimpicRounds OlimpicRound = FList.OlimpicRoundsList[figure_box.SelectedIndex];
                if (int.TryParse(new_X.Text, out int number) && int.TryParse(new_Y.Text, out number))
                {
                    OlimpicRound.MoveTo(int.Parse(new_X.Text), int.Parse(new_Y.Text));
                }
                else
                {
                    MessageBox.Show("Некорректный формат ввода");
                }
            }
            else
            {
                MessageBox.Show("Выберите существующую фигуру");
            }
        }

        private void figure_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonDelete.Enabled = true;
            Button_New_Cords.Enabled = true;
            Button_New_Size.Enabled = true;
        }

        private void Button_New_Size_Click(object sender, EventArgs e)
        {
            if (int.TryParse(new_height.Text, out int check) && int.TryParse(new_width.Text, out check))
            {
                int height = int.Parse(new_height.Text);
                int width = int.Parse(new_width.Text);
                if (height > 0 && width > 0)
                {
                    OlimpicRounds OlimpicRound = FList.OlimpicRoundsList[figure_box.SelectedIndex];
                    OlimpicRound.ResizeOlimpicRounds(width, height);
                }
                else 
                {
                    MessageBox.Show("Габариты ракеты - положительные числа");
                }
            }
            else
            {
                MessageBox.Show("Ошибка ввода, вводите целые числа");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            OlimpicRounds OlimpicRound = FList.OlimpicRoundsList[figure_box.SelectedIndex];
            FList.OlimpicRoundsList.Remove(OlimpicRound);
            OlimpicRound.DeleteF(OlimpicRound, true);
            figure_box.Items.Clear();
            figure_box.SelectedIndex = -1;
            for (int i = 0; i < FList.OlimpicRoundsList.Count; i++)
            {
                figure_box.Items.Add(FList.OlimpicRoundsList[i]);
                figure_box.Items[i] = $"OlimpicRound{FList.OlimpicRoundsList[i].number}";
            }
            buttonDelete.Enabled = false;
            Button_New_Cords.Enabled = false;
            Button_New_Size.Enabled = false;
        }

        private void width_text_changed(object sender, EventArgs e)
        {
            if (int.TryParse(width.Text, out int number))
            {
                int width_f = int.Parse(width.Text);
                if (width_f > 0)
                {
                    height.Text = $"{Convert.ToInt32(width_f * 7/15)}";
                }
                else
                {
                    MessageBox.Show("У фигуры должна быть положительная длина и высота");
                }
            }
            else
            {
                MessageBox.Show("Некорректный формат ввода");
            }
        }
        private void new_width_text_changed(object sender, EventArgs e)
        {
            if (int.TryParse(new_width.Text, out int number))
            {
                int new_width_f = int.Parse(new_width.Text);
                if (new_width_f > 0)
                {
                    new_height.Text = $"{Convert.ToInt32(new_width_f * 7 / 15)}";
                }
                else
                {
                    MessageBox.Show("У фигуры должна быть положительная длина и высота");
                }
            }
            else
            {
                MessageBox.Show("Некорректный формат ввода");
            }
        }
    }
}

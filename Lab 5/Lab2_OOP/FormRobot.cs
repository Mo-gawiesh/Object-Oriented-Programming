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
    public partial class FormRobot : Form
    {
        private Button but;
        public FormRobot(Button but)
        {
            InitializeComponent();
            this.but = but;
            for (int i = 0; i < FList.RobotsList.Count; i++)
            {
                figure_box.Items.Add(FList.RobotsList[i]);
                figure_box.Items[i] = $"Robot{FList.RobotsList[i].number}";
            }
            buttonDelete.Enabled = false;
            Button_New_Cords.Enabled = false;
            Button_New_Size.Enabled = false;
        }
        private void FormRobots_MouseDown(object sender, MouseEventArgs e)
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
                        Robot Robot = new Robot(x, y, width_f, height_f);
                        Robot.Draw();
                        figure_box.Items.Add(Robot);
                        figure_box.Items[figure_box.FindStringExact(Robot.ToString())] = $"Robot{Robot.number}";
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
            if (FList.RobotsList[figure_box.SelectedIndex] != null)
            {
                Robot Robot = FList.RobotsList[figure_box.SelectedIndex];
                if (int.TryParse(new_X.Text, out int number) && int.TryParse(new_Y.Text, out number))
                {
                    Robot.MoveTo(int.Parse(new_X.Text), int.Parse(new_Y.Text));
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
                    Robot Robot = FList.RobotsList[figure_box.SelectedIndex];
                    Robot.ResizeRobot(width, height);
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
            Robot Robot = FList.RobotsList[figure_box.SelectedIndex];
            FList.RobotsList.Remove(Robot);
            Robot.DeleteF(Robot, true);
            figure_box.Items.Clear();
            figure_box.SelectedIndex = -1;
            for (int i = 0; i < FList.RobotsList.Count; i++)
            {
                figure_box.Items.Add(FList.RobotsList[i]);
                figure_box.Items[i] = $"Robot{FList.RobotsList[i].number}";
            }
            buttonDelete.Enabled = false;
            Button_New_Cords.Enabled = false;
            Button_New_Size.Enabled = false;
        }
    }
}

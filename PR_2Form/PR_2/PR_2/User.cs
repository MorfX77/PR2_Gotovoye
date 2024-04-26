using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR_11
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }
        List<double> numbers = new List<double>();
        ErrorProvider errorProvider = new ErrorProvider();
        /// <summary>
        /// Нахождение максимального и минимального значения с заменой
        /// </summary>
        public void List()
        {
            int maxIndex = numbers.IndexOf(numbers.Max());
            int  minIndex = numbers.IndexOf(numbers.Min());

            double temp = numbers[0];
            numbers[0] = numbers[maxIndex];
            numbers[maxIndex] = temp;

            temp = numbers[numbers.Count - 1];
            numbers[numbers.Count - 1] = numbers[minIndex];
            numbers[minIndex] = temp;

            // Вывод списка после замены
            string result = String.Join(", ", numbers.Select(n => n.ToString()));
            textBox_Result.Text = result;
        }
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            List();
        }
        private void btn_Close1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private async void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                string number = textBox_List.Text;
                if (!String.IsNullOrEmpty(textBox_List.Text))
                {
                    double number1 = Double.Parse(number);
                    numbers.Add(number1);
                    textBox_List.Clear();
                }
                else
                {
                    errorProvider.SetError(textBox_List, "Поле не должно быть пустым");
                    await Task.Delay(1500); // Задержка в 3 секунды
                    errorProvider.SetError(textBox_List, "");
                }
                // Вывод списка до замены
                string list = String.Join(", ", numbers.Select(n => n.ToString()));
                textBox_ReadyList.Text = list;
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Введено неправильно, вводите по 1 значению. "+ fe.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс... что-то пошло не так "+ ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            numbers.Clear();
            textBox_List.Clear();
            textBox_Result.Clear();
            textBox_ReadyList.Clear();
        }

        private void мToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private async void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List();
        }
    }
}

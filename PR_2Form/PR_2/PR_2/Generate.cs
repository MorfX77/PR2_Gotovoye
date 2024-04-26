using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR_11
{
    public partial class Generate : Form
    {
        public Generate()
        {
            InitializeComponent();
        }
        List<int> numbers = new List<int>();
        /// <summary>
        /// Генерация чисел и вывод их в textbox
        /// </summary>
        public void List()
        {
            numbers.Clear();
            textBox_List.Clear();
            textBox_Result.Clear();
            Random random = new Random();
            for (int i = 0; i < 9; i++)
            {
                numbers.Add(random.Next(1, 100)); // Генерировать случайные числа от 1 до 100
            }
            if (numbers.Count > 0)
            {
                // Вывод исходного списка
                string originalList = string.Join(", ", numbers.Select(n => n.ToString()));
                textBox_List.Text = originalList;

                int maxIndex = numbers.IndexOf(numbers.Max());
                int minIndex = numbers.IndexOf(numbers.Min());

                int temp = numbers[0];
                numbers[0] = numbers[maxIndex];
                numbers[maxIndex] = temp;

                temp = numbers[numbers.Count - 1];
                numbers[numbers.Count - 1] = numbers[minIndex];
                numbers[minIndex] = temp;

                // Вывод списка после замены
                string result = string.Join(", ", numbers.Select(n => n.ToString()));
                textBox_Result.Text = result;
            }
            else MessageBox.Show("Список пуст!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btn_Generate_Click(object sender, EventArgs e)
        {
            List();
        }

        private void расчётToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List();
        }

        private void btn_Close1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            numbers.Clear();
            textBox_List.Clear();
            textBox_Result.Clear();
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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibMas;
using Lib_5;

namespace _13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Дана целочисленная матрица размера M * N. Найти номер первого из ее столбцов," +
                " содержащих только нечетные числа. Если таких столбцов нет, то вывести 0.");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void заполнитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkingWithArray.Fill(table, (Int32)nudMin.Value, (Int32)nudMax.Value);
            textBoxCol.Clear();
        }

        private void сброситьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkingWithArray.Clear(table);
        }

        private void рассчитатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int col;
            Class1.Odd(table, out col);
            textBoxCol.Text = col.ToString();
        }

        private void задатьКоличествоСтрокИСтолбцовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login setting = new Login();
            setting.ShowDialog();

            table.ColumnCount = Data.Cols;
            table.RowCount = Data.Rows;

            nudRow.Value = Data.Rows;
            nudCol.Value = Data.Cols;

            statusStrip1.Items[0].Text = "Количесво строк - " + table.RowCount + ", Количество столбцов - " + table.ColumnCount;
        }

        private void nud1_ValueChanged(object sender, EventArgs e)
        {
            table.CurrentCell = table[0, 0];

            table.RowCount = (Int32)nudRow.Value;

            Data.Rows = table.RowCount;

            statusStrip1.Items[0].Text = "Количесво строк - " + table.RowCount + ", Количество столбцов - " + table.ColumnCount;
        }

        private void nud2_ValueChanged(object sender, EventArgs e)
        {
            table.CurrentCell = table[0, 0];

            table.ColumnCount = (Int32)nudCol.Value;

            Data.Cols = table.ColumnCount;

            statusStrip1.Items[0].Text = "Количесво строк - " + table.RowCount + ", Количество столбцов - " + table.ColumnCount;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog(this);

            Data.Open();
            table.ColumnCount = Data.Cols;
            table.RowCount = Data.Rows;

            nudRow.Value = Data.Rows;
            nudCol.Value = Data.Cols;

            statusStrip1.Items[0].Text = "Количесво строк - " + table.RowCount + ", Количество столбцов - " + table.ColumnCount;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkingWithArray.OpenFile(table);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkingWithArray.SaveFile(table);
        }

        private void table_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            statusStrip1.Items[1].Text = $"Текущая ячейка [{table.CurrentCell.RowIndex},{table.CurrentCell.ColumnIndex}]";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Data.Save();
            if (MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButtons.YesNo) == DialogResult.No) e.Cancel = true;
        }
    }
}

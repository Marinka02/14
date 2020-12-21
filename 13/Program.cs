using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    public class Data
    {
        public static int Rows;
        public static int Cols;
        public static void Save()
        {
            StreamWriter file = new StreamWriter("config.ini");
            file.WriteLine(Cols);
            file.WriteLine(Rows);
            file.Close();
        }
        public static void Open()
        {
            try
            {
                StreamReader file = new StreamReader("config.ini");
                int col = Convert.ToInt32(file.ReadLine());
                int row = Convert.ToInt32(file.ReadLine());
                Cols = col;
                Rows = row;
                file.Close();
            }
            // есшли файл конфигурации отсутствует
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("Файл конфигурации не найден! Количество столбцов и строк будет присвоено по умолчанию (5).");
                Rows = 5;
                Cols = 5;
            }
        }
    }
}

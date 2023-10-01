using CSCS2_Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerApp
{
    internal static class Program
    {
        /// <summary>
        /// Головна точка входу для програми.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Увімкнення візуальних стилів для додатка.
            Application.EnableVisualStyles();

            // Встановлення сумісності з текстовим відображенням.
            Application.SetCompatibleTextRenderingDefault(false);

            // Запуск головного вікна програми, яке представлене об'єктом класу Form1.
            Application.Run(new Form1());
        }
    }
}

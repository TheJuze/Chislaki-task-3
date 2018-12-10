using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3
{
    static class Program
    {
        public static double a = -1.0;//левая, правая границы
        public static double b = 1.0;//левая, правая границы
        public static int N = 5;//число узлов
        public static double step = (Math.Abs(a) + Math.Abs(b)) / (N - 1); //шаг

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using System.Xml.Serialization;

namespace Task3
{
    class Polynom
    {
        public static double Method1(double x,double[] X)//метод наименьших квадратов
        {
            double[] a=new double[4];
            a=Kramer(X);
            return a[0] * x * x * x + a[1] * x * x + a[2] * x + a[3];
        }
        //Далее метод Крамера
        static double[] Kramer(double[] X)//определитель системы, надо проверить на единственность решения
        {
            double[] coef=new double[4];
            double delta = Matrix.FindDet(-1,X);
            if ( delta== 0)
            {
                Console.WriteLine("СИСТЕМА ИМЕЕТ НЕЕДИНСТВЕННОЕ РЕШЕНИЕ");
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    coef[i] = Matrix.FindDet(i,X);
                }
            }
            return coef;
        }
    }
}

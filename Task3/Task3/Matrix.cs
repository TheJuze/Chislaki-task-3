using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Matrix
    {
        public static double[,] matrix=new double[4,4];// A- матрица левой части уравнения
        public static double[] column=new double[4];//b- матрица правой части
        public double Det;

        public static void fill()//обнулить матрицу
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    matrix[i, j] = 0;
                }
                column[i] = 0;
            }
        }
        public static void fullFill(double[] X)//конструктор
        {
            fill();
            //заполнить ячейки
            for (int i = 0; i < Program.N; i++)
            {
                matrix[0, 0] += Math.Pow(X[i], 6);
                matrix[0, 1] += Math.Pow(X[i], 5);
                matrix[0, 2] += Math.Pow(X[i], 4);
                matrix[0, 3] += Math.Pow(X[i], 3);
                matrix[1, 3] += Math.Pow(X[i], 2);
                matrix[2, 3] += X[i];
                double Xi = Equation.getFunctionValue(X[i]);
                column[0] += Math.Pow(X[i], 3) *Xi ;
                column[1] += Math.Pow(X[i], 2) * Xi;
                column[2] += X[i] * Xi;
                column[3] +=Xi;
            }
            matrix[1, 0] = matrix[0, 1];
            matrix[2, 0] = matrix[0, 2];
            matrix[1, 1] = matrix[2, 0];
            matrix[3, 0] = matrix[0, 3];
            matrix[2, 1] = matrix[3, 0];
            matrix[1, 2] = matrix[3, 0];
            matrix[2, 2] = matrix[1, 3];
            matrix[3, 1] = matrix[1, 3];
            matrix[3, 2] = matrix[2, 3];
            matrix[3, 3] = Program.N;
            //#
        }

        public static double FindDet(int c, double[] X)// |Определитель Крамера|
        {
            fullFill(X);
            double[,] temp = new double[4, 4];
            for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
            {
                    temp[i, j] = matrix[i, j];
            }
            if (c!=-1)//подстановка нужного столбца
            {
                for (int i = 0; i < 4; i++)
                {
                    temp[i, c] = column[i];
                }
            }
            return det(temp);
        }

        public static double det(double[,] A)//|a| 4x4
        {

            return A[0, 0] * (A[1, 1] * (A[2, 2] * A[3, 3] - A[2, 3] * A[3, 2]) -
                              A[1, 2] * (A[2, 1] * A[3, 3] - A[2, 3] * A[3, 1]) +
                              A[1, 3] * (A[2, 1] * A[3, 2] - A[2, 2] * A[3, 1])) -
                   A[0, 1] * (A[1, 0] * (A[2, 2] * A[3, 3] - A[2, 3] * A[3, 2]) -
                              A[1, 2] * (A[2, 0] * A[3, 3] - A[2, 3] * A[3, 0]) +
                              A[1, 3] * (A[2, 0] * A[3, 2] - A[2, 2] * A[3, 0])) +
                   A[0, 2] * (A[1, 0] * (A[2, 1] * A[3, 3] - A[2, 3] * A[3, 1]) -
                              A[1, 1] * (A[2, 0] * A[3, 3] - A[2, 3] * A[3, 0]) +
                              A[1, 3] * (A[2, 0] * A[3, 1] - A[2, 1] * A[3, 0])) -
                   A[0, 3] * (A[1, 0] * (A[2, 1] * A[3, 2] - A[2, 2] * A[3, 1]) -
                              A[1, 1] * (A[2, 0] * A[3, 2] - A[2, 2] * A[3, 0]) +
                              A[1, 2] * (A[2, 0] * A[3, 1] - A[2, 1] * A[3, 0]));
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace Task3
{
    public partial class Form1 : Form
    {
        //cоздаем график
        private Chart myChart = new Chart();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //берем равноудаленные узлы
            double[] X = new double[Program.N];
            X[0] = -1;
            X[1] = -0.5;
            X[2] = 0.1;
            X[3] = 0.5;
            X[4] = 1;

            //кладем его на форму и растягиваем на все окно.
            myChart.Parent = this;
            myChart.Dock = DockStyle.Fill;
            //добавляем в Chart область для рисования графиков, их может быть
            //много, поэтому даем ей имя.
            myChart.ChartAreas.Add(new ChartArea("Math functions"));
            //Создаем и настраиваем набор точек для рисования графика, в том
            //не забыв указать имя области на которой хотим отобразить этот
            //набор точек.
            Series mySeriesOfPoint = new Series("Function");
            mySeriesOfPoint.ChartType = SeriesChartType.Line;
            mySeriesOfPoint.ChartArea = "Math functions";
            //
            Series newSeries= new Series("Square method");
            newSeries.ChartType = SeriesChartType.Line;
            newSeries.ChartArea = "Math functions";
            //
            for (double x = Program.a; x <= Program.b; x += 0.0001)
            {
                mySeriesOfPoint.Points.AddXY(x, Equation.getFunctionValue(x));
                newSeries.Points.AddXY(x, Polynom.Method1(x, X));
            }
            //Добавляем созданный набор точек в Chart
            myChart.Series.Add(mySeriesOfPoint);
            myChart.Series.Add(newSeries);
        }
    }
}

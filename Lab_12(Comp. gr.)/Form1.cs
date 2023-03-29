using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Lab_12_Comp.gr._
{
    public partial class Form1 : Form
    {
        int MAX = 40; int N = 10;
        Graphics dc; Pen p;
        double[] x, y;
        
        double xmin, xmax, ymin, ymax;
        double Xmin, Xmax, Ymin, Ymax;
        double fx, fy, f, XC, YC, c1, c2;

        double eps = 0.04, X, Y, t, xA, xB, xC, xD, yA, yB, yC,
        yD, a0, a1, a2, a3, b0, b1, b2, b3;
        int n, i, j, first;
        
        public Form1()
        {
            InitializeComponent();
            Form2 form2 = new Form2();
            form2.Show();

            Xmin = 0.2; Xmax = 8.2; Ymin = 0.5; Ymax = 6.5;
            dc = pictureBox.CreateGraphics();
            p = new Pen(Brushes.Black, 1);
            x = new double[MAX]; y = new double[MAX];
        }

        /* Метод преобразования вещественной координаты X в целую */
        private int IX(double x)
        {
            double xx = x * (pictureBox.Size.Width / 10.0) + 0.5;
            return (int)xx;
        }

        /* Метод преобразования вещественной координаты Y в целую */
        private int IY(double y)
        {
            double yy = pictureBox.Size.Height - y *
            (pictureBox.Size.Height / 7.0) + 0.5;
            return (int)yy;
        }
        /* Функция вычерчивания линии (область вывода 10х7 усл.ед.*/
        private void Draw(double x1, double y1, double x2, double y2)
        {
            Point point1 = new Point(IX(x1), IY(y1));
            Point point2 = new Point(IX(x2), IY(y2));
            dc.DrawLine(p, point1, point2);
        }
        /* Функция генерации B-сплайна */
        private void curv_Fit()
        {
            double Xold = 0, Yold = 0;
            /* Заданные точки отмечаются маркером */
            for (i = 1; i < n; i++)
            {
                X = f*x[i]+c1; Y = f*y[i]+c2;
                Draw(X - eps, Y - eps, X + eps, Y + eps);
                Draw(X + eps, Y - eps, X - eps, Y + eps);
            }
            /* Отрисовка B-сплайна */
            first = 1;
            for (i = 1; i < n - 1; i++)
            { /* Вычисление коэффициентов */
                xA = x[i - 1]; xB = x[i]; xC = x[i + 1]; xD = x[i + 2];
                yA = y[i - 1]; yB = y[i]; yC = y[i + 1]; yD = y[i + 2];
                a3 = (-xA + 3 * (xB - xC) + xD) / 6.0;
                b3 = (-yA + 3 * (yB - yC) + yD) / 6.0;
                a2 = (xA - 2 * xB + xC) / 2.0;
                b2 = (yA - 2 * yB + yC) / 2.0;
                a1 = (xC - xA) / 2.0;
                b1 = (yC - yA) / 2.0;
                a0 = (xA + 4 * xB + xC) / 6.0;
                b0 = (yA + 4 * yB + yC) / 6.0;
                /* Отрисовка сегмента дуги */
            for (j = 0; j <= N; j++)
                {
                    t = (double)j / (double)N;
                    X = f*(((a3 * t + a2) * t + a1) * t + a0) + c1;
                    Y = f*(((b3 * t + b2) * t + b1) * t + b0) + c2;
                    if (first == 1) { first = 0; }
                    else Draw(Xold, Yold, X, Y);
                    Xold = X; Yold = Y;
                }
            }
        }
        /* Функция чтения количества и координат точек из файла
        Curv.dat */
        private void read_File()
        {
            StreamReader reader = new StreamReader("Curv.dat");
            
            n = Convert.ToInt32(reader.ReadLine()) - 1;
            /* Чтение координат точек точек*/
            for (i = 0; i <= n; i++)
            {
                string[] xy = reader.ReadLine().Split(' ');
                x[i] = Convert.ToDouble(xy[0]);
                y[i] = Convert.ToDouble(xy[1]);
           
                if (x[i] < xmin) xmin = x[i];
                if (x[i] > xmax) xmax = x[i];
                if (y[i] < ymin) ymin = y[i];
                if (y[i] > ymax) ymax = y[i];
            }

            reader.Close();
            /* Получение коэффициентов формулы перевода мировых
            координат в экранные */
            fx = (Xmax - Xmin) / (xmax - xmin);
            fy = (Ymax - Ymin) / (ymax - ymin);
            f = (fx < fy ? fx : fy);
            xC = 0.5 * (xmin + xmax); yC = 0.5 * (ymin + ymax);
            XC = 0.5 * (Xmin + Xmax); YC = 0.5 * (Ymin + Ymax);
            c1 = XC - f * xC; 
            c2 = YC - f * yC;
        }

        private void buttonGen_Click(object sender, EventArgs e)
        {
            /* Вызов функции чтения данных из файла Curv.dat */
            read_File();
            /* Вызов функции отрисовки B-сплайна */
            curv_Fit();
        }
    }
}

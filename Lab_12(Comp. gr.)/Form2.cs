using System;
using System.IO;
using System.Windows.Forms;

namespace Lab_12_Comp
{
    public partial class Form2 : Form
    {
        struct Simple
        {
            public double xx; public double yy; public int ii;
        };

        Simple s;
        FileInfo my_file = new FileInfo("Curv.dat");
        StreamWriter fw;
        Random rnd;
        int first = 1, phi = 0, alpha = 0;

        public Form2()
        {
            InitializeComponent();
        }

        void pfopen()
        {
            fw = new StreamWriter(my_file.Open(FileMode.Create,
            FileAccess.Write));
        }

        /* Запись в файл точки с флагом рисования */
        void pwrite(double x, double y)
        {
            s.xx = x; s.yy = y;

            fw.Write("\n");  fw.Write(s.xx + " "); fw.Write(s.yy);
        }

        /* Закрытие файла */
        void pfclose()
        {
            fw.Close();
        }

        /* Функция, возвращающая новое направление кривой */
        double direction()
        {
            if (first == 1) { first = 0; rnd = new Random(); }
            alpha += rnd.Next(10000) % 13 - 6;
            if (Math.Abs(alpha) > 15) alpha = 0;
            phi += alpha;
            return ((double)phi * Math.PI / 180.0);
        }

        /* Главная функция генерации точек случайной кривой */
        void curvgen()
        {
            int i, N = 40;
            double x = 0.0, y = 0.0, x0, y0, phi = direction();
            pfopen();
            
            fw.Write(N);

            pwrite(x, y);
            for (i = 0; i < N; i++)
            {
                x0 = x; y0 = y; phi = direction();
                x = x0 + Math.Cos(phi); y = y0 + Math.Sin(phi);
                pwrite(x, y);
            }
            pfclose();
        }

        private void buttonGenCurv_Click(object sender, EventArgs e)
        {
            curvgen();
            MessageBox.Show("Кривая сгенерирована в файл Curv.dat");
        }
    }
}

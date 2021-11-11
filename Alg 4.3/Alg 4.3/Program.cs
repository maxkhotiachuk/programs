using System;

namespace Alg_4._3
{
    class Program
    {
        static double[] MasX = { 0.5, 0.69, 0.78, 0.99, 1.21, 1.34, 1.51, 1.63, 1.71, 1.83 };
        static double[] MasY = { 0.55962, 0.77293, 0.87062, 1.0886, 1.30131, 1.41963, 1.566561, 1.66523, 1.72884, 1.82114 };
        static double Global(double x)
        {
            int amount = 10;
            double L_Func = 0;

            for (int i = 0; i < amount; i++)
            {
                double L_num = 1, L_den = 1;
                for (int j = 0; j < amount; j++)
                {
                    if (i != j)
                    {
                        L_num *= (x - MasX[j]);
                        L_den *= (MasX[i] - MasX[j]);
                    }
                }
                L_Func += (L_num / L_den) * MasY[i];
            }
            return L_Func;

        }
        static double LagrangePolynom(double x, int size)
        {
            double answer = 0;

            for (int i = 0; i < size; i++)
            {
                double basicsPol = 1;
                for (int j = 0; j < size; j++)
                {
                    if (j != i)
                    {
                        basicsPol *= (x - MasX[j]) / (MasX[i] - MasX[j]);
                    }
                }
                answer += basicsPol * MasY[i];
            }

            return answer;
        }
        static void Aaaa()
        {
            int size;
            double x0;
            Console.WriteLine("Input size");
            size = int.Parse(Console.ReadLine());
            Console.WriteLine("Input X");
            x0 = double.Parse(Console.ReadLine());
            var xValues = new double[size];
            var yValues = new double[size];

            for (int i = 1; i <= size; i++)
            {
                Console.WriteLine("Input xValues" + i + ":");
                xValues[i - 1] = double.Parse(Console.ReadLine());

                Console.WriteLine("Input yValues" + i + ":");
                yValues[i - 1] = double.Parse(Console.ReadLine());
            }
            Console.WriteLine("");
            double rez = LagrangePolynom(x0, size);
            Console.WriteLine(rez);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("x\tЗа формулою\tЛокальна\tГлобальна\t1 п за фор\t1 п за чис\t2 п за фор\t2 п за чис");
            double x = 0;
            double[] Mas1 = new double[151];
            for (int i = 0; i < 151; i++)
            {
                Mas1[i] = Math.Log(x * x + x + 1);
                x += 0.01;
            }
            x = 0;
            int j = 0;
            double[] Mas2 = new double[2000];
            for (int k = 1, i = 0; i < MasY.Length - 1; i++)
            {

                do
                {
                    Mas2[j] = ((MasY[i + 1] - MasY[i]) * (x - MasX[i]) / (MasX[i + 1] - MasX[i]) + MasY[i]);
                    j++;
                    x += 0.01;
                }
                
                while (x <= MasX[i + 1] + 0.01);
            }
            x = 0;
            int p = 0;
            double L;
            double[] Mas3 = new double[200];
            for (int i = 0; i < MasX.Length - 1; i++)
            {
                do
                {
                    Mas3[p] = Global(x);
                    x += 0.01;
                    p++;
                }
                while (x < MasX[i]);
            }
            x = 0;
            double[] Mas4 = new double[200];
            for (int o = 0; o < 151; o++)
            {
                Mas4[o]= (2 * x + 1) / (x * x + x + 1);
                x += 0.01;
            }
            x = 0;
            double f, f1, dif;
            int c = 0;
            double[] Mas5 = new double[200];
            for (int k = 1, i = 0; k < 150; i++)
            {

                do
                {
                    f = (MasY[i + 1] - MasY[i]) * (x - MasX[i]) / (MasX[i + 1] - MasX[i]) + MasY[i];
                    x += 0.01;
                    f1 = (MasY[i + 1] - MasY[i]) * (x - MasX[i]) / (MasX[i + 1] - MasX[i]) + MasY[i];
                    Mas5[c] = (f1 - f) / 0.01;
                    c++;
                    k++;
                }
                while (x <= MasX[i]);
            }
            double[] Mas6 = new double[200];
            for (int kk = 1, ii = 0; kk < 152; kk++, ii++)
            {
                Mas6[ii] = (-2 * x * x - 2 * x + 1) / ((x * x + x + 1) * (x * x + x + 1));
                x += 0.01;
            }
            double f2;
            double[] Mas7 = new double[200];
            for (int k = 1, i = 0; i < MasX.Length - 1; i++)
            {

                do
                {
                    f = (MasY[i + 1] - MasY[i]) * (x - MasX[i]) / (MasX[i + 1] - MasX[i]) + MasY[i];
                    x -= 0.01;
                    f1 = (MasY[i + 1] - MasY[i]) * (x - MasX[i]) / (MasX[i + 1] - MasX[i]) + MasY[i];
                    x += 0.02;
                    f2 = (MasY[i + 1] - MasY[i]) * (x - MasX[i]) / (MasX[i + 1] - MasX[i]) + MasY[i];
                    x -= 0.01;
                    Mas7[k] = (f2 + f1 - 2 * f) / (0.01 * 0.01);
                    k++;
                    x += 0.01;
                }
                while (x <= MasX[i]);
            }
            x = 0;
            for (int i = 0; i < 151; i++)
            {
                Console.WriteLine($"{x:f2}\t{Mas1[i],7:f5}\t      {Mas2[i],10:f5}\t{Mas3[i],-7:f5}\t\t{Mas4[i],-7:f5}\t\t{Mas5[i],-7:f5}\t\t{Mas6[i],-7:f5}\t{Mas7[i],-7:f5}");
                x += 0.01;
            }
            //Aaaa();
        }
    }
}

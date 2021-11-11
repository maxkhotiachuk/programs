using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1
{
    class Program
    {
        static double Count(double a, double b, double e)
        {

            int i = 0;
            double x, F, k;
            Console.WriteLine("Номер ітерації \t| x \t\t| ak \t\t| bk \t\t| |bk-ak| \t| f(xk) ");
            Console.WriteLine("____________________________________________________________________________________________");
            do
            {
                x = (a + b) / 2.0;
                F = x * x - Math.Sin(5 * x);
                if ((a * a - Math.Sin(5 * a)) * (x * x - Math.Sin(5 * x)) < 0)
                    b = x;
                else
                    a = x;
                k = Math.Abs(b - a);
                i++;
                Console.WriteLine("{0} \t\t| {1:F4} \t| {2:F4} \t| {3:F4} \t| {4:F4} \t| {5,-6:F4}", i, x, a, b, k, F);
                Console.WriteLine("____________________________________________________________________________________________");
            }

            while ((k >= e));
            return x;
        }
        static double Other(double a, double b, double e)
        {
            int i = 0;
            double x, F, k;

            do
            {
                x = (a + b) / 2.0;
                F = x * x - Math.Sin(5 * x);
                if ((a * a - Math.Sin(5 * a)) * (x * x - Math.Sin(5 * x)) < 0)
                    b = x;
                else
                    a = x;
                k = Math.Abs(b - a);
                i++;

            }

            while ((k >= e));
            return x;
        }
        static double Nuton(double w, double t, double e)
        {
            int i = 0;
            double F, x0, x, k;
            F = (w * w - Math.Sin(5 * w)) * (2 + 25 * Math.Sin(5 * w));
            Console.WriteLine("Номер ітерації \t| |x(k)-x(k-1)|");
            Console.WriteLine("_______________________________");
            if (F > 0)
            {
                x0 = t;
            }
            else
            {
                x0 = w;
            }
            //double x0=0,59;
            do
            {
                x = x0 - ((x0 * x0 - Math.Sin(5 * x0)) / (2 * x0 - 5 * Math.Cos(5 * x0)));
                k = Math.Abs(x - x0);
                x0 = x;
                i++;
                Console.WriteLine("{0:F4} \t\t| {1}", i, k);
                Console.WriteLine("_______________________________");
            }
            while (k > e);
            return x;
        }
        static void Main()
        {
            int q = 1;
            Console.WriteLine("==================Метод бісекції==================");
            double x;
            Console.WriteLine("Input a");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Input b");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Input e");
            double e = double.Parse(Console.ReadLine());
            x = Count(a, b, e);
            Console.WriteLine("1 корінь рівння={0:F4}", x);
            Console.ReadLine();
            Console.WriteLine("==================Інші корені==================");
            do
            {
                Console.WriteLine("Input a");
                double n = double.Parse(Console.ReadLine());
                Console.WriteLine("Input b");
                double o = double.Parse(Console.ReadLine());
                x = Other(n, o, e);
                q++;
                Console.WriteLine("{0} корінь рівння = {1:F4}", q, x);
            }
            while (q != 4);
            Console.ReadLine();
            Console.WriteLine("==================Метод Ньютона================");
            Console.WriteLine("Input a");
            double l = double.Parse(Console.ReadLine());
            Console.WriteLine("Input b");
            double p = double.Parse(Console.ReadLine());
            Console.WriteLine("Input e");
            e = double.Parse(Console.ReadLine());
            x = Nuton(l, p, e);
            Console.WriteLine("Корінь рівняння {0:F4}", x);
        }
    }
}

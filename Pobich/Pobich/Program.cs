using System;

namespace laba_9_2_
{
    class Program
    {
        static void CreateMas(int[,] Mas)
        {
            Random rn = new Random();
            for (int u = 0; u < Mas.GetLength(0); u++)
            {
                for (int i = 0; i < Mas.GetLength(1); i++)
                {
                    Mas[u, i] = rn.Next(100);
                }
            }
        }
        static void Main()
        {
            try
            {
                int n;
                do
                {
                    Console.WriteLine("Введiть порядок матрицi");
                    n = int.Parse(Console.ReadLine());
                }
                while (n < 0);
                int[,] Mas = new int[n, n];
                CreateMas(Mas);
                PrintMas(Mas);
                int Max=MaxElMasVerh(Mas);
                Console.WriteLine("Найбiльший елемент над побiчною дiагоналлю {0}", Max);
                //Console.WriteLine();
                Max=MaxElMasNiz(Mas);
                Console.WriteLine("Найбiльший елемент пiд побiчною дiагоналлю {0}", Max);
            }
            catch (OverflowException e1)
            {
                Console.WriteLine(e1.Message);
            }
            catch (IndexOutOfRangeException e2)
            {
                Console.WriteLine(e2.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void PrintMas(int[,] Mas)
        {
            for (int k = 0; k < Mas.GetLength(0); k++)
            {
                for (int j = 0; j < Mas.GetLength(1); j++)
                    Console.Write(String.Format("{0,4}", Mas[k, j]));
                Console.WriteLine();
            }
        }
        static public int MaxElMasVerh(int[,] Mas)
        {
            int Max = 0;
            for (int i = 0; i < Mas.GetLength(0); i++)
            {
                for (int j = 0; j < (Mas.GetLength(0) - i - 1); j++)
                {
                    if (Mas[i, j] > Max)
                        Max = Mas[i, j];
                }
            }
            return Max;
        }
        static public int MaxElMasNiz(int[,] Mas)
        {
            int Max = 0;
            for (int i=0;i<Mas.GetLength(0);i++)
            {
                for (int j=Mas.GetLength(1)- i;j<Mas.GetLength(1);j++)
                {
                    if (Mas[i, j] > Max)
                        Max = Mas[i, j];
                }
            }
            return Max;
        }

    }
}

    


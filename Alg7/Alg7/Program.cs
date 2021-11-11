using System;

namespace Alg7
{
    class Program
    {
        static void Show_array_elements(int[] arr)
        {
            foreach (var element in arr)
            {
                Console.Write(element + " ");
            }
            Console.Write("\n");
        }
        static int ShellSort(int[] array, int key)
        {
            int h = 0;
            for (h = 1; h <= array.Length / 9; h = h * 3 + 1);
            while (h >= 1)
            {
                for (int i = h; i < array.Length; i++)
                {
                    for (int j = i - h; j >= 0; j -= h)
                    {
                        if (array[j] > array[j + h])
                        {
                            int swap = array[j];
                            array[j] = array[j + h];
                            array[j + h] = swap;
                        }
                    }
                }
                h = (h - 1) / 3;
            }
            int a = Binary(array, key);
            return a;
        }
        static int LinearWithBarA(int[] A, int key)
        {
            int[] A1 = new int[A.Length + 1];
            for (int k = 0; k < A.Length; k++)
            {
                A1[k] = A[k];
            }
            A1[A.Length] = key;
            int i = 0;
            while (A1[i] != key)
            {
                i++;
            }
            return i;
        }
        static int Binary(int[] A, int key)
        {
            int L = 0, couter = 0;
            int R = A.Length - 1;
            while (L <= R)
            {
                couter++;
                int m = (L + R) / 2;
                if (A[m] == key)
                {
                    Console.WriteLine("Number of compare is " + couter);
                    return m;
                }
                if (A[m] < key)
                    L = m + 1;
                else
                    R = m + 1;
            }
            Console.WriteLine("Number of compare is " + couter);
            return -1;
        }
        static void SerchOrdinary(int[] A, int[] B)
        {
            string sum = null;
            Console.WriteLine("Elements that are present only in mass A");
            int counter = 0;
            for (int i = 0; i < A.Length; i++)
            {
                counter = 0;
                for (int j = 0; j < B.Length; j++)
                {
                    if (A[i] == B[j])
                        counter++;
                }
                if (counter == 0)
                    sum += $"{A[i]} "; 
                    //Console.Write(A[i] + "  ");
            }
            if (sum == null)
                Console.WriteLine("Елементiв, якi присутнi тiльки в масивi А, немає");
            else
                Console.WriteLine(sum);
            sum = null;
            Console.WriteLine();
            Console.WriteLine("Elements that are present only in mass B");
            for (int i = 0; i < B.Length; i++)
            {
                counter = 0;
                for (int j = 0; j < A.Length; j++)
                {
                    if (B[i] == A[j])
                        counter++;
                }
                if (counter == 0)
                    sum += $"{B[i]} ";
            }
            if (sum == null)
                Console.WriteLine("Елементiв, якi присутнi тiльки в масивi А, немає");
            else
                Console.WriteLine(sum);
        }
        static void Main(string[] args)
        {
            int index = 0;
            Console.WriteLine("Input length of mass A");
            int number = int.Parse(Console.ReadLine());
            int[] A = new int[number];
            do
            {
                Console.WriteLine("Input " + index + " element");
                A[index] = int.Parse(Console.ReadLine());
                index++;
            }
            while (index < number);
            Console.WriteLine("Input length of mass B");
            number = int.Parse(Console.ReadLine());
            int[] B = new int[number];
            index = 0;
            do
            {
                Console.WriteLine("Input " + index + " element");
                B[index] = int.Parse(Console.ReadLine());
                index++;
            }
            while (index < number);
            string s = null;
            Console.WriteLine("Linear with bar");
            Console.WriteLine("Input mass: A, B or quit");
            s = Console.ReadLine();
            if (s != "quit")
            {
                Console.WriteLine("Input key");
                int key = int.Parse(Console.ReadLine());
                
                Console.WriteLine();
                if ((s == "A") || (s == "a"))
                {
                    int i = LinearWithBarA(A, key);
                    int p = i + 1;
                    if (i == A.Length)
                    {
                        
                        Console.WriteLine("There is not this element in mass A");
                        Console.WriteLine("Number of compare is " + p );
                    }
                    else
                    {
                        Console.WriteLine("Element " + key + " has index " + i + " in mass A");
                        Console.WriteLine("Number of compare is " + p);
                    }
                }
                else if ((s == "B") || (s == "b"))
                {

                    int i = LinearWithBarA(B, key);
                    int p = i + 1;
                    if (i == B.Length)
                    {
                        Console.WriteLine("There is not this element in mass B");
                        Console.WriteLine("Number of compare is " + p);
                    }
                    else
                    {
                        Console.WriteLine("Element " + key + " has index " + i + " in mass B");
                        Console.WriteLine("Number of compare is " + p);
                    }
                }
            }
            Console.WriteLine("Binary");
            Console.WriteLine("Input mass: A, B or quit");
            s = Console.ReadLine();
            if (s != "quit")
            {
                Console.WriteLine("Input key");
                int key = int.Parse(Console.ReadLine());

                Console.WriteLine();
                if ((s == "A") || (s == "a"))
                {
                    int i = ShellSort(A, key);
                    Show_array_elements(A);
                    if (i == -1)
                    {
                        Console.WriteLine("There is not this element in mass A");
                    }
                    else
                    {
                        Console.WriteLine("Element " + key + " has index " + i + " in mass A");
                    }
                }
                else if ((s == "B") || (s == "b"))
                {

                    int i = ShellSort(B, key);
                    if (i == -1)
                    {
                        Console.WriteLine("There is not this element in mass B");
                    }
                    else
                    {
                        Console.WriteLine("Element " + key + " has index " + i + " in mass B");
                    }
                }
            }
            SerchOrdinary(A, B);
        }
    }
}

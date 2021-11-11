using System;
using System.IO;
using System.Collections;

namespace file1
{
    class Program
    {
        static public void Compare (string s)
        {
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(s, FileMode.Open)))
                {
                    int counterM = 0;
                    int counterP = 0;
                    int counterQ = 0;
                    int b = reader.ReadInt32();
                    //int n = reader.ReadInt32();
                    //bool status = reader3.EndOfStream;
                    while (reader.PeekChar() != -1)
                    {
                        int n = reader.ReadInt32();
                        if (b > n)
                            counterM++;
                        else if (b < n)
                            counterP++;
                        else
                            counterQ++;
                        b = n;
                        //reader.BaseStream.Position++;
                    }

                    if ((counterM == 0)&&(counterQ==0))
                        Console.WriteLine("Зростає");
                    else if ((counterP == 0)&&(counterQ==0))
                        Console.WriteLine("Спадає");
                    else
                        Console.WriteLine("Ні спадає, ні зростає");
                }
            }
            catch (EndOfStreamException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FileNotFoundException e1)
            {
                Console.WriteLine(e1.Message);
            }
            catch (Exception e2)
            {
                Console.WriteLine(e2.Message);
            }
        }
        static public void Writing(string s)
        {
            try
            {
                int a, b;
                int counter = 0;
                Console.WriteLine("input number");
                do
                {
                    a = int.Parse(Console.ReadLine());
                }
                while (a <= 1);
                Console.WriteLine("input numbers");
                using (BinaryWriter writer = new BinaryWriter(new FileStream(s, FileMode.OpenOrCreate)))
                {
                    do
                    {
                        b = int.Parse(Console.ReadLine());
                        counter++;
                        writer.Write(b);
                    }
                    while (counter < a);
                }
            }
            catch (EndOfStreamException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FileNotFoundException e1)
            {
                Console.WriteLine(e1.Message);
            }
            catch (Exception e2)
            {
                Console.WriteLine(e2.Message);
            }
        }

        static void Main()
        {
            try
            {
                bool i;
                string name;
                Console.WriteLine("Input name of file");
                do
                {
                    name = Console.ReadLine();
                    i = ChekFile1(name);
                }
                while (i == false);
                string s = @"G:\c\"+name;
                //s=CheckFile(s);
                Writing(s);
                Compare(s);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        static bool ChekFile1 (string name)
        {
            bool i = false;
            if (name.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
            {
                Console.WriteLine("path error");
            }
            else
                i = true;
            return i;
        }
        static string CheckFile(string s)
        {
            try
            {
                if (!File.Exists(s))
                {
                    using (StreamWriter f = new StreamWriter(File.Create(s)));
                    //f.Close();
                }
            }
            catch (EndOfStreamException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FileNotFoundException e1)
            {
                Console.WriteLine(e1.Message);
            }
            catch (Exception e2)
            {
                Console.WriteLine(e2.Message);
            }
            return s;
        }
    }
}








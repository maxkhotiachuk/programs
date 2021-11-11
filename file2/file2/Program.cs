using System;
using System.IO;
namespace file2
{
    class Program
    {
        static void Main()
        {
            bool i; 
            string name2;
            string path = @"G:\c\";
            string name1 = "file1.txt";
            string s1 = @"G:\c\" + name1;
            Console.WriteLine("Input name of file2");
            do
            {
                name2 = Console.ReadLine();
                i = ChekFile1(name2);
            }
            while (i == false);
            string s2= path + name2+".txt";
            //s2=CheckFile(s2);
            //Writing();
            Perep(s1, s2);
            //Console.WriteLine("End");
            Read(s2);
        }
        static public void Read(string s2)
        {
            string p;
            using (StreamReader br = new StreamReader(new FileStream(s2, FileMode.Open)))
            {
                p = br.ReadToEnd();
                Console.WriteLine(p);
            }
        }
        static bool ChekFile1(string name)
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
        /*static public void Reading()
        {
            try
            {
                string a;
                Console.WriteLine("Введіть текст");
                a = Console.ReadLine();
                StreamReader reader = new StreamReader(new FileStream(@"D:\c\file1.txt", FileMode.OpenOrCreate));
                Rea.Write(a);
                writer.Close();
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
        }*/
        static public void Perep(string s1, string s2) 
        {
            try
            {
                string u;
                //string k = null;

                using (StreamReader br = new StreamReader(new FileStream(s1, FileMode.Open)))
                {

                    using (StreamWriter writer = new StreamWriter(new FileStream(s2, FileMode.OpenOrCreate)))
                    {
                        int i = 0;
                        while ((br.Peek()) !=-1 )
                        {
                            u = br.ReadLine();
                            
                            string[] words = u.Split(new[] { ' ' } , StringSplitOptions.RemoveEmptyEntries);
                            foreach (var word in words)
                            {
                                //File.WriteAllText(s2, words[i]);
                                writer.WriteLine(word);
                                //writer.WriteLine();

                            }
                            i++;
                            writer.WriteLine();
                        }
                    }
                    
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
        static string CheckFile(string s2)
        {
            try
            {
                if (!File.Exists(s2))
                {
                    using (StreamWriter str = new StreamWriter(File.Create(s2))) ;   
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //Console.WriteLine(s);

            }
            return s2;
        }
    }
}
        



        





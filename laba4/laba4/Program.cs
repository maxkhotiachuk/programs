using System;
using System.Collections.Generic;
using System.IO;

namespace laba4
{
    public delegate bool Sort(StDirectory d1, StDirectory d2);
    public struct StDirectory
    {
        public string direct;
        public DateTime timecreate;
        public DateTime timechanged;
        public double size;
        public int numberoffiles;
        public List<string> typeoffiles;// = new List<string>() { null };
        public static Sort CompareBySize// delegate ne null
        {
            get
            {
                //if (CompareBySize != null)
                //    return new Sort(SortBySize);
                //else
                //    return new Sort = null;
               // if (Sort!=null)
                return new Sort(SortBySize);
            //}*/
            //=> Sort != null ? new Sort(SortBySize);
            }
        }
        public static Sort CompareByNumber
        {
            get
            {
                return new Sort(SortByNumber);
            }
        }
        public StDirectory(string direct)
        {
            typeoffiles = new List<string>();
            if (!Directory.Exists(direct))
            {
                Directory.CreateDirectory(direct);
                this.direct = direct;
                string s1 = "12 / 05 / 2000 10:05:36";
                this.timecreate = DateTime.Parse(s1);
                s1 = "12 / 05 / 2000 10:10:10";
                this.timechanged = DateTime.Parse(s1);
                this.size = 0;
                this.numberoffiles = 0;
                typeoffiles = null;
            }
            else
            {
                double s = 0;
                string ss = null;
                this.direct = direct;
                this.timecreate = Directory.GetCreationTime(direct);
                this.timechanged = Directory.GetLastWriteTime(direct);
                foreach (string file in Directory.GetFiles(direct))
                {
                    if (File.Exists(file))
                    {
                        FileInfo finfo = new FileInfo(file);
                        s += finfo.Length;
                    }
                }
                this.size = s;
                this.numberoffiles = Directory.GetFiles(direct).Length;
                foreach (string file in Directory.GetFiles(direct))
                {
                    if (File.Exists(file))
                    {
                        //FileInfo finfo = new FileInfo(file);
                        ss = Path.GetExtension(file);
                        typeoffiles.Add(ss);
                    }
                }
            }
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())

                return false;
            StDirectory d = (StDirectory)obj;
            return (this.direct == d.direct) && (this.timecreate == d.timecreate) && (this.size == d.size);
        }//override get hashcode
        public override string ToString()
        {
            return $"Direct: " + this.direct + "\nTime of creating: " + this.timecreate +
                "\nTime of changing: " + this.timechanged + "\nSize: " + this.size + "\nNumber of files: " +
                this.numberoffiles;
            //foreach (string type in typeoffiles)
            //    Console.WriteLine(type);
        }
        public static bool SortBySize(StDirectory d1, StDirectory d2)
        {
            if (d1.size > d2.size)
                return true;
            else
                return false;
        }
        public static bool SortByNumber(StDirectory d1, StDirectory d2)
        {
            if (d1.numberoffiles > d2.numberoffiles)
                return true;
            else
                return false;
        }
    }
    class Container
    {
        StDirectory startdirectory = new StDirectory();
        public Sort go;
        private StDirectory[] container = new StDirectory[8];
        public int GetLength
        {
            get
            {
                return container.Length;
            }
        }
        public int ThisLength { get; set; }
        public Container()
        {
            for (int i = 0; i < container.Length; i++)
            {
                container[i] = new StDirectory();
            }
        }
        public StDirectory this[int index]
        {
            get
            {
                if (index > container.Length)
                {
                    throw new IndexOutOfRangeException("Out of range.");
                }
                else
                {
                    return container[index];
                }
            }
            set
            {
                if (index > container.Length)
                {
                    throw new IndexOutOfRangeException("Out of range.");
                }
                else
                {
                    container[index] = value;
                }
            }
        }
        public void AddElement(string direct)
        {
            if (ThisLength < container.Length)
            {
                if (!Directory.Exists(direct))
                {
                    Directory.CreateDirectory(direct);
                    container[ThisLength].direct = direct;
                    container[ThisLength].timecreate = Directory.GetCreationTime(direct);
                    container[ThisLength].timechanged = Directory.GetLastWriteTime(direct);
                    double s = 0;
                    foreach (string file in Directory.GetFiles(direct))
                    {
                        if (File.Exists(file))
                        {
                            FileInfo finfo = new FileInfo(file);
                            s += finfo.Length;
                        }
                    }
                    container[ThisLength].size = s;
                    container[ThisLength].numberoffiles = Directory.GetFiles(direct).Length;
                }
                else
                {
                    string ss;
                    container[ThisLength].direct = direct;
                    container[ThisLength].timecreate = Directory.GetCreationTime(direct);
                    container[ThisLength].timechanged = Directory.GetLastWriteTime(direct);
                    double s = 0;
                    foreach (string file in Directory.GetFiles(direct))
                    {
                        if (File.Exists(file))
                        {
                            FileInfo finfo = new FileInfo(file);
                            s += finfo.Length;
                        }
                    }
                    container[ThisLength].size = s;
                    container[ThisLength].numberoffiles = Directory.GetFiles(direct).Length;
                    /*foreach (string file in Directory.GetFiles(direct))
                    {
                        if (File.Exists(file))
                        {
                            //FileInfo finfo = new FileInfo(file);
                            ss = Path.GetExtension(direct);
                            container[ThisLength].typeoffiles.Add(ss);
                        }
                    }*/
                }
                ThisLength++;
            }
        }
        public void RemoveElement(int index)
        {
            if (index < GetLength)
                container[index] = startdirectory;
            else throw new IndexOutOfRangeException("Out of range");
        }
        public StDirectory[] Sorter(Sort go)//char c)//delegate
        {//check go not null
            //ChangeCompare(c);
            if (go != null)
            {
                for (int i = 0; i < container.Length; i++)
                {
                    for (int j = i + 1; j < container.Length; j++)
                    {
                        if (go(container[i], container[j]))
                        {
                            var temp = container[i];
                            container[i] = container[j];
                            container[j] = temp;
                        }
                    }
                }
                return container;
            }
            else
                throw new Exception("Delegate = null");
        }
        public void ChangeCompare(char ch)
        {
            if (ch == 's' | ch == 'S')
            {
                go = StDirectory.CompareBySize;
            }
            if (ch == 'n' | ch == 'N')
            {
                go = StDirectory.CompareByNumber;
            }
        }
        public void PrintElements()
        {
            for (int i = 0; i < container.Length; i++)
            {
                Console.WriteLine($"container[{i}] = {container[i]}");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public string PrintIndex(int index)
        {
            return container[index].ToString();
        }
        public void ModifyByCreateTime(DateTime time)
        {
            int counter = 0;
            for (int i = 0; i < container.Length; i++)
            {
                if (container[i].timecreate > time)
                {
                    Console.WriteLine(container[i]);
                    counter++;
                }
            }
            if (counter == 0)
                Console.WriteLine("There are not directory that were created later");
        }
        public void ModifyByChangeTime(DateTime time)
        {
            int counter = 0;
            for (int i = 0; i < container.Length; i++)
            {
                if (container[i].timechanged > time)
                {
                    Console.WriteLine(container[i]);
                    counter++;
                }
            }
            if (counter == 0)
                Console.WriteLine("There are not directory that were created later");
        }
        public void ModifyBySize(double size)
        {
            int counter = 0;
            for (int i = 0; i < container.Length; i++)
            {
                if (container[i].size > size)
                {
                    Console.WriteLine(container[i]);
                    counter++;
                }
            }
            if (counter == 0)
                Console.WriteLine("There are not directory that have bigger size");
        }
        public void ModifyByNumber(int number)
        {
            int counter = 0;
            for (int i = 0; i < container.Length; i++)
            {
                if (container[i].numberoffiles > number)
                {
                    Console.WriteLine(container[i]);
                    counter++;
                }
            }
            if (counter == 0)
                Console.WriteLine("There are not directory that have more files");
        }
        public void OutputByExtension(string extension)
        {
            string ss = null;
            string d = null;
            int counter = 0;
            foreach (StDirectory directory in container)
            {
                d = directory.direct;
                foreach (string file in Directory.GetFiles(d))
                {
                    if (File.Exists(file))
                    {
                        //FileInfo finfo = new FileInfo(file);
                        ss = Path.GetExtension(file);
                        //foreach (string typeoffile in directory.typeoffiles)
                        //{
                        if (ss == extension)
                        {
                            counter++;
                            Console.WriteLine(directory.ToString());
                            
                        }
                        break;
                    }
                }
            }
            if (counter == 0)
                Console.WriteLine("There is not directory with this extension");
        }
    }
    class Program
    {
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
        static void Main(string[] args)
        {
            bool b;
            string name = null;
            Container con = new Container();
            for (int i = 0; i < con.GetLength; i++)
            {
                Console.WriteLine("Input name of " + i + " directory");
                do
                {
                    name = Console.ReadLine();
                    b = ChekFile1(name);
                    if (b == false)
                        Console.WriteLine("Name is incorrect. Input one more time");
                }
                while (b == false);
                string direct = @"F:\c#\" + name;
                con.AddElement(direct);
            }
            con.PrintElements();
            Console.WriteLine();
            char sort;
            do
            {
                Console.WriteLine("Input <s> to sort by size or <n> to sort by number of files");
                sort = char.Parse(Console.ReadLine());
            }
            while ((sort != 's') && (sort != 'n'));
            if (sort == 's')
            {
                con.Sorter(StDirectory.CompareBySize);
            }
            if (sort == 'n')
            {
                con.Sorter(StDirectory.CompareByNumber);
            }
            Console.WriteLine();
            con.PrintElements();
            Console.WriteLine();
            Console.WriteLine("Output by index");
            Console.WriteLine("Input index");
            int index = int.Parse(Console.ReadLine());
            if ((index >= 0) && (index < con.GetLength))
            {
                Console.WriteLine(con.PrintIndex(index));
            }
            else
                Console.WriteLine("Out of range");
            Console.WriteLine();
            int output = 0;
            Console.WriteLine("Output more by: 1. timecreate 2. timechanged 3. size 4. numberoffiles");
            do
            {
                output = int.Parse(Console.ReadLine());
            }
            while ((output < 1) || (output > 4));
            switch (output)
            {
                case 1:
                    {
                        Console.WriteLine("Input time");
                        DateTime time = DateTime.Parse(Console.ReadLine());
                        con.ModifyByCreateTime(time);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Input time");
                        DateTime time = DateTime.Parse(Console.ReadLine());
                        con.ModifyByChangeTime(time);
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Input size");
                        double size = double.Parse(Console.ReadLine());
                        con.ModifyBySize(size);
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Input number");
                        int number = int.Parse(Console.ReadLine());
                        con.ModifyByNumber(number);
                        break;
                    }
            }
            Console.WriteLine();
            Console.WriteLine("Input extension in format .xxx");
            string ext = Console.ReadLine();
            con.OutputByExtension(ext);
        }
    }
}

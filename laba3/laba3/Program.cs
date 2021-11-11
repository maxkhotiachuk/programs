using System;

namespace laba3
{
    class Printer
    {
        enum Color { cyan, magenta, yellow, black }
        public string modelOfPrinter { get; set; }
        protected int[] levelOfPaints = new int[4];
        protected int maxlevelOfCyanPaint = 100;
        protected int maxlevelOfMagentaPaint = 100;
        protected int maxlevelOfYellowPaint = 100;
        protected int maxlevelOfBlackPaint = 100;
        protected int averagelevelOfPaint;
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())

                return false;
            Printer temp = (Printer)obj;
            return (this.levelOfPaints[0] == temp.levelOfPaints[0]) && (this.modelOfPrinter == temp.modelOfPrinter) && (this.levelOfPaints[1] == temp.levelOfPaints[1]) &&
                (this.levelOfPaints[2] == temp.levelOfPaints[2]) && (this.levelOfPaints[3] == temp.levelOfPaints[3]);
            //(this.levelOfPaints[(int)Color.yellow] == temp.levelOfPaints[(int)Color.yellow]) && (this.levelOfPaints[(int)Color.magenta] == temp.levelOfPaints[(int)Color.magenta]));
            //return ((this.modelOfPrinter == temp.ModelOfPrinter) && (this.levelOfPaints[(int)index]==)
        }
        public static Printer operator +(Printer t1, Printer t2)
        {
            Printer t3 = new Printer(t1.levelOfPaints[0] + t2.levelOfPaints[0], t1.levelOfPaints[1] + t2.levelOfPaints[1],
                t1.levelOfPaints[2] = t2.levelOfPaints[2], t1.levelOfPaints[3] + t2.levelOfPaints[3], t1.modelOfPrinter + t2.modelOfPrinter);
            return t3;
        }
        public override string ToString()
        {
            return "Printer: " + this.modelOfPrinter + "\nLevel of black colour: " + this.levelOfPaints[3] + "\nLevel " +
                "of cyan colour: " + this.levelOfPaints[0] + "\nLevel of magenta colour:" + this.levelOfPaints[1] + "\nLevel of yellow colour:" + this.levelOfPaints[2];
        }
        public Printer() : this(90, 90, 90, 90, "Epson 0202")
        {
        }
        public Printer(int levelOfBlackPaint, int levelOfCyanPaint, int levelOfMagentaPaint, int levelOfYellowPaint, string modelOfPrinter)
        {
            levelOfPaints[3] = levelOfBlackPaint;
            levelOfPaints[0] = levelOfCyanPaint;
            levelOfPaints[1] = levelOfMagentaPaint;
            levelOfPaints[2] = levelOfYellowPaint;
            this.modelOfPrinter = modelOfPrinter;
        }
        public virtual string PaintLevel()
        {
            return "Printer paint level:\nLevel of cyan:" + levelOfPaints[0] + "\nLevel of magenta:" + levelOfPaints[1].ToString() +
                "\nLevel of yellow:" + levelOfPaints[2].ToString() + "\nLevel of black:" + levelOfPaints[3].ToString();
        }
        /*public void totalPaintLevel()
            {
                averagelevelOfPaint = (levelOfPaints[(int)Color.cyan] + levelOfPaints[(int)Color.yellow] +
                         levelOfPaints[(int)Color.magenta] + levelOfPaints[(int)Color.black]) / 4;
                Console.WriteLine("Level of Paint is:" + averagelevelOfPaint);
            }*/
        public virtual string Print(int numberOfPages)
        {
            int printedPages = 0;
            if (((levelOfPaints[0] + levelOfPaints[1] +
            levelOfPaints[2] + levelOfPaints[3]) / 4) - (numberOfPages / 5) < 0)
            {
                return "Not enough paint";
            }
            else
            {
                printedPages += numberOfPages;
                Console.WriteLine("Printing {0} pages", numberOfPages);
                for (int n = 0; n < numberOfPages; n++)
                {
                    if (n % 5 == 0)
                    {
                        levelOfPaints[0] = levelOfPaints[(int)Color.cyan] - 1;
                        levelOfPaints[1] = levelOfPaints[(int)Color.magenta] - 1;
                        levelOfPaints[2] = levelOfPaints[(int)Color.yellow] - 1;
                        levelOfPaints[3] = levelOfPaints[(int)Color.black] - 1;
                    }
                }
            }
            return "Level of paint:\nBlue=" + levelOfPaints[0] + "\nViolet=" + levelOfPaints[1] +
                "\nYellow=" + levelOfPaints[2] + "\nBlack=" + levelOfPaints[3];
        }
        public int this[int index]
        {
            get
            {
                return levelOfPaints[index];
            }
            set
            {
                for (index = 0; index < levelOfPaints.Length; index++)
                {
                    if ((value >= 0) && (value <= 100))
                        levelOfPaints[index] = value;
                }
            }
        }
        public int MaxlevelOfCyanPaint
        {
            get
            {
                return maxlevelOfCyanPaint;
            }
            set
            {
                if ((value >= 0) && (value <= 100))
                    maxlevelOfCyanPaint = value;
            }
        }
        public int MaxlevelOfMagentaPaint
        {
            get
            {
                return maxlevelOfMagentaPaint;
            }
            set
            {
                if ((value >= 0) && (value <= 100))
                    maxlevelOfMagentaPaint = value;
            }
        }
        public int MaxlevelOfYellowPaint
        {
            get
            {
                return maxlevelOfYellowPaint;
            }
            set
            {
                if ((value >= 0) && (value <= 100))
                    maxlevelOfYellowPaint = value;
            }
        }
        public int MaxlevelOfBlackPaint
        {
            get
            {
                return maxlevelOfBlackPaint;
            }
            set
            {
                if ((value >= 0) && (value <= 100))
                    maxlevelOfBlackPaint = value;
            }
        }
        public int AveragelevelOfPaint
        {
            get
            {
                return averagelevelOfPaint;
            }
            set
            {
                if ((value >= 0) && (value <= 100))
                    averagelevelOfPaint = value;
            }
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public virtual void reFill(string s, int k)
        {
            if (s == "full")
            {
                levelOfPaints[0] = 100;
                levelOfPaints[1] = 100;
                levelOfPaints[3] = 100;
                levelOfPaints[2] = 100;
            }
            else if (s == "manual")
            {
                levelOfPaints[3] = levelOfPaints[(int)Color.black] + k;
                levelOfPaints[0] = levelOfPaints[(int)Color.cyan] + k;
                levelOfPaints[1] = levelOfPaints[(int)Color.magenta] + k;
                levelOfPaints[2] = levelOfPaints[(int)Color.yellow] + k;
                if (levelOfPaints[3] > 100)
                    levelOfPaints[3] = 100;
                if (levelOfPaints[0] > 100)
                    levelOfPaints[0] = 100;
                if (levelOfPaints[1] > 100)
                    levelOfPaints[1] = 100;
                if (levelOfPaints[2] > 100)
                    levelOfPaints[2] = 100;
            }
        }
        public virtual string showMaxLevelOfPaint()
        {
            return "Max paint level of printer:\nCyan" + maxlevelOfCyanPaint + "\nmagenta:" + maxlevelOfMagentaPaint +
                "\nyellow:" + maxlevelOfYellowPaint + "\nblack:" + maxlevelOfBlackPaint;

        }
        public void InputModelOfPrinter(string model)
        {
            modelOfPrinter = model;
        }
        public virtual void PrinterInfo()
        {
            ToString();
        }
        public virtual void ShowNasl()
        {
            Console.WriteLine("Ми в класi Printer");
        }
    }
    class StrumPrinter : Printer
    {
        private int speedOfPrinting;
        public int SpeedOfPrinting
        {
            get
            {
                return speedOfPrinting;
            }
            set
            {
                if ((value >= 0) && (value <= 100))
                    speedOfPrinting = value;
            }
        }
        public StrumPrinter() : this(20, 20, 20, 20, "Epson Strum", 10)
        {
        }
        public StrumPrinter(int levelOfBlackPaint, int levelOfCyanPaint, int levelOfMagentaPaint, int levelOfYellowPaint, string modelOfPrinter, int speedOfPrinting) : base(levelOfBlackPaint, levelOfCyanPaint, levelOfMagentaPaint, levelOfYellowPaint, modelOfPrinter)
        {
            this.speedOfPrinting = speedOfPrinting;
        }
        public override string ToString()
        {
            return "Strum printer: " + this.modelOfPrinter + "\nLevel of black colour: " + this.levelOfPaints[3] + "\nLevel " +
                    "of cyan colour: " + this.levelOfPaints[0] + "\nLevel of magenta colour:" + this.levelOfPaints[1] + "\nLevel of yellow colour:" + this.levelOfPaints[2] +
                    "\nSpeed of printing:" + this.speedOfPrinting;
        }
        public override void PrinterInfo()
        {
            ToString();
        }
        public override string Print(int numberOfPages)
        {
            int printedPages = 0;
            if (((levelOfPaints[0] + levelOfPaints[1] +
            levelOfPaints[2] + levelOfPaints[3]) / 4) - (numberOfPages / 5) < 0)
            {
                return "Not enough paint";
            }
            else
            {
                printedPages += numberOfPages;
                Console.WriteLine("Printing {0} pages", numberOfPages);
                for (int n = 0; n < numberOfPages; n++)
                {
                    if (n % 5 == 0)
                    {
                        levelOfPaints[0] = levelOfPaints[0] - 1;
                        levelOfPaints[1] = levelOfPaints[1] - 1;
                        levelOfPaints[2] = levelOfPaints[2] - 1;
                        levelOfPaints[3] = levelOfPaints[3] - 1;
                    }
                }
            }
            return "StrumPrinter level of paint:\nBlue=" + levelOfPaints[0] + "\nViolet=" + levelOfPaints[1] +
                "\nYellow=" + levelOfPaints[2] + "\nBlack=" + levelOfPaints[3];
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())

                return false;
            StrumPrinter temp = (StrumPrinter)obj;
            return (this.levelOfPaints[0] == temp.levelOfPaints[0]) && (this.modelOfPrinter == temp.modelOfPrinter) && (this.levelOfPaints[1] == temp.levelOfPaints[1]) &&
                (this.levelOfPaints[2] == temp.levelOfPaints[2]) && (this.levelOfPaints[3] == temp.levelOfPaints[3]) && (this.speedOfPrinting == temp.speedOfPrinting);
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public override void ShowNasl()
        {
            Console.WriteLine("Ми в класi StrumPrinter");
        }
        public override string PaintLevel()
        {
            return "Strum printer paint level:\nLevel of cyan:" + levelOfPaints[0] + "\nLevel of magenta:" + levelOfPaints[1].ToString() +
                "\nLevel of yellow:" + levelOfPaints[2].ToString() + "\nLevel of black:" + levelOfPaints[3].ToString();
        }
        public override string showMaxLevelOfPaint()
        {
            return "Max paint level of strum printer:\nCyan" + maxlevelOfCyanPaint + "\nmagenta:" + maxlevelOfMagentaPaint +
                "\nyellow:" + maxlevelOfYellowPaint + "\nblack:" + maxlevelOfBlackPaint;

        }
    }
    class ChornPrinter : Printer
    {
        int speedOfPrinting;
        public int SpeedOfPrinting
        {
            get
            {
                return speedOfPrinting;
            }
            set
            {
                if ((value >= 0) && (value <= 100))
                    speedOfPrinting = value;
            }
        }
        public ChornPrinter() : this(0, 0, 0, 10, "Epson Corn", 9)
        {
        }
        public ChornPrinter(int levelOfBlackPaint, int levelOfCyanPaint, int levelOfMagentaPaint, int levelOfYellowPaint, string modelOfPrinter, int speedOfPrinting) : base(levelOfBlackPaint, levelOfCyanPaint, levelOfMagentaPaint, levelOfYellowPaint, modelOfPrinter)
        {
            this.speedOfPrinting = speedOfPrinting;
            this.levelOfPaints[0] = levelOfCyanPaint;
            this.levelOfPaints[1] = levelOfMagentaPaint;
            this.levelOfPaints[2] = levelOfYellowPaint;
        }
        public override string ToString()
        {
            return "Chorn printer: " + this.modelOfPrinter + "\nLevel of black colour: " + this.levelOfPaints[3] +
                    "\nSpeed of printing:" + this.speedOfPrinting;
        }
        public override void PrinterInfo()
        {
            ToString();
        }
        public override string Print(int numberOfPages)
        {
            int printedPages = 0;
            if (levelOfPaints[3] - (numberOfPages / 10) < 0)
            {
                return "Not enough paint";
            }
            else
            {
                printedPages += numberOfPages;
                Console.WriteLine("Printing {0} pages", numberOfPages);
                for (int n = 0; n < numberOfPages; n++)
                {
                    if (n % 2 == 0)
                    {
                        levelOfPaints[3] = levelOfPaints[3] - 1;
                    }
                }
            }
            return "Chorn printer level of paint:\nBlack=" + levelOfPaints[3];
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())

                return false;
            ChornPrinter temp = (ChornPrinter)obj;
            return (this.levelOfPaints[3] == temp.levelOfPaints[3]) && (this.modelOfPrinter == temp.modelOfPrinter) && (this.levelOfPaints[1] == temp.levelOfPaints[1]) &&  (this.speedOfPrinting == temp.speedOfPrinting);
        }
        public new virtual void ShowNasl()
        {
            Console.WriteLine("Ми в класi ChornPrinter");
        }
        public override void reFill(string s, int k)
        {
            if (s == "full")
            {
                levelOfPaints[3] = 100;
            }
            else if (s == "manual")
            {
                levelOfPaints[3] = levelOfPaints[0] + k;
                if (levelOfPaints[3] > 100)
                    levelOfPaints[3] = 100;
            }
        }
        public override string PaintLevel()
        {
            return "Chorn printer paint level:\nLevel of black:" + levelOfPaints[0].ToString();
        }
        public override string showMaxLevelOfPaint()
        {
            return "Max paint level of chorn printer:\nblack:" + maxlevelOfBlackPaint;

        }
    }
    class Program
    {
        static void Show(Printer a)
        {
            a.ShowNasl();
        }
        static void Main(string[] args)
        {
            string s;
            int a, n, k = 0, chose;
            Console.WriteLine("Input level of Black paint of strum printer");
            int strumblack = int.Parse(Console.ReadLine());
            Console.WriteLine("Input level of Blue paint of strum printer");
            int strumblue = int.Parse(Console.ReadLine());
            Console.WriteLine("Input level of Violet paint of strum printer");
            int strumbviolet = int.Parse(Console.ReadLine());
            Console.WriteLine("Input level of Yellow paint of strum printer");
            int strumyellow = int.Parse(Console.ReadLine());
            Console.WriteLine("Input speed of printing of strum printer");
            int strumspeed = int.Parse(Console.ReadLine());
            Console.WriteLine("Input model of strum printer");
            string strummodel = Console.ReadLine();
            Console.WriteLine("Input level of black color of chorn printer");
            int chornblack = int.Parse(Console.ReadLine());
            Console.WriteLine("Input speed of printing of chorn printer");
            int chornspeed = int.Parse(Console.ReadLine());
            Console.WriteLine("Input model of chorn printer");
            string chornmodel = Console.ReadLine();
            Printer myChornPrinter = new ChornPrinter(chornblack, 0, 0, 0, chornmodel, chornspeed);
            Printer myStrumPrinter = new StrumPrinter(strumblack, strumblue, strumbviolet, strumyellow, strummodel, strumspeed);
            Printer myPrinter = new Printer();
            Console.WriteLine();
            myPrinter.ShowNasl();
            Console.WriteLine();
            myStrumPrinter.ShowNasl();
            Console.WriteLine();
            myChornPrinter.ShowNasl();
            Console.WriteLine();
            Show(myPrinter);
            Console.WriteLine();
            Show(myStrumPrinter);
            Console.WriteLine();
            Show(myChornPrinter);
            do
            {
                Console.WriteLine("Choose action: 1. print 2. refill 3. paint info 4. printer info 5. max level of paint (max) 6. Clean 7. Quit");
                a = int.Parse(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        {
                            Console.WriteLine("Choose printer: 1. printer 2. strum printer 3. chorn printer");
                            chose = int.Parse(Console.ReadLine());
                            switch (chose)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("Input number of pages");
                                        n = int.Parse(Console.ReadLine());
                                        string m = myPrinter.Print(n);
                                        Console.WriteLine(m);
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine("Input number of pages");
                                        n = int.Parse(Console.ReadLine());
                                        string m = myStrumPrinter.Print(n);
                                        Console.WriteLine(m);
                                        break;
                                    }
                                default:
                                    {
                                        Console.WriteLine("Input number of pages");
                                        n = int.Parse(Console.ReadLine());
                                        string m = myChornPrinter.Print(n);
                                        Console.WriteLine(m);
                                        break;
                                    }
                            
                            }
                            break;
                            
                        }                          
                    case 2:
                        {
                            Console.WriteLine("Choose printer: 1. printer 2. strum printer 3. chorn printer");
                            chose = int.Parse(Console.ReadLine());
                            switch (chose)
                            {
                                case 1:
                                    {
                                        do
                                        {
                                            Console.WriteLine("Choose: full or manual");
                                            s = Console.ReadLine();
                                            if (s == "full")
                                            {
                                                myPrinter.reFill(s, k);
                                            }
                                            else if (s == "manual")
                                            {
                                                Console.WriteLine("How much do u want to fill?");
                                                k = int.Parse(Console.ReadLine());
                                                myPrinter.reFill(s, k);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Error! Try again!");
                                            }
                                        }

                                        while ((s != "full") && (s != "manual"));
                                        break;
                                    }
                                case 2:
                                    {
                                        do
                                        {
                                            Console.WriteLine("Choose: full or manual");
                                            s = Console.ReadLine();
                                            if (s == "full")
                                            {
                                                myStrumPrinter.reFill(s, k);
                                            }
                                            else if (s == "manual")
                                            {
                                                Console.WriteLine("How much do u want to fill?");
                                                k = int.Parse(Console.ReadLine());
                                                myStrumPrinter.reFill(s, k);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Error! Try again!");
                                            }
                                        }

                                        while ((s != "full") && (s != "manual"));
                                        break;
                                    }
                                default:
                                    {
                                        do
                                        {
                                            Console.WriteLine("Choose: full or manual");
                                            s = Console.ReadLine();
                                            if (s == "full")
                                            {
                                                myChornPrinter.reFill(s, k);
                                            }
                                            else if (s == "manual")
                                            {
                                                Console.WriteLine("How much do u want to fill?");
                                                k = int.Parse(Console.ReadLine());
                                                myChornPrinter.reFill(s, k);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Error! Try again!");
                                            }
                                        }

                                        while ((s != "full") && (s != "manual"));
                                        break;
                                    }
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Choose printer: 1. printer 2. strum printer 3. chorn printer");
                            chose = int.Parse(Console.ReadLine());
                            switch (chose)
                            {
                                case 1:
                                    Console.WriteLine(myPrinter.PaintLevel());
                                    break;
                                case 2:
                                    Console.WriteLine(myStrumPrinter.PaintLevel());
                                    break;
                                default:
                                    Console.WriteLine(myChornPrinter.PaintLevel());
                                    break;
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Choose printer: 1. printer 2. strum printer 3. chorn printer");
                            chose = int.Parse(Console.ReadLine());
                            switch (chose)
                            {
                                case 1:
                                    Console.WriteLine(myPrinter);
                                    break;
                                case 2:
                                    Console.WriteLine(myStrumPrinter);
                                    break;
                                default:
                                    Console.WriteLine(myChornPrinter);
                                    break;
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Choose printer: 1. printer 2. strum printer 3. chorn printer");
                            chose = int.Parse(Console.ReadLine());
                            switch (chose)
                            {
                                case 1:
                                    Console.WriteLine(myPrinter.showMaxLevelOfPaint());
                                    break;
                                case 2:
                                    Console.WriteLine(myStrumPrinter.showMaxLevelOfPaint());
                                    break;
                                default:
                                    Console.WriteLine(myChornPrinter.showMaxLevelOfPaint());
                                    break;
                            }
                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Goodbye!");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Error! Try again!");
                            break;
                        }
                }
            }
            
            while (a != 7);

        }
    }
}

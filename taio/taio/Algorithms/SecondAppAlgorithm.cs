using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace taio.Algorithms
{
    /*algorytm Agnieszki*/
    class SecondAppAlgorithm : Algorithm
    {
        private Thread secondThread;

        public Thread SecondThread
        {
            get { return secondThread; }
            set { secondThread = value; }
        }
        /**finds the solution**/
        private int LU = 0, //corners representation of the rectangle being covered
                    LD = 2,
                    RU = 1,
                    RD = 3;
        private int areaOfSolution; 
        private List<Data.Rectangle> listOfPossibleSolutions;
        private List<Data.Rectangle> myRectangles; //working rectangle list
        /*ula*/
        public override void StartAlgorithm()
        {            
            secondThread = new Thread(new ThreadStart(startAlgorithm));
            secondThread.Start();   
            //this.MainFrm.Engine.Solutions.Add(this.Solution);
            //this.refreshTab();
        }
        public override void StopAlgorithm()
        {
            //this.endthread = true;
            if(secondThread != null)
                secondThread.Abort();
            System.Console.WriteLine("stopAlgorithm second");
        }        
        public void startAlgorithm()
        {//koniec ula
            
            this.copyRectangles(this.Rectangles);
            DateTime t1 = DateTime.Now;
            try
            {
                this.myRectangles.Sort(sortBySquare);
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.ToString());
            }
            
            this.areaOfSolution = this.sumOfAreas();
            Console.Out.WriteLine("Max possible area: " + areaOfSolution);
            this.listOfPossibleSolutions = new List<Data.Rectangle>();

            /*Main loop of the program. Algorith tries to cover every possible rectangle starting
             * from the one which square is the sum of input rectangles' squares with the step
             *  dynamicaly changing, according to the starting value. 
             */
            while (this.areaOfSolution > 0)
            {
                this.listOfPossibleSolutions.Clear();
                this.fillListOfPossibleSolutions();
                IEnumerator<Data.Rectangle> e = this.listOfPossibleSolutions.GetEnumerator();
                while (e.MoveNext())
                {
                    this.Solution.PartsOfSolution.Clear();
                    Console.Out.WriteLine("Now trying to cover: " + e.Current.Width + "x" + e.Current.Height);
                    if (this.coverSolution(e.Current))
                    {
                        this.convertSolution();
                        /*DateTime t2 = DateTime.Now;
                        TimeSpan t = t2 - t1;
                        Console.Out.WriteLine("Working time:" + t);
                        this.convertSolution();
                        Console.Out.WriteLine("Success!");
                        Console.Out.WriteLine("Found area:" + this.areaOfSolution);

                        Console.Out.WriteLine("Dimensions: " + e.Current.Width + "\t" + e.Current.Height);*/

                        Console.Out.WriteLine("Dimensions: " + e.Current.Width + "\t" + e.Current.Height);
                        /*ula*/
                        Console.Out.WriteLine("MAINAADD");
                        this.MainFrm.Engine.Solutions.Add(this.Solution);
                        this.refreshTab();
                        //koniec ula

                        return;
                    }
                    
                  
                }
                if (this.areaOfSolution > 1E5)
                    this.areaOfSolution-=1000;
                else if (this.areaOfSolution > 1E4)
                    this.areaOfSolution -= 10;
                else
                    this.areaOfSolution--;

            }
            /*if (this.Solution.PartsOfSolution.Count==0)
            {
                Console.Out.WriteLine("Failure");
                return;
            }*/
            //this.MainFrm.Engine.Solutions.Add(this.Solution);
            //this.refreshTab();
            //System.Windows.Forms.MessageBox.Show(tab.Index.ToString());
        }

        private int sumOfAreas()
        {
            int sum=0;
            IEnumerator<Data.Rectangle> e = this.myRectangles.GetEnumerator();
            while (e.MoveNext())
            {
                sum += e.Current.Height * e.Current.Width;
            }
            return sum;
        }
        private void fillListOfPossibleSolutions()
        {
            int n, m;  
            n=(int)Math.Ceiling(Math.Sqrt(this.areaOfSolution)); 
            
            /*szukamy mozliwych rozwiazan w postaci prostokatow n x m spelniajacych ograniczenie*/
            while ((0.5*this.areaOfSolution <= n * n) && (n * n  <= 2 * this.areaOfSolution))
            {
                if (this.areaOfSolution % n == 0)
                {
                    m = this.areaOfSolution / n;
                    this.listOfPossibleSolutions.Add(new taio.Data.Rectangle(m, n));
                    /*ponizsza instrukcja wydluza czas dzialania algorytmu o ok.100%
                     * dlatego dodano warunek dotyczacy pola pokrywanego prostokata*/
                    if (this.areaOfSolution <1E3) 
                    this.listOfPossibleSolutions.Add(new taio.Data.Rectangle(n, m));
                }
                n++;
            }
        }
        private bool coverSolution(Data.Rectangle r) //r-pokrywany prostokat
        {
            bool[,] usage = new bool [r.Height, r.Width];// tablica zajetosci
            Data.PartOfSolution part;
            /*nowa lista aby moc 4 pierwsze prostokaty umiescic w rogach,
             * pozniej je usunac i probowac ukladac kolejne*/
            List<Data.Rectangle> rect = new List<Data.Rectangle>(this.myRectangles);//rect will be modified in each loop
            int k = 0;
            //pierwsze 4 prostokaty do rogow
            for (k = 0; k < rect.Count && k < 4; k++)
            {
                part=this.fillCorners(rect[k], r, k);
                if (part == null)
                {
                    this.rotateRectangle(rect[k]);
                    part = this.fillCorners(rect[k], r, k);
                }
                if (part != null)
                {
                    this.Solution.PartsOfSolution.Add(part);
                    //uaktualnij usage
                    for (int i = part.Ylu; i <= part.Yrd; i++)
                    {
                        for (int j = part.Xlu; j <= part.Xrd; j++)
                        {
                            usage[i, j] = true;
                        }
                    }
                    if (this.isCovered(usage))
                    {
                        return true;
                    } 
                }
            }
            rect.RemoveRange(0, k); //remove those in corners
            IEnumerator<Data.Rectangle> e = rect.GetEnumerator(); //through new list
            while (e.MoveNext())
            {
                
                /*find the coordinates for the remainder*/
                part=this.insertRectangle(e.Current, r, usage);
                if (part != null)
                {
                    this.Solution.PartsOfSolution.Add(part);
                    //updates usage
                    for (int i = part.Ylu; i <= part.Yrd; i++)
                    {
                        for (int j = part.Xlu; j <= part.Xrd; j++)
                        {
                            usage[i, j] = true;
                        }
                    }
                    if (this.isCovered(usage))
                    {
                        return true;
                    } 
                }
            }    
            return false;
        }
        public void printListOfPossibleSolutions ()
        {
            IEnumerator<Data.Rectangle> e = this.listOfPossibleSolutions.GetEnumerator();
            while(e.MoveNext())
            {
                Console.Out.WriteLine(e.Current.Width + "\t" + e.Current.Height);
            }
        }
        
        //metoda implementujaca sortowanie dla komparatora
        private int sortBySquare(Data.Rectangle x ,Data.Rectangle y)
        {
            if (x.Height * x.Width == y.Height * y.Width) return 0;
            else if (x.Height * x.Width > y.Height * y.Width) return -1;
            else if (x.Height * x.Width < y.Height * y.Width) return 1;
            else throw new Exception("Comparing failed");
        }

        private Data.PartOfSolution insertRectangle(Data.Rectangle x, Data.Rectangle r, bool[,] t)
        {
            Data.PartOfSolution part = new Data.PartOfSolution();
            int m = t.GetLength(0);  //liczba wierszy
            int n = t.GetLength(1);  //liczba kolumn
            
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (t[i, j] == false)
                    {
                        //czy mozna wstawic prostokat
                        if (this.canBeInserted(i, j, x.Height, x.Width, t))
                        {
                            part.Ylu = i;
                            part.Xlu = j;
                            part.Yrd = i + x.Height - 1;
                            part.Xrd = j + x.Width - 1;
                            return part;
                        }
                        //a moze obrocony?
                        if (this.canBeInserted(i, j, x.Width, x.Height, t))
                        {
                            part.Ylu = i;
                            part.Xlu = j;
                            part.Yrd = i + x.Width - 1;
                            part.Xrd = j + x.Height - 1;
                            return part;
                        }
                        
                    }
                }
            }
            part = this.findBestPlacement(x, r, t);
            if (part == null)
            {
                this.rotateRectangle(x);
                part = this.findBestPlacement(x, r, t);
            }
            return part;
        }
        private bool canBeInserted (int a, int b, int width, int height, bool [,]t)
        {
            int m = t.GetLength(0);
            int n = t.GetLength(1);
            if ((a+width > m) || (b+height > n)) return false;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (t[a+i,b+j] == true) return false;
                }
            }
            return true;
        }
        private Data.PartOfSolution findBestPlacement(Data.Rectangle x, Data.Rectangle r, bool[,] t)
        {
            Data.PartOfSolution part = new Data.PartOfSolution();
            int m = t.GetLength(0);  //liczba wierszy
            int n = t.GetLength(1);  //liczba kolumn
            int max = -1, tmp;
            int a=0, b=0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    //find the max free area for current rectangle
                    tmp = this.countFreeSquares(x.Width, x.Height, i, j, t);
                    if (max < tmp)
                    { 
                        max = tmp;
                        a = i;
                        b = j;
                    }
                }
            }
            if (max < 0) return null;  //rectangle cannot be inserted
            part.Ylu = a;
            part.Xlu = b;
            part.Yrd = a + x.Width - 1;
            part.Xrd = b + x.Height - 1;
            return part;
        }
        private Data.PartOfSolution fillCorners(Data.Rectangle x, Data.Rectangle r, int c)
        {
            if ((x.Width > r.Width) || (x.Height > r.Height)) return null;
            Data.PartOfSolution part = new Data.PartOfSolution();
            if (c==this.LU)  //lewy gorny
            {
                part.Xlu = 0;
                part.Ylu = 0;
                part.Xrd = x.Width - 1;
                part.Yrd = x.Height - 1;
                return part;
            }
            if (c==this.RU) //prawy gorny
            {
                part.Xlu = r.Width - x.Width;
                part.Ylu = 0;
                part.Xrd = r.Width - 1;
                part.Yrd = x.Height - 1;
                return part;
            }
            if (c==this.LD) //lewy dolny
            {
                part.Xlu = 0;
                part.Ylu = r.Height - x.Height;
                part.Xrd = x.Width - 1;
                part.Yrd = r.Height - 1;
                return part;
            }
            if (c == this.RD) //prawy dolny
            {
                part.Xlu = r.Width - x.Width;
                part.Ylu = r.Height - x.Height;
                part.Xrd = r.Width - 1;
                part.Yrd = r.Height - 1;
                return part;
            }
            return null;
        }
        private int countFreeSquares(int w, int h, int x, int y, bool [,]t)
        {
            int counter = -1;
            if ((x + w > t.GetLength(0)) || y + h > t.GetLength(1)) return counter; 
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    if (t[x + i, y + j] == false) counter++;
                }
            }
            return counter;
        }
        private void copyRectangles(List<Data.Rectangle> l)
        {
            this.myRectangles = new List<Data.Rectangle>();
            IEnumerator<Data.Rectangle> e = l.GetEnumerator();
            while (e.MoveNext())
            {
                this.myRectangles.Add(new Data.Rectangle(e.Current.Width, e.Current.Height));
            }
        }
        private void convertSolution()
        {
            IEnumerator<Data.PartOfSolution> e = this.Solution.PartsOfSolution.GetEnumerator();
            while (e.MoveNext())
            {
                
                e.Current.Xrd++;
                e.Current.Yrd++;
            }
        }
        private void printUsage(bool[,] t)
        {
            int m = t.GetLength(0);
            int n = t.GetLength(1);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (t[i,j]==true) Console.Out.Write("1" + "\t");
                    else Console.Out.Write("0" + "\t");
                }
                Console.Out.WriteLine();
            }
        }
        private bool isCovered(bool[,] t)
        {
            int m = t.GetLength(0);
            int n = t.GetLength(1);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (t[i, j] == false) return false;
                }
            }
            return true;
        }
        private void rotateRectangle(Data.Rectangle x)
        {
            int tmp;
            tmp = x.Height;
            x.Height = x.Width;
            x.Width = tmp;
        }
        private void printListOfRectangles(List<Data.Rectangle> l)
        {
            IEnumerator<Data.Rectangle> e = l.GetEnumerator();
            while (e.MoveNext())
            {
                Console.Out.WriteLine(e.Current.Width + "\t" + e.Current.Height);
            }
        }
        private void printPartsOfSolution()
        {
            IEnumerator<Data.PartOfSolution> en = this.Solution.PartsOfSolution.GetEnumerator();
            while (en.MoveNext())
            {
                Console.Out.WriteLine(en.Current.Xlu + " " + en.Current.Ylu + " " + en.Current.Xrd + " " + en.Current.Yrd);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace taio.Algorithms
{
    /*algorytm Agnieszki*/
    class SecondAppAlgorithm : Algorithm
    {
        /**finds the solution*/
        private int LU = 0,
                    LD = 2,
                    RU = 1,
                    RD = 3;
        private int areaSolution;
        private List<Data.Rectangle> listOfPossibleSolutions;
        
        public override void StartAlgorithm()
        {
            //begin of tests
            
            this.Rectangles = new List<Data.Rectangle>();
            //this.Rectangles.Clear();
            this.Rectangles.Add(new taio.Data.Rectangle(3,6));
            this.Rectangles.Add(new taio.Data.Rectangle(2, 3));
            this.Rectangles.Add(new taio.Data.Rectangle(1, 2));
            this.Rectangles.Add(new taio.Data.Rectangle(2, 2));
            this.Rectangles.Add(new taio.Data.Rectangle(3, 3));
            //this.Rectangles.Add(new taio.Data.Rectangle(2, 1));
            this.Rectangles.Add(new taio.Data.Rectangle(2, 4));
            this.Rectangles.Add(new taio.Data.Rectangle(5, 1));
            
            //end of tests
            
            try
            {
                this.Rectangles.Sort(sortBySquare);
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.ToString());
            }
            this.areaSolution = this.sumOfAreas();
            this.listOfPossibleSolutions = new List<Data.Rectangle>();
            while (this.areaSolution > 0)
            {
                this.Solution.PartsOfSolution.Clear();
                this.listOfPossibleSolutions.Clear();
                this.fillListOfPossibleSolutions();
                //this.printListOfPossibleSolutions();
                IEnumerator<Data.Rectangle> e = this.listOfPossibleSolutions.GetEnumerator();
                while (e.MoveNext())
                {
                    if (this.coverSolution(e.Current))
                    {
                        //this.printPartsOfSolution();
                        return;
                    }
                }
                this.areaSolution--;
            }
        }

        private int sumOfAreas()
        {
            int sum=0;
            IEnumerator<Data.Rectangle> e = this.Rectangles.GetEnumerator();
            while (e.MoveNext())
            {
                sum += e.Current.Height * e.Current.Width;
            }
            return sum;
        }
        private void fillListOfPossibleSolutions()
        {
            int n, m;  
            n=(int)Math.Ceiling(Math.Sqrt(this.areaSolution));
            
            /*szukamy mozliwych rozwiazan w postaci prostokatow n x m spelniajacych ograniczenie*/
            while ((0.5*this.areaSolution <= n * n) && (n * n  <= 2 * this.areaSolution))
            {
                if (this.areaSolution % n == 0)
                {
                    m = this.areaSolution / n;
                    this.listOfPossibleSolutions.Add(new taio.Data.Rectangle(m, n));
                }
                n++;
            }
        }
        private bool coverSolution(Data.Rectangle r) //r-pokrywany prostokat
        {
            bool[,] usage = new bool [r.Height, r.Width];// tablica zajetosci
            Data.PartOfSolution part;
            List<Data.Rectangle> rect = new List<Data.Rectangle>(this.Rectangles);
            //pierwsze 4 prostokaty do rogow
            for (int k = 0; k < rect.Count && k < 4; k++)
            {
                part=this.fillCorners(rect[k], r, k);
                if (part != null)
                {
                    this.Solution.PartsOfSolution.Add(part);
                    //this.printPartsOfSolution();
                    for (int i = part.Ylu; i <= part.Yrd; i++)
                    {
                        for (int j = part.Xlu; j <= part.Xrd; j++)
                        {
                            usage[i, j] = true;
                        }
                    }
                }
            }
            rect.RemoveRange(0, 4);
            //this.printUsage(usage);
            IEnumerator<Data.Rectangle> e = rect.GetEnumerator();
            while (e.MoveNext())
            {
                
                /*find the coordinates*/
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
                    if (this.isCovered(usage)) //checks usage
                    {
                        this.printUsage(usage);
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
            return this.findBestPlacement(x, r, t);
            //return null;
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
        private void printListOfRectangles()
        {
            IEnumerator<Data.Rectangle> e = this.Rectangles.GetEnumerator();
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

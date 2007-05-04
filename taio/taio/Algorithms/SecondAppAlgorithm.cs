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
        private List<Data.Rectangle> myRectangles; //robocza lista prostokatow
        public override void StartAlgorithm()
        {
            
            this.copyRectangles(this.Rectangles);
            try
            {
                this.myRectangles.Sort(sortBySquare);
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.ToString());
            }
            this.printListOfRectangles(this.myRectangles);
            this.areaSolution = this.sumOfAreas();
            Console.Out.WriteLine("Max possible area: " + areaSolution);
            this.listOfPossibleSolutions = new List<Data.Rectangle>();
            while (this.areaSolution > 0)
            {
                this.Solution.PartsOfSolution.Clear();
                this.listOfPossibleSolutions.Clear();
                this.fillListOfPossibleSolutions();
                /*if (this.listOfPossibleSolutions.Count == 0)
                {
                    Console.Out.WriteLine("Failure");
                    return;
                }*/
                IEnumerator<Data.Rectangle> e = this.listOfPossibleSolutions.GetEnumerator();
                while (e.MoveNext())
                {
                    if (this.coverSolution(e.Current))
                    {
                        Console.Out.WriteLine("Success!");
                        Console.Out.WriteLine("Found area:" + this.areaSolution);
                        Console.Out.WriteLine("Wymiary: " + e.Current.Width + "\t" + e.Current.Height);
                        return;
                    }
                }
                this.areaSolution--;
            }
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
            /*nowa lista aby moc 4 pierwsze prostokaty umiescic w rogach,
             * pozniej je usunac i probowac ukladac kolejne*/
            List<Data.Rectangle> rect = new List<Data.Rectangle>(this.myRectangles);
            //pierwsze 4 prostokaty do rogow
            for (int k = 0; k < rect.Count && k < 4; k++)
            {
                part=this.fillCorners(rect[k], r, k);
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
            rect.RemoveRange(0, 4);
            IEnumerator<Data.Rectangle> e = rect.GetEnumerator(); //po nowej liscie
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
                    if (this.isCovered(usage))
                    {
                        //this.printPartsOfSolution();
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
            int max = 0, tmp;
            int a=0, b=0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    tmp = this.countFreeSquares(x.Width, x.Height, i, j, t);
                    if (max < tmp)
                    { 
                        max = tmp;
                        a = i;
                        b = j;
                    }
                }
            }
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
                Data.Rectangle rect = new Data.Rectangle(e.Current.Width, e.Current.Height);
                this.myRectangles.Add(rect);
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
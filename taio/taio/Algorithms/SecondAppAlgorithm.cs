using System;
using System.Collections.Generic;
using System.Text;

namespace taio.Algorithms
{
    /*algorytm Agnieszki*/
    class SecondAppAlgorithm : Algorithm
    {
        /**finds the solution*/
        private int areaSolution;
        private List<Data.Rectangle> listOfPossibleSolutions;
        
        public override void StartAlgorithm()
        {
            //this.areaSolution = 256;
            //begin of tests
            this.Rectangles = new List<Data.Rectangle>();
            //this.Rectangles.Clear();
            //this.Rectangles.Add(new taio.Data.Rectangle(2,5));
            //this.Rectangles.Add(new taio.Data.Rectangle(3,6));
            this.Rectangles.Add(new taio.Data.Rectangle(9, 9));
            this.Rectangles.Add(new taio.Data.Rectangle(1,7));
            this.Rectangles.Add(new taio.Data.Rectangle(3, 6));
            //end of tests
            //this.printListOfRectangles();
            try
            {
                this.Rectangles.Sort(sortBySquare);
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.ToString());
            }
            //this.printListOfRectangles();
            this.areaSolution = this.sumOfAreas();
            this.listOfPossibleSolutions = new List<Data.Rectangle>();
            while (this.areaSolution > 0)
            {
                this.listOfPossibleSolutions.Clear();
                this.fillListOfPossibleSolutions();
                IEnumerator<Data.Rectangle> e = this.listOfPossibleSolutions.GetEnumerator();
                while (e.MoveNext())
                {
                    if (this.coverSolution(e.Current)) return;            
                }
                this.areaSolution--;
            }
            //this.printListOfPossibleSolutions();
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
            bool[,] usage = new bool [r.Width, r.Height];  // tablica zajetosci
            Data.PartOfSolution part;
            IEnumerator<Data.Rectangle> e = this.Rectangles.GetEnumerator();
            while (e.MoveNext())
            {
                /*find the coordinates*/
                part=this.insertRectangle(e.Current, r, usage);
                this.Solution.PartsOfSolution.Add(part); 
            }
            
            //Console.Out.WriteLine(r.Width + "\t" + r.Height);

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
                                        
                }
            }
            return part;
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

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
            
            //begin of tests
            //this.areaSolution = 256;
            this.Rectangles.Clear();
            this.Rectangles.Add(new taio.Data.Rectangle(2,5));
            this.Rectangles.Add(new taio.Data.Rectangle(3,6));
            this.Rectangles.Add(new taio.Data.Rectangle(9, 9));
            this.Rectangles.Add(new taio.Data.Rectangle(1,7));
            this.Rectangles.Add(new taio.Data.Rectangle(3, 6));
            //end of tests
            //this.printListOfRectangles();
            this.Rectangles.Sort(compare);
            
            //this.printListOfRectangles();
            this.areaSolution = this.sumOfAreas();
            this.listOfPossibleSolutions = new List<Data.Rectangle>();
            while (this.areaSolution > 0)
            {
                this.listOfPossibleSolutions.Clear();
                this.fillListOfPossibleSolutions();
                for (int i = 0; i < this.listOfPossibleSolutions.Count; i++)
                {
                    if (this.coverSolution(this.listOfPossibleSolutions[i])) return;            
                }
                this.areaSolution--;
            }
            //this.printListOfPossibleSolutions();
        }

        private int sumOfAreas()
        {
            int sum=0;
            for (int i = 0; i < this.Rectangles.Count; i++)
            {
                sum += this.Rectangles[i].Height * this.Rectangles[i].Width;
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
                        
            return false;
        }
        public void printListOfPossibleSolutions ()
        {
            IEnumerator<Data.Rectangle> e = this.listOfPossibleSolutions.GetEnumerator();
            while(e.MoveNext())
            {
                Console.Out.WriteLine(e.Current.Height + " " + e.Current.Width);
            }
        }
        
        //metoda implementujaca sortowanie
        private int compare(Data.Rectangle x ,Data.Rectangle y)
        {
            if (x.Height * x.Width == y.Height * y.Width) return 0;
            else if (x.Height * x.Width > y.Height * y.Width) return -1;
            else if (x.Height * x.Width < y.Height * y.Width) return 1;
            else throw new Exception("Comparing failed");
        }
        /*private void addToSolution(Data.Rectangle r)
        {

        }*/
        private void printListOfRectangles()
        {
            IEnumerator<Data.Rectangle> e = this.Rectangles.GetEnumerator();
            while (e.MoveNext())
            {
                Console.Out.WriteLine(e.Current.Height + "\t" + e.Current.Width);
            }
        }

    }
}

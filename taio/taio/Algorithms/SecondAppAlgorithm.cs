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
            this.areaSolution = this.sumOfAreas();
            //test this.areaSolution = 56;
            this.listOfPossibleSolutions = new List<Data.Rectangle>();
            while (this.areaSolution > 0)
            {
                this.fillListOfPossibleSolutions();
                for (int i = 0; i < this.listOfPossibleSolutions.Count; i++)
                {
                    if (this.coverSolution()) return;            
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
        private bool coverSolution()
        {
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
    }
}

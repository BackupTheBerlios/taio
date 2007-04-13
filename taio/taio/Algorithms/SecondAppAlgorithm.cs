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

            while (this.areaSolution > 0)
            {
                this.fillListOfPossibleSolutions();
                for (int i = 0; i < this.listOfPossibleSolutions.Count; i++)
                {
                    if (this.coverSolution()) return;            
                }
                this.areaSolution--;
            }
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
               
        }
        private bool coverSolution()
        {
            return false;
        }

    }
}

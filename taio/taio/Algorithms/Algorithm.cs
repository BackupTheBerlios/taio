using System;
using System.Collections.Generic;
using System.Text;

namespace taio.Algorithms
{
    abstract class Algorithm
    {
        
        /**found solution*/
        Data.Solution solution;

        List<Data.Rectangle> rectangles;

        public List<Data.Rectangle> Rectangles
        {
            get { return rectangles; }
            set { rectangles = value; }
        }

        public Algorithm()
        {
            solution = new Data.Solution();
        }

        /**finds the solution*/

        public abstract void StartAlgorithm();

        /**returns Solution which algorithm has founded*/

        public Data.Solution Solution
        {
            get { return solution; }
        }


    }
}

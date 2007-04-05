using System;
using System.Collections.Generic;
using System.Text;

namespace taio.Algorithms
{
    abstract class Algorithm
    {
        
        /**founded solution*/
        Data.Solution solution;

        List<Data.Rectangle> rectangles;

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
        public List<Data.Rectangle> Rectangle
        {
            set { rectangles = value; }
        }

    }
}

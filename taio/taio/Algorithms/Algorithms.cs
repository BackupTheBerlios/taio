using System;
using System.Collections.Generic;
using System.Text;

namespace taio.Algorithms
{
    class Algorithms
    {
        public static int BRUTAL_ALGORTIHM = 0, 
                        FIRST_APP_ALGORITHM = 1, 
                        SECOND_APP_ALGORITHM = 2; 

        //private Data.Solution[] solutions;
        private Algorithm[] algorithms;

        internal Algorithm[] getAlgorithms
        {
            get { return algorithms; }
            set { algorithms = value; }
        }

        /**initializes fields of class*/
        public Algorithms()
        {
            //solutions = new Data.Solution[SECOND_APP_ALGORITHM + 1];

            algorithms = new Algorithm[SECOND_APP_ALGORITHM + 1];

            algorithms[BRUTAL_ALGORTIHM] = new BrutalAlgorithm();
            algorithms[FIRST_APP_ALGORITHM] = new FirstAppAlgorithm();
            algorithms[SECOND_APP_ALGORITHM] = new SecondAppAlgorithm();
        }

        /**calls algorithm
         * rectangles - list of rectangles
         * algorithmType - which algorithm is to be called*/

        //public void FindSolution( List<Data.Rectangle> rectangles, int algorthimType)
        //{
        //    algorithms[algorthimType].StartAlgorithm();
        //    solutions[algorthimType] = algorithms[algorthimType].Solution;
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace taio.Algorithms.FirstAppAlgorithm1
{
    class Layer
    {
        private enum direction { Vertical, Horizontal };
        private direction directionOfLayer;
        private int start, //poziom na którym ukladana jest warstwa
            end; // "najglebsze wciecie" warstwy

        public int End
        {
            get { return end; }
            set { end = value; }
        }
        public int Start
        {
            get { return start; }
            set { start = value; }
        }
        private List<Data.PartOfSolution> listPartOfSolution;
        private List<Data.Rectangle> listUsedRectangles; //chyba nie potzrebna

        public Layer()
        {
            

        }
        public bool constructHorizontalLayer(List<Data.Rectangle> rectangle)
        {
            this.directionOfLayer = direction.Horizontal;


            return true;
        }

        public bool constructVerticalLayer(List<Data.Rectangle> rectangle)
        {
            this.directionOfLayer = direction.Vertical;


            return true;
        }

    }
}

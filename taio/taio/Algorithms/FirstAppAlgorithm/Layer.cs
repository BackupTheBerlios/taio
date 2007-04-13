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
        private List<Data.PartOfSolution> listPartOfSolution;
        private List<Data.Rectangle> listRectangle; //chyba nie potzrebna

        /*public Layer(direction direction)
        {
            this.directionOfLayer = direction;

        }*/
    }
}

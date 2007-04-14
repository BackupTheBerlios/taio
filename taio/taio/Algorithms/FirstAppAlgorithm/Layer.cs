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

        internal List<Data.PartOfSolution> ListPartOfSolution
        {
            get { return listPartOfSolution; }
            set { listPartOfSolution = value; }
        }
        private List<Data.Rectangle> listUsedRectangles; //chyba nie potzrebna

        public Layer()
        {
            this.listPartOfSolution = new List<taio.Data.PartOfSolution>();
            this.listUsedRectangles = new List<taio.Data.Rectangle>();

        }
        public bool constructHorizontalLayer(List<Data.Rectangle> rectangle, int w,int h)
        {
            this.directionOfLayer = direction.Horizontal;
            int w1 = 0;
            this.start = h;
            this.end = -1;
            while (w1 < w )
            {
                if (rectangle.Count == 0)
                    return false; //moze cos lepiej
                Data.Rectangle rect = rectangle[0];
                rectangle.Remove(rect);
                this.listUsedRectangles.Add(rect); //niepotzrebne

                Data.PartOfSolution part = new Data.PartOfSolution();
                part.Xlu = w1;
                part.Ylu = h;
                part.Xrd = w1 + rect.Width;
                part.Yrd = h + rect.Height;
                this.listPartOfSolution.Add(part);
                w1 += rect.Width;

                if (this.end == -1 || this.end > h + rect.Height) 
                    this.end = h + rect.Height;  //zapamietuje najglebsze wciecie!!!!!!
            }
            return true;
        }

        public bool constructVerticalLayer(List<Data.Rectangle> rectangle, int w, int h)
        {
            this.directionOfLayer = direction.Vertical;
            int h1 = 0;
            this.start = w;
            this.end = -1;
            while (h1 < h)
            {
                if (rectangle.Count == 0)
                    return false; //moze cos lepiej
                Data.Rectangle rect = rectangle[0];
                rectangle.Remove(rect);
                this.listUsedRectangles.Add(rect); //niepotzrebne

                Data.PartOfSolution part = new Data.PartOfSolution();
                part.Xlu = w;
                part.Ylu = h1;
                part.Xrd = part.Xlu + rect.Height;
                part.Yrd = part.Ylu + rect.Width;
                this.listPartOfSolution.Add(part);
                h1 += rect.Width; //bo obracam prostokat o 90 stopni

                if (this.end == -1 || this.end > w + rect.Width)
                    this.end = w + rect.Height;  //zapamietuje najglebsze wciecie!!!!!!
            }
            return true;
        }
        //bedzie probowala cofnac warstwe do glebokosci "najg³ebszego wciecia",
        //moze sie okazac to niewykonalne, bo cofany prostokat bedzie wychodzil
        //poza konstruowany prostokat z drugiej strony
        public bool moveBack()
        {
            if (this.directionOfLayer == direction.Horizontal)
            {
                Console.Out.WriteLine("COFNIJ WARSTWE HORIZ");
                for (int i = 0; i < this.listPartOfSolution.Count; ++i)
                {
                    Data.PartOfSolution part = this.listPartOfSolution[i];
                    int p = part.Yrd - this.end;
                    part.Ylu = part.Ylu - p;
                    part.Yrd = part.Yrd - p;

                    if (part.Ylu < 0) return false;
                }
            }
            else //vertical
            {
                Console.Out.WriteLine("COFNIJ WARSTWE VERT end: "+this.end);
                for (int i = 0; i < this.listPartOfSolution.Count; ++i)
                {
                    Data.PartOfSolution part = this.listPartOfSolution[i];
                    int p = part.Xrd - this.end;
                    Console.Out.WriteLine("i: " + i + " p " + p);
                    part.Xlu = part.Xlu - p;
                    part.Xrd = part.Xrd - p;

                    if (part.Xlu < 0) return false;
                }
            }
            Console.Out.WriteLine("COFNIJ WARSTWE OK");
            return true;             
        }

    }
}

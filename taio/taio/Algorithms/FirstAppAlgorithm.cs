using System;
using System.Collections.Generic;
using System.Text;

namespace taio.Algorithms
{
    /**algorytm Uli*/
    class FirstAppAlgorithm : Algorithm
    {
        /**finds the solution*/
      
        private Data.Rectangle firstRectangle;
        private int a, b; //wymiary: szerokosc i wysokosc biezacego prostokata
        
        public override void StartAlgorithm() {   
            setFirst();
            while (this.Rectangles.Count > 0)
            {

            }
        }

        private Data.Rectangle findTheBiggest()
        {
            int area=0, nr = 0;
            for (int i = 0; i < this.Rectangles.Count; ++i)
            {
                int area1 = this.Rectangles[i].Width * this.Rectangles[i].Height;
                if (area1 > area)
                {
                    area = area1;
                    nr = i;
                }
            }
            Data.Rectangle rectangle = this.Rectangles[nr];
            this.Rectangles.RemoveAt(nr);
            return rectangle;
        }
        private void setFirst()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace taio.Algorithms
{
    /**algorytm Uli*/
    class FirstAppAlgorithm : Algorithm
    {
        private Data.Rectangle startRectangle;  //albo pierwsza warstwa moze byc startowyProstokat 
        private List<FirstAppAlgorithm1.Layer> listLayer;
        int w, h; //szerokosc i wysokosc biezacej konstrukcji (najglebsze wciecia zewnetrznych warstw)
        

        private List<Data.Rectangle> rectangles;////
        private List<Data.Rectangle> rectangles1;///
       
        public FirstAppAlgorithm(List<Data.Rectangle> rectangles) 
        {
            this.rectangles1 = rectangles;
            this.rectangles = new List<taio.Data.Rectangle>(rectangles);
            //kopiuje bo bede ja niszczyla
            this.listLayer = new List<FirstAppAlgorithm1.Layer>();
            
        }


        /**finds the solution*/        
        public override void StartAlgorithm() {
            this.startRectangle = findTheBiggest();
            while (this.buildNextLayer())
            {                
                Console.Out.WriteLine("warstwa ");
                break;
            }

        }


        //////////////////////////////////////////////////////////////////////
        private bool buildNextLayer()
        {
            Console.Out.WriteLine("przed budowaniem wartwy: "+rectangles.Count+" prostokatow");
            FirstAppAlgorithm1.Layer newLayer = new FirstAppAlgorithm1.Layer();
            bool res;
            if (this.w <= this.h) //decyzja czy pozioma czy pionowa warstwa
            {
                newLayer.Start = h;
                if(res = newLayer.constructVerticalLayer(this.rectangles))
                    h = newLayer.End;
             
            }
            else
            {
                newLayer.Start = w;
                if(res = newLayer.constructHorizontalLayer(this.rectangles))
                    w = newLayer.End;
            }

            if (res)
                this.listLayer.Add(newLayer);
            Console.Out.WriteLine("po budowaniu wartwy: " + rectangles.Count + " prostokatow");
            return res;
        }
        private Data.Rectangle findTheBiggest()
        {          

            int area = 0, nr = 0;
            for (int i = 0; i < this.rectangles.Count; ++i)
            {
                int area1 = this.Rectangles[i].Width * this.Rectangles[i].Height;
                if (area1 > area)
                {
                    area = area1;
                    nr = i;
                }
            }
            Data.Rectangle rectangle = this.rectangles[nr];

            Console.Out.WriteLine("StartRectangle: " + rectangle.Width + " : " + rectangle.Height);
            this.rectangles.RemoveAt(nr);
            return rectangle;
        }
    
    

    }
}

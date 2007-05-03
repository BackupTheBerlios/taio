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
        FirstAppAlgorithm1.Layer lastHorizontal, lastVertical;
        int w, h; //szerokosc i wysokosc biezacej konstrukcji (najglebsze wciecia zewnetrznych warstw)
        

        private List<Data.Rectangle> rectangles;////
        private List<Data.Rectangle> rectangles1;///
       
        public FirstAppAlgorithm() 
        {
            this.listLayer = new List<FirstAppAlgorithm1.Layer>();            
        }


        /**finds the solution*/        
        public override void StartAlgorithm() {

            this.rectangles1 = this.Rectangles ;
            this.rectangles = new List<taio.Data.Rectangle>(rectangles1);
            //kopiuje bo bede ja niszczyla


            setStartRectangle();
            this.sortRectangle();
            while (this.buildNextLayer())
            {                
                //Console.Out.WriteLine("warstwa ");
                //break;
            }
            Console.Out.WriteLine(); Console.Out.WriteLine("SOLUTION przed cofaniem warstw:");
            this.printSolutution();
            for (int i = 0; i < this.listLayer.Count; ++i)
                this.listLayer[i].moveBack(w, h);
            //if (lastHorizontal!=null) lastHorizontal.moveBackLastLayer(h);
            //if (lastVertical != null) lastVertical.moveBackLastLayer(w);

            this.saveSolution(); //zbiera partOfSolution z warstw w jedna liste w Algoritm.Solution

            Console.Out.WriteLine(); Console.Out.WriteLine("SOLUTION po cofaniu warstw:");
            this.printSolutution();
        }


        //////////////////////////////////////////////////////////////////////
        private bool buildNextLayer()
        {
            Console.Out.WriteLine("przed budowaniem wartwy: "+rectangles.Count+" prostokatow");
            FirstAppAlgorithm1.Layer newLayer = new FirstAppAlgorithm1.Layer();
            bool res;
            if (this.w <= this.h) //decyzja czy pozioma czy pionowa warstwa
            {
                Console.Out.WriteLine("Wartwa vertical");
                newLayer.Start = w;
                if (res = newLayer.constructVerticalLayer(this.rectangles, w, h))
                {
                    w = newLayer.End;
                    this.lastVertical = newLayer;
                }
            }
            else
            {
                Console.Out.WriteLine("Warstwa horizontal");
                newLayer.Start = h;
                if (res = newLayer.constructHorizontalLayer(this.rectangles, w, h))
                {
                    h = newLayer.End;
                    this.lastHorizontal = newLayer;
                }
            }

            if (res)
                this.listLayer.Add(newLayer);
            Console.Out.WriteLine("po budowaniu wartwy: " + rectangles.Count + " prostokatow");
            return res;
        }
        private void setStartRectangle()
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
            this.startRectangle = rectangle;
            this.w = rectangle.Width;
            this.h = rectangle.Height;
        }
        private void sortRectangle()
        {
            List<Data.Rectangle> listSorted = new List<taio.Data.Rectangle>();           
            for (int i = 0; i < rectangles.Count; ++i)
            {
                Data.Rectangle rect = rectangles[i];
                if (rect.Width < rect.Height)
                {
                    int k = rect.Width;
                    rect.Width = rect.Height;
                    rect.Height = k;
                }
                int j = 0;
                for (j = 0; j < listSorted.Count; ++j)
                {                    
                    if (listSorted[j].Width < rect.Width)
                    {
                        listSorted.Insert(j, rect);
                        break;
                    }
                    if(listSorted[j].Width == rect.Width 
                        && listSorted[j].Height < rect.Height )
                    {
                        listSorted.Insert(j, rect);
                        break;
                    }
                }
                if(j==listSorted.Count)
                    listSorted.Add(rect);
            }
            rectangles = listSorted;
            Console.Out.WriteLine("Sorted:");
            for (int j = 0; j < listSorted.Count; ++j)
            {
                Console.Out.WriteLine(listSorted[j].Width + " " + listSorted[j].Height);
            }
        }
        private void saveSolution()
        {
            Data.PartOfSolution part = new taio.Data.PartOfSolution();
            part.Xlu = 0;
            part.Ylu = 0;
            part.Xrd = this.startRectangle.Width;
            part.Yrd = this.startRectangle.Height;
            this.Solution.PartsOfSolution.Add(part);
            for (int i = 0; i < this.listLayer.Count; ++i)
            {
                for (int j = 0; j < this.listLayer[i].ListPartOfSolution.Count; ++j)
                {
                    this.Solution.PartsOfSolution.Add(this.listLayer[i].ListPartOfSolution[j]);
                }
            }         

        }
        private void printSolutution()
        {
            Console.Out.WriteLine("Startowy prostokat: " + this.startRectangle.Width + " : " + this.startRectangle.Height);
            Console.Out.WriteLine("Part[]: (0,0)  (" + this.startRectangle.Width + "," + this.startRectangle.Height + ")");
            for (int i = 0; i < this.listLayer.Count; ++i)
            {
                Console.Out.WriteLine("WArstwa nr: "+i+"  INFO: start "+this.listLayer[i].Start
                    +" end: "+this.listLayer[i].End+" lastEnd: "+ this.listLayer[i].LastPartEnd
                    + " end2: " + this.listLayer[i].End2);             
                for (int j = 0; j < this.listLayer[i].ListPartOfSolution.Count; ++j)
                {
                    Data.PartOfSolution part = this.listLayer[i].ListPartOfSolution[j];
                    Console.Out.WriteLine("Part[" + j + "]: ("
                        + part.Xlu + "," + part.Ylu + ")  (" + part.Xrd + "," + part.Yrd + ")");
                }
                
            }
        }


    }
}

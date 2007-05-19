using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace taio.Algorithms
{
    class FirstAppAlgorithm : Algorithm
    {
        private Thread firstThread;
        public Thread FirstThread
        {
            get { return firstThread; }
            set { firstThread = value; }
        }
        private bool endthread;

        private Data.Rectangle startRectangle;  //albo pierwsza warstwa moze byc startowyProstokat 
        private List<FirstAppAlgorithm1.Layer> listLayer;
        FirstAppAlgorithm1.Layer lastHorizontal, lastVertical;
        int w, h; //szerokosc i wysokosc biezacej konstrukcji (najglebsze wciecia zewnetrznych warstw)
        private List<Data.Rectangle> rectangles;
        //private List<Data.Rectangle> rectangles1;///

        public FirstAppAlgorithm()
        {
            this.listLayer = new List<FirstAppAlgorithm1.Layer>();
        }
        public override void StartAlgorithm()
        {
            this.endthread = false;
            firstThread = new Thread(new ThreadStart(startAlgorithm));
            firstThread.Start();
        }
        public override void StopAlgorithm()
        {
            this.endthread = true;
            firstThread.Abort();
            System.Console.WriteLine("stopAlgorithm first");
            //this.MainFrm.Engine.Solutions.Add(this.Solution);
            //this.refreshTab();
        }


        private void startAlgorithm()
        {
            copyRectangles(this.Rectangles);
            setStartRectangle();
            this.sortRectangle();
            while (!endthread && this.buildNextLayer())
            {
            }
            this.checkProportion();
            bool noLayerToDelate = true;
            while (true)
            {
                noLayerToDelate = true;
                for (int i = 0; i < this.listLayer.Count; ++i)
                {
                    FirstAppAlgorithm1.Layer layer = listLayer[i];
                    if (!layer.moveBack(w, h))
                    {
                        this.listLayer.RemoveAt(i);
                        for (int j = i; j < this.listLayer.Count; ++j)
                        {
                            if (this.listLayer[j].isHorizontal() == layer.isHorizontal())
                            {
                                this.listLayer[j].printInfo();
                                this.listLayer[j].moveStart(layer.End - layer.Start, layer.isHorizontal());
                                Console.Out.WriteLine("PO:");
                                this.listLayer[j].printInfo();
                            }
                        }
                        noLayerToDelate = false;
                        if (layer.isHorizontal())
                        {
                            h -= (layer.End - layer.Start);
                            Console.Out.WriteLine("ZM o: " + (layer.End - layer.Start)+
                                "na "+ h);
                        }
                        else
                        {
                            Console.Out.WriteLine("w: " +w);
                            w -= (layer.End - layer.Start);
                            Console.Out.WriteLine("ZM o: " + (layer.End - layer.Start)+
                                "na "+w);
                           
                        }
                        checkProportion();
                        break;
                         
                    }
                    //layer.test();
                    //layer.printInfo();
                }
                if (noLayerToDelate)
                   break;
                //Console.Out.WriteLine("!!PETLA NOLAYERTODELATE");
            }
            this.saveSolution(); //zbiera partOfSolution z warstw w jedna liste w Algoritm.Solution
            Console.Out.WriteLine("ROZW :" + w + " na " + h);
            this.MainFrm.Engine.Solutions.Add(this.Solution);
            this.refreshTab();
        }
        private void checkProportion()//warunek stosunku wymiarow
        {
            if ((w / h) > 2)
            {
                w = 2 * h;
                Console.Out.WriteLine("Zmiana szerokosci!!!!!!!!!!!!!!");
            }
            if (((double)w / (double)h) < 0.5)
            {
                h = (int) 2*w;
                Console.Out.WriteLine("Zmiana wysokosci!!!!!!!!!!!!!!");
            }
            return;
        }
        private void copyRectangles(List<Data.Rectangle> l)
        {
            this.rectangles = new List<Data.Rectangle>();
            IEnumerator<Data.Rectangle> e = l.GetEnumerator();
            while (e.MoveNext())
            {
                this.rectangles.Add(new Data.Rectangle(e.Current.Width, e.Current.Height));
            }
        }
        /*private int sortBySquare(Data.Rectangle x, Data.Rectangle y)
        {
            if (x.Height * x.Width == y.Height * y.Width) return 0;
            else if (x.Height * x.Width > y.Height * y.Width) return -1;
            else if (x.Height * x.Width < y.Height * y.Width) return 1;
            else throw new Exception("Comparing failed");
        }*/
        private int sortByLength(Data.Rectangle x, Data.Rectangle y)
        {
            int lx = x.Width, ly = y.Width;
            if (x.Height > lx) lx = x.Height;
            if (y.Height > ly) ly = y.Height;

            if (lx == ly) return 0;
            else if (lx > ly) return -1;
            else if (lx < ly) return 1;
            else throw new Exception("Comparing failed");
        }
        private void test()
        {
            Console.WriteLine();
            for (int i = 0; i < this.Solution.PartsOfSolution.Count; ++i)
            {
                Data.PartOfSolution p = this.Solution.PartsOfSolution[i];
                Console.WriteLine("new Rectangle(" +
                    p.Xlu + "," + p.Ylu + "," + (p.Xrd - p.Xlu) + "," + (p.Yrd - p.Ylu) +
                    "),");
            }
        }
        //////////////////////////////////////////////////////////////////////
        private bool buildNextLayer()
        {
            //Console.Out.WriteLine("przed budowaniem wartwy: "+rectangles.Count+" prostokatow");
            FirstAppAlgorithm1.Layer newLayer = new FirstAppAlgorithm1.Layer();
            bool res;
            if (this.w <= this.h) //decyzja czy pozioma czy pionowa warstwa
            {
                //Console.Out.WriteLine("Wartwa vertical");
                newLayer.Start = w;
                if (res = newLayer.constructVerticalLayer(this.rectangles, w, h))
                {
                    w = newLayer.End;
                    this.lastVertical = newLayer;
                }
            }
            else
            {
                //Console.Out.WriteLine("Warstwa horizontal");
                newLayer.Start = h;
                if (res = newLayer.constructHorizontalLayer(this.rectangles, w, h))
                {
                    h = newLayer.End;
                    this.lastHorizontal = newLayer;
                }
            }

            if (res)
                this.listLayer.Add(newLayer);
            //Console.Out.WriteLine("po budowaniu wartwy: " + rectangles.Count + " prostokatow");
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
                    if (listSorted[j].Width == rect.Width
                        && listSorted[j].Height < rect.Height)
                    {
                        listSorted.Insert(j, rect);
                        break;
                    }
                }
                if (j == listSorted.Count)
                    listSorted.Add(rect);
            }
            rectangles = listSorted;
            /*Console.Out.WriteLine("Sorted:");
            for (int j = 0; j < listSorted.Count; ++j)
            {
                Console.Out.WriteLine(listSorted[j].Width + " " + listSorted[j].Height);
            }*/
        }
        private void saveSolution()
        {
            this.Solution.PartsOfSolution = new List<taio.Data.PartOfSolution>();
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
                String dir = " Vert ";
                if (this.listLayer[i].isHorizontal()) dir = " Hor ";
                Console.Out.WriteLine("WArstwa nr: " + i + dir + "  INFO: start " + this.listLayer[i].Start
                    + " end: " + this.listLayer[i].End + " lastEnd: " + this.listLayer[i].LastPartEnd
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

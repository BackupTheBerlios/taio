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
        private int lastPartEnd; //w horizontal: wysuniecie na prawo,
                                 //w verical: wysuniecie do dolu
        private int end2; //"najdalsze wysuniecie"                

        public int End2
        {
            get { return end2; }
            set { end2 = value; }
        }

        public int LastPartEnd
        {
            get { return lastPartEnd; }
            set { lastPartEnd = value; }
        }

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
                {
                    Console.WriteLine("Zabraklo prostokatow by skonczyc warstwe");
                    return false; //moze cos lepiej
                }
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

                if (this.end == -1 || this.end > part.Yrd)//h + rect.Height) 
                    this.end = part.Yrd;// h + rect.Height;  //zapamietuje najglebsze wciecie!!!!!!
                this.lastPartEnd = part.Xrd;
                if (this.end2 < part.Yrd)
                    this.end2 = part.Yrd;
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
                {
                    Console.WriteLine("Zabraklo prostokatow by skonczyc warstwe");
                    return false; //moze cos lepiej
                }
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

                if (this.end == -1 || this.end > part.Xrd )// w + rect.Width)
                    this.end = part.Xrd;// w + rect.Width;  //zapamietuje najglebsze wciecie!!!!!!
                this.lastPartEnd = part.Yrd;
                if (this.end2 < part.Xrd)
                    this.end2 = part.Xrd;
            }
            return true;
        }
        //bedzie probowala cofnac warstwe do glebokosci "najg³ebszego wciecia",
        //moze sie okazac to niewykonalne, bo cofany prostokat bedzie wychodzil
        //poza konstruowany prostokat z drugiej strony
        public bool moveBackLastLayer(int pos)
        {
            //Console.Out.WriteLine("MBLL !!!!!! end2: "+end2+" pos "+pos );
            if (this.end2 <= pos)
                return true;
            if (this.directionOfLayer == direction.Horizontal)
            {
                //Console.Out.WriteLine("COFNIJ WARSTWE HORIZ");
                for (int i = 0; i < this.listPartOfSolution.Count; ++i)
                {
                    Data.PartOfSolution part = this.listPartOfSolution[i];
                    if (part.Yrd > pos)
                    {                        
                        int p = part.Yrd - pos;// this.end;
                        part.Ylu = part.Ylu - p;
                        part.Yrd = part.Yrd - p;
                        this.end2 = pos;
                        if (part.Ylu < 0) return false;
                    }
                }
            }
            else //vertical
            {
                //Console.Out.WriteLine("COFNIJ WARSTWE VERT end: "+pos);
                for (int i = 0; i < this.listPartOfSolution.Count; ++i)
                {                   
                    Data.PartOfSolution part = this.listPartOfSolution[i];
                    if (part.Xrd > pos)
                    {
                        int p = part.Xrd - pos;// this.end;
                        //Console.Out.WriteLine("i: " + i + " p " + p);
                        part.Xlu = part.Xlu - p;
                        part.Xrd = part.Xrd - p;
                        this.end2 = pos;
                        if (part.Xlu < 0) return false;
                    }
                }
            }
            //Console.Out.WriteLine("COFNIJ WARSTWE OK");
            return true;             
        }
        public void moveStart(int a, bool isHorizontal)
        {
            Console.WriteLine("movestart");
            if (isHorizontal == this.isHorizontal())
            {
                if (this.isHorizontal())
                {
                    Console.WriteLine("COFAM: elem" + this.listPartOfSolution.Count);
                    for (int i = 0; i < this.listPartOfSolution.Count; ++i)
                    {
                        Data.PartOfSolution part = this.listPartOfSolution[i];
                        part.Ylu -= a;
                        part.Yrd -= a;                       
                    }
                }
                else
                {
                    for (int i = 0; i < this.listPartOfSolution.Count; ++i)
                    {
                        Data.PartOfSolution part = this.listPartOfSolution[i];
                        part.Xlu -= a;
                        part.Xrd -= a;
                    }
                }
                this.start -= a;
                this.end -= a;
                this.end2 -= a;
            }
        }
        public bool moveBackVertical(int w,int h)
        {           
            if(!moveBackLastLayer(w))
                return false;
            if (this.lastPartEnd <= h)
                return true;            
            Data.PartOfSolution part = this.listPartOfSolution[this.listPartOfSolution.Count - 1];
            part.Ylu -= (this.lastPartEnd - h);
            part.Yrd -= (this.lastPartEnd - h);
            this.lastPartEnd = h;
            if (part.Ylu < 0)
                return false;
            //Console.WriteLine("COFback VER OK!!  o "+(this.lastPartEnd - h));          

            return true;
        }
        public bool moveBackHorizontal(int w,int h)
        {
            if(!moveBackLastLayer(h))
                return false;
            if (this.lastPartEnd <= w)
                return true;
            Data.PartOfSolution part = this.listPartOfSolution[this.listPartOfSolution.Count - 1];
            part.Xlu -= (this.lastPartEnd - w);
            part.Xrd -= (this.lastPartEnd - w);
            this.lastPartEnd = w;
            if (part.Xlu < 0)
                return false;
            //Console.WriteLine("COFback HOR OK!!  o " + (this.lastPartEnd - w));
           
            return true;
        }
        public bool moveBack(int w, int h)
        {
            if (this.directionOfLayer == direction.Horizontal)
                return this.moveBackHorizontal(w, h);
            else
                return this.moveBackVertical(w, h);                 
        }
        public bool isHorizontal()
        {
            return (this.directionOfLayer == direction.Horizontal);
        }
        public void printInfo()
        {
            System.Console.WriteLine("horiz: "+isHorizontal()+
                " start: "+start+" end: "+end+" end2: "+end2
                +" lastPEnd: "+lastPartEnd);
        }
        public void test()
        {
            /*
             * start, //poziom na którym ukladana jest warstwa
               end; // "najglebsze wciecie" warstwy
               lastPartEnd; //w horizontal: wysuniecie na prawo,
                                 //w verical: wysuniecie do dolu
               end2; //"najdalsze wysuniecie"    
            */ 
            if (isHorizontal())
            {
                for (int i = 0; i < this.listPartOfSolution.Count; ++i)
                {
                    Data.PartOfSolution p = this.listPartOfSolution[i];
                    if (p.Yrd < end)
                        System.Console.WriteLine("end");
                    if (p.Yrd > end2)
                        System.Console.WriteLine("end2");
                    if(p.Xrd > lastPartEnd)         
                        System.Console.WriteLine("lastPartEnd");
                    if(p.Ylu < start)              
                        System.Console.WriteLine("start");
                }
            }
            else
            {
                for (int i = 0; i < this.listPartOfSolution.Count; ++i)
                {
                    Data.PartOfSolution p = this.listPartOfSolution[i];
                    if (p.Xrd < end)
                        System.Console.WriteLine("end");
                    if (p.Xrd > end2)
                        System.Console.WriteLine("end2");
                    if(p.Yrd > lastPartEnd)         
                        System.Console.WriteLine("lastPartEnd");
                    if(p.Xlu < start)              
                        System.Console.WriteLine("start");
                }


            }
        }
    }
}

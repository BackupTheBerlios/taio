using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace taio.Algorithms
{
    class BrutalAlgorithm : Algorithm
    {
        private Thread brutalThread;
        // maciek
        public Thread BrutalThread
        {
            get { return brutalThread; }
            set { brutalThread = value; }
        }

        // end maciek
        
        private bool endthread;
        int liczSolution = 0;
        private bool[,] use; //wspolrzedne [y,x], informuje czy dany fragment prostokata
        //(y-1,x-1) na (y,x) jest pokryty przez ktorys z PartOfSolution

        //w tych dwoch listach ponizej zapamietuje jakie elementy tablicy use zostaly zmienione
        //poprzez dodanie kolejnych PartOfSolution, przy rekurencyjnym wywolaniu addNextRect kiedy chce zdjac ostatnio dolozony PartOfSolution
        //zmieniam w tablicy use tylko te elementy 
        private List<bool[,]> lastAddToUse;//(element z lastAddToUseXY to wspolrzedne umieszczenia lewego gornego rogu PartOfSolution,
        private List<int[]> lastAddToUseXY;// element z lastAddToUse to tablica o wymierach rectangle.width na rectangle.height,
        // mowiaca, ktory element dokladanej PartOfSolution wprowadzil zmiane w tablicy use z false na true 

        private List<Data.PartOfSolution> bestPartOfSolution; //najlepsze dotad znalezione rozwiazanie
        private int bestArea = 0; // pole tego rozwiazania

        private int sumOfArea; // suma pol wszystkich wejsciowych prostokatow 

        /**finds the solution*/
        public override void StartAlgorithm()
        {
            this.endthread = false;
            brutalThread = new Thread(new ThreadStart(startAlgorithm));
            brutalThread.Start();
        }
        public override void StopAlgorithm()
        {
            this.endthread = true;
            //if (brutalThread != null)
               // brutalThread.Abort();
            System.Console.WriteLine("stopAlgorithm brutal");
        }
        private void startAlgorithm()
        {
            this.endthread = false;
            this.lastAddToUse = new List<bool[,]>();
            lastAddToUseXY = new List<int[]>();
            this.Solution = new Data.Solution();

            sumOfArea = this.sumAreaOfRectangles();
            int sizeUse = this.sumLenghtOfRectangles() + 1;
            use = new bool[sizeUse, sizeUse];
            this.bestArea = 0;
            this.liczSolution = 0;
            List<int> list = new List<int>();
            int i = 0;
            while (i < this.Rectangles.Count)
            {
                list.Add(i);
                ++i;
            }
            this.generatePermutations<int>(list, this.Rectangles.Count);
            
            //this.Solution.PartsOfSolution = this.bestPartOfSolution;
            System.Console.WriteLine("koniec startAlgorithm");

            this.MainFrm.Engine.Solutions.Add(this.Solution);
            this.refreshTab();
            this.brutalThread.Abort();
            return;
        }
        //liczy sume pol prostokatow:
        private int sumAreaOfRectangles()
        {
            int sum = 0;
            for (int i = 0; i < this.Rectangles.Count; ++i)
            {
                sum += this.Rectangles[i].Width * this.Rectangles[i].Height;
            }
            return sum;
        }

        //liczy sume dlugoœci dluzszych bokow prostokatow:
        private int sumLenghtOfRectangles()
        {
            int length = 0;
            for (int i = 0; i < this.Rectangles.Count; ++i)
            {
                int l = this.Rectangles[i].Width;
                if (this.Rectangles[i].Height > l)
                    l = this.Rectangles[i].Height;
                length += l;
            }
            return length;
        }

        private void printPart(List<Data.PartOfSolution> listPart)
        {
            for (int j = 0; j < listPart.Count; ++j)
            {
                Data.PartOfSolution part = listPart[j];
                Console.Out.Write(" Part[" + j + "]: ("
                        + part.Xlu + "," + part.Ylu + ")  (" + part.Xrd + "," + part.Yrd + ")  ");
            }
            Console.Out.WriteLine();

            //drukowanie tablicy use:
            /*for (int i = 0; i < use.GetLength(0); ++i)
            {
                for (int j = 0; j < use.GetLength(1); ++j)
                {
                    if (use[i, j] == true)
                        Console.Write("1,");
                    else
                        Console.Write("0,");
                }
                Console.WriteLine();
            }
            Console.WriteLine();*/

        }

        //wywolywana kiedy usuwamy z listy PartOfSolution ostatnio dolozona PartOfSolution,
        //zmieniania w tablicy use z true na false te elementy, ktore byly pokryte przez te zdejmowana PartOfSolution   
        private void takeFromUse()
        {
            for (int i = 0; i < this.lastAddToUse[this.lastAddToUse.Count - 1].GetLength(0); ++i)//H; ++i)
            {
                for (int j = 0; j < this.lastAddToUse[this.lastAddToUse.Count - 1].GetLength(1); ++j)//W; ++j)
                {
                    if (this.lastAddToUse[this.lastAddToUse.Count - 1][i, j] == true)
                    {
                        use[i + lastAddToUseXY[this.lastAddToUseXY.Count - 1][1],
                            j + lastAddToUseXY[this.lastAddToUseXY.Count - 1][0]] = false;
                    }
                }
            }
            this.lastAddToUse.RemoveAt(this.lastAddToUse.Count - 1);
            this.lastAddToUseXY.RemoveAt(this.lastAddToUseXY.Count - 1);
        }
        private bool addToUse(Data.PartOfSolution part)
        {
            bool ret = false;
            int lastAddToUseX = part.Xlu;
            int lastAddToUseY = part.Ylu;
            int lastAddToUseW = part.Xrd - part.Xlu;
            int lastAddToUseH = part.Yrd - part.Ylu;

            bool[,] lastUse = new bool[lastAddToUseH, lastAddToUseW];
            for (int i = 0; i < lastAddToUseH; ++i)
            {
                for (int j = 0; j < lastAddToUseW; ++j)
                {
                    if (use[i + lastAddToUseY, j + lastAddToUseX] == false)
                    {
                        use[i + lastAddToUseY, j + lastAddToUseX] = true;
                        lastUse[i, j] = true;
                        ret = true;
                    }
                }
            }
            int[] tab = { lastAddToUseX, lastAddToUseY };
            if (ret) lastAddToUseXY.Add(tab);
            if (ret) lastAddToUse.Add(lastUse);
            return ret;
        }
        private bool ifIsNeighbour(Data.PartOfSolution part)
        {
            int startX = part.Xlu;
            int startY = part.Ylu;
            if (startX > 0) startX -= 1;
            if (startY > 0) startY -= 1;
            for (int i = startY; i < part.Yrd + 1; ++i)
            {
                for (int j = startX; j < part.Xrd + 1; ++j)
                {
                    if (use[i, j] == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // wywolywana rekurencyjnie dodaje kolejne prostokaty
        private void addNextRect(int[] permutation, List<Data.PartOfSolution> listPart, int countRect, int wMax, int hMax)
        {
            if (wMax * hMax > this.sumOfArea)
            {
                //Console.WriteLine("TNE!");
                return;//suma pol prostokatow jest mniejsza niz pole potencjalnego rozwiazania
                //nie jest mozliwe pokrycie prostokata o wymiarach wMax na hMax danymi prostokatami 
            }
            if (countRect == Rectangles.Count)
                return; //ulozono juz wszystkie prostokaty w danej permutacji

            Data.Rectangle rect = Rectangles[permutation[countRect]];
            int wMax1 = wMax, hMax1 = hMax, //nowe parametry wywolania addNextRect
                wMax2 = wMax, hMax2 = hMax; //nowe parametry wywolania addNextRect dla obroconego o 90stopni  prostokata 


            for (int i = 0; i <= wMax; ++i) //posX 
            {
                for (int j = 0; j <= hMax; ++j) //posY
                {
                    if (endthread)
                    {
                        System.Console.WriteLine("przerywam Addrect");
                        return;
                    }
                    Data.PartOfSolution part = new taio.Data.PartOfSolution();

                    //Console.Out.WriteLine("Probuje dodac prostokat nr " + nrRect + " na pozycji " + i + " : " + j);
                    part.Xlu = i;
                    part.Ylu = j;
                    part.Xrd = i + rect.Width;
                    part.Yrd = j + rect.Height;

                    /* jesli jest to pierwszy ukladany prostokat lub jesli nowy part sasiaduje z poprzednimi
                       i jesli dodanie part zmienia cos w tablicy use tzn. nowa part nie zawiera sie calkowicie w juz istniejacych */
                    if ((listPart.Count == 0 || this.ifIsNeighbour(part))
                        && this.addToUse(part))
                    {
                        listPart.Add(part);
                        //printPart(listPart);                        
                        if (wMax1 < part.Xrd)
                            wMax1 = part.Xrd;
                        if (hMax1 < part.Yrd)
                            hMax1 = part.Yrd;

                        isBestSolution(wMax1, hMax1, listPart); //jesli tak to zapamietuje
                        addNextRect(permutation, listPart, countRect + 1, wMax1, hMax1);
                        listPart.RemoveAt(countRect);
                        this.takeFromUse();
                    }
                    //else
                    //    Console.Out.WriteLine("!!!!!!!!!!!!!!!!!!!NIE");                    


                    //nizej obrocony o 90 stopni:
                    if ((listPart.Count == 0 || this.ifIsNeighbour(part)) &&
                       rect.Height != rect.Width && this.addToUse(part))
                    {
                        part = new taio.Data.PartOfSolution();
                        part.Xlu = i;
                        part.Ylu = j;
                        part.Xrd = i + rect.Height;
                        part.Yrd = j + rect.Width;

                        listPart.Add(part);
                        //printPart(listPart);                      

                        if (wMax2 < part.Xrd)
                            wMax2 = part.Xrd;
                        if (hMax2 < part.Yrd)
                            hMax2 = part.Yrd;
                        isBestSolution(wMax2, hMax2, listPart); //jesli tak to zapamietuje
                        addNextRect(permutation, listPart, countRect + 1, wMax2, hMax2);
                        listPart.RemoveAt(countRect);
                        this.takeFromUse();
                    }
                    //else
                    //    Console.Out.WriteLine("!!!!!!!!!!!!NIE");

                }
            }

        }
        private void isBestSolution(int width, int height, List<Data.PartOfSolution> listPart)
        {
            if (!(width / height <= 2) ||
                !(((double)width / (double)height) >= 0.5))//warunek stosunku wymiarow
            {
                //Console.WriteLine("NIE stosunek: "+((double)width / (double)height));
                return;
            }
            int area = width * height;
            if (area <= this.bestArea)
                return;
            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                {
                    if (use[j, i] == false)
                        return;
                }
            this.bestPartOfSolution = new List<taio.Data.PartOfSolution>(listPart);
            this.bestArea = area;
            Console.WriteLine("!!!!!!!!!!NOWE SOLUTION!!!!!!!!!!!");
            this.printPart(listPart);
            liczSolution++;
            this.Solution = new Data.Solution();
            this.Solution.PartsOfSolution = this.bestPartOfSolution;
            //this.MainFrm.Engine.Solutions.Add(this.Solution);
            //this.refreshTab();
            
            //if (liczSolution == 3) endthread = true;
            return;
        }
        //wywoluje addNextRect dla kazdej wygenerowanej permutacji prostokatow
        private void generatePermutations<T>(IEnumerable<T> input, int count)
        {
            foreach (IEnumerable<T> permutation in FirstAppAlgorithm1.PermuteUtils.Permute<T>(input, count))
            {
                List<Data.PartOfSolution> listPartOfSolution = new List<taio.Data.PartOfSolution>();
                int[] permutationTab = new int[Rectangles.Count];
                int k = 0;
                foreach (T ii in permutation)
                {
                    //Console.Write(" " + ii.ToString());
                    int i = int.Parse(ii.ToString());
                    permutationTab[k] = i;
                    ++k;
                }
                //Console.WriteLine();        
                addNextRect(permutationTab, listPartOfSolution, 0, 0, 0);
                if (endthread) break;
            }
            System.Console.WriteLine("koniec generatePermutations");
        }
        
    
    }
}

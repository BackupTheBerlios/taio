/* G³owna klasa aplkacji(engin), tutaj bedie cala funkcioanlnosc */ 

using System;

using System.Collections.Generic;

using System.Text;



namespace taio

{

    class main

    {

        private Data.DataLoader dataLoader; // obiekt wczytujacy i trzymajacy dane z pliku

        private List<Data.Rectangle> rectangles; //prostokaty na ktorych dzialaja algorytmy, moze to byc inny zbior niz wczytany z pliku np zedytowany

        private List<Data.Solution> solutions; // litsta z gotowymi rozwiazaniami 

        private String fileName;

        private bool isFromFile; //czy dane były wczytywane z pliku,, czy utworzone w programie

        private String dataInfo; //info wczytane z pliku



        #region getters and setters



        public Data.Solution getSolution(int index)

        {

            return this.solutions[index];

        }

        

        public List<Data.Solution> Solutions

        {

            get { return solutions; }

            set { solutions = value; }

        }



        public List<Data.Rectangle> Rectangles

        {

            get { return rectangles; }

            set { rectangles = value; }

        }



        public String FileName

        {

            get { return fileName; }

            set { fileName = value; }

        }



        public bool IsFromFile

        {

            get { return isFromFile; }

            set { isFromFile = value; }

        }



        public String DataInfo

        {

            get { return dataInfo; }

            set { dataInfo = value; }

        }



        #endregion



        public main(taio.MainFrm mainFrm)

        {

            this.dataLoader = new taio.Data.DataLoader(this);

            this.solutions = new List<Data.Solution>();

            fileName = "";

        }

    

    

    

    // wczytuje dane w obiekcie dataLoader

        public void loadData(String path)

        {

            if (path == null || path.Length == 0)

                return;

            fileName = path;

            this.dataLoader.loadData(path);

            this.isFromFile = true;

        }



        public void WriteData()

        {

            dataLoader.WriteData(this);

        }

    }

}


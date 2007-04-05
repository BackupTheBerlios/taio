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


        public List<Data.Rectangle> Rectangles
        {
            get { return rectangles; }
            set { rectangles = value; }
        }

        public main(taio.MainFrm mainFrm)
        {
            this.dataLoader = new taio.Data.DataLoader(this);
        }
    
    
    
    // wczytuje dane w obiekcie dataLoader
        public void loadData(String path)
        {
            this.dataLoader.loadData(path);
        }
    }
}

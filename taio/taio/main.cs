/* G³owna klasa aplkacji(engin), tutaj bedie cala funkcioanlnosc */ 
using System;
using System.Collections.Generic;
using System.Text;

namespace taio
{
    class main
    {
        private Data.DataLoader dataLoader; // obiekt wczytujacy i trzymajacy dane z pliku

        public main(taio.MainFrm mainFrm)
        {
            this.dataLoader = new taio.Data.DataLoader();
        }
    
    
    
    // wczytuje dane w obiekcie dataLoader
        public void loadData(String path)
        {
            this.dataLoader.loadData(path);
        }
    }
}

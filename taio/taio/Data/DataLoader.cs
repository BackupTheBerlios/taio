/* klasa do wczytywania danych wejsciowych z pliku */ 
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;

namespace taio.Data
{
    /**reads data from file*/
   
   
    class DataLoader
    {
        private String[] info;
        private String[] input;  // tablica z prostokatami wejœciowymi, stringi w formacie „int,int”
        private String[] result; // tablica z gotowymi rozwiazaniami, stringi w formacie „tagm \r\n int,int,int,int \r\n … int,int,int,int \r\n”

        private main engine;

        public DataLoader(main engine)
        {
            this.engine = engine; //do listy rectangle z engine wczytane zostana prostokaty
         }
       

// wczytuje dane
        public void loadData(String path)
        {
            StreamReader reader;
            String content;  // cala zawartosc tekstowa pliku
            Regex patern;
            Match m;
            CaptureCollection tab; // kolekcja wierszy wczytanych z danej grupy: <info> lub <input> lub <result> 

            if (path != null)
            {
                reader = File.OpenText(path);
                content = reader.ReadToEnd();
                reader.Close();

                patern = new Regex("##\r\n(?<info>(.|\r|\n)*?)\r\n##\r\n(?<input>([0-9]*,[0-9]*)\r\n)*##\r\n(#(?<result>(.){0,4}\r\n([0-9]*,[0-9]*,[0-9]*,[0-9]*(\r\n)?)*))*");
                m = patern.Match(content);

                if (m.Success)
                {
                    // wczytuje dane do tablicy info
                    tab = m.Groups["info"].Captures;
                    this.info = new string[tab.Count];
                    this.captureToStringTab(this.info, tab);

                    // wczytuje dane do tablicy input
                    tab = m.Groups["input"].Captures;
                    this.input = new string[tab.Count];
                    this.captureToStringTab(this.input, tab);

                    // wczytuje dane do tablicy result
                    tab = m.Groups["result"].Captures;
                    this.result = new string[tab.Count];
                    this.captureToStringTab(this.result, tab);
                    
                    
                    this.createRectangles();                   
                }
                else
                {
                    throw new Exception("Nieprawid³owy format pliku");
                }
          
            }
        }
    // wczytuje wiersze z odpowiedniej grupy(tab) do odpowiedniej tablicy info(dest),input(dest) lub result(dest)
        private void captureToStringTab(String[] dest, CaptureCollection tab)
        {
            int i = 0;

            foreach (Capture capt in tab)
            {
                dest[i] = capt.Value;
                i++;
            }
        }

        //tworzy liste prostok¹tow na podstawie tablicy input
        private void createRectangles()
        {
            List<Rectangle> rectangles = new List<Rectangle>();
            for (int i = 0; i < input.Length; i++)
            {
                int w,h;                
                try
                {
                    String[] s = input[i].Split(',');
                    w = int.Parse(s[0]);
                    h = int.Parse(s[1]);
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine("Nieprawidlowy format danych wejsciowych "+e.ToString());
                    break;
                }
                Rectangle rect = new Data.Rectangle(w,h);               
                rectangles.Add(rect);              
            }
            engine.Rectangles = rectangles;
        }
    
    }
}

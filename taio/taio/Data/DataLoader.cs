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
        private String[] input;  // tablica z prostokatami wejściowymi, stringi w formacie "int,int" + ostatni wiersz pusty string "" 
        private String[] result; // tablica z gotowymi rozwiazaniami, stringi w formacie - "tag/r/n (int,int,int,int/r/n)*" + pierwszy wiersz pusty string ""

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
            Capture cap; // wiersze wczytane z danej grupy: <info> lub <input> lub <result> 

            if (path != null)
            {
                reader = File.OpenText(path);
                content = reader.ReadToEnd();
                reader.Close();

                patern = new Regex("##\r\n(?<info>(.|\r|\n)*?)\r\n##\r\n(?<input>(([0-9]*,[0-9]*)\r\n)*)##\r\n(?<result>(#((.)*\r\n([0-9]*,[0-9]*,[0-9]*,[0-9]*(\r\n)?)*))*)");
                m = patern.Match(content);

                if (m.Success)
                {
                    // wczytuje dane do tablicy info
                    cap = m.Groups["info"].Captures[0];
                    this.info = cap.Value.Split('\n');
                    engine.DataInfo = cap.Value;

                    // wczytuje dane do tablicy input
                    cap = m.Groups["input"].Captures[0];
                    this.input = cap.Value.Split('\n');

                    // wczytuje dane do tablicy result
                    cap = m.Groups["result"].Captures[0];
                    this.result = cap.Value.Split('#');
                    
                    this.createRectangles();
                    this.createSolution();
                }
                else
                {
                    throw new Exception("Nieprawidłowy format pliku");
                }
          
            }
        }

        //tworzy liste prostokątow na podstawie tablicy input
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
    // tworzy gotowe rozwiazania z tablicy result i umieszcza w liscie solutions w enginie;
        private void createSolution()
        {
            String[] resRows,coordinates;
            Data.Solution solution;
            Data.PartOfSolution partOfSolution;
            bool flag = true;  // flaga jest ustawiana na true zawsze przed czytaniem nastepnego rozw., a na false po przeczytaniu pierwszego wiersza w rozw. ktory jest tagiem
            
            // dla kazdego rozwiazania
            foreach (String res in this.result)
                if (res != "")
                {
                    solution = new Solution(true);
                    resRows = res.Split('\n');

                    // dla kazdego wiersza w danym rozwiazaniu
                    foreach (String row in resRows)
                        if (row != "")
                        {
                            // jezeli w wierszu jest tag
                            if (flag)
                            {
                                solution.Tag = row;
                                flag = false;
                            }
                            // jezeli w wierszu sa wspolrzedne
                            else
                            {
                                partOfSolution = new PartOfSolution();

                                // wpisanie odpowienich wspolrzednych do partOfSolution i dodanie do do solution
                                coordinates = row.Split(',');
                                // x1
                                partOfSolution.Xlu = int.Parse(coordinates[0]);
                                // y1
                                partOfSolution.Ylu = int.Parse(coordinates[1]);
                                // x2
                                partOfSolution.Xrd = partOfSolution.Xlu + int.Parse(coordinates[2]);
                                // y2
                                partOfSolution.Yrd = partOfSolution.Ylu + int.Parse(coordinates[3]);

                                solution.PartsOfSolution.Add(partOfSolution);
                            }
                          }   
                  this.engine.Solutions.Add(solution);
                  flag = true;
               }
       }

        public void WriteData(main data)
        {
            String line = null;
            int width, height;
            StreamWriter wr = new StreamWriter(File.Open(data.FileName, FileMode.Append));
            if (!data.IsFromFile)
            {
                wr.Close();
                wr = new StreamWriter(File.Open(data.FileName, FileMode.Create));
            }
            if (!data.IsFromFile)
            //zapisz dane wejściowe
            {
                wr.WriteLine("##");
                wr.WriteLine(engine.DataInfo);
                wr.WriteLine("##");
                foreach (Rectangle rect in engine.Rectangles)
                {
                    line = rect.Width + "," + rect.Height;
                    wr.WriteLine(line);
                }
                wr.WriteLine("##");
            }
            //zapisz rowiązania, które nie sa z pliku
            foreach (Solution solution in data.Solutions)
            {
                if (solution.IsFromFile) continue;

                line = "#" + solution.Tag; wr.WriteLine(line);

                foreach (PartOfSolution part in solution.PartsOfSolution)
                {
                    line = "";
                    width = part.Xrd - part.Xlu;
                    height = part.Yrd - part.Ylu;
                    line += part.Xlu + "," + part.Ylu + ",";
                    //wersja 1
                    //line += part.Xrd + "," + part.Yrd;
                    //wersja 2
                    line += width + "," + height;
                    wr.WriteLine(line);
                }
            }

            wr.Close();
            data.IsFromFile = true;
        }

    }
}


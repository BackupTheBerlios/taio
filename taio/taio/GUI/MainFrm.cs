using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace taio
{
    public partial class MainFrm : Form
    {
        private main engine; // glowna klasa programu

        internal main Engine
        {
            get { return engine; }
            set { engine = value; }
        }

    
        private GUI.SolutionsFrm solutionsFrm;

        public MainFrm()
        {
            InitializeComponent();
            this.engine = new main(this);
            
        }

        private void MainFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void wczytajDaneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            String filePath = null;
           
            try
            {
                // pobiera nazwe pliku z danymi     
                openFileDialog.Filter = "data files (*.data)|*.data|All files (*.*)|*.*";
                openFileDialog.Title = "Wybierz plik z danymi.";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    filePath = openFileDialog.FileName;
                
                // wywolanie odp. funk. z enginu
                this.statusStrip1.Items[0].Text = "Wczytuje dane...";
                this.statusStrip1.Refresh();
                Cursor.Current = Cursors.WaitCursor;
                
                this.engine.loadData(filePath);
                Console.Out.WriteLine("PATH: "+filePath);
                Cursor.Current = Cursors.Default;
                this.statusStrip1.Items[0].Text = "Bezczynny";
                this.statusStrip1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                this.statusStrip1.Items[0].Text = "Bezczynny";
                this.statusStrip1.Refresh();
            }
        }



        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        
        }

        private void BrutalAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Algorithms.Algorithm algorithm = new Algorithms.BrutalAlgorithm();
            if (engine.Rectangles == null)
            {
                MessageBox.Show("Brak prostok�t�w wejsciowych");
                return;
            }
            algorithm.Rectangles = engine.Rectangles;
            algorithm.StartAlgorithm();
            //Data.Solution sol  = new taio.Data.Solution();
            //sol.PartsOfSolution = algorithm.
            engine.Solutions = new List<taio.Data.Solution>();
            engine.Solutions.Add(algorithm.Solution);

        }

        private void SecondAppAlgorithmToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Algorithms.Algorithm algorithm = new Algorithms.SecondAppAlgorithm();
            /*begin of tests*/
            algorithm.StartAlgorithm();
            return;
            /*end of tests*/
            if (engine.Rectangles == null)
            {
                
                MessageBox.Show("Brak prostok�t�w wejsciowych");
                return;
            }
            algorithm.Rectangles = engine.Rectangles;
            algorithm.StartAlgorithm();

        }

        private void FirstAppAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.engine.loadData("daneTaio.data");//("C:\\Documents and Settings\\ula\\Pulpit\\TAIO\\taio\\taio\\bin\\Debug\\daneTaio.txt");
            if (engine.Rectangles == null)
            {
                MessageBox.Show("Brak prostok�t�w wejsciowych");
                return;
            }
            Algorithms.Algorithm algorithm = new Algorithms.FirstAppAlgorithm();
            algorithm.Rectangles = engine.Rectangles;
            algorithm.StartAlgorithm();
        }

        private void poka�Rozwi�zaniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            try
            {
                // jezeli s� rozwiazania
                if(this.engine.Solutions.Count>0)
                {
                   // jezeli okno rozwiazan nie jest uz otwarte
                   if (GUI.SolutionsFrm.counter == 0)
                   {

                    this.solutionsFrm = new taio.GUI.SolutionsFrm(this);
                    this.solutionsFrm.MdiParent = this;
                    this.solutionsFrm.Show();
                   }
                }
                else
                MessageBox.Show("Brak rozwi�za�","Informacja",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
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
        private main engine; // glowan klasa programu

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
                MessageBox.Show(ex.ToString(), "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Brak prostok¹tów wejsciowych");
                return;
            }
        }

        private void SecondAppAlgorithmToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Algorithms.Algorithm algorithm = new Algorithms.SecondAppAlgorithm();
            if (engine.Rectangles == null)
            {
                MessageBox.Show("Brak prostok¹tów wejsciowych");
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
                MessageBox.Show("Brak prostok¹tów wejsciowych");
                return;
            }
            Algorithms.Algorithm algorithm = new Algorithms.FirstAppAlgorithm();
            algorithm.Rectangles = engine.Rectangles;
            algorithm.StartAlgorithm();
        }

        private void poka¿Rozwi¹zaniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TESTY
            try
            {
                List<Data.Solution> solutions = this.engine.Solutions;
                List<Data.Rectangle> rectangles = this.engine.Rectangles;
                MessageBox.Show(solutions.Count.ToString()+ " " + rectangles.Count.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // End TESTY
        }
    }
}
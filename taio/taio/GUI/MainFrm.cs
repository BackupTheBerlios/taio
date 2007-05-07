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
        private GUI.RandomDataFrm randomDataFrm;
        private GUI.EditDataFrm editDataFrm;

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
                {
                    filePath = openFileDialog.FileName;
                    MessageBox.Show("Dane wczytano", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    return;
                // wywolanie odp. funk. z enginu
                this.statusStrip1.Items[0].Text = "Wczytuje dane...";
                this.statusStrip1.Refresh();
                Cursor.Current = Cursors.WaitCursor;
                if (this.engine.Rectangles != null)
                this.engine.Rectangles.Clear();
                this.engine.Solutions.Clear();
                this.engine.loadData(filePath);
                editRectangles();
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

        private void BrutalAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Algorithms.Algorithm algorithm = new Algorithms.BrutalAlgorithm();
            if (engine.Rectangles == null)
            {
                MessageBox.Show("Brak prostok¹tów wejsciowych");
                return;
            }
            algorithm.Rectangles = engine.Rectangles;
            algorithm.StartAlgorithm();
            algorithm.Solution.Tag = "Algorytm brutalny";
            engine.Solutions.Add(algorithm.Solution);
            this.showSolutions();
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
            algorithm.Solution.Tag = "Algorytm drugi";
            engine.Solutions.Add(algorithm.Solution);
            this.showSolutions();
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
            algorithm.Solution.Tag = "Algorytm pierwszy";
            engine.Solutions.Add(algorithm.Solution);
            this.showSolutions();
        }

        private void poka¿Rozwi¹zaniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            try
            {
                this.showSolutions();   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void showSolutions()
        {
            // jezeli s¹ rozwiazania
            //MessageBox.Show(engine.Solutions[0].PartsOfSolution.Count.ToString());
            if (this.engine.Solutions.Count > 0 && engine.Solutions[0].PartsOfSolution != null)
            {
                // jezeli okno rozwiazan nie jest uz otwarte
                if (GUI.SolutionsFrm.counter == 0)
                {

                    this.solutionsFrm = new taio.GUI.SolutionsFrm(this);
                    this.solutionsFrm.MdiParent = this;
                    this.solutionsFrm.Show();
                }
                else
                {
                    solutionsFrm.CreateTabs();
                    solutionsFrm.Invalidate();
                    solutionsFrm.Update();
                }
            }
            else
                MessageBox.Show("Brak rozwi¹zañ", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void zapiszDaneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.engine.Rectangles != null && this.engine.Rectangles.Count > 0)
                {
                    if (engine.IsFromFile)
                    {
                        this.engine.WriteData();
                        MessageBox.Show("Dane zapisano w pliku:\n" + engine.FileName, "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (!engine.IsFromFile)
                    {
                        SaveFileDialog save = new SaveFileDialog();
                        save.Filter = "data files (*.data)|*.data|All files (*.*)|*.*";
                        save.Title = "Wybierz nazwe pliku.";
                        if (save.ShowDialog() == DialogResult.OK)
                        {
                            this.engine.FileName = save.FileName;
                            this.engine.WriteData();
                            MessageBox.Show("Dane zapisano w pliku:\n" + engine.FileName, "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                    MessageBox.Show("Brak danych", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void losujDaneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GUI.RandomDataFrm.counter == 0)
            {

                this.randomDataFrm = new taio.GUI.RandomDataFrm(this);
                this.randomDataFrm.MdiParent = this;
                this.randomDataFrm.Show();
            }
        }

        private void edytujDaneToolStripMenuItem_Click(object sender, EventArgs e)
        {
          editRectangles();
        }
        private void editRectangles()
        {
          if ((this.engine.Rectangles != null) && (this.engine.Rectangles.Count > 0))
            {
              
                if (GUI.EditDataFrm.counter == 0)
                {

                    this.editDataFrm = new taio.GUI.EditDataFrm(this);
                    this.editDataFrm.MdiParent = this;
                    this.editDataFrm.Show();
                }
            }
            else
                MessageBox.Show("Brak prostok¹tów wejœciowych", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        }
    }
}
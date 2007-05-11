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

    
        internal GUI.SolutionsFrm solutionsFrm;
        internal GUI.RandomDataFrm randomDataFrm;
        internal GUI.EditDataFrm editDataFrm;

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
               if (Engine.Rectangles != null)
                if (Engine.Rectangles.Count > 0 || Engine.Solutions.Count > 0)
                    if (MessageBox.Show("Istniej�ce w pami�ci prostok�ty zostan� nadpisane,\na rozwi�zania skasowane !\nKontynuowa�?", "Ostrze�enie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return;
                // pobiera nazwe pliku z danymi     
                openFileDialog.Filter = "data files (*.data)|*.data|txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.Title = "Wybierz plik z danymi.";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
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
                if (editDataFrm != null && editDataFrm.Visible)
                    editDataFrm.Close();
                if (randomDataFrm != null && randomDataFrm.Visible)
                    randomDataFrm.Close();
                if (solutionsFrm != null && solutionsFrm.Visible)
                    solutionsFrm.Close();
                editRectangles();
                Cursor.Current = Cursors.Default;
                this.statusStrip1.Items[0].Text = "Bezczynny";
                this.statusStrip1.Refresh();
                MessageBox.Show("Dane wczytano", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Brak prostok�t�w wejsciowych");
                return;
            }
            algorithm.Rectangles = engine.Rectangles;
            this.statusStrip1.Items[0].Text = "Oblicza - algorytm brutalny...";
            this.statusStrip1.Refresh();
            Cursor.Current = Cursors.WaitCursor;
            DateTime t1 = DateTime.Now;
            
            algorithm.StartAlgorithm();
          
            DateTime t2 = DateTime.Now;
            TimeSpan t = t2 - t1;
            Cursor.Current = Cursors.Default;
            this.statusStrip1.Items[0].Text = "Bezczynny";
            this.statusStrip1.Refresh();
            algorithm.Solution.Tag = "Algorytm brutalny " + t.ToString();
            if (algorithm.Solution.PartsOfSolution.Count > 0)
                engine.Solutions.Add(algorithm.Solution);
            this.showSolutions();
        }

        private void SecondAppAlgorithmToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Algorithms.Algorithm algorithm = new Algorithms.SecondAppAlgorithm();

            if (engine.Rectangles == null)
            {
                
                MessageBox.Show("Brak prostok�t�w wejsciowych");
                return;
            }
            algorithm.Rectangles = engine.Rectangles;
            this.statusStrip1.Items[0].Text = "Oblicza - algorytm drugi...";
            this.statusStrip1.Refresh();
            Cursor.Current = Cursors.WaitCursor;
            DateTime t1 = DateTime.Now;
          
            algorithm.StartAlgorithm();
            
            DateTime t2 = DateTime.Now;
            TimeSpan t = t2 - t1;
            Cursor.Current = Cursors.Default;
            this.statusStrip1.Items[0].Text = "Bezczynny";
            this.statusStrip1.Refresh();
            algorithm.Solution.Tag = "Algorytm drugi "+ t.ToString();
            if (algorithm.Solution.PartsOfSolution.Count > 0)
                engine.Solutions.Add(algorithm.Solution);
            this.showSolutions();
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
            this.statusStrip1.Items[0].Text = "Oblicza - algorytm pierwszy...";
            this.statusStrip1.Refresh();
            Cursor.Current = Cursors.WaitCursor;
            DateTime t1 = DateTime.Now;
            algorithm.StartAlgorithm();
            DateTime t2 = DateTime.Now;
            TimeSpan t = t2 - t1;
            Cursor.Current = Cursors.Default;
            this.statusStrip1.Items[0].Text = "Bezczynny";
            this.statusStrip1.Refresh();
            algorithm.Solution.Tag = "Algorytm pierwszy "+ t.ToString();
            if (algorithm.Solution.PartsOfSolution.Count > 0)
                engine.Solutions.Add(algorithm.Solution);
            this.showSolutions();
        }

        private void poka�Rozwi�zaniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            try
            {
                this.showSolutions();   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void showSolutions()
        {
            // jezeli s� rozwiazania
            //MessageBox.Show(engine.Solutions[0].PartsOfSolution.Count.ToString());
            if (this.engine.Solutions.Count > 0 )
            {
                this.statusStrip1.Items[0].Text = "Generuje rozwi�zania...";
                this.statusStrip1.Refresh();
                Cursor.Current = Cursors.WaitCursor;
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
                Cursor.Current = Cursors.Default;
                this.statusStrip1.Items[0].Text = "Bezczynny";
                this.statusStrip1.Refresh();
            }
            else
                MessageBox.Show("Brak rozwi�za�", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        save.Filter = "data files (*.data)|*.data|txt files (*.txt)|*.txt|All files (*.*)|*.*";
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
                MessageBox.Show(ex.ToString(), "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Brak prostok�t�w wej�ciowych", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        }
    }
}
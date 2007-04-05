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
            algorithm.Rectangle = engine.Rectangles;
            algorithm.StartAlgorithm();

        }

        private void FirstAppAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Algorithms.Algorithm algorithm = new Algorithms.FirstAppAlgorithm();
            if (engine.Rectangles == null)
            {
                MessageBox.Show("Brak prostok¹tów wejsciowych");
                return;
            }
        }
    }
}
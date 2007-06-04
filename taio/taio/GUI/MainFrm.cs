using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

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
        internal GUI.EditSolution editSolution;


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
                    if (MessageBox.Show("Istniej¹ce w pamiêci prostok¹ty zostan¹ nadpisane,\na rozwi¹zania skasowane !\nKontynuowaæ?", "Ostrze¿enie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
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
                    solutionsFrm.CreateTabs();
                if (editSolution != null && editSolution.Visible)
                    editSolution.Close();
                editRectangles();
                Cursor.Current = Cursors.Default;
                this.statusStrip1.Items[0].Text = "Bezczynny";
                this.statusStrip1.Refresh();
                
                statusStrip1.Items["lab2"].Text = "Dane: "+filePath;
                lab2.Visible = true;
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
        internal void showSolutions()
        {
            // jezeli s¹ rozwiazania
            //MessageBox.Show(engine.Solutions[0].PartsOfSolution.Count.ToString());
            //if (this.engine.Solutions.Count > 0 )
            //{
                //this.statusStrip1.Items[0].Text = "Generuje rozwi¹zania...";
                //this.statusStrip1.Refresh();
                //Cursor.Current = Cursors.WaitCursor;
                // jezeli okno rozwiazan nie jest uz otwarte
            if (GUI.SolutionsFrm.counter == 0)
            {

                    this.solutionsFrm = new taio.GUI.SolutionsFrm(this);
                    this.solutionsFrm.MdiParent = this;
                    this.solutionsFrm.Show();
                    this.solutionsFrm.Focus();
                    this.solutionsFrm.Refresh();
                }
                else
                {
                    this.solutionsFrm.Focus();
                    this.solutionsFrm.Refresh();
                }
                //Cursor.Current = Cursors.Default;
                //this.statusStrip1.Items[0].Text = "Bezczynny";
                //this.statusStrip1.Refresh();
            //}
            //else
            //    MessageBox.Show("Brak rozwi¹zañ", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        save.Title = "Wybierz nazwe pliku...";
                        if (save.ShowDialog() == DialogResult.OK)
                        {
                            this.engine.FileName = save.FileName;
                            this.engine.WriteData();
                            MessageBox.Show("Dane zapisano w pliku:\n" + engine.FileName, "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            statusStrip1.Items["lab2"].Text = "Dane: " + save.FileName;
                            lab2.Visible = true;
                            this.statusStrip1.Refresh();
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
                //this.randomDataFrm.MdiParent = this;
                this.randomDataFrm.Show();
            }
            this.randomDataFrm.Focus();
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
                    //this.editDataFrm.MdiParent = this;
                    this.editDataFrm.Show();
                }
                this.editDataFrm.Focus(); 
           }
            else
                MessageBox.Show("Brak prostok¹tów wejœciowych", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            this.showSolutions();
        }

        private void edycjaRozwToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((this.engine.Rectangles != null) && (this.engine.Rectangles.Count > 0))
            {

                if (GUI.EditSolution.counter == 0)
                {

                    this.editSolution= new taio.GUI.EditSolution(this);
                    this.editSolution.MdiParent = this; 
                    this.editSolution.Show();
                }
                this.editSolution.Focus();
            }
            else
                MessageBox.Show("Brak prostok¹tów wejœciowych", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MainFrm_Activated(object sender, EventArgs e)
        {
            this.Refresh();
        }



    }
}
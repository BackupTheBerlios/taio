using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace taio.GUI
{
    public partial class SolutionsFrm : Form
    {

        public static int counter = 0;
        private MainFrm mainFrm;

        public MainFrm MainFrm
        {
            get { return mainFrm; }
            set { mainFrm = value; }
        }
       
 
        public SolutionsFrm(taio.MainFrm mainFrm)
        {
            this.mainFrm = mainFrm;        
            InitializeComponent();
        }

        private void SolutionsFrm_Load(object sender, EventArgs e)
        {
            counter++;

            foreach (Data.Solution sol in this.mainFrm.Engine.Solutions)
            {
                GUI.tab tab = new tab(this, this.mainFrm.Engine.Solutions.IndexOf(sol));
                TabPage tabPage = new TabPage(sol.Tag);
                tab.Dock = DockStyle.Fill;
                tabPage.Controls.Add(tab);
                this.tabSolutons.TabPages.Add(tabPage);
            }
        }

        private void SolutionsFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            counter = 0;
            
        }
        
       
        private void Tab_Changed(object sender, TabControlEventArgs e)
        {

       
            
        }

        private void Tab_Added(object sender, ControlEventArgs e)
        {
  
            
        }
    }
}
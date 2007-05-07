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
            CreateTabs();
            this.WindowState = FormWindowState.Maximized;
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
        internal void CreateTabs()
        {
            tabSolutons.TabPages.Clear();

            foreach (Data.Solution sol in this.mainFrm.Engine.Solutions)
            {
                GUI.tab tab = new tab(this, this.mainFrm.Engine.Solutions.IndexOf(sol));
                TabPage tabPage = new TabPage(sol.Tag);
                tab.Dock = DockStyle.Fill;
                //tab.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom));
                tabPage.Controls.Add(tab);
                this.tabSolutons.TabPages.Add(tabPage);
            }
        }
    }
}
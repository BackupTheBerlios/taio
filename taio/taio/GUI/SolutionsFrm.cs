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
        private GUI.tab tabBrutal, tabFirst, tabSecond;

        public GUI.tab TabSecond
        {
            get { return tabSecond; }
            set { tabSecond = value; }
        }

        public GUI.tab TabFirst
        {
            get { return tabFirst; }
            set { tabFirst = value; }
        }

        public GUI.tab TabBrutal
        {
            get { return tabBrutal; }
            set { tabBrutal = value; }
        }

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

            
                tabBrutal = new tab(this,0);
                MainFrm.Engine.getAlgorithm(0).Tab = TabBrutal; 
                TabPage tabPage1 = new TabPage("Algorytm brutalny");
                tabBrutal.Dock = DockStyle.Fill;
                //tab.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom));
                tabPage1.Controls.Add(tabBrutal);
                this.tabSolutons.TabPages.Add(tabPage1);

                tabFirst = new tab(this, 1);
                MainFrm.Engine.getAlgorithm(1).Tab = TabFirst;
                TabPage tabPage2 = new TabPage("Algorytm pierwszy");
                tabFirst.Dock = DockStyle.Fill;
                //tab.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom));
                tabPage2.Controls.Add(tabFirst);
                this.tabSolutons.TabPages.Add(tabPage2);


                tabSecond = new tab(this, 2);
                MainFrm.Engine.getAlgorithm(2).Tab = TabSecond;
                TabPage tabPage3 = new TabPage("Algorytm drugi");
                tabSecond.Dock = DockStyle.Fill;
                //tab.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom));
                tabPage3.Controls.Add(tabSecond);
                this.tabSolutons.TabPages.Add(tabPage3);

                foreach(Data.Solution sol in MainFrm.Engine.Solutions)
                    //if (sol.IsFromFile)
                    {
                        GUI.tab tab = new tab(this, 55);
                        tab.Solution = sol;
                        
                        tab.LabAlgorytm.Visible = false;
                        tab.LabTime.Visible = false;
                        tab.BtnStart.Visible = false;
                        tab.BtnStop.Visible = false;

                        TabPage tabPage = new TabPage(sol.Tag);
                        tab.Dock = DockStyle.Fill;
                        //tab.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom));
                        tabPage.Controls.Add(tab);
                        this.tabSolutons.TabPages.Add(tabPage);

                        //tab.uly = 10;
                        tab.refreshTab();
                       
                    }

  
        }

        private void trFactor_Scroll(object sender, EventArgs e)
        {
            if (trFactor.Value > 0)
            {
                chAuto.Checked = false;
                GUI.tab.factor = ((double)trFactor.Value) / 1000.0;
                tabSolutons.Refresh();
                tabSolutons.Invalidate();
                tabSolutons.Update();
            }
        }

        private void chAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (chAuto.Checked)
                GUI.tab.factor = 0.0;
            else
                GUI.tab.factor = ((double)trFactor.Value) / 1000.0;

            tabSolutons.Refresh();
            tabSolutons.Invalidate();
            tabSolutons.Update();
        }

        private void chColor_CheckedChanged(object sender, EventArgs e)
        {
            tabSolutons.Refresh();
            tabSolutons.Invalidate();
            tabSolutons.Update();
        }

        private void chNumbers_CheckedChanged(object sender, EventArgs e)
        {
            tabSolutons.Refresh();
            tabSolutons.Invalidate();
            tabSolutons.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainFrm.Engine.getAlgorithm(0).StartAlgorithm();
        }

        private void SolutionsFrm_Activated(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
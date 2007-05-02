using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace taio.GUI
{
    public partial class tab : UserControl
    {

        private int longestSide;
        private Data.Solution solution;
        private GUI.SolutionsFrm solutionFrm;
        private int index,clikedIndex=-1,maxX,maxY;
        private const int SQR_SIZE = 100; // rozmiar boku podloza dla rysowanych prost. wejsciowych

        public tab(GUI.SolutionsFrm solutionFrm, int index)
        {
            InitializeComponent();
            this.solutionFrm = solutionFrm;
            this.index = index;
        }

        private void tab_Load(object sender, EventArgs e)
        {
            this.solution = this.solutionFrm.MainFrm.Engine.getSolution(this.index);
            this.getLongestSide();
            maxX = getMaxX(this.solution);
            maxY = getMaxY(this.solution);

            double hRatio = (double)SQR_SIZE / (double)this.longestSide;
            double vRatio = (double)SQR_SIZE / (double)this.longestSide;

            int uly = 20;
            int index = 0;

            Panel p;
            Label lab;

            foreach (Data.PartOfSolution part in this.solution.PartsOfSolution)
            {
         
                    double width = (double)(part.Xrd - part.Xlu);
                    double height = (double)(part.Yrd - part.Ylu);
                    
                    p = new Panel();
                    p.Width = Convert.ToInt32(width * hRatio);
                    p.Height = Convert.ToInt32(height * vRatio);
                    p.BackColor = Color.Green;
                    p.Name = Convert.ToString(index);
                    p.Location = new System.Drawing.Point(20, uly);
                    p.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left));
                    p.Cursor = Cursors.Hand;    

                    lab = new Label();
                    lab.Location = new System.Drawing.Point(p.Width+20, uly);
                    lab.Text = "Nr. "+ (index+1) +"\nSzeroko��: "+ width.ToString() +"\nWysoko��: "+ height.ToString();
                    lab.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left));
                    lab.Height = 60;
                    lab.Width = 100; 

                    uly += SQR_SIZE + 5;
                    index++;
                   
                    p.Click +=new EventHandler(panel_Click);
                    this.splitContainer1.Panel1.Controls.Add(p);
                    this.splitContainer1.Panel1.Controls.Add(lab);
                    
            }
            lab = new Label();
            lab.Location = new System.Drawing.Point(5, uly);
            lab.Text = "Prostok�t wype�niany:";
            lab.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left));
            lab.Height = 15;
            lab.Width = 120;
            this.splitContainer1.Panel1.Controls.Add(lab);

            p = new Panel();
            p.Width = Convert.ToInt32(maxX * hRatio);
            p.Height = Convert.ToInt32(maxY * vRatio);
            p.BackColor = Color.Yellow;
            p.Name = Convert.ToString(index);
            p.Location = new System.Drawing.Point(20, uly+30);
            p.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left));
            this.splitContainer1.Panel1.Controls.Add(p);

            lab = new Label();
            lab.Location = new System.Drawing.Point(p.Width + 20, uly+30);
            lab.Text = "Szeroko��: " + maxX.ToString() + "\nWysoko��: " + maxY.ToString();
            lab.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left));
            lab.Height = 60;
            lab.Width = 100;
            this.splitContainer1.Panel1.Controls.Add(lab);
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Data.PartOfSolution part;
           
            Rectangle r;  

            double hRatio = (double)e.ClipRectangle.Width / (double)this.longestSide;
            double vRatio = (double)e.ClipRectangle.Height / (double)this.longestSide;

            r = new Rectangle(0,0,Convert.ToInt32(maxX*hRatio),Convert.ToInt32(maxY*vRatio));
            g.FillRectangle(Brushes.Yellow, r);
            g.DrawRectangle(Pens.Yellow, r);

            for (int i = 0; i < this.solution.PartsOfSolution.Count; i++)
            {
                part = this.solution.PartsOfSolution[i];
                double width = (double)(part.Xrd - part.Xlu);
                double height = (double)(part.Yrd - part.Ylu);

               r = new Rectangle(Convert.ToInt32(part.Xlu * vRatio),Convert.ToInt32(part.Ylu*vRatio),Convert.ToInt32(width*hRatio),Convert.ToInt32(height*vRatio));

                if (i == this.clikedIndex)
                    g.FillRectangle(Brushes.Red, r);
                else
                g.FillRectangle(Brushes.Green, r);
                g.DrawRectangle(Pens.Yellow, r);
            }
         //TESTY
            this.solutionFrm.MainFrm.StatusStrip1.Items[0].Text = "Width: " + e.ClipRectangle.Width.ToString() + "  Height: " + e.ClipRectangle.Height.ToString();
        //End TESTY
        }
        /// <summary>
        /// //
        /// </summary>
        private void getLongestSide()
        {
            this.longestSide = 0;
            foreach (Data.PartOfSolution part in this.solution.PartsOfSolution)
            {           
                if ((part.Xrd - part.Xlu) > this.longestSide)
                    this.longestSide = (part.Xrd - part.Xlu);

                if ((part.Yrd - part.Ylu) > this.longestSide)
                    this.longestSide = (part.Yrd - part.Ylu);
            }
        }
        private int getMaxX(Data.Solution sol)
        {
            int maxX = 0;
            foreach (Data.PartOfSolution part in sol.PartsOfSolution)
            {
                if (part.Xrd > maxX)
                    maxX = part.Xrd;
            }
            return maxX;
        }
        private int getMaxY(Data.Solution sol)
        {
            int maxY = 0;
            foreach (Data.PartOfSolution part in sol.PartsOfSolution)
            {
                if (part.Yrd > maxY)
                    maxY = part.Yrd;
            }
            return maxY;
        }
        private void panel_Click(Object sender, EventArgs e)
        {
            Panel p = (Panel)sender;
            this.clikedIndex = Int32.Parse(p.Name);
            this.splitContainer1.Panel2.Invalidate();
            this.splitContainer1.Panel2.Update();
      
        }

        private void splitContainer1_Panel1_Click(object sender, EventArgs e)
        {
            this.clikedIndex = -1;
            this.splitContainer1.Panel2.Invalidate();
            this.splitContainer1.Panel2.Update();
        }


    }
}

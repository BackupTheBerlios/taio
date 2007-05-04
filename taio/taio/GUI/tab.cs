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

        private Data.Solution solution;
        private GUI.SolutionsFrm solutionFrm;
        private int index,clikedIndex=-1,maxX,maxY,maxCoordinate;
        private const int SQR_SIZE = 70; // rozmiar boku podloza dla rysowanych prost. wejsciowych

        public tab(GUI.SolutionsFrm solutionFrm, int index)
        {
            InitializeComponent();
            this.solutionFrm = solutionFrm;
            this.index = index;
        }

        private void tab_Load(object sender, EventArgs e)
        {
            this.solution = this.solutionFrm.MainFrm.Engine.getSolution(this.index);
            this.maxX = getMaxX(this.solution);
            this.maxY= getMaxY(this.solution);
            this.getMaxCoordinate();

            double hRatio = ((double)SQR_SIZE *0.9)/ (double)maxCoordinate;
            double vRatio = ((double)SQR_SIZE *0.9)/ (double)maxCoordinate;
 

            int uly = 15, index2 = 0;

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
                    p.Name = Convert.ToString(index2);
                    p.Location = new System.Drawing.Point(10, uly);
                    p.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left));
                    p.Cursor = Cursors.Hand;    

                    lab = new Label();
                    lab.Location = new System.Drawing.Point(p.Width+15, uly);
                    lab.Text = "Nr. "+ ((index2)+1) +"\nSzerokoœæ: "+ width.ToString() +"\nWysokoœæ: "+ height.ToString()+ "\nPole: " + Convert.ToString(width*height);
                    lab.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left));
                    lab.Height = 60;
                    lab.Width = 100; 

                    uly += SQR_SIZE;
                    index2++;
                   
                    p.Click +=new EventHandler(panel_Click);
                    this.splitContainer1.Panel1.Controls.Add(p);
                    this.splitContainer1.Panel1.Controls.Add(lab);
                    
            }
            
            lab = new Label();
            lab.Location = new System.Drawing.Point(5, uly);
            lab.Text = "Prostok¹t wype³niany:";
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
            lab.Text = "Szerokoœæ: " + maxX.ToString() + "\nWysokoœæ: " + maxY.ToString()+ "\nPole: "+Convert.ToString( maxX*maxY)+ "\nPokrycie:";
            lab.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left));
            lab.Height = 60;
            lab.Width = 100;
            this.splitContainer1.Panel1.Controls.Add(lab);
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Data.PartOfSolution part;
            Rectangle r,selected;
            int minWidthOrHeight;

            if (maxX > maxY)
                maxCoordinate = maxX;
            else
                maxCoordinate = maxY;

            if (e.ClipRectangle.Width > e.ClipRectangle.Height)
                minWidthOrHeight = e.ClipRectangle.Height;
            else
                minWidthOrHeight = e.ClipRectangle.Width;

            double vRatio = (0.9 * minWidthOrHeight) / maxCoordinate;
            double hRatio = (0.9 * minWidthOrHeight) / maxCoordinate;

            r = new Rectangle(0,0,Convert.ToInt32(maxX*hRatio),Convert.ToInt32(maxY*vRatio));
            g.FillRectangle(Brushes.Yellow, r);
            g.DrawRectangle(Pens.Yellow, r);

            selected = new Rectangle();

            for (int i = 0; i < this.solution.PartsOfSolution.Count; i++)
            {
                part = this.solution.PartsOfSolution[i];
                double width = (double)(part.Xrd - part.Xlu);
                double height = (double)(part.Yrd - part.Ylu);

               r = new Rectangle(Convert.ToInt32(part.Xlu * vRatio),Convert.ToInt32(part.Ylu*vRatio),Convert.ToInt32(width*hRatio),Convert.ToInt32(height*vRatio));
               
               if (i == this.clikedIndex)
               {
                   selected = r = new Rectangle(Convert.ToInt32(part.Xlu * vRatio), Convert.ToInt32(part.Ylu * vRatio), Convert.ToInt32(width * hRatio), Convert.ToInt32(height * vRatio));
               }
               else
               {
                   r = new Rectangle(Convert.ToInt32(part.Xlu * vRatio), Convert.ToInt32(part.Ylu * vRatio), Convert.ToInt32(width * hRatio), Convert.ToInt32(height * vRatio));
                   g.FillRectangle(Brushes.Green, r);
                   g.DrawRectangle(Pens.Yellow, r);
               }
            }
            if (clikedIndex > -1)
            {
                g.FillRectangle(Brushes.Red, selected);
                g.DrawRectangle(Pens.Red, selected);
            }

        }

        private void getMaxCoordinate()
        {
            if (this.maxX > this.maxY)
                this.maxCoordinate = this.maxX;
            else
                this.maxCoordinate = maxY;
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

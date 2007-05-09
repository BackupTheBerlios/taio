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
        private int index, clikedIndex = -1;
        private const int SQR_SIZE = 100; // rozmiar boku podloza dla rysowanych prost. wejsciowych
        private static int maxX=0, maxY=0, maxCoordinate=0, minWidthOrHeight=0;
        internal static double ratio,factor=0.0;
        internal static bool flag = true;

        public tab(GUI.SolutionsFrm solutionFrm, int index)
        {
            InitializeComponent();
            this.solutionFrm = solutionFrm;
            this.index = index;
        }

        private void tab_Load(object sender, EventArgs e)
        {
            this.solution = this.solutionFrm.MainFrm.Engine.getSolution(this.index);
            double square = 0.0;
            splitContainer1.SplitterDistance = 40;

            if (flag)
            {
                maxX = getMaxX(this.solution);
                maxY = getMaxY(this.solution);
                maxCoordinate = getMaxCoordinate();
            }
            flag = false;

            double hRatio = ((double)SQR_SIZE *1.0)/ (double)maxCoordinate;
            double vRatio = ((double)SQR_SIZE *1.0)/ (double)maxCoordinate;

            int uly = 15, index2 = 0;

            Panel p;
            Label lab;

            foreach (Data.PartOfSolution part in this.solution.PartsOfSolution)
            {
         
                    double width = (double)(part.Xrd - part.Xlu);
                    double height = (double)(part.Yrd - part.Ylu);
                    square += width * height;

                    p = new Panel();
                    p.Width = Convert.ToInt32(width * hRatio);
                    p.Height = Convert.ToInt32(height * vRatio);
                    p.BackColor = Color.Green;
                    p.Name = Convert.ToString(index2);
                    p.Location = new System.Drawing.Point(10, uly);
                    p.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left));
                    p.Cursor = Cursors.Hand;    

                    lab = new Label();
                    lab.Cursor = Cursors.Hand;   
                    lab.Name = Convert.ToString(index2);
                    lab.Location = new System.Drawing.Point(p.Width+15, uly);
                    lab.Text = "Nr. "+ ((index2)+1) +"\nSzerokoœæ: "+ width.ToString() +"\nWysokoœæ: "+ height.ToString()+ "\nPole: " + Convert.ToString(width*height);
                    lab.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left));
                    lab.Height = 60;
                    lab.Width = 100; 

                    uly += SQR_SIZE-15;
                    index2++;
                   
                    p.Click +=new EventHandler(panel_Click);
                    lab.Click += new EventHandler(label_Click);
                    this.splitContainer1.Panel1.Controls.Add(p);
                    this.splitContainer1.Panel1.Controls.Add(lab);
                    
            }
            
            lab = new Label();
            lab.Location = new System.Drawing.Point(0, uly);
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
            p.Location = new System.Drawing.Point(10, uly+20);
            p.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left));
            this.splitContainer1.Panel1.Controls.Add(p);

            lab = new Label();
            lab.Location = new System.Drawing.Point(p.Width + 20, uly+30);
            lab.Text = "Szerokoœæ: " + maxX.ToString() + "\nWysokoœæ: " + maxY.ToString() + "\nPole: " + Convert.ToString(maxX * maxY) + "\nUtylizacja:" + Convert.ToString(Math.Round(((double)(maxX*maxY)/square)*100.0)) + "%";
            lab.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left));
            lab.Height = 60;
            lab.Width = 100;
            this.splitContainer1.Panel1.Controls.Add(lab);

            lab = new Label();
            lab.Location = new System.Drawing.Point(p.Width + 20, uly + 30);
            lab.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left));
            lab.Text = "  ";
            lab.Height = 60;
            lab.Width = 100;
            this.splitContainer1.Panel1.Controls.Add(lab);
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Data.PartOfSolution part;
            Rectangle r, selected;

            minWidthOrHeight = calculateMinWidthOrHeight(e.ClipRectangle);
            ratio = calculateRatio(factor);

            r = new Rectangle(0,0,Convert.ToInt32(maxX*ratio),Convert.ToInt32(maxY*ratio));
            g.FillRectangle(Brushes.Yellow, r);
            g.DrawRectangle(Pens.Yellow, r);

            selected = new Rectangle();

            for (int i = 0; i < this.solution.PartsOfSolution.Count; i++)
            {
                part = this.solution.PartsOfSolution[i];
                double width = (double)(part.Xrd - part.Xlu);
                double height = (double)(part.Yrd - part.Ylu);

               r = new Rectangle(Convert.ToInt32(part.Xlu * ratio),Convert.ToInt32(part.Ylu*ratio),Convert.ToInt32(width*ratio),Convert.ToInt32(height*ratio));
               
               if (i == this.clikedIndex)
               {
                   selected = r = new Rectangle(Convert.ToInt32(part.Xlu * ratio), Convert.ToInt32(part.Ylu * ratio), Convert.ToInt32(width * ratio), Convert.ToInt32(height * ratio));
               }
               else
               {
                   r = new Rectangle(Convert.ToInt32(part.Xlu * ratio), Convert.ToInt32(part.Ylu * ratio), Convert.ToInt32(width * ratio), Convert.ToInt32(height * ratio));
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

        private int getMaxCoordinate()
        {
            if (maxX > maxY)
                return maxX;
            else
                return maxY;
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
        private double calculateRatio(double factor)
        {
            if (factor == 0.0)
                return (0.99 * minWidthOrHeight) / maxCoordinate;
            else
                return factor;
        }

        private int calculateMinWidthOrHeight(Rectangle r)
        {
            if (r.Width > r.Height)
                return r.Height;
            else
                return r.Width;
        }
        private void panel_Click(Object sender, EventArgs e)
        {
            Panel p = (Panel)sender;
            this.clikedIndex = Int32.Parse(p.Name);
            this.splitContainer1.Panel2.Invalidate();
            this.splitContainer1.Panel2.Update();
      
        }
        private void label_Click(Object sender, EventArgs e)
        {
            Label l = (Label)sender;
            this.clikedIndex = Int32.Parse(l.Name);
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

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

        internal Data.Solution solution;
        private GUI.SolutionsFrm solutionFrm;
        private int index, clikedIndex = -1;
        private const int SQR_SIZE = 100; // rozmiar boku podloza dla rysowanych prost. wejsciowych
        private int maxX, maxY, maxCoordinate, minWidthOrHeight;
        internal static double ratio,factor=0.0;

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
            splitContainer1.SplitterDistance =45;

                maxX = getMaxX(this.solution);
                maxY = getMaxY(this.solution);
                maxCoordinate = getMaxCoordinate();
            

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
                    lab.Text = "Nr. "+ ((index2)+1) +"\nSzeroko��: "+ width.ToString() +"\nWysoko��: "+ height.ToString()+ "\nPole: " + Convert.ToString(width*height);
                    lab.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left));
                    lab.Height = 60;
                    lab.Width = 100; 

                    uly += SQR_SIZE+2;
                    index2++;
                   
                    p.Click +=new EventHandler(panel_Click);
                    lab.Click += new EventHandler(label_Click);
                    this.splitContainer1.Panel1.Controls.Add(p);
                    this.splitContainer1.Panel1.Controls.Add(lab);
                    
            }
            
            lab = new Label();
            lab.Location = new System.Drawing.Point(0, uly);
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
            p.Location = new System.Drawing.Point(10, uly+20);
            p.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left));
            this.splitContainer1.Panel1.Controls.Add(p);

            lab = new Label();
            lab.Location = new System.Drawing.Point(p.Width + 20, uly+30);
            lab.Text = "Szeroko��: " + maxX.ToString() + "\nWysoko��: " + maxY.ToString() + "\nPole: " + Convert.ToString(maxX * maxY) + "\nUtylizacja pokrycia:" + Convert.ToString(Math.Round(((double)(maxX*maxY)/square)*100.0)) + "%\nNiewykorzystane\nprostok�ty: "+Convert.ToString (solutionFrm.MainFrm.Engine.Rectangles.Count-solution.PartsOfSolution.Count);
            lab.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left));
            lab.Height = 80;
            lab.Width = 150;
            this.splitContainer1.Panel1.Controls.Add(lab);

            lab = new Label();
            lab.Location = new System.Drawing.Point(0,p.Location.Y+p.Height+5);
            lab.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left));
            lab.Text = " ";
            lab.Height = 10;
            lab.Width = 100;
            this.splitContainer1.Panel1.Controls.Add(lab);
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Data.PartOfSolution part;
            Rectangle r, selected;
            List<Rectangle> rectangles = new List<Rectangle>();
            short index = 1;
            //List<Rectangle> intersection = new List<Rectangle>();

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

               
               if (i == this.clikedIndex)
                   selected = new Rectangle(Convert.ToInt32(part.Xlu * ratio), Convert.ToInt32(part.Ylu * ratio), Convert.ToInt32(width * ratio), Convert.ToInt32(height * ratio));
             
               r = new Rectangle(Convert.ToInt32(part.Xlu * ratio), Convert.ToInt32(part.Ylu * ratio), Convert.ToInt32(width * ratio), Convert.ToInt32(height * ratio));
               Brush b = drawBrush(solutionFrm.ChColor.Checked);
               g.FillRectangle(b, r);
               rectangles.Add(r);
               
            }
            if (clikedIndex > -1)
            {
                g.FillRectangle(Brushes.Red, selected);
                g.DrawRectangle(Pens.Red, selected);
            }
            foreach (Rectangle r2 in rectangles)
            {
                g.DrawRectangle(Pens.Yellow, r2);
                paintNumbers(solutionFrm.ChNumbers.Checked, g, r2, ref index);
            }//paintIntersection(g, rectangles, intersection);
        }
        private void paintNumbers(bool numbers, Graphics g, Rectangle r, ref short index)
        {
            if (numbers)
            {
                int min = r.Height;
                if (r.Height > r.Width)
                    min = r.Width;
                float em = (float)(0.5f * min);

                if (em > 10f)
                    em = 10f;
                if (em < 0.1f)
                    em = 0.1f;

                Font f = new Font(FontFamily.GenericSansSerif, em);
                g.DrawString(index.ToString(), f, Brushes.Black, (float)(r.X + (r.Width / 2)), (float)(r.Y + (r.Height / 2)));
                index++;
            }
        }
        private Brush drawBrush(bool color)
        {
            Brush b;

            if (color)
            {
                Random r = new Random(DateTime.UtcNow.Millisecond);
                Color c = Color.FromArgb(r.Next(0,255),r.Next(0,255),r.Next(0,255));

                while((c.R ==255) && (c.G==255) && (c.B==0))
                    c = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));

                b = new SolidBrush(c);
                System.Threading.Thread.Sleep(20);
            }
            else
            {
                b = Brushes.Green;
            }
            return b;
        }
        //private void paintIntersection(Graphics g, List<Rectangle> rectangles, List<Rectangle> intersection)
        //{
        //    for (int i = 0; i< rectangles.Count;i++)
        //        for (int j = i; j < rectangles.Count; j++)
        //            if (rectangles[i].IntersectsWith(rectangles[j]))
        //            {
        //                Rectangle r = new Rectangle(rectangles[i].Location,rectangles[i].Size);
        //                r.Intersect(rectangles[j]);
        //                Pen p = new Pen(Color.Yellow);
        //                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
        //                g.DrawRectangle(p, r);
        //            }
        //}
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

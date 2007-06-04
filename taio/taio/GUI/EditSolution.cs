using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace taio.GUI
{
    public partial class EditSolution : Form
    {
        private MainFrm mainFrm;
        public static int counter = 0;
        int uly = 10;
        internal double ratio,factor,ratio2;
        private const int SQR_SIZE = 100;
        internal GUI.rectangle selectedRectangle;
        internal List<GUI.rectangle> rectangles;
        internal int x = 0, y = 0;
        internal decimal square;

        public EditSolution(MainFrm mainFrm)
        {
            this.mainFrm = mainFrm;
            this.rectangles = new List<rectangle>();
            InitializeComponent();
        }

        private void EditSolution_Load(object sender, EventArgs e)
        {
            counter++;
            ratio = calculateRatio();
            factor = calculateFactor();
            //MessageBox.Show(factor.ToString());
            splitContainer1.SplitterDistance = 130;
            paintRectangles();
        }

        private double calculateFactor()
        {
            int max = getMaxCoordinate();
            return ((0.5*splitContainer1.Panel2.Height)/(double)max);
        }
        private void EditSolution_FormClosed(object sender, FormClosedEventArgs e)
        {
            counter--;
        }
        private void paintRectangles()
        {
            int index = 1;
            Color c;
            Label lab;
            GUI.rectangle r2;

            foreach (Data.Rectangle r in mainFrm.Engine.Rectangles)
            {
                r2 = new rectangle(index, r.Width, r.Height,1,this);
                r2.Width = Convert.ToInt32(r2.OriginalWidth * ratio);
                r2.Height = Convert.ToInt32(r2.OriginalHeight * ratio);
              
                c = drawBrush();
                r2.BackColor = c;
                r2.color = c;
                r2.Location = new System.Drawing.Point(10, uly);
                r2.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left));
                splitContainer1.Panel1.Controls.Add(r2);
                r2.OldUly = r2.Location.Y;

                lab = new Label();
                lab.Name = Convert.ToString(index);
                lab.Location = new System.Drawing.Point(SQR_SIZE+12, uly);
                lab.Text = "Nr. " + (index) + "\nSzerokoœæ: " + r.Width.ToString() + "\nWysokoœæ: " + r.Height.ToString() + "\nPole: " + Convert.ToString(r.Height*r.Width);
                lab.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left));
                lab.Height = 60;
                lab.Width = 100;

                splitContainer1.Panel1.Controls.Add(lab);
                //rectangles.Add(r2)
                index++;
                uly += SQR_SIZE +2;
            }
        }
        private int getMaxCoordinate()
        {
            int maxh=0,maxw=0,max=0;
            foreach (Data.Rectangle r in mainFrm.Engine.Rectangles)
            {
                if (r.Height > maxh)
                    maxh= r.Height;
                if (r.Width > maxw)
                    maxw = r.Width;
            }
            if (maxw > maxh)
                max = maxw;
            else
                max = maxh;
            
            return max;
        }
        private double calculateRatio()
        {
            int max = getMaxCoordinate();
            return ((double)SQR_SIZE / (double)max);
        }

        private void splitContainer1_Panel2_DragEnter(object sender, DragEventArgs e)
        {
            //e.Effect = DragDropEffects.All;
            // string[] formats = e.Data.GetFormats();

            // if (formats[0].Equals("taio.GUI.rectangle"))
            // {

            //     GUI.rectangle r2 = (GUI.rectangle)e.Data.GetData(formats[0]);
            //     if (r2.Owner == 1)
            //     {
            //         //r2.Location = new System.Drawing.Point(e.X - splitContainer1.SplitterDistance, e.Y - (this.Height - splitContainer1.Panel2.Height));
            //         //r2.Width = Convert.ToInt32(r2.OriginalWidth * factor);
            //         //r2.Height = Convert.ToInt32(r2.OriginalHeight * factor);
            //         //r2.Anchor = (AnchorStyles.None);
            //         //r2.Owner = 2;
            //         //r2.BackColor = Color.Red;
            //         //selectedRectangle = r2;
            //         //splitContainer1.Panel2.Controls.Add(r2);
            //         //rectangles.Add(r2);
            //         //updateColors();
            ////         //this.Refresh();
            //     }
            // }
        }

        private void splitContainer1_Panel2_DragDrop(object sender, DragEventArgs e)
        {
           string[] formats = e.Data.GetFormats();
           
            if (formats[0].Equals("taio.GUI.rectangle"))
           {
            // GUI.rectangle r2 = (GUI.rectangle)e.Data.GetData(formats[0]);     
            // r2.Location = new System.Drawing.Point(e.X - splitContainer1.SplitterDistance, e.Y - (this.Height - splitContainer1.Panel2.Height));
            //// r2.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | AnchorStyles.Right| AnchorStyles.Bottom));
            // updateColors();
            // //Label lab;
            // //foreach (Control c in splitContainer1.Panel1.Controls)
            // //{
            // //    if (c.GetType() == typeof(Label))
            // //    {
            // //        lab = (Label)c;
            // //        if (lab.Name.Equals(r2.Index.ToString()))
            // //            lab.Hide();
            // //    }
            // //}
            this.Refresh();
                   
           }
        }
        private Color drawBrush()
        {
                Random r = new Random(DateTime.UtcNow.Millisecond);
                Color c = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));

                while ((c.R == 255) && (c.G == 255) && (c.B == 0))
                    c = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
                
                System.Threading.Thread.Sleep(20);
            return c;
        }
        internal void updateColors()
        {
            foreach (GUI.rectangle r in rectangles)
                if (r.Index != selectedRectangle.Index || r.Owner==1)
                    r.BackColor = r.color;
            this.Refresh();
        }

        private void splitContainer1_Panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
      
        }

        private void splitContainer1_Panel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] formats = e.Data.GetFormats();

            if (formats[0].Equals("taio.GUI.rectangle"))
            {
                GUI.rectangle r2 = (GUI.rectangle)e.Data.GetData(formats[0]);
                if (r2.Owner == 2)
                {
                    foreach (Control c in splitContainer1.Panel1.Controls)
                    {
                        if (c.GetType() == typeof(GUI.rectangle))
                        {
                            GUI.rectangle r = (GUI.rectangle)c;
                            if (r.Index == r2.Index)
                            {
                                r.Show();
                                rectangles.Remove(r2);
                                splitContainer1.Panel2.Controls.Remove(r2);
                            }
                        }
                    }

                }


                this.Refresh();
            }
        }

        private void splitContainer1_Panel2_DragOver(object sender, DragEventArgs e)
        {
             string[] formats = e.Data.GetFormats();

             if (formats[0].Equals("taio.GUI.rectangle"))
             {
                 GUI.rectangle r2 = (GUI.rectangle)e.Data.GetData(formats[0]);
                 r2.Location = new System.Drawing.Point(e.X - splitContainer1.SplitterDistance, e.Y - (this.Height - splitContainer1.Panel2.Height));
                 this.Refresh();
             }
        }



        private void EditSolution_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
                if (e.Shift)
                    moveRectangle(e.KeyCode, true);
                else
                    moveRectangle(e.KeyCode, false);
            if (e.KeyCode == Keys.Space)
                rotateRectangle();
        }

        private void moveRectangle(Keys key, bool ofset)
        {
            int step = 1;

            if (ofset)
                step = 10;

            if (selectedRectangle != null && (selectedRectangle.Owner == 2))
            {
                if (key == Keys.Up)
                    if(selectedRectangle.Location.Y >0)
                    selectedRectangle.Location = new Point(selectedRectangle.Location.X, selectedRectangle.Location.Y -step);
                if (key == Keys.Down)
                    selectedRectangle.Location = new Point(selectedRectangle.Location.X, selectedRectangle.Location.Y +step);
                if (key == Keys.Left)
                    if(selectedRectangle.Location.X >0)
                    selectedRectangle.Location = new Point(selectedRectangle.Location.X - step, selectedRectangle.Location.Y);
                if (key == Keys.Right)
                    selectedRectangle.Location = new Point(selectedRectangle.Location.X + step, selectedRectangle.Location.Y);
            }
            if (selectedRectangle.Location.Y < 0)
                selectedRectangle.Location = new Point(selectedRectangle.Location.X, 0);

            if (selectedRectangle.Location.X < 0)
                selectedRectangle.Location = new Point(0, selectedRectangle.Location.Y);
            this.Refresh();
        }

        private void EditSolution_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
                moveRectangle(e.KeyCode,false);
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            x = 0;
            y = 0;
            paintFilledRectangle(g);

        }
        private void paintFilledRectangle(Graphics g)
        {
            double xtemp, ytemp;
            foreach (GUI.rectangle r in rectangles)
            {
                if (r.Owner == 2)
                {
                    if ((r.Width + r.Location.X) > x)
                        x = (r.Width + r.Location.X);
                    if ((r.Height + r.Location.Y) > y)
                        y = (r.Height + r.Location.Y);
                }
            }
            Rectangle r2 = new Rectangle(0, 0, x, y);
            g.FillRectangle(Brushes.Yellow, r2);

            if (rectangles.Count > 0)
            {
                square = Math.Round((decimal)((x / factor) * (y / factor)), 1);
                labSquare.Text = "Pole: " + square;
                xtemp = Math.Round( x /factor,1);
                ytemp = Math.Round( y/factor,1);
               
                ratio2 = xtemp/ytemp;
                labRatio.Text = "Szerokoœæ / Wysokoœæ: " + Math.Round(ratio2, 2);
                labHeight.Text = "Wysokoœæ: " + Math.Round((y / factor), 1);
                labWidth.Text = "Szerokoœæ: " + Math.Round((x / factor), 1);
            }
            }

        private void rotateRectangle()
        {
            int tempWidth,tempHeight;

            if (selectedRectangle != null && (selectedRectangle.Owner == 2))
            {
                 tempWidth= selectedRectangle.Width;
                 tempHeight = selectedRectangle.Height;

                 selectedRectangle.Height = tempWidth;
                 selectedRectangle.Width = tempHeight;

                 this.Refresh();
                //Rectangle r = new Rectangle(selectedRectangle.Location.X, selectedRectangle.Location.Y, selectedRectangle.Width, selectedRectangle.Height);
                //Point[] points = { new Point(r.X, r.Y), new Point((r.X + r.Width), r.Y),new Point(r.X,(r.Height+y)) };
                ////points[0] = new Point(r.X,r.Y);
                ////points[1] = new Point((r.X+r.Width),r.Y);
                ////points[2] = new Point(r.X,(r.Height+y));
                //MessageBox.Show(r.X.ToString() + " " + r.Y.ToString());
                //Matrix m = new Matrix(r, points);
                //m.Rotate(90);
                
                //MessageBox.Show(r.X.ToString() + " " + r.Y.ToString());
                
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool flag;

            if (rectangles.Count == 0)
                return;
            if((ratio2<0.5)||(ratio2>2))
            {
                MessageBox.Show("Zbudowany prostok¹t ma niepoprawny stosunek szerokoœci do wysokoœci.\n Wartoœæ ta musi byæ sprzedzia³u [0.5, 2]");
                return;
            }

            int xIndex, yIndex,x2,y2,x1,y1;
            for (xIndex=0;xIndex<=x;xIndex++)
                for (yIndex=0; yIndex <= y; yIndex++)
                {
                    flag = false;
                    foreach (GUI.rectangle r in rectangles)
                    {
                        x1 = r.Location.X;
                        y1 = r.Location.Y;
                        x2 = r.Width + r.Location.X;
                        y2 = r.Height + r.Location.Y;

                        if (((x1 <= xIndex) && (xIndex <= x2)) && ((y1 <= yIndex) && (yIndex <= y2)))
                        {
                            flag = true;
                            break;
                        }

                    }
                    if (!flag)
                    {
                        MessageBox.Show("Proszê pokryæ dok³adnie ¿ó³ty prostok¹t !");
                        return;
                    }
                }

            Data.Solution sol = new taio.Data.Solution(false);
            sol.Tag = txtName.Text;
            foreach (GUI.rectangle r in rectangles)
            {
                x1 = (int)Math.Round((r.Location.X/factor),0);
                y1 = (int)Math.Round((r.Location.Y / factor),0);
                x2 = (int)Math.Round(((r.Width + r.Location.X) / factor),0);
                y2 = (int)Math.Round(((r.Height + r.Location.Y) / factor),0);

                Data.PartOfSolution part = new taio.Data.PartOfSolution();
                part.Xlu = x1;
                part.Ylu = y1;
                part.Xrd = x2;
                part.Yrd = y2;

                sol.PartsOfSolution.Add(part);
            }
            mainFrm.Engine.Solutions.Add(sol);
            MessageBox.Show("Stworzono nowe rozwi¹zanie.");
            if (mainFrm.solutionsFrm != null && mainFrm.solutionsFrm.Visible)
                mainFrm.solutionsFrm.CreateTabs();
        }

    }
}
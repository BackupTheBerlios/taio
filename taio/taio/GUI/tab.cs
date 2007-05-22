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
        DateTime start;

        delegate void paintLeftSplitCallback();
        delegate void refreshTabCallback();

        internal Data.Solution Solution
        {
            get { return solution; }
            set { solution = value; }
        }
       
        private GUI.SolutionsFrm solutionFrm;
        private int index, clikedIndex = -1;

        public int Index
        {
            get { return index; }
            set { index = value; }
        }
        private const int SQR_SIZE = 100; // rozmiar boku podloza dla rysowanych prost. wejsciowych
        private int maxX, maxY, maxCoordinate, minWidthOrHeight;
        internal static double ratio,factor=0.0;
        internal  int uly = 60;

        public tab(GUI.SolutionsFrm solutionFrm,int index)
        {
            InitializeComponent();
            this.solutionFrm = solutionFrm;
            this.index = index;
        }

        private void tab_Load(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 45;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            paintRightSplit(e.Graphics, e);  
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

    internal void paintLeftSplit()
    {

        if (this.InvokeRequired)
        {
            paintLeftSplitCallback d = new paintLeftSplitCallback(paintLeftSplit);
            this.Invoke(d);
        }
        else
             if (solution != null)
                if (solution.PartsOfSolution.Count > 0)
                {
                
                    double square = 0.0;
                    splitContainer1.SplitterDistance = 270;

                    maxX = getMaxX(this.solution);
                    maxY = getMaxY(this.solution);
                    maxCoordinate = getMaxCoordinate();


                    double hRatio = ((double)SQR_SIZE * 1.0) / (double)maxCoordinate;
                    double vRatio = ((double)SQR_SIZE * 1.0) / (double)maxCoordinate;

                    int  index2 = 0;

                    Panel p;
                    Label lab;

                    lab = new Label();
                    lab.Location = new System.Drawing.Point(10, uly);
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
                    p.Location = new System.Drawing.Point(10, uly + 20);
                    p.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left));
                    this.splitContainer1.Panel1.Controls.Add(p);

                    lab = new Label();
                    lab.Location = new System.Drawing.Point(SQR_SIZE + 15, uly + 30);
                    lab.Name = "labSolution";
                    lab.Text = "Szerokoœæ: " + maxX.ToString() + "\nWysokoœæ: " + maxY.ToString() + "\nPole: " + Convert.ToString(maxX * maxY) + "\nNiewykorzystane\nprostok¹ty: " + Convert.ToString(solutionFrm.MainFrm.Engine.Rectangles.Count - solution.PartsOfSolution.Count);
                    lab.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left));
                    lab.Height = 80;
                    lab.Width = 150;
                    this.splitContainer1.Panel1.Controls.Add(lab);

                    

                    lab = new Label();
                    lab.Location = new System.Drawing.Point(10, uly+SQR_SIZE+30);
                    lab.Name = "labRectangles";
                    lab.Text = "Prostok¹ty rozwi¹zania:";
                    lab.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left));
                    lab.Height = 15;
                    lab.Width = 150;
                    this.splitContainer1.Panel1.Controls.Add(lab);

                    uly += SQR_SIZE + 50;
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
                        lab.Location = new System.Drawing.Point(SQR_SIZE + 15, uly);
                        lab.Text = "Nr. " + ((index2) + 1) + "\nSzerokoœæ: " + width.ToString() + "\nWysokoœæ: " + height.ToString() + "\nPole: " + Convert.ToString(width * height);
                        lab.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left));
                        lab.Height = 60;
                        lab.Width = 100;

                        index2++;
                        uly += SQR_SIZE + 5;

                        p.Click += new EventHandler(panel_Click);
                        lab.Click += new EventHandler(label_Click);
                        this.splitContainer1.Panel1.Controls.Add(p);
                        this.splitContainer1.Panel1.Controls.Add(lab);

                    }
                    this.splitContainer1.Panel1.Controls["labSolution"].Text += "\nUtylizacja pokrycia:" + Convert.ToString(Math.Round(((double)(maxX * maxY) / square) * 100.0))+"%";

                    lab = new Label();
                    lab.Location = new System.Drawing.Point(0, p.Location.Y + p.Height + 5);
                    lab.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left));
                    lab.Text = " ";
                    lab.Height = 10;
                    lab.Width = 100;
                    this.splitContainer1.Panel1.Controls.Add(lab);
                }
         

    }
        internal void paintRightSplit(Graphics g, PaintEventArgs e)
            {
             if (solution != null)
                if (solution.PartsOfSolution.Count > 0)
                {
                    Data.PartOfSolution part;
                    Rectangle r, selected;
                    List<Rectangle> rectangles = new List<Rectangle>();
                    short index = 1;

                    minWidthOrHeight = calculateMinWidthOrHeight(e.ClipRectangle);
                    ratio = calculateRatio(factor);

                    r = new Rectangle(0, 0, Convert.ToInt32(maxX * ratio), Convert.ToInt32(maxY * ratio));
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
                    }
  
            }
    }
        public void refreshTab()
        {
            if (this.InvokeRequired)
            {

                refreshTabCallback d = new refreshTabCallback(refreshTab);
                this.Invoke(d);
            }
            else
            {
                timer.Stop();
                Cursor.Current = Cursors.WaitCursor;
                clearTabs();
                paintLeftSplit();
                Cursor.Current = Cursors.Default;
                this.btnStart.Enabled = true;
                this.Refresh();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (index == 0 && solutionFrm.MainFrm.Engine.Algoritms.getBrutal().BrutalThread != null)
                if (index == 0 && (solutionFrm.MainFrm.Engine.Algoritms.getBrutal().BrutalThread.ThreadState == System.Threading.ThreadState.Running))
                {
                    MessageBox.Show("Algortm jest ju¿ uruchomiony !");
                    this.Refresh();
                    return;
                }
            if (index == 1 && solutionFrm.MainFrm.Engine.Algoritms.getFirst().FirstThread != null)
                if (index == 1 && (solutionFrm.MainFrm.Engine.Algoritms.getFirst().FirstThread.ThreadState == System.Threading.ThreadState.Running))
                {
                    MessageBox.Show("Algortm jest ju¿ uruchomiony !");
                    this.Refresh();
                    return;
                }
            if (index == 2 && solutionFrm.MainFrm.Engine.Algoritms.getSecond().SecondThread != null)
                if (index == 2 && (solutionFrm.MainFrm.Engine.Algoritms.getSecond().SecondThread.ThreadState == System.Threading.ThreadState.Running))
                {
                    MessageBox.Show("Algortm jest ju¿ uruchomiony !");
                    this.Refresh();
                    return;
                }
            if (solutionFrm.MainFrm.Engine.Rectangles != null)
            {

                clearTabs();
                if(solution != null)
                solution.PartsOfSolution.Clear();
                this.Refresh();
                this.btnStart.Enabled = false;
                start = DateTime.Now;
                timer.Start();
                solutionFrm.MainFrm.Engine.getAlgorithm(index).StartAlgorithm();

            }
            else
                MessageBox.Show("Brak prostok¹tów wejsciowych");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            solutionFrm.MainFrm.Engine.getAlgorithm(index).StopAlgorithm();
            timer.Stop();
            this.btnStart.Enabled = true;
        }
        public void setTime(TimeSpan time)
        {
            this.labTime.Text = "Czas: " + time.ToString();
        }

        private void clearTabs()
        {
            uly = 60;
            Label l;
            foreach (Control c in splitContainer1.Panel1.Controls)
            {
                if (c.GetType() == typeof(Label) && !c.Name.Equals("labTime") && !c.Name.Equals("labAlgorytm"))
                {
                    l = (Label)c;
                    splitContainer1.Panel1.Controls.Remove(l);
                    l.Dispose();
                    
                }
                if (c.GetType() == typeof(Panel))
                {
                   //c.Hide();
                   splitContainer1.Panel1.Controls.Remove(c);
                   c.Dispose();
                   
                }
                
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            TimeSpan current = start - DateTime.Now;
            setTime(current);
        }
       
    }
}

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

        private int maxCoordinate;
        private Data.Solution solution;
        private GUI.SolutionsFrm solutionFrm;
        private int index, hRatio, vRatio;

        public tab(GUI.SolutionsFrm solutionFrm, int index)
        {
            InitializeComponent();
            this.solutionFrm = solutionFrm;
            this.index = index;
        }

        private void tab_Load(object sender, EventArgs e)
        {
            this.solution = this.solutionFrm.MainFrm.Engine.getSolution(this.index);
            this.getMaxCoordinate();
            //MessageBox.Show(this.maxCoordinate.ToString());
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            this.calculateRatios(e.ClipRectangle);

            foreach (Data.PartOfSolution part in this.solution.PartsOfSolution)
            {
                Rectangle r = new Rectangle(part.Xlu * this.hRatio, part.Ylu * this.vRatio, part.Xrd * this.hRatio, part.Yrd * this.vRatio);
               
                g.FillRectangle(Brushes.Green,r);
                g.DrawRectangle(Pens.White, r);
            }
            //MessageBox.Show(this.hRatio.ToString() + " " + this.vRatio.ToString());
        }
        /// <summary>
        /// //
        /// </summary>
        private void getMaxCoordinate()
        {
            foreach (Data.PartOfSolution part in this.solution.PartsOfSolution)
            {
                this.maxCoordinate = part.Xlu;
                //MessageBox.Show(part.Xlu.ToString() + " " + part.Ylu.ToString() + " " + part.Xrd.ToString() + " " + part.Yrd.ToString());
                if (part.Xrd > this.maxCoordinate)
                    this.maxCoordinate = part.Xrd;

                if (part.Ylu > this.maxCoordinate)
                    this.maxCoordinate = part.Ylu;

                if (part.Yrd > this.maxCoordinate)
                    this.maxCoordinate = part.Yrd;

            }
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="panel"></param>
        private void calculateRatios(Rectangle panel)
        {
            this.hRatio = panel.Width / this.maxCoordinate;
            this.vRatio = panel.Height / this.maxCoordinate;
            
        }
    }
}

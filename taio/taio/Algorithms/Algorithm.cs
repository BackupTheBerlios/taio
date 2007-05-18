using System;
using System.Collections.Generic;
using System.Text;

namespace taio.Algorithms
{
    abstract class Algorithm
    {
        
        /**found solution*/
        protected Data.Solution solution;
        protected GUI.tab tab;

        protected void refreshTab()
        {
           
            tab.Solution = this.Solution;
            tab.refreshTab();
        }
        public GUI.tab Tab
        {
            get { return tab; }
            set { tab = value; }
        }

        List<Data.Rectangle> rectangles;

        private MainFrm mainFrm;

        public MainFrm MainFrm
        {
            get { return mainFrm; }
            set { mainFrm = value; }
        }

        public List<Data.Rectangle> Rectangles
        {
            get { return rectangles; }
            set { rectangles = value; }
        }

        public Algorithm()
        {
            solution = new Data.Solution();
            rectangles = new List<taio.Data.Rectangle>();
        }

        /**finds the solution*/

        public abstract void StartAlgorithm();


        public abstract void StopAlgorithm();
        /**returns Solution which algorithm has found*/

        public Data.Solution Solution
        {
            get { return solution; }
            set { solution = value; }
        }


    }
}

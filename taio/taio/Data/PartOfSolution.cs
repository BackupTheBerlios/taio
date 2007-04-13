using System;
using System.Collections.Generic;
using System.Text;

namespace taio.Data
{
    class PartOfSolution
    {
        /**coordinates of left-up corner and right-down corner of rectangle */
        int xlu, ylu,
            xrd, yrd;

        public int Xrd
        {
            get { return xrd; }
            set { xrd = value; }
        }

        public int Xlu
        {
            get { return xlu; }
            set { xlu = value; }
        }

        public int Ylu
        {
            get { return ylu; }
            set { ylu = value; }
        }

        public int Yrd
        {
            get { return yrd; }
            set { yrd = value; }
        }
    }
}

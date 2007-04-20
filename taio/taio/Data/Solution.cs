using System;
using System.Collections.Generic;
using System.Text;

namespace taio.Data
{
    class Solution
    {
        /**the list of parts of solution*/
        List<PartOfSolution> partsOfSolution;
        private String tag; // tag identyfikujacy dane rozw.

        public String Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        internal List<PartOfSolution> PartsOfSolution
        {
            get { return partsOfSolution; }
            set { partsOfSolution = value; }
        }

        public Solution()
        {
            partsOfSolution = new List<PartOfSolution>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace taio.Data
{
    class Solution
    {
        /**the list of parts of solution*/
        List<PartOfSolution> partsOfSolution;

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

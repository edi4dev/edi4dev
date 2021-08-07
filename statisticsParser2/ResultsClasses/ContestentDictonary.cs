using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statisticsParser2.ResultsClasses
{
    class ContestentDictonary
    {
        private string contestantFirstName;
        private string contestantLastName;
        private string contestantCode;

        public string ContestantFirstName
        {
            get { return contestantFirstName; }
            set { contestantFirstName = value; }
        }

        public string ContestantLastName
        {
            get { return contestantLastName; }
            set { contestantLastName = value; }
        }

        public string ContestantCode
        {
            get { return contestantCode; }
            set { contestantCode = value; }
        }
    }
}

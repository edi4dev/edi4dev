using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statisticsParser2.ResultsClasses
{
    abstract class  IContestantResult
    {

        protected string contestantFirstName;
        protected string contestantLastName;
        protected string contestantCode;
        protected bool didContestantQuit;
        protected int numberOfSets;
        protected string extraInfo;

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

        public bool DidContestantQuit
        {
            get { return didContestantQuit; }
            set { didContestantQuit = value; }
        }

        public int NumberOfSets
        {
            get { return numberOfSets; }
            set { numberOfSets = value; }
        }

        public string ExtraInfo
        {
            get { return extraInfo; }
            set { extraInfo = value; }
        }

        public abstract double returnTotalResult();
    }
}

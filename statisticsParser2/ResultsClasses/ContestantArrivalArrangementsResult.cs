using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statisticsParser2.ResultsClasses
{
    class ContestantArrivalArrangementsResult : IContestantResult
    {
        private double arrivalScore=0;
        private double consistentScore=0;
        private double allwaysOnTopScore=0;
        private int samePlaceCounter = 0;

        
        public double ArrivalScore
        {
            get { return arrivalScore; }
            set { arrivalScore = value; }
        }

        public double ConsistentScore
        {
            get { return consistentScore; }
            set { consistentScore = value; }
        }

        public double AllwaysOnTopScore
        {
            get { return allwaysOnTopScore; }
            set { allwaysOnTopScore = value; }
        }

        public int SamePlaceCounter
        {
            get { return samePlaceCounter; }
            set { samePlaceCounter = value; }
        }


        public override double returnTotalResult() 
        {
            if (didContestantQuit)
                return 0;
            else
                return arrivalScore + consistentScore + allwaysOnTopScore;
        }

    }
}

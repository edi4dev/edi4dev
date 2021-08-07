using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statisticsParser2.ResultsClasses
{
    class ContestantSociometricStretcherResult : IContestantResult
    {
        private double achivmentPoints;
        private double consistentScore = 0;
        private int allwaysTopPlaceCounter = 0;

        public double AchivmentPoints
        {
            get { return achivmentPoints; }
            set { achivmentPoints = value; }
        }

        public double ConsistentScore
        {
            get { return consistentScore; }
            set { consistentScore = value; }
        }

        public int AllwaysTopPlaceCounter
        {
            get { return allwaysTopPlaceCounter; }
            set { allwaysTopPlaceCounter = value; }
        }

        public override double returnTotalResult()
        {
            if (didContestantQuit)
                return 0;
            else
                return AchivmentPoints + ConsistentScore;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statisticsParser2.ResultsClasses
{
    class ContestantTimeMentalExerciseResult : IContestantResult
    {

        private double place;

        public double Place
        {
            get { return place; }
            set { place = value; }
        }

        public override double returnTotalResult()
        {
            if (didContestantQuit)
                return 0;
            else
                return place;
        }

    }
}

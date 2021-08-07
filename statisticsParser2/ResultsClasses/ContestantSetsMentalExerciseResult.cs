using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statisticsParser2.ResultsClasses
{
    class ContestantSetsMentalExerciseResult : IContestantResult
    {
        public override double returnTotalResult()
        {
            if (didContestantQuit)
                return 0;
            else
                return numberOfSets;
        }
    }
}

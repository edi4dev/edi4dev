using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statisticsParser2.ExelHandling
{
    class ExerciseParameters
    {
        string exerciseName;
        string exexerciseType;
        string exexerciseID;
        protected Dictionary<String, ResultsClasses.IContestantResult> contestantsResults;

    }
}

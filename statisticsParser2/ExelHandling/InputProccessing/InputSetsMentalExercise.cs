using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statisticsParser2.ExelHandling.InputProccessing
{
    class InputSetsMentalExercise : IInputExercise
    {


        protected override void CalculateCellResult(int row, int col)
        {


            //sanity
            if (xlRange.Cells[row, col].value2 == null)
                return;

            var score = xlRange.Cells[row, col].Value2.ToString();
            var key = xlRange.Cells[row, 1].Value2.ToString();

            //entrie doesnt exist it
            if (!contestantsResults.ContainsKey(key))
            {
                ResultsClasses.IContestantResult contestantResult = new ResultsClasses.ContestantSetsMentalExerciseResult();


                //init state
                contestantResult.ContestantCode = contestentsDictonary[key].ContestantCode;
                contestantResult.ContestantFirstName = contestentsDictonary[key].ContestantFirstName;
                contestantResult.ContestantLastName = contestentsDictonary[key].ContestantLastName;

                contestantsResults[key] = contestantResult;
            }

            double ScoreDouble = (double)(Int32.Parse(score));

            (contestantsResults[key] as ResultsClasses.ContestantSetsMentalExerciseResult).NumberOfSets = (int)ScoreDouble;

        }



        protected override bool InnerInitialize()
        {

            //sample all contestents
            numberOfcontestentsToSample = contestentsDictonary.Count;

            maxRowNumber = contestentsDictonary.Count;

            //number of col = number of contestents
            maxColNumber = 2;

            return true;
        }

        public override void calculateScore()
        {
            literateList();
            var x = 2;
        }

    }
}

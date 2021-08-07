using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statisticsParser2.ExelHandling.InputProccessing
{
    class InputArrivalArrangementsExercise :IInputExercise
    {

       
        private void samePlaceCheck(ResultsClasses.ContestantArrivalArrangementsResult contestantResult, int row, int col, double setPlace)
        {
            //first lap
            if (row == Resources.FirstContestantCell.row)
                return;



            string key="<currentKey>";
            string PrevKey = "<previousKey>"; ;

            if (xlRange.Cells[row, col].Value2 != null)
                key = xlRange.Cells[row, col].Value2.ToString();

            //prv set
            if (xlRange.Cells[row - 1, col].Value2 != null)
                PrevKey = xlRange.Cells[row - 1, col].Value2.ToString();


            if (key == PrevKey && setPlace <= Resources.ConsistentMinPlace)
            {
                //first counter include the prvious
                if(contestantResult.SamePlaceCounter == 0)
                    contestantResult.SamePlaceCounter++;

                contestantResult.SamePlaceCounter++;
            }
            else
            {
                contestantResult.SamePlaceCounter = 0;
            }

            if (contestantResult.SamePlaceCounter >= Resources.ConsistentMinSetsInRow)
            {
                contestantResult.ConsistentScore += Resources.ConsistentScoreToAdd;
            }
        }

        protected override void CalculateCellResult(int row, int col)
        {
            

            //sanity
            if (xlRange.Cells[row, col].value2 == null)
                return;

            var key = xlRange.Cells[row, col].Value2.ToString();

            //entrie doesnt exist it
            if (!contestantsResults.ContainsKey(key))
            {
                ResultsClasses.IContestantResult contestantResult = new ResultsClasses.ContestantArrivalArrangementsResult();

                //init state
                (contestantResult as ResultsClasses.ContestantArrivalArrangementsResult).AllwaysOnTopScore = Resources.AllwaysOnTopScoreToAdd;
                contestantResult.ContestantCode = contestentsDictonary[key].ContestantCode;
                contestantResult.ContestantFirstName = contestentsDictonary[key].ContestantFirstName;
                contestantResult.ContestantLastName = contestentsDictonary[key].ContestantLastName;

                contestantsResults[key] = contestantResult;
            }

            double setPlace = (double)(Int32.Parse(xlRange.Cells[Resources.ContestantListCodeCol, col].Value2.ToString()));

            if (setPlace > Resources.AllwaysOnTopMaxPlace)
                (contestantsResults[key] as ResultsClasses.ContestantArrivalArrangementsResult).AllwaysOnTopScore = 0;

            (contestantsResults[key] as ResultsClasses.ContestantArrivalArrangementsResult).ArrivalScore += (double)(numberOfcontestentsToSample) + 1 - setPlace;
            samePlaceCheck(contestantsResults[key] as ResultsClasses.ContestantArrivalArrangementsResult, row, col, setPlace);
        }

        protected override bool InnerInitialize()
        {



            //sample all contestents
            numberOfcontestentsToSample = contestentsDictonary.Count;
            
            maxRowNumber = Resources.ArrivalArragmentRowNumber;

            //number of col = number of contestents
            maxColNumber = contestentsDictonary.Count;
            
            return true;
        }

        public override void calculateScore()
        {
            literateTable();
            var x = 2;
        }
    }
}

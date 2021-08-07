using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statisticsParser2.ExelHandling.InputProccessing
{
    class InputtSociometricStretcherExercise : IInputExercise
    {

      
        protected override void CalculateCellResult(int row, int col)
        {


            //sanity
            if (xlRange.Cells[row, col].value2 == null)
                return;

            var key = xlRange.Cells[row, col].Value2.ToString();

            //entrie doesnt exist it
            if (!contestantsResults.ContainsKey(key))
            {
                ResultsClasses.IContestantResult contestantResult = new ResultsClasses.ContestantSociometricStretcherResult();


                //init state
                (contestantResult as ResultsClasses.ContestantSociometricStretcherResult).AllwaysTopPlaceCounter = 0;
                contestantResult.ContestantCode = contestentsDictonary[key].ContestantCode;
                contestantResult.ContestantFirstName = contestentsDictonary[key].ContestantFirstName;
                contestantResult.ContestantLastName = contestentsDictonary[key].ContestantLastName;
                
                contestantsResults[key] = contestantResult;
            }

            double setPlace = (double)(Int32.Parse(xlRange.Cells[Resources.ContestantListCodeCol, col].Value2.ToString()));

                        
            //(contestantsResults[key] as ResultsClasses.ContestantSociometricStretcherResult).ArrivalScore += (double)(numberOfcontestentsToSample) + 1 - setPlace;

       
            if (setPlace <= Resources.SociometricStretcherMinPlaceForFullScore)
            {
                (contestantsResults[key] as ResultsClasses.ContestantSociometricStretcherResult).AchivmentPoints += Resources.SociometricStretcherFullScore;
                (contestantsResults[key] as ResultsClasses.ContestantSociometricStretcherResult).AllwaysTopPlaceCounter++;
            }
            else 
            {
                (contestantsResults[key] as ResultsClasses.ContestantSociometricStretcherResult).AllwaysTopPlaceCounter = 0;

                if (setPlace == Resources.SociometricStretcherMinPlaceForPartScore)
                    (contestantsResults[key] as ResultsClasses.ContestantSociometricStretcherResult).AchivmentPoints += Resources.SociometricStretcherPartScore;
            }

            if ((contestantsResults[key] as ResultsClasses.ContestantSociometricStretcherResult).AllwaysTopPlaceCounter >= Resources.ConsistentMinSetsInRow)
            {
                (contestantsResults[key] as ResultsClasses.ContestantSociometricStretcherResult).ConsistentScore += Resources.ConsistentScoreToAdd;
            }
            
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

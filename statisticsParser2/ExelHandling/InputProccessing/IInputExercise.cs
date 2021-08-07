using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel; 

namespace statisticsParser2.ExelHandling.InputProccessing
{
    abstract class IInputExercise
    {
        protected Excel._Worksheet inputWorksheet;
        protected Excel.Range xlRange;
        

        protected Dictionary<String, ResultsClasses.IContestantResult> contestantsResults;
        //hold the code , private and family name of all the  contestents
        protected Dictionary<String, ResultsClasses.ContestentDictonary> contestentsDictonary;

        protected int quitColNumber =- 1;
        protected int maxColNumber;
        protected int maxRowNumber;
        protected int numberOfcontestentsToSample;
        protected string ExerciseName;

        //protected int numberOfParticipant;
        //protected int numberOfSets;


        public abstract void calculateScore();

        void checkAndSetIfQuitTable(int row)
        {
            //sanity
            if(quitColNumber == -1 || xlRange.Cells[row, quitColNumber].Value2 == null)
                return;

            string quitText= xlRange.Cells[row, quitColNumber].Value2.ToString();
            quitText = quitText.Replace(" ", string.Empty);
            string[] quiterList = quitText.Split(',');

            foreach (string key in quiterList)
            {
                if (contestantsResults.ContainsKey(key))
                    contestantsResults[key].DidContestantQuit = true;
            }
        }

        void checkAndSetIfQuitList(int row)
        {
            //sanity
            if (quitColNumber == -1 || xlRange.Cells[row, quitColNumber].Value2 == null)
                return;

            string quitText = xlRange.Cells[row, quitColNumber].Value2.ToString();
            string key = xlRange.Cells[row, Resources.ContestantListFirstNameCol].Value2.ToString();

            if (quitText == Resources.AprovalMark || quitText ==  Resources.AprovalMark.ToLower())
            {
                if (contestantsResults.ContainsKey(key))
                    contestantsResults[key].DidContestantQuit = true;
            }


        }

        public bool Initialize(Excel._Worksheet inputWorksheet,Dictionary<String, ResultsClasses.ContestentDictonary> contestentsDictonary)
        {
            //System.Collections.ArrayList a2 = new System.Collections.ArrayList();
            //a2.Add(1);
            //a2.Add(1);

            var a =new [] {1,1};            
            this.contestentsDictonary = contestentsDictonary;
            this.inputWorksheet = inputWorksheet;
            xlRange = inputWorksheet.UsedRange;
            contestantsResults = new Dictionary<string, ResultsClasses.IContestantResult>();
            ExerciseName = xlRange.Cells[Resources.ExerciseNameCell.row, Resources.ExerciseNameCell.col].Value2.ToString();



            //for(int col = 1 ; )

                int col = 1;
                int row = Resources.FirstContestantRow-1;
                while(true)
                {
                    if(xlRange.Cells[row, col].Value2 == null)
                        break;

                    var text = xlRange.Cells[row, col].Value2.ToString();        
                    if(text == Resources.QuitText )
                        quitColNumber = col;

                    col++;
                }

                if (quitColNumber == -1)
                {
                    Console.WriteLine("failed to get quitColNumber");
                }
                
            return InnerInitialize();
        }

        //row,col
        protected void literateTable()
        {
            for (int row = Resources.FirstContestantCell.row ; row < maxRowNumber; row++)
            {
                for (int col = Resources.FirstContestantCell.col; col < Resources.FirstContestantCell.col + numberOfcontestentsToSample; col++)
                {
                    CalculateCellResult(row, col);
                }

                
            }

            for (int row = Resources.FirstContestantCell.row; row < maxRowNumber; row++)
            {
                checkAndSetIfQuitTable(row);
            }
        }

        protected void literateList()
        {
            int col = Resources.FirstContestantCell.col;
            for (int row = Resources.FirstContestantCell.row; row < Resources.FirstContestantCell.row + numberOfcontestentsToSample; row++)
            {
                CalculateCellResult(row, col);
            }
            
            for (int row = Resources.FirstContestantCell.row; row < Resources.FirstContestantCell.row + numberOfcontestentsToSample; row++)
            {
                checkAndSetIfQuitList(row);
            }
        }

        protected abstract void CalculateCellResult(int row,int col);

        protected abstract bool InnerInitialize();
    }
}

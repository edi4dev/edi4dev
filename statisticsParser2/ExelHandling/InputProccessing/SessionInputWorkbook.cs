using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;



namespace statisticsParser2.ExelHandling.InputProccessing
{
     
    class SessionInputWorkbook
    {
        private Excel.Application inputApp;
        private Excel.Workbook inputWorkbook;
        //hold the code , private and family name of all the  contestents
        Dictionary<String, ResultsClasses.ContestentDictonary> contestentsDictonary;
        List<IInputExercise> exersicesSheets;
        

        
        public bool Initialize(Excel.Application inputApp,string inputPath)
        {
            this.inputApp = inputApp;
            contestentsDictonary = new Dictionary<String, ResultsClasses.ContestentDictonary>();
            exersicesSheets = new List<IInputExercise>();

            //open workbook
            try
            {
                inputWorkbook = inputApp.Workbooks.Open(inputPath);
            }
            catch (Exception e)
            {
                Console.WriteLine("got {0} trying to open input workbook {1}",e.Message,inputPath);
                return false;
            }

            //row,col
            foreach (Excel._Worksheet worksheet in inputWorkbook.Sheets)
            {
                Excel.Range xlRange = worksheet.UsedRange;
                CheckedAndHandleConstantList(xlRange);
                var exexerciseType = xlRange.Cells[Resources.ExerciseTypeCell.row, Resources.ExerciseTypeCell.col].Value2;
                

                IInputExercise exersicesSheet = null;
                if (exexerciseType == Resources.ArrivalArrangementsWorksheetType)
                {
                    exersicesSheet =  new InputArrivalArrangementsExercise();
                }
                else if (exexerciseType == Resources.SociometricStretcherWorksheetType)
                {
                    exersicesSheet = new InputtSociometricStretcherExercise();
                }
                if (exexerciseType == Resources.ThinkingExerciseWorksheetType)
                {
                    var x = 2;
                }
                if (exexerciseType == Resources.SetsMentalExerciseWorksheetType)
                {
                    exersicesSheet = new InputSetsMentalExercise();
                }
                if (exexerciseType == Resources.TimeMentalWorksheetType)
                {
                    var x = 2;
                }
                if (exexerciseType == Resources.GeneralCommentsWorksheetType)
                {
                    var x = 2;
                }

                if (exersicesSheet != null)
                {
                    exersicesSheet.Initialize(worksheet, contestentsDictonary);
                    exersicesSheets.Add(exersicesSheet);
                }
            }

            return true;
        }
        
        public  void Calculate()
        {
            foreach ( var exersicesSheet in exersicesSheets)
            {
                exersicesSheet.calculateScore();
            }
        }

        private void CheckedAndHandleConstantList(Excel.Range xlRange)
        {

            var text = xlRange.Cells[Resources.ContestantListTitleCell.row, Resources.ContestantListTitleCell.col].Value2;


            if (text == Resources.ContestantListTitle)
            {
                int row = Resources.FirstContestantRow;
                while(true)
                {
                    ResultsClasses.ContestentDictonary aContestent = new ResultsClasses.ContestentDictonary();
                    bool quit=false;


                    //end of number of Contestant
                    if (xlRange.Cells[row, Resources.ContestantListFirstNameCol].Value2 == null &&
                        xlRange.Cells[row, Resources.ContestantListLastNameCol].Value2 == null &&
                        xlRange.Cells[row, Resources.ContestantListCodeCol].Value2 == null)
                    {
                        break;
                    }

                    aContestent.ContestantFirstName = xlRange.Cells[row, Resources.ContestantListFirstNameCol].Value2;
                    aContestent.ContestantLastName= xlRange.Cells[row, Resources.ContestantListLastNameCol].Value2;
                    aContestent.ContestantCode = xlRange.Cells[row, Resources.ContestantListCodeCol].Value2;


                    /*
                    for(int col = Resources.ContestantListFirstNameCol  ; col <= Resources.ContestantListCodeCol ; col++)
                    {
                        
                        if ((col == Resources.ContestantListFirstNameCol || col == Resources.ContestantListCodeCol) && xlRange.Cells[row, col].Value2 == null)
                        {
                            quit = true;
                        }

                        text = xlRange.Cells[row, col].Value2;

                        if (col == Resources.ContestantListFirstNameCol)
                        {
                            aContestent.ContestantFirstName = text;
                        }

                        if (col == Resources.ContestantListLastNameCol)
                        {
                            aContestent.ContestantLastName = text;
                        }

                        if (col == Resources.ContestantListCodeCol)
                        {
                            aContestent.ContestantCode = text;
                        }
                    }*/
                    
                    row++;
                    //if (!quit)
                      contestentsDictonary[aContestent.ContestantCode] = aContestent;
                    //else
                      //  break;
                }
            }

        }
        
        
    }
}

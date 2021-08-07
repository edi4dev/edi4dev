using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel; 


namespace statisticsParser2.ExelHandling.Output
{
    class IOutputExercise
    {
        protected string ExerciseName;
        protected InputProccessing.SessionInputWorkbook outputWorkbook;
        protected Excel._Worksheet inputWorksheet;
        protected Excel.Range xlRange;
        protected ResultsClasses.IContestantResult contestantResult;




    }
}

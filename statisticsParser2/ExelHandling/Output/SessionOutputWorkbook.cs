using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel; 

namespace statisticsParser2.ExelHandling.Output
{

//    protected string ExerciseName;

    class SessionOutputWorkbook
    {
        protected InputProccessing.SessionInputWorkbook outputWorkbook;
        protected Dictionary<string,List<ResultsClasses.IContestantResult>> contestantsResults;

        //protected Excel._Worksheet inputWorksheet;
        //protected Excel.Range xlRange;
    }
}

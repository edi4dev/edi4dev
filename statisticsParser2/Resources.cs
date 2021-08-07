using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statisticsParser2
{

    public class CellPoint
    {
        public int row, col;

        public CellPoint(int row,int col)
        {
            this.row = row;
            this.col = col;
        }
    }
    public static class Resources
    {
        //general
        public const int FirstContestantRow = 4;
        public const int FirstContestantCol = 2;

        public static  CellPoint FirstContestantCell
        {
            get { return new CellPoint(FirstContestantRow, FirstContestantCol); }  
        }

        public const int ExerciseNameRow = 1;
        public const int ExerciseNameCol= 1;
        
        public static CellPoint ExerciseNameCell
        {
            get { return new CellPoint(ExerciseNameRow, ExerciseNameCol); }
        }

        public const int ExerciseTypeRow = 2;
        public const int ExerciseTypeCol = 1;

        public static CellPoint ExerciseTypeCell
        {
            get { return new CellPoint(ExerciseTypeRow, ExerciseTypeCol); }
        }

        //arrival arragment
        public const int ConsistentMinPlace = 4;
        public const int ConsistentMinSetsInRow = 3;
        public const double ConsistentScoreToAdd = 0.5;

        public const double AllwaysOnTopScoreToAdd = 2;
        public const double AllwaysOnTopMaxPlace = 3;


        //depercated
        //public const int ArrivalArragmentNumberOfcontestentsToSample = 20;
        public const int ArrivalArragmentRowNumber = 20;
        //public const int ArrivalArragmentColNumber = 40;



        public const string QuitText = "פרישה";
        public const string AprovalMark = "V";
        


        public const string ArrivalArrangementsWorksheetType = "סדרי הגעה";
        public const string SetsMentalExerciseWorksheetType = "מנטלי מספר סטים";
        public const string SociometricStretcherWorksheetType = "אלונקה סוציומטרית";
        public const string ThinkingExerciseWorksheetType = "תרגילי חשיבה";
        public const string TimeMentalWorksheetType = "מנטלי זמן";
        public const string GeneralCommentsWorksheetType = "הערות כליליות";
        
        public const string ContestantListTitle = "רשימת מתמודדים";
        public const int ContestantListTitleRow = 1;
        public const int ContestantListTitleCol = 1;

        public static CellPoint ContestantListTitleCell
        {
            get { return new CellPoint(ContestantListTitleRow, ContestantListTitleCol); }
        }

        public const int ContestantListFirstNameCol = 1;
        public const int ContestantListLastNameCol = 2;
        public const int ContestantListCodeCol = 3;

        public const int SociometricStretcherMinPlaceForFullScore = 4;
        public const int SociometricStretcherMinPlaceForPartScore = 5;

        public const int SociometricStretcherFullScore = 2;
        public const int SociometricStretcherPartScore = 1;

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statisticsParser2.ResultsClasses
{
    class ContestantThinkingExerciseResult : IContestantResult
    {

        private double leading;
        private double creativity;
        private double teamWork;
        private double openMindedness;
        private double aggression;
        private double lackOfControl;
        private double showOff;

        public double Leading
        {
            get { return leading; }
            set { leading = value; }
        }

        public double Creativity
        {
            get { return creativity; }
            set { creativity = value; }
        }

        public double TeamWork
        {
            get { return teamWork; }
            set { teamWork = value; }
        }

        public double OpenMindedness
        {
            get { return openMindedness; }
            set { openMindedness = value; }
        }

        public double Aggression
        {
            get { return aggression; }
            set { aggression = value; }
        }

        public double LackOfControl
        {
            get { return lackOfControl; }
            set { lackOfControl = value; }
        }
        public double ShowOff
        {
            get { return showOff; }
            set { showOff = value; }
        }


        public override double returnTotalResult()
        {
            if (didContestantQuit)
                return 0;
            else
                return leading + creativity + teamWork + openMindedness - (aggression + lackOfControl + showOff);
        }
    }
}

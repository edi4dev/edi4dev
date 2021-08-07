using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel; 

namespace statisticsParser2.ExelHandling
{
    class ExelHandling
    {
        private Excel.Application inputApp;
        private InputProccessing.SessionInputWorkbook inputWorkbook;
        private InputProccessing.SessionInputWorkbook outputWorkbook;

        public bool Initialize(string inputFile)
        {
            inputApp = new Excel.Application();
            inputWorkbook = new InputProccessing.SessionInputWorkbook();
            inputWorkbook.Initialize(inputApp ,inputFile);
            inputWorkbook.Calculate();
            return true;
        }
    }
}

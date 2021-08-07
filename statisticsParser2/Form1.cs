using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace statisticsParser2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ExelHandling.ExelHandling xlHandler = new ExelHandling.ExelHandling();
            xlHandler.Initialize(@"C:\Users\develop\Documents\projects files\C#\statisticsParser\statisticsParser\bin\Debug\newDataSheet.xlsx");
        }
    }
}

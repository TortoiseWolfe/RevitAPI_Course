using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevitAPI_Course
{
    internal class Analysis
    {
        public static string ShowMessage(List<string> allNames)
        {
            foreach (string name in allNames)
            {
                MessageBox.Show(name);

            }
            return "Completed";
        }
    }
}

using Autodesk.Revit.DB;
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
        public static void ShowElementsData(List<Element> allElements)
        {
            foreach (Element s in allElements)
            {
                MessageBox.Show(s.Category.Name + "|:|" + s.Id.ToString());

            }
            //  return "Completed";
        }
    }
}

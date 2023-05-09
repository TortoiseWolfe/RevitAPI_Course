using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;

namespace RevitAPI_Course
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]

    public class _01_MessageTest : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Analysis AN = new Analysis();
            string text = "sample";
            double number = 3.45;
            int intNumber = 4;
            string multipleTypes = "type1|type2|type3";

            List<string> allNames = new List<string>();
            
            allNames.Add(text);
            allNames.Add(number.ToString());
            allNames.Add(intNumber.ToString());
            allNames.Add(multipleTypes);

            MessageBox.Show(Analysis.ShowMessage(allNames));

            //throw new NotImplementedException();
            return Result.Succeeded;
        }       
    }
}

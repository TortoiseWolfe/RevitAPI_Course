using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;

namespace RevitAPI_Course
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]

    public class _02_MainAddInStructure : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Selection or Extraction
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Element SelectedElement = Extraction.SingleElementSelection(uiapp);
            
            // Analysis
            MessageBox.Show(SelectedElement.Category.Name + "|:|" + SelectedElement.Id.ToString());
            // Creation
            //Transaction trans = new Transaction(doc);
            //trans.Start("Starting Process");

            // Creation Process

            //trans.Commit();
            return Result.Succeeded;
        }       
    }
}

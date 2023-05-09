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
            Selection sel = uiapp.ActiveUIDocument.Selection;
            Reference pickref = null;
            Transaction trans = new Transaction(doc);
            Element Selected = null;
            trans.Start("Selection");

            pickref = sel.PickObject(ObjectType.Element, "Select");
            Selected = doc.GetElement(pickref);

            trans.Commit();
            // Analysis

            // Creation
            //Transaction trans = new Transaction(doc);
            //trans.Start("Starting Process");

            // Creation Process

            //trans.Commit();
            return Result.Succeeded;
        }       
    }
}

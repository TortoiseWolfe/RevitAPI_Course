//using Autodesk.Revit.DB;
//using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
namespace RevitAPI_Course
{
    internal class Extraction
    {
        public static Element SingleElementSelection(UIApplication uiapp)
        {
        Document doc = uiapp.ActiveUIDocument.Document;
        Selection sel = uiapp.ActiveUIDocument.Selection;
        Reference pickref = null;
        Transaction trans = new Transaction(doc);
        Element Selected = null;
        trans.Start("Selection");
        pickref = sel.PickObject(ObjectType.Element, "Select");
        Selected = doc.GetElement(pickref);

        trans.Commit();
        return Selected;
        }
    }
}

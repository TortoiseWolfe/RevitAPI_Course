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
            
        try {
            pickref = sel.PickObject(ObjectType.Element, "Select");
            Selected = doc.GetElement(pickref);
            }
        catch
            {
            }

        trans.Commit();
        return Selected;
        }

        public static List<Element> MultipleElementSelection(UIApplication uiapp)
        {
            List<Element> allSelection = new List<Element>();
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;
            Reference pickref = null;
            Boolean flag = true;
            Transaction trans = new Transaction(doc);
            //  Element Selected = null;
            trans.Start("Selection");
            while (flag)
            {
                try
                {
                    pickref = sel.PickObject(ObjectType.Element, "Select");
                    Element Selected = doc.GetElement(pickref);
                    allSelection.Add(Selected);
                }
                catch
                {
                    flag = false;
                }
            }   

            trans.Commit();
            return allSelection;
        }
    }
}

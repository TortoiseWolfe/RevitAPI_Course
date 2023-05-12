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
        public static List<Element> MultipleStructuralColumnElementSelection(UIApplication uiapp)
        {
            List<Element> allSelection = new List<Element>();
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;
            ISelectionFilter filter = new StructuralColumnSelectionFilter();
            Reference pickref = null;
            Boolean flag = true;
            Transaction trans = new Transaction(doc);
            //  Element Selected = null;
            trans.Start("Selection");
            while (flag)
            {
                try
                {
                    pickref = sel.PickObject(ObjectType.Element, filter, "Select");
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
        public class StructuralColumnSelectionFilter : ISelectionFilter
        {
            public bool AllowElement(Element elem)
            {
                if (elem.Category.Name == "Structural Columns")
                {
                    return true;
                }
                return false;
            }
            public bool AllowReference(Reference reference, XYZ position)
            {
                return false;
            }
        }
        
        public static List<FamilyInstance> GetAllFamilyInstancesOfCategory(Document doc, BuiltInCategory category)
        {
            List<FamilyInstance> allFamilies = new List<FamilyInstance>();
            FilteredElementCollector collector = new FilteredElementCollector(doc).OfCategory(category).WhereElementIsNotElementType();
            FilteredElementIterator famIT = collector.GetElementIterator();
            famIT.Reset();
            while (famIT.MoveNext())
            {
                Element efam = famIT.Current as Element;
                FamilyInstance famin = famIT.Current as FamilyInstance;
                allFamilies.Add(famin);

            }
            return allFamilies;
        }

        public static List<FamilySymbol> GetAllFamilySymbolsOfCategory(Document doc, BuiltInCategory category)
        {
            List<FamilySymbol> allFamilySymbols = new List<FamilySymbol>();
            FilteredElementCollector collector = new FilteredElementCollector(doc).OfCategory(category).OfClass(typeof(FamilySymbol));
            FilteredElementIdIterator famIT = collector.GetElementIdIterator();
            famIT.Reset();
            while (famIT.MoveNext())
            {
                ElementId efam = famIT.Current;
                FamilySymbol famsymb = doc.GetElement(efam) as FamilySymbol;
                allFamilySymbols.Add(famsymb);

            }
            return allFamilySymbols;
        }

    }
}

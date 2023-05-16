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
using Autodesk.Revit.DB.Structure;
namespace RevitAPI_Course
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]

    public class _07_Family_with_Data : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Selection or Extraction
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Element selected = Extraction.SingleElementSelection(uiapp);
            ElementId familyTypeId = selected.GetTypeId();

            FamilySymbol FamS = doc.GetElement(familyTypeId) as FamilySymbol;
            Level lvl = doc.GetElement(selected.LevelId) as Level;
            List<FamilySymbol> allColumnsFamilySymbols = Extraction.GetAllFamilySymbolsOfCategoryFamilyName(doc, BuiltInCategory.OST_StructuralColumns, "Concrete-Rectangular-Column");
            
            //foreach(FamilySymbol FS in allColumnsFamilySymbols)
            //           {
            //    if (FS.FamilyName = FamS.FamilyName)
            //    {
            //        FamS = FS;
            //        break;
            //    }
            //}

            List<Level> allLevels = Extraction.GetAllLevelsFromModel(doc);
            Location locationPoint = selected.Location;
            LocationPoint LP = locationPoint as LocationPoint;
            XYZ centerPoint = LP.Point;



            // Creation
            Transaction trans = new Transaction(doc);
            trans.Start("Starting Process");
            if (!allColumnsFamilySymbols[0].IsActive)
            {
                allColumnsFamilySymbols[0].Activate();
                doc.Regenerate();
            }
            // Creation Process
            FamilyInstance fam = doc.Create.NewFamilyInstance(centerPoint.Add(new XYZ(3,0,0)), FamS, lvl, StructuralType.Column);

            trans.Commit();
            return Result.Succeeded;
        }       
    }
}

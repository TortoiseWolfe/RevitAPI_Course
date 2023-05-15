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

    public class _06_FamilyInstanceCreation : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Selection or Extraction
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            List<FamilySymbol> allColumnsFamilySymbols = Extraction.GetAllFamilySymbolsOfCategoryFamilyName(doc, BuiltInCategory.OST_StructuralColumns, "Concrete-Rectangular-Column");
            List<Level> allLevels = Extraction.GetAllLevelsFromModel(doc);

            // Analysis
            // Creation
            Transaction trans = new Transaction(doc);
            trans.Start("Starting Process");
            if (!allColumnsFamilySymbols[0].IsActive)
            {
                allColumnsFamilySymbols[0].Activate();
                doc.Regenerate();
            }
            // Creation Process
            FamilyInstance fam = doc.Create.NewFamilyInstance(new XYZ(0, 0, 0), allColumnsFamilySymbols[0], allLevels[0], StructuralType.Column);

            trans.Commit();
            return Result.Succeeded;
        }       
    }
}

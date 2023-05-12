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
            //List<Element> SelectedElements = Extraction.MultipleStructuralColumnElementSelection(uiapp);
            List<FamilyInstance> allColumns = Extraction.GetAllFamilyInstancesOfCategory(doc, BuiltInCategory.OST_StructuralColumns);
            // List<FamilySymbol> allColumnsFamilySymbols = Extraction.GetAllFamilySymbolsOfCategory(doc, BuiltInCategory.OST_StructuralColumns);
            List<FamilySymbol> allColumnsFamilySymbols = Extraction.GetAllFamilySymbolsOfCategoryFamilyName(doc, BuiltInCategory.OST_StructuralColumns, "Concrete-Rectangular-Column");
            List<ElementType> allColumnsElementTypes = Extraction.GetAllElementTypesOfCategory(doc, BuiltInCategory.OST_StructuralColumns);

            // Element - FamilyInstance
            // Elementtype - FamilyType - FamilySymbol



            // Analysis
            //MessageBox.Show(SelectedElement.Category.Name + "|:|" + SelectedElement.Id.ToString());
            //Analysis.ShowFamilyInstanceData(allColumns);
            Analysis.ShowFamilySymbolsData(allColumnsFamilySymbols);
            //Analysis.ShowElementTypesData(allColumnsElementTypes);
            // Analysis.ShowElementsData(SelectedElements);
            // Creation
            //Transaction trans = new Transaction(doc);
            //trans.Start("Starting Process");

            // Creation Process

            //trans.Commit();
            return Result.Succeeded;
        }       
    }
}

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

    public class _05_ElemetTypes_Extraction : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Selection or Extraction
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            List<ElementType> allColumnsElementTypes = Extraction.GetAllElementTypesOfCategory(doc, BuiltInCategory.OST_StructuralColumns);

            // Analysis
            Analysis.ShowElementTypesData(allColumnsElementTypes);
            
            // Creation
            return Result.Succeeded;
        }       
    }
}

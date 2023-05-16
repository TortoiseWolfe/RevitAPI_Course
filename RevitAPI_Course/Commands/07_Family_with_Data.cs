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

            Parameter PAR = selected.get_Parameter(BuiltInParameter.INSTANCE_LENGTH_PARAM);
            double length = PAR.AsDouble();
            string val = selected.LookupParameter("Reference").AsString();

            Location locationPoint = selected.Location;
            LocationPoint LP = locationPoint as LocationPoint;
            XYZ centerPoint = LP.Point;

            List<XYZ> aP = new List<XYZ>();
            for ( int i = 1; i < 3; i++)
            {
                XYZ P = centerPoint.Add(new XYZ(i * length, 0, 0));
                aP.Add(P);
            }

            // Creation
            Transaction trans = new Transaction(doc);
            trans.Start("Starting Process");
            // Creation Process
            foreach (XYZ p in aP)
            {
            FamilyInstance fam = doc.Create.NewFamilyInstance(p, FamS, lvl, StructuralType.Column);
            fam.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).Set("Checked Value");
            fam.LookupParameter("Reference").Set(val);
            }

            trans.Commit();
            return Result.Succeeded;
        }       
    }
}

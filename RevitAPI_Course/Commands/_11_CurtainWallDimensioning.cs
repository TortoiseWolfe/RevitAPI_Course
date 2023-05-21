using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using System.Linq;

namespace RevitAPI_Course
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class _11_CurtainWallDimensioning : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            UIDocument uidoc = uiapp.ActiveUIDocument;

            try
            {
                Reference pickedObj = uidoc.Selection.PickObject(ObjectType.Element);
                ElementId elementId = pickedObj.ElementId;
                Element SelectedElement = doc.GetElement(elementId);

                using (Transaction trans = new Transaction(doc, "Create Dimension"))
                {
                    trans.Start();
                    TaskDialog.Show("Debug", "Starting transaction...");

                    Wall wall = SelectedElement as Wall;
                    if (wall != null)
                    {
                        TaskDialog.Show("Debug", "Selected Wall Type: " + wall.WallType.Name);

                        LocationCurve wallLocationCurve = wall.Location as LocationCurve;
                        Curve wallCurve = wallLocationCurve.Curve;

                        XYZ start = wallCurve.GetEndPoint(0);
                        XYZ end = wallCurve.GetEndPoint(1);

                        Options opt = new Options();
                        opt.ComputeReferences = true; // This is necessary to get References from the GeometryObjects

                        List<Reference> refs = new List<Reference>();

                        if (wall.WallType.Kind == WallKind.Curtain)
                        {
                            CurtainGrid grid = wall.CurtainGrid;

                            foreach (ElementId panelId in grid.GetPanelIds())
                            {
                                Panel panel = doc.GetElement(panelId) as Panel;

                                if (panel != null)
                                {
                                    GeometryElement geomElem = panel.get_Geometry(opt);

                                    foreach (GeometryObject geomObj in geomElem)
                                    {
                                        if (geomObj is Solid solid)
                                        {
                                            foreach (Face face in solid.Faces)
                                            {
                                                PlanarFace pf = face as PlanarFace;
                                                if (pf != null)
                                                {
                                                    refs.Add(pf.Reference);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            GeometryElement geomElem = wall.get_Geometry(opt);

                            foreach (GeometryObject geomObj in geomElem)
                            {
                                if (geomObj is Solid solid)
                                {
                                    foreach (Face face in solid.Faces)
                                    {
                                        PlanarFace pf = face as PlanarFace;
                                        if (pf != null)
                                        {
                                            refs.Add(pf.Reference);
                                        }
                                    }
                                }
                            }
                        }

                        TaskDialog.Show("Debug", "Number of References: " + refs.Count);

                    if (refs.Count >= 2)
                        {
                            ReferenceArray refArray = new ReferenceArray();
                            foreach (Reference reference in refs)
                            {
                                refArray.Append(reference);
                            }

                            XYZ offset = new XYZ(0, -10, 0); // 10 feet offset in negative y direction
                            Line dimLine = Line.CreateBound(start + offset, end + offset);

                            // Create the dimension
                            Dimension dim = doc.Create.NewDimension(doc.ActiveView, dimLine, refArray);
                            TaskDialog.Show("Success", "Created dimension with ID: " + dim.Id.ToString());
                        }
                    }

                    TaskDialog.Show("Debug", "Ending transaction...");
                    trans.Commit();
                }

                TaskDialog.Show("Debug", "Transaction committed...");
                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Error", "An error occurred: " + ex.Message);
                message = ex.Message;
                return Result.Failed;
            }
        }
    }
}

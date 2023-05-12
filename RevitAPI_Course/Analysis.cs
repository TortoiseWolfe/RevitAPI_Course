using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevitAPI_Course
{
    internal class Analysis
    {
        public static void ShowElementsData(List<Element> allElements)
        {
            foreach (Element s in allElements)
            {
                MessageBox.Show(s.Category.Name + "|:|" + s.Id.ToString());

            }
            //  return "Completed";
        }

        public static void ShowFamilyInstanceData(List<FamilyInstance> allElements)
        {
            foreach (FamilyInstance s in allElements)
            {
                MessageBox.Show(s.Category.Name + "|:|" + s.Id.ToString());

            }
            //  return "Completed";
        }

        public static void ShowFamilySymbolsData(List<FamilySymbol> allElements)
        {
            foreach (FamilySymbol s in allElements)
            {
                MessageBox.Show(s.FamilyName + "|:|" + s.Name);

            }
        }

        public static void ShowElementTypesData(List<ElementType> allElements)
        {
            foreach (ElementType s in allElements)
            {
                MessageBox.Show(s.FamilyName + "|:|" + s.Name);

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;

namespace RevitAPI_Course
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    internal class App: IExternalApplication
    {
        void AddRibbonPanel(UIControlledApplication application)
        {
            // Create a custom ribbon tab
            String tabName = "RevitAPI Course";
            application.CreateRibbonTab(tabName);
            // Create a ribbon panel
            RibbonPanel ribbonPanel = application.CreateRibbonPanel(tabName, "Commands");
            // Create a push button
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            PushButtonData A1 = new PushButtonData(
                "cmdMessageText",
                "Show a Message",
                thisAssemblyPath,
                "RevitAPI_Course._01_MessageTest");
            PushButton pb1 = ribbonPanel.AddItem(A1) as PushButton;
            pb1.ToolTip = "Displays a Message";
            pb1.LongDescription = "This is a long description for the command";
            //Uri uriImage = new Uri(@"C:\Users\Public\Pictures\Sample Pictures\Chrysanthemum.jpg");
            //BitmapImage largeImage = new BitmapImage(uriImage);
            //pushButton.LargeImage = largeImage;

        }

        public Result OnStartup(UIControlledApplication application)
        {
            AddRibbonPanel(application);
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

    }
}

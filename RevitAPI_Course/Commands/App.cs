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

            CreatePushButton(thisAssemblyPath, ribbonPanel, "Show a Message", "_01_MessageTest");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Show a Message", "_02_Selection_of_Objects");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Show a Message", "_03_Instance_Extraction");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Show a Message", "_04_Symbol_Extraction");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Show a Message", "_05_ElementTypes_Extraction");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Show a Message", "_06_Family_Instance_Creation");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Show a Message", "_07_Family_with_Data");
            //CreatePushButton(thisAssemblyPath, ribbonPanel, "cmdCommand_08", "Show a Message", "_01_MessageTest");
        }

        public void CreatePushButton(string AssemblyPath, RibbonPanel ribbonPanel, string toolTipText, string commandName)
        {
            // Create a push button
            PushButtonData A1 = new PushButtonData(
                               commandName,
                               commandName,
                               AssemblyPath,
                               "RevitAPI_Course." + commandName);

            PushButton pb1 = ribbonPanel.AddItem(A1) as PushButton;
            pb1.ToolTip = toolTipText;
            //pb1.LongDescription = "This is a long description for the command";
            
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using System.Windows.Media.Imaging;

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

            CreatePushButton(thisAssemblyPath, ribbonPanel, "Show a Message", "_01_MessageTest", "Trinam_Design_32.png", "Trinam_Design_16.png");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Show a Message", "_02_Selection_of_Objects", "Trinam_Design_32.png", "Trinam_Design_16.png");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Show a Message", "_03_Instance_Extraction", "Trinam_Design_32.png", "Trinam_Design_16.png");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Show a Message", "_04_Symbol_Extraction", "Trinam_Design_32.png", "Trinam_Design_16.png");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Show a Message", "_05_ElementTypes_Extraction", "Trinam_Design_32.png", "Trinam_Design_16.png");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Show a Message", "_06_Family_Instance_Creation", "Trinam_Design_32.png", "Trinam_Design_16.png");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Show a Message", "_07_Family_with_Data", "Trinam_Design_32.png", "Trinam_Design_16.png");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Show a Message", "_08_MacroRecorder", "Trinam_Design_32.png", "Trinam_Design_16.png");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Show a Message", "_09_ScopeBox", "Trinam_Design_32.png", "Trinam_Design_16.png");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Show a Message", "_10_CurtainWallSelection", "Trinam_Design_32.png", "Trinam_Design_16.png");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Show a Message", "_11_CurtainWallDimensioning", "Trinam_Design_32.png", "Trinam_Design_16.png");
        }

        public void CreatePushButton(string AssemblyPath, RibbonPanel ribbonPanel, string toolTipText, string commandName, string largeImageFileName, string smallImageFileName)
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

            Uri uriImageLarge = new Uri(@"C:\Users\JonPo\source\repos\TortoiseWolfe\RevitAPI_Course\RevitAPI_Course\" + largeImageFileName);
            BitmapImage largeImage = new BitmapImage(uriImageLarge);
            pb1.LargeImage = largeImage;

            Uri uriImageSmall = new Uri(@"C:\Users\JonPo\source\repos\TortoiseWolfe\RevitAPI_Course\RevitAPI_Course\" + smallImageFileName);
            BitmapImage smallImage = new BitmapImage(uriImageSmall);
            pb1.Image = smallImage;
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

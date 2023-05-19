using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace HelloPanel
{
    /// <remarks>
    /// This application's main class. The class must be Public.
    /// </remarks>
    public class CsAddPanel : IExternalApplication
    {
        // Both OnStartup and OnShutdown must be implemented as public method
        public Result OnStartup(UIControlledApplication application)
        {
            // Add a new ribbon panel
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("NewRibbonPanel");

            // Create a push button to trigger a command add it to the ribbon panel.
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;
            PushButtonData buttonData = new PushButtonData("cmdHelloWorld",
               "Hello World", thisAssemblyPath, "HelloPanel.HelloWorld");

            PushButton pushButton = ribbonPanel.AddItem(buttonData) as PushButton;

            // Optionally, other properties may be assigned to the button
            // a) tool-tip
            pushButton.ToolTip = "Say hello to the entire world.";

            // b) icon bitmaps
            // Small icon
            Uri uriImageSmall = new Uri(@"C:\Users\JonPo\source\repos\TortoiseWolfe\HelloPanel\Trinam_96.png");
            BitmapImage smallImage = new BitmapImage(uriImageSmall);
            pushButton.Image = smallImage;

            // Large icon
            Uri uriImage = new Uri(@"C:\Users\JonPo\source\repos\TortoiseWolfe\HelloPanel\Trinam_96.png");
            BitmapImage largeImage = new BitmapImage(uriImage);
            pushButton.LargeImage = largeImage;

         return Result.Succeeded;
      }

      public Result OnShutdown(UIControlledApplication application)
      {
         // nothing to clean up in this simple case
         return Result.Succeeded;
      }
   }
   /// <remarks>
   /// The "HelloWorld" external command. The class must be Public.
      /// </remarks>
      [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class HelloWorld : IExternalCommand
        {
            // The main Execute method (inherited from IExternalCommand) must be public
            public Autodesk.Revit.UI.Result Execute(ExternalCommandData revit,
                ref string message, ElementSet elements)
            {
                TaskDialog.Show("Revit", "Hello World");
                return Autodesk.Revit.UI.Result.Succeeded;
            }
        }
    }
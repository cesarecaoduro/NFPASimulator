namespace NFPASimulator.Events
{
    using System;
    using NFPASimulator.UI;
    using Autodesk.Revit.UI;
    using Autodesk.Revit.UI.Events;

    internal class ApplicationEventHandlers
    {
        internal static void Idling(object sender, IdlingEventArgs e, MainPage mainWindow)
        {
            UIApplication uiapp = sender as UIApplication;
            if (uiapp != null)
            {
                mainWindow.ActiveDocument = uiapp.ActiveUIDocument.Document;
                mainWindow.txtProjectName.Title = string.Format("[{0}]",uiapp.ActiveUIDocument.Document.Title);
            }
        }
    }
}
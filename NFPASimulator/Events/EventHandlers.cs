using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using NFPASimulator.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFPASimulator.Events
{
    public class EventHandlers
    {
        internal static void DocumentChanged(object sender, DocumentChangedEventArgs e, MainPage mainPage)
        {
            Document d = e.GetDocument();

        }
    }
}

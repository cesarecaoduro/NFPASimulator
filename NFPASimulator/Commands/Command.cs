
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using NFPASimulator.UI;
using Autodesk.Revit.UI.Events;

namespace NFPASimulator.Commands
{
    /// <summary>
    /// Show dockable dialog
    /// </summary>
    [Transaction(TransactionMode.ReadOnly)]
    public class NFPASimulator : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            DockablePaneId dpid = new DockablePaneId(new Guid("{4f3caa71-44fa-4329-9c9c-687956834eac}"));

            DockablePane dp = commandData.Application.GetDockablePane(dpid);
            dp.Show();

            return Result.Succeeded;
        }
    }

    /// <summary>
    /// Hide dockable dialog
    /// </summary>
    [Transaction(TransactionMode.ReadOnly)]
    public class HideDockableWindow : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            DockablePaneId dpid = new DockablePaneId(new Guid("{4f3caa71-44fa-4329-9c9c-687956834eac}"));

            DockablePane dp = commandData.Application.GetDockablePane(dpid);

            dp.Hide();

            return Result.Succeeded;
        }
    }
}

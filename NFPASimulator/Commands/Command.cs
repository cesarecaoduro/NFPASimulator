
using System;
using System.Windows;

namespace NFPASimulator.Commands
{
    using Autodesk.Revit.UI;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.Attributes;

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

    /// <summary>
    /// Use this to test commands
    /// </summary>
    [Transaction(TransactionMode.ReadOnly)]
    public class NFPASimulatorCommand : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            var specEq = Utilities.Utilities.CollectElementsByCategory(commandData.Application.ActiveUIDocument.Document, BuiltInCategory.OST_SpecialityEquipment);
            MessageBox.Show(string.Format("Number of elements: {0}", specEq.Count));

            return Result.Succeeded;
        }

    }
}

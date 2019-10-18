using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Resources;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;


using Autodesk.Revit.UI.Events;
using Autodesk.Revit.DB.Events;

namespace NFPASimulator
{
    using NFPASimulator.Utilities;
    using NFPASimulator.Properties;
    using NFPASimulator.UI;
    using System.Windows;

    /// <summary>
    /// 
    /// </summary>
    public class Application : IExternalApplication
    {
        MainPage m_MyDockableWindow = null;

        Result IExternalApplication.OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        Result IExternalApplication.OnStartup(UIControlledApplication application)
        {

   
            string path = Assembly.GetExecutingAssembly().Location;

            #region DockableWindow            
            PushButtonData pushButtonShowDockableWindow = new PushButtonData("NFPA Simulator", "NFPA Simulator", path, "NFPASimulator.Commands.NFPASimulator");
            pushButtonShowDockableWindow.LargeImage = Utilities.Utilities.GetImage(Resources.NFPALogo.GetHbitmap());
            RibbonPanel panel = application.CreateRibbonPanel(Tab.Analyze, "NFPA130");
            var rItem = panel.AddItem(pushButtonShowDockableWindow);
            #endregion

            MainPage mainWindow = RegisterDockableWindow(application);

            #region Register to events
            application.Idling += (sender, e) => Events.ApplicationEventHandlers.Idling(sender, e, mainWindow);
            #endregion

            return Result.Succeeded;
        }


        private MainPage RegisterDockableWindow(UIControlledApplication application)
        {
            #region Register DockableDialog
            DockablePaneProviderData data = new DockablePaneProviderData();

            MainPage MainDockableWindow = new MainPage();

            m_MyDockableWindow = MainDockableWindow;

            //MainDockableWindow.SetupDockablePane(me);

            data.FrameworkElement = MainDockableWindow as System.Windows.FrameworkElement;
            data.InitialState = new DockablePaneState();

            data.InitialState.DockPosition = DockPosition.Tabbed;


            data.InitialState.TabBehind = DockablePanes.BuiltInDockablePanes.ProjectBrowser;

            DockablePaneId dpid = new DockablePaneId(new Guid("{4f3caa71-44fa-4329-9c9c-687956834eac}"));

            application.RegisterDockablePane(dpid, "NFPA 130 Simulator", MainDockableWindow as IDockablePaneProvider);


            return MainDockableWindow;
            #endregion
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class AvailabilityNoOpenDocument : IExternalCommandAvailability
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool IsCommandAvailable(
          UIApplication a,
          CategorySet b)
        {
            if (a.ActiveUIDocument == null)
            {
                return true;
            }
            return false;
        }
    }
}

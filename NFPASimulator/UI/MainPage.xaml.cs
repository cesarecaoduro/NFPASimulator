using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Autodesk.Revit.UI;


namespace NFPASimulator.UI
{
    using Autodesk.Revit.DB;
    using NFPASimulator.Models;
    using NFPASimulator.Utilities;
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    
    public partial class MainPage : Page, IDockablePaneProvider
    {

        private List<EscalatorViewModel> EscalatorsVM { get; set; }
        private List<EscalatorModel> EscalatorsM { get; set; }
        public Document ActiveDocument { get; set; }

        public MainPage()
        {
            InitializeComponent(); 
        }

        public void SetupDockablePane(DockablePaneProviderData data)
        {
            data.FrameworkElement = this as FrameworkElement;
            data.InitialState = new Autodesk.Revit.UI.DockablePaneState();
            data.InitialState.DockPosition = DockPosition.Left;
            data.InitialState.TabBehind = Autodesk.Revit.UI.DockablePanes.BuiltInDockablePanes.ProjectBrowser;

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {

            EscalatorsVM = new List<EscalatorViewModel>();
            EscalatorsM = new List<EscalatorModel>();
            var specEqs = Utilities.CollectElementsByCategory(ActiveDocument, BuiltInCategory.OST_SpecialityEquipment);
            foreach(var specEq in specEqs)
            {
                var el = ActiveDocument.GetElement(specEq);
                try
                {
                    EscalatorModel esM = new EscalatorModel()
                    {
                        BaseLevel = ActiveDocument.GetElement(
                        el.get_Parameter(BuiltInParameter.FAMILY_BASE_LEVEL_PARAM).AsElementId()
                        ) as Level,
                        TopLevel = ActiveDocument.GetElement(
                        el.get_Parameter(BuiltInParameter.FAMILY_TOP_LEVEL_PARAM).AsElementId()
                        ) as Level,
                        FamilyInstance = el.Id,
                        ClearWidth = 0,
                        EscalatorFlowCapacity = 0,
                        NumberOfPerson = 0
                    };
                    EscalatorsM.Add(esM);
                    EscalatorsVM.Add(new EscalatorViewModel(ActiveDocument, esM));
                }
                catch(Exception ex)
                {

                }
                
            }

            dgEscalators.ItemsSource = EscalatorsVM;
        }
    }
}

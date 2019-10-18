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
using LiveCharts.Wpf;


namespace NFPASimulator.UI
{
    using Autodesk.Revit.DB;
    using NFPASimulator.Models;
    using NFPASimulator.Utilities;
    using System.Reflection;
    using ComboBox = System.Windows.Controls.ComboBox;

    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>

    public partial class MainPage : Page, IDockablePaneProvider
    {

        private List<EscalatorViewModel> EscalatorsVM { get; set; }
        private List<EscalatorModel> EscalatorsM { get; set; }
        private DesignParametersModel[] DesignParameters { get; set; }
        public Document ActiveDocument { get; set; }
        private AboutWindow AboutWindow = null;

        public MainPage()
        {
            InitializeComponent();
            InitializeDesignParameters();
        }

        

        public void SetupDockablePane(DockablePaneProviderData data)
        {
            data.FrameworkElement = this as FrameworkElement;
            data.InitialState = new Autodesk.Revit.UI.DockablePaneState();
            data.InitialState.DockPosition = DockPosition.Left;
            data.InitialState.TabBehind = Autodesk.Revit.UI.DockablePanes.BuiltInDockablePanes.ProjectBrowser;

        }

        #region PRIVATE METHODS

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

        private void cmbName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ComboBox cmb = sender as ComboBox;
                int index = cmb.SelectedIndex;

                txtPlatformTravelSpeed.Text = DesignParameters[index].PlatformTravelSpeed.ToString();
                txtConcourseTravelSpeed.Text = DesignParameters[index].ConcourseTravelSpeed.ToString();
                txtSpeedElevation.Text = DesignParameters[index].SpeedElevation.ToString();
                txtMultiLeafDoorsFlowCapacity.Text = DesignParameters[index].MultiLeafDoorsFlowCapacity.ToString();
                txtBottleNeckFlowCapacity.Text = DesignParameters[index].BottleNeckFlowCapacity.ToString();
                txtTurnstileFlowCapacity.Text = DesignParameters[index].TurnstileFlowCapacity.ToString();
                txtSingleLeafDoorsFlowCapacity.Text = DesignParameters[index].SingleLeafDoorsFlowCapacity.ToString();
                txtGatesFlowCapacity.Text = DesignParameters[index].GatesFlowCapacity.ToString();
                txtStairsFlowCapacity.Text = DesignParameters[index].StairsFlowCapacity.ToString();
                txtEscalatorFlowCapacity.Text = DesignParameters[index].EscalatorFlowCapacity.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message));
            }

        }

        private void InitializeDesignParameters()
        {
            try
            {
                string dir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string path = string.Format(@"{0}\NFPADesignParameters.json", dir);
                DesignParameters = Utilities.DesignParametersFromJSON(path);
                foreach (var dp in DesignParameters)
                {
                    cmbDesignParameterName.Items.Add(dp.Name);
                }
                int index = 3;
                cmbDesignParameterName.SelectedIndex = index;
                txtPlatformTravelSpeed.Text = DesignParameters[index].PlatformTravelSpeed.ToString();
                txtConcourseTravelSpeed.Text = DesignParameters[index].ConcourseTravelSpeed.ToString();
                txtSpeedElevation.Text = DesignParameters[index].SpeedElevation.ToString();
                txtMultiLeafDoorsFlowCapacity.Text = DesignParameters[index].MultiLeafDoorsFlowCapacity.ToString();
                txtBottleNeckFlowCapacity.Text = DesignParameters[index].BottleNeckFlowCapacity.ToString();
                txtTurnstileFlowCapacity.Text = DesignParameters[index].TurnstileFlowCapacity.ToString();
                txtSingleLeafDoorsFlowCapacity.Text = DesignParameters[index].SingleLeafDoorsFlowCapacity.ToString();
                txtGatesFlowCapacity.Text = DesignParameters[index].GatesFlowCapacity.ToString();
                txtStairsFlowCapacity.Text = DesignParameters[index].StairsFlowCapacity.ToString();
                txtEscalatorFlowCapacity.Text = DesignParameters[index].EscalatorFlowCapacity.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message));
            }
            
        }

        #endregion

        private void mniAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow = new AboutWindow();
            string dir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path = string.Format(@"{0}\Docs\about.html", dir);
            //AboutWindow.webBrowser.Address = path;
            AboutWindow.ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace NFPASimulator.Models
{
    using Autodesk.Revit.DB;

    class StairViewModel : INotifyPropertyChanged
    {
        private StairModel StairM;
        private Document Doc;

        public StairViewModel() { }

        public StairViewModel(Document doc, StairModel sM)
        {
            StairM = sM;
            Doc = doc;
        }

        public string FamilyType { 
            get => Doc.GetElement(StairM.FamilyInstance).get_Parameter(BuiltInParameter.ELEM_FAMILY_AND_TYPE_PARAM).AsValueString();
            //set => EscalatorM.FamilyType = value;
        }
        public string TopLevel {
            get => StairM.TopLevel.Name;
            //set => EscalatorVM.TopLevel = value;
        }
        public string BaseLevel {
            get => StairM.BaseLevel.Name;
            //set => EscalatorVM.BaseLevel = value;
        }
        public double ClearWidth {
            get => StairM.ClearWidth;
            set => StairM.ClearWidth = value;
        }
        public double EscalatorFlowCapacity {
            get => StairM.StairFlowCapacity;
            set => StairM.StairFlowCapacity = value;
        }
        public int NumberOfPerson {
            get => StairM.NumberOfPerson;
            set => StairM.NumberOfPerson = value;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace NFPASimulator.Models
{
    using Autodesk.Revit.DB;

    class EscalatorViewModel : INotifyPropertyChanged
    {
        private EscalatorModel EscalatorM;
        private Document Doc;

        public EscalatorViewModel() { }

        public EscalatorViewModel(Document doc, EscalatorModel eM)
        {
            EscalatorM = eM;
            Doc = doc;
        }

        public string FamilyType { 
            get => Doc.GetElement(EscalatorM.FamilyInstance).get_Parameter(BuiltInParameter.ELEM_FAMILY_AND_TYPE_PARAM).AsValueString();
            //set => EscalatorM.FamilyType = value;
        }
        public string TopLevel {
            get => EscalatorM.TopLevel.Name;
            //set => EscalatorVM.TopLevel = value;
        }
        public string BaseLevel {
            get => EscalatorM.BaseLevel.Name;
            //set => EscalatorVM.BaseLevel = value;
        }
        public double ClearWidth {
            get => EscalatorM.ClearWidth;
            set => EscalatorM.ClearWidth = value;
        }
        public double EscalatorFlowCapacity {
            get => EscalatorM.EscalatorFlowCapacity;
            set => EscalatorM.EscalatorFlowCapacity = value;
        }
        public int NumberOfPerson {
            get => EscalatorM.NumberOfPerson;
            set => EscalatorM.NumberOfPerson = value;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

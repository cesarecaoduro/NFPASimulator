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
        private EscalatorViewModel EscalatorVM;

        public EscalatorViewModel(EscalatorViewModel eVM)
        {
            EscalatorVM = eVM;
        }

        public FamilyType FamilyType { 
            get => EscalatorVM.FamilyType;
            set => EscalatorVM.FamilyType = value;
        }
        public Level TopLevel {
            get => EscalatorVM.TopLevel;
            set => EscalatorVM.TopLevel = value;
        }
        public Level BaseLevel {
            get => EscalatorVM.BaseLevel;
            set => EscalatorVM.BaseLevel = value;
        }
        public double ClearWidth {
            get => EscalatorVM.ClearWidth;
            set => EscalatorVM.ClearWidth = value;
        }
        public double EscalatorFlowCapacity {
            get => EscalatorVM.EscalatorFlowCapacity;
            set => EscalatorVM.EscalatorFlowCapacity = value;
        }
        public int NumberOfPerson {
            get => EscalatorVM.NumberOfPerson;
            set => EscalatorVM.NumberOfPerson = value;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

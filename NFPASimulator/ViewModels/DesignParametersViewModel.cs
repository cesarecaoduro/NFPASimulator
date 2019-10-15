using NFPASimulator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFPASimulator.ViewModels
{
    class DesignParametersViewModel : INotifyPropertyChanged
    {
        private DesignParametersModel DesignParameters;

        public DesignParametersViewModel()
        {
            DesignParameters = new DesignParametersModel();
        }
        public DesignParametersViewModel(DesignParametersModel designParameters)
        {
            DesignParameters = designParameters;
        }

        public string name
        {
            get => DesignParameters.Name;
            set => DesignParameters.Name = value;
        }

        public double platformTravelSpeed
        {
            get => DesignParameters.PlatformTravelSpeed;
            set => DesignParameters.PlatformTravelSpeed = value;
        }

        public double concourseTravelSpeed
        {
            get => DesignParameters.ConcourseTravelSpeed;
            set => DesignParameters.ConcourseTravelSpeed = value;
        }

        public double speedElevation
        {
            get => DesignParameters.SpeedElevation;
            set => DesignParameters.SpeedElevation = value;
        }

        public double multiLeafDoorsFlowCapacity
        {
            get => DesignParameters.MultiLeafDoorsFlowCapacity;
            set => DesignParameters.MultiLeafDoorsFlowCapacity = value;
        }
        public double bottleNeckFlowCapacity
        {
            get => DesignParameters.BottleNeckFlowCapacity;
            set => DesignParameters.BottleNeckFlowCapacity = value;
        }
        public double turnstileFlowCapacity
        {
            get => DesignParameters.TurnstileFlowCapacity;
            set => DesignParameters.TurnstileFlowCapacity = value;
        }

        public double singleLeafDoorsFlowCapacity
        {
            get => DesignParameters.SingleLeafDoorsFlowCapacity;
            set => DesignParameters.SingleLeafDoorsFlowCapacity = value;
        }

        public double gatesFlowCapacity
        {
            get => DesignParameters.GatesFlowCapacity;
            set => DesignParameters.GatesFlowCapacity = value;
        }

        public double stairsFlowCapacity
        {
            get => DesignParameters.StairsFlowCapacity;
            set => DesignParameters.StairsFlowCapacity = value;
        }

        public double escalatorFlowCapacity
        {
            get => DesignParameters.EscalatorFlowCapacity;
            set => DesignParameters.EscalatorFlowCapacity = value;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

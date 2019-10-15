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

        public string name
        {
            get => DesignParameters.Name;
            set => DesignParameters.Name = value;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFPASimulator.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class DesignParametersModel
    {
        public string Name { get; set; }
        public double PlatformTravelSpeed { get; set; }
        public double ConcourseTravelSpeed { get; set; }
        public double SpeedElevation { get; set; }
        public double BottleNeckFlowCapacity { get; set; }
        public double MultiLeafDoorsFlowCapacity { get; set; }
        public int TurnstileFlowCapacity { get; set; }
        public double SingleLeafDoorsFlowCapacity { get; set; }
        public double GatesFlowCapacity { get; set; }
        public double StairsFlowCapacity { get; set; }
        public double EscalatorFlowCapacity { get; set; }
    }
}


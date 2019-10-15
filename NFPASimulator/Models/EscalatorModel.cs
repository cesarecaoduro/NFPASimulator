using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFPASimulator.Models
{
    using Autodesk.Revit.DB;

    class EscalatortModel
    {
        public FamilyType FamilyType { get; set; }
        public Level TopLevel { get; set; }
        public Level BaseLevel { get; set; }
        public double ClearWidth { get; set; }
        public double EscalatorFlowCapacity { get; set; }
        public int NumberOfPerson { get; set; }
    }
}

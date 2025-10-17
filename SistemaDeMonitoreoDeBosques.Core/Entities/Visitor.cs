using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeMonitoreoDeBosques.Core.Entities
{
    public partial class Visitor
    {
        public int id { get; set; }
        public string name { get; set; }
        public int ci { get; set; }
        public int phoneNumber { get; set; }
        public int emergencyNumber { get; set; }
        public bool isCamping { get; set; }
        public bool hasVehicle { get; set; }
        public int? vehicleId { get; set; }
        public virtual Vehicle vehicle { get; set; }
        public DateTime entryDate { get; set; }
        public DateTime exitDate { get; set; }


    }
}

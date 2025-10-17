using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeMonitoreoDeBosques.Infraestructure.DTOs
{
    public class VehicleDto
    {
        public string vehicle_type { get; set; }
        public string placa { get; set; }
        public string modelo { get; set; }
        public string marca { get; set; }
        public string color { get; set; }
    }
}

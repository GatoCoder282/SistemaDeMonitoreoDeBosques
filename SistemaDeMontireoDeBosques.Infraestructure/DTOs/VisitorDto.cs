using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace SistemaDeMonitoreoDeBosques.Infraestructure.DTOs
    {
        public class VisitorDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Ci { get; set; }
            public int PhoneNumber { get; set; }
            public int EmergencyNumber { get; set; }
            public bool IsCamping { get; set; }
            public bool HasVehicle { get; set; }
            public int? VehicleId { get; set; }
            public VehicleDto? Vehicle { get; set; } 
            public DateTime EntryDate { get; set; }
            public DateTime ExitDate { get; set; }
        }
    }



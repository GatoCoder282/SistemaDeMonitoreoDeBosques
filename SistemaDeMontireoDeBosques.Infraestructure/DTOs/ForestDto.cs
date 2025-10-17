using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeMonitoreoDeBosques.Infraestructure.DTOs
{
    public class ForestDto
    {
        public string name { get; set; }
        public float surface { get; set; }
        public float averageAltitude { get; set; }
    }
}

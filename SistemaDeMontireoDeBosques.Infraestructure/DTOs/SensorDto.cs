using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeMonitoreoDeBosques.Infraestructure.DTOs
{
    public class SensorDto
    {
        public int zonaId { get; set; }
        public string state { get; set; }
        public DateTime installationDate { get; set; }
        public DateTime lastReading { get; set; }
        public int readingFrequency { get; set; }
        public int sensorTypeId { get; set; }
        public int modelId { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }

    }
}

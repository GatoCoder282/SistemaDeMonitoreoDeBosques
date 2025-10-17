using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeMonitoreoDeBosques.Core.Entities
{
    public partial class Forest
    {
        public int id { get; set; }
        public string name { get; set; }
        public float surface { get; set; }
        public float averageAltitude { get; set; }
        public string vegatationType { get; set; }

    }
}

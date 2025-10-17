using SistemaDeMonitoreoDeBosques.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeMonitoreoDeBosques.Core.Interfaces
{
    public interface ISensorRepository
    {
        Task<IEnumerable<Sensor>> GetAllSensorAsync();
        Task<Sensor> GetSensorAsync(int id);
        Task InsertSensorAsync(Sensor sensor);
        Task UpdateSensorAsync(Sensor sensor);
        Task DeleteSensorAsync(Sensor sensor);
    }
}

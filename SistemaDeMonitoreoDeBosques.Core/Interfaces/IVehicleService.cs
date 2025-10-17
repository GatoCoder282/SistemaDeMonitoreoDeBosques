using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   
using SistemaDeMonitoreoDeBosques.Core.Entities;

namespace SistemaDeMonitoreoDeBosques.Core.Interfaces
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> GetAllVehicleAsync();
        Task<Vehicle?> GetVehicleAsync(int id);
        Task InsertVehicleAsync(Vehicle vehicle);
        Task UpdateVehicleAsync(Vehicle vehicle);
        Task DeleteVehicleAsync(Vehicle vehicle);
    }
}


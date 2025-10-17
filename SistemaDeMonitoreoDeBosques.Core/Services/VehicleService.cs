
using SistemaDeMonitoreoDeBosques.Core.Entities;
using SistemaDeMonitoreoDeBosques.Core.Interfaces;

namespace SistemaDeMonitoreoDeBosques.Core.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public Task<IEnumerable<Vehicle>> GetAllVehicleAsync() =>
            _vehicleRepository.GetAllVehicleAsync();

        public Task<Vehicle?> GetVehicleAsync(int id) =>
            _vehicleRepository.GetVehicleAsync(id);

        public Task InsertVehicleAsync(Vehicle vehicle) =>
            _vehicleRepository.InsertVehicleAsync(vehicle);

        public Task UpdateVehicleAsync(Vehicle vehicle) =>
            _vehicleRepository.UpdateVehicleAsync(vehicle);

        public Task DeleteVehicleAsync(Vehicle vehicle) =>
            _vehicleRepository.DeleteVehicleAsync(vehicle);
    }
}

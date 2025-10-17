// Core/Services/VisitorService.cs  (reemplaza el archivo; robusto)
using SistemaDeMonitoreoDeBosques.Core.Entities;
using SistemaDeMonitoreoDeBosques.Core.Interfaces;

namespace SistemaDeMonitoreoDeBosques.Core.Services
{
    public class VisitorService : IVisitorService
    {
        private readonly IVisitorRepository _visitorRepository;
        private readonly IVehicleRepository _vehicleRepository;

        public VisitorService(IVisitorRepository visitorRepository, IVehicleRepository vehicleRepository)
        {
            _visitorRepository = visitorRepository;
            _vehicleRepository = vehicleRepository;
        }

        public Task<IEnumerable<Visitor>> GetAllVisitorAsync() =>
            _visitorRepository.GetAllVisitorAsync();

        public Task<Visitor?> GetVisitorAsync(int id) =>
            _visitorRepository.GetVisitorAsync(id);

        public async Task InsertVisitorAsync(Visitor visitor)
        {
            // Reglas cruzadas que no cubre FluentValidation por sí sola:
            if (visitor.entryDate > visitor.exitDate)
                throw new Exception("La fecha de entrada no puede ser mayor a la de salida.");

            if (visitor.hasVehicle)
            {
                // Caso 1: mandan VehicleId
                if (visitor.vehicleId.HasValue)
                {
                    var exists = await _vehicleRepository.GetVehicleAsync(visitor.vehicleId.Value);
                    if (exists == null)
                        throw new Exception("El vehículo indicado no existe.");
                }
                // Caso 2: mandan objeto Vehicle sin Id
                else if (visitor.vehicle != null)
                {
                    await _vehicleRepository.InsertVehicleAsync(visitor.vehicle);
                    visitor.vehicleId = visitor.vehicle.id; // EF asigna el id
                    visitor.vehicle = null; // evitar tracking doble
                }
                else
                {
                    throw new Exception("Marcaste HasVehicle pero no enviaste VehicleId ni objeto Vehicle.");
                }
            }
            else
            {
                visitor.vehicleId = null;
                visitor.vehicle = null;
            }

            await _visitorRepository.InsertVisitorAsync(visitor);
        }

        public async Task UpdateVisitorAsync(Visitor visitor)
        {
            if (visitor.entryDate > visitor.exitDate)
                throw new Exception("La fecha de entrada no puede ser mayor a la de salida.");

            if (visitor.hasVehicle)
            {
                if (visitor.vehicleId.HasValue)
                {
                    var exists = await _vehicleRepository.GetVehicleAsync(visitor.vehicleId.Value);
                    if (exists == null)
                        throw new Exception("El vehículo indicado no existe.");
                }
                else if (visitor.vehicle != null)
                {
                    await _vehicleRepository.InsertVehicleAsync(visitor.vehicle);
                    visitor.vehicleId = visitor.vehicle.id;
                    visitor.vehicle = null;
                }
                else
                {
                    throw new Exception("Marcaste HasVehicle pero no enviaste VehicleId ni objeto Vehicle.");
                }
            }
            else
            {
                visitor.vehicleId = null;
                visitor.vehicle = null;
            }

            await _visitorRepository.UpdateVisitorAsync(visitor);
        }

        public Task DeleteVisitorAsync(Visitor visitor) =>
            _visitorRepository.DeleteVisitorAsync(visitor);
    }
}

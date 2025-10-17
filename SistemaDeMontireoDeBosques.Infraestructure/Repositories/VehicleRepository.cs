using Microsoft.EntityFrameworkCore;
using SistemaDeMonitoreoDeBosques.Core.Entities;
using SistemaDeMonitoreoDeBosques.Core.Interfaces;
using SistemaDeMonitoreoDeBosques.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeMonitoreoDeBosques.Infraestructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ForestMonitoringDbContext _context;

        public VehicleRepository(ForestMonitoringDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Vehicle>> GetAllVehicleAsync()
        {
            var vehicles = await _context.vehicles.ToListAsync();
            return vehicles;
        }


        public async Task<Vehicle> GetVehicleAsync(int id)
        {
            var vehicle = await _context.vehicles.FirstOrDefaultAsync(
                x => x.id == id);
            return vehicle;
        }

        public async Task InsertVehicleAsync(Vehicle Vehicle)
        {
            _context.vehicles.Add(Vehicle);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVehicleAsync(Vehicle Vehicle)
        {
            _context.vehicles.Update(Vehicle);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVehicleAsync(Vehicle Vehicle)
        {
            _context.vehicles.Remove(Vehicle);
            await _context.SaveChangesAsync();
        }


    }
}

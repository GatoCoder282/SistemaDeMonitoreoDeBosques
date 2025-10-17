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
    public class SensorRepository : ISensorRepository
    {
        private readonly ForestMonitoringDbContext _context;

        public SensorRepository(ForestMonitoringDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Sensor>> GetAllSensorAsync()
        {
            var sensors = await _context.sensors.ToListAsync();
            return sensors;
        }


        public async Task<Sensor> GetSensorAsync(int id)
        {
            var sensor = await _context.sensors.FirstOrDefaultAsync(
                x => x.id == id);
            return sensor;
        }

        public async Task InsertSensorAsync(Sensor Sensor)
        {
            _context.sensors.Add(Sensor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSensorAsync(Sensor Sensor)
        {
            _context.sensors.Update(Sensor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSensorAsync(Sensor Sensor)
        {
            _context.sensors.Remove(Sensor);
            await _context.SaveChangesAsync();
        }


    }
}

using SistemaDeMonitoreoDeBosques.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeMonitoreoDeBosques.Core.Interfaces;
using SistemaDeMonitoreoDeBosques.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeMonitoreoDeBosques.Infraestructure.Repositories
{
    public class ForestRepository : IForestRepository
    {
        private readonly ForestMonitoringDbContext _context;

        public ForestRepository(ForestMonitoringDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Forest>> GetAllForestAsync()
        {
            var forests = await _context.forests.ToListAsync();
            return forests;
        }


        public async Task<Forest> GetForestAsync(int id)
        {
            var forest = await _context.forests.FirstOrDefaultAsync(
                x => x.id == id);
            return forest;
        }

        public async Task InsertForestAsync(Forest Forest)
        {
            _context.forests.Add(Forest);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateForestAsync(Forest Forest)
        {
            _context.forests.Update(Forest);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteForestAsync(Forest Forest)
        {
            _context.forests.Remove(Forest);
            await _context.SaveChangesAsync();
        }


    }
}

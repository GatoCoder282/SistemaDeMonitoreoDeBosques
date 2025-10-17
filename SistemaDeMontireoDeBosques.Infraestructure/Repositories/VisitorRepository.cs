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
    public class VisitorRepository : IVisitorRepository
    {
        private readonly ForestMonitoringDbContext _context;

        public VisitorRepository(ForestMonitoringDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Visitor>> GetAllVisitorAsync()
        {
            var visitors = await _context.visitors.ToListAsync();
            return visitors;
        }


        public async Task<Visitor> GetVisitorAsync(int id)
        {
            var visitor = await _context.visitors.FirstOrDefaultAsync(
                x => x.id == id);
            return visitor;
        }

        public async Task InsertVisitorAsync(Visitor visitor)
        {
            _context.visitors.Add(visitor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVisitorAsync(Visitor visitor)
        {
            _context.visitors.Update(visitor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVisitorAsync(Visitor visitor)
        {
            _context.visitors.Remove(visitor);
            await _context.SaveChangesAsync();
        }


    }
}

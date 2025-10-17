using SistemaDeMonitoreoDeBosques.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeMonitoreoDeBosques.Core.Interfaces
{
    public interface IVisitorRepository
    {
        Task<IEnumerable<Visitor>> GetAllVisitorAsync();
        Task<Visitor> GetVisitorAsync(int id);
        Task InsertVisitorAsync(Visitor visitor);
        Task UpdateVisitorAsync(Visitor visitor);
        Task DeleteVisitorAsync(Visitor visitor);
    }
}

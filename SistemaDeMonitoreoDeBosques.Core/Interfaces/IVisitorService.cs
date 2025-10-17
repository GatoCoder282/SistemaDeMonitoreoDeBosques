using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeMonitoreoDeBosques.Core.Entities;

namespace SistemaDeMonitoreoDeBosques.Core.Interfaces
{
    public interface IVisitorService
    {
        Task<IEnumerable<Visitor>> GetAllVisitorAsync();
        Task<Visitor?> GetVisitorAsync(int id);
        Task InsertVisitorAsync(Visitor visitor);
        Task UpdateVisitorAsync(Visitor visitor);
        Task DeleteVisitorAsync(Visitor visitor);
    }
}


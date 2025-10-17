using SistemaDeMonitoreoDeBosques.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeMonitoreoDeBosques.Core.Interfaces
{
    public interface IForestRepository
    {
        Task<IEnumerable<Forest>> GetAllForestAsync();
        Task<Forest> GetForestAsync(int id);
        Task InsertForestAsync(Forest forest);
        Task UpdateForestAsync(Forest forest);
        Task DeleteForestAsync(Forest forest);
    }
}

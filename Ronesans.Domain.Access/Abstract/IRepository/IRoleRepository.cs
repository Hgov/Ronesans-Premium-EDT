using Ronesans.Domain.Concrete.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ronesans.Domain.Access.Abstract.IRepository
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<bool> GetAnyAsync(int id);
    }
}

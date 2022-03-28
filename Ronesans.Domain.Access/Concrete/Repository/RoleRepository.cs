using Microsoft.EntityFrameworkCore;
using Ronesans.Domain.Access.Abstract.IRepository;
using Ronesans.Domain.Access.Helpers;
using Ronesans.Domain.Concrete.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ronesans.Domain.Access.Concrete.Repository
{
   public class RoleRepository:Repository<Role>,IRoleRepository
    {
        public RoleRepository(RonesansDbContext ronesansDbContext) : base(ronesansDbContext)
        {

        }
        public RonesansDbContext ronesansDbContext { get { return _Context as RonesansDbContext; } }

        public async Task<bool> GetAnyAsync(int id)
        {
            return await _Context.Roles.AnyAsync(x=>x.role_id==id);
        }
    }
}

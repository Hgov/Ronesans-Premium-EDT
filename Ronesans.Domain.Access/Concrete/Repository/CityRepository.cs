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
   public class CityRepository:Repository<City>,ICityRepository
    {
        public CityRepository(RonesansDbContext ronesansDbContext) : base(ronesansDbContext)
        {

        }
        public RonesansDbContext ronesansDbContext { get { return _Context as RonesansDbContext; } }

        public async Task<bool> GetIdAnyAsync(int id)
        {
            return await _Context.Cities.AnyAsync(x=>x.city_id==id);
        }
    }
}

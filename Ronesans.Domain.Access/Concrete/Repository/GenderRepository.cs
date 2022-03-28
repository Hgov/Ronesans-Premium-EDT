using Microsoft.EntityFrameworkCore;
using Ronesans.Domain.Access.Abstract.IRepository;
using Ronesans.Domain.Access.Helpers;
using Ronesans.Domain.Concrete.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Ronesans.Domain.Access.Concrete.Repository
{
   public class GenderRepository : Repository<Gender>, IGenderRepository
    {
        public GenderRepository(RonesansDbContext ronesansDbContext) : base(ronesansDbContext)
        {

        }
        public RonesansDbContext ronesansDbContext { get { return _Context as RonesansDbContext; } }
        public async Task<bool> GetAnyAsync(int id)
        {
            return await _Context.Genders.AnyAsync(x=>x.gender_id==id);
        }
    }
}

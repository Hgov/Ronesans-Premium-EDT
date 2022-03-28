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
    public class ShopRepository : Repository<Shop>, IShopRepository
    {
        public ShopRepository(RonesansDbContext ronesansDbContext) : base(ronesansDbContext)
        {

        }
        public RonesansDbContext ronesansDbContext { get { return _Context as RonesansDbContext; } }

        public async Task<Shop> GetByIdShopAllAsync(int id)
        {
            return await _Context.Shops.Where(x => x.shop_id == id)
                .Include(x => x.City)
                //.Include(x => x.User.gender)
                //.Include(x => x.User.Role)
                //.Include(x => x.User.UserFiles)
                //.ThenInclude(x => x.File)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> GetIdAnyAsync(int id)
        {
            return await _Context.Shops.AnyAsync(x => x.shop_id == id);
        }

        public async Task<IEnumerable<Shop>> GetShopAllAsync()
        {
            return await _Context.Shops
                .Include(x => x.City)
                //.Include(x => x.User.gender)
                //.Include(x => x.User.Role)
                //.Include(x => x.User.UserFiles)
                //.ThenInclude(x => x.File)
                .ToListAsync();
        }

        public async Task<bool> GetShopNameAnyAsync(string shop_name)
        {
            return await _Context.Shops.AnyAsync(x => x.shop_name == shop_name);
        }

        public async Task<bool> GetShopTitleAnyAsync(string shop_title)
        {
            return await _Context.Shops.AnyAsync(x => x.title == shop_title);
        }
    }
}

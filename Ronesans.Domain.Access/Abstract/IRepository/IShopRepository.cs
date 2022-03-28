using Ronesans.Domain.Concrete.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ronesans.Domain.Access.Abstract.IRepository
{
    public interface IShopRepository:IRepository<Shop>
    {
        Task<IEnumerable<Shop>> GetShopAllAsync();
        Task<Shop> GetByIdShopAllAsync(int id);
        Task<bool> GetIdAnyAsync(int id);
        Task<bool> GetShopNameAnyAsync(string shop_name);
        Task<bool> GetShopTitleAnyAsync(string shop_title);
    }
}

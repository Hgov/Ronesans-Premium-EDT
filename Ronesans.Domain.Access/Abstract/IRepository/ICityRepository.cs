using Ronesans.Domain.Concrete.Domain;
using System.Threading.Tasks;

namespace Ronesans.Domain.Access.Abstract.IRepository
{
    public interface ICityRepository : IRepository<City>
    {
        Task<bool> GetIdAnyAsync(int id);
    }
}

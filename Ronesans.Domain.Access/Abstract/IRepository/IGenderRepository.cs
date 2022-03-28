using Ronesans.Domain.Concrete.Domain;
using System.Threading.Tasks;

namespace Ronesans.Domain.Access.Abstract.IRepository
{
    public interface IGenderRepository : IRepository<Gender>
    {
        Task<bool> GetAnyAsync(int id);
    }
}

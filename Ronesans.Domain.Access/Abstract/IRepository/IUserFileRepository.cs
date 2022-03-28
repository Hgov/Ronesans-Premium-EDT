using Ronesans.Domain.Concrete.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ronesans.Domain.Access.Abstract.IRepository
{
    public  interface IUserFileRepository:IRepository<UserFile>
    {
        Task<UserFile> GetByIdUserWithFileAsync(int id);
        Task<IEnumerable<UserFile>> GetUserWithFileAsync();
    }
}

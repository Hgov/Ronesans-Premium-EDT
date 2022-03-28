using Ronesans.Domain.Concrete.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ronesans.Domain.Access.Abstract.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetUserAllAsync();
        Task<bool> GetIdAnyAsync(int id);
        Task<bool> GetEmailAnyAsync(string email);
        Task<bool> GetPhoneAnyAsync(string phone);
        Task<User> GetByIdUserAllAsync(int id);
    }
}

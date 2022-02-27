using Ronesans.Domain.Concrete.Domain;
using System;
using System.Collections.Generic;

namespace Ronesans.Domain.Access.Abstract.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetUserAll();
        bool GetIdAny(int id);
        bool GetEmailAny(string email);
        bool GetPhoneAny(string phone);
        User GetByIdUserAll(int id);
    }
}

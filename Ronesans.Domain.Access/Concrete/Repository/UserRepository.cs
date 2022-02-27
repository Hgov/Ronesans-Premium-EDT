using Microsoft.EntityFrameworkCore;
using Ronesans.Domain.Access.Abstract.IRepository;
using Ronesans.Domain.Access.Helpers;
using Ronesans.Domain.Concrete.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ronesans.Domain.Access.Concrete.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RonesansDbContext ronesansDbContext) : base(ronesansDbContext)
        {

        }
        public RonesansDbContext ronesansDbContext { get { return _Context as RonesansDbContext; } }

        public IEnumerable<User> GetUserAll()
        {

            return _Context.Users
                .Include(x => x.gender)
                .Include(x => x.Role)
                .Include(x => x.UserFiles)
                .ThenInclude(x => x.File)
                .ToList();
        }

        public User GetByIdUserAll(int id)
        {
            return _Context.Users.Where(x => x.user_id == id)
                .Include(x => x.gender)
                .Include(x => x.Role)
                .Include(x => x.UserFiles)
                .ThenInclude(x => x.File)
                .FirstOrDefault();
        }
        public bool GetIdAny(int id)
        {
            return _Context.Users.Any(x => x.user_id == id);
        }
        public bool GetEmailAny(string email)
        {
            return _Context.Users.Any(x => x.email == email);
        }
        public bool GetPhoneAny(string phone)
        {
            return _Context.Users.Any(x => x.phone == phone);
        }
    }
}

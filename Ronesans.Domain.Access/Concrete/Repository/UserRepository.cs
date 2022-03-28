using Microsoft.EntityFrameworkCore;
using Ronesans.Domain.Access.Abstract.IRepository;
using Ronesans.Domain.Access.Helpers;
using Ronesans.Domain.Concrete.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ronesans.Domain.Access.Concrete.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RonesansDbContext ronesansDbContext) : base(ronesansDbContext)
        {

        }
        public RonesansDbContext ronesansDbContext { get { return _Context as RonesansDbContext; } }

        public async Task<IEnumerable<User>> GetUserAllAsync()
        {
            return await _Context.Users
                .Include(x => x.gender)
                .Include(x => x.Role)
                //.Include(x => x.UserFiles)
                //.ThenInclude(x => x.File)
                .ToListAsync();
        }

        public async Task<User> GetByIdUserAllAsync(int id)
        {
            return await _Context.Users
                .Where(x => x.user_id == id)
                .Include(x => x.gender)
                .Include(x => x.Role)
                //.Include(x => x.UserFiles)
                //.ThenInclude(x => x.File)
                .FirstOrDefaultAsync();
        }
        public async Task<bool> GetIdAnyAsync(int id)
        {
            return await _Context.Users.AnyAsync(x => x.user_id == id);
        }
        public async Task<bool> GetEmailAnyAsync(string email)
        {
            return await _Context.Users.AnyAsync(x => x.email == email);
        }
        public async Task<bool> GetPhoneAnyAsync(string phone)
        {
            return await _Context.Users.AnyAsync(x => x.phone == phone);
        }
    }
}

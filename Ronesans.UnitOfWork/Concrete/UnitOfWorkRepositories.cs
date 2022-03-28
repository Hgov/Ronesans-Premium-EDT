using Ronesans.Domain.Access.Abstract.IRepository;
using Ronesans.Domain.Access.Concrete.Repository;
using Ronesans.Domain.Access.Helpers;
using Ronesans.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ronesans.UnitOfWork.Concrete
{
   public class UnitOfWorkRepositories:IUnitOfWorkRepositories
    {
        private RonesansDbContext _RonesansDbContext;
        public UnitOfWorkRepositories(RonesansDbContext RonesansDbContext)
        {
            _RonesansDbContext = RonesansDbContext;
            userRepository = new UserRepository(_RonesansDbContext);
            fileRepository = new FileRepository(_RonesansDbContext);
            userFileRepository = new UserFileRepository(_RonesansDbContext);
            genderRepository = new GenderRepository(_RonesansDbContext);
            cityRepository = new CityRepository(_RonesansDbContext);
            roleRepository = new RoleRepository(_RonesansDbContext);
            shopRepository = new ShopRepository(_RonesansDbContext);
            shopFileRepository = new ShopFileRepository(_RonesansDbContext);

        }

        public IUserRepository userRepository { get; private set; }

        public IFileRepository fileRepository { get; private set; }

        public IUserFileRepository userFileRepository { get; private set; }

        public IGenderRepository genderRepository { get; private set; }

        public ICityRepository cityRepository { get; private set; }

        public IRoleRepository roleRepository { get; private set; }

        public IShopRepository shopRepository { get; private set; }

        public IShopFileRepository shopFileRepository { get; private set; }

        public int Complete()
        {

            return _RonesansDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _RonesansDbContext.Dispose();
        }
    }
}

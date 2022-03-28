using Ronesans.Domain.Access.Abstract.IRepository;
using Ronesans.Domain.Access.Concrete.Repository;
using Ronesans.Domain.Access.Helpers;
using Ronesans.Domain.Concrete.Domain;
using Ronesans.Mapper.Abstract;
using Ronesans.Rule.Rule.Abstract;
using Ronesans.Rule.Rule.Concrete;
using Ronesans.UnitOfWork.Abstract;

namespace Ronesans.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private RonesansDbContext _RonesansDbContext;
        public UnitOfWork(RonesansDbContext RonesansDbContext)
        {
            _RonesansDbContext = RonesansDbContext;
            fileCreate = new FileCreate<File>();
            mapper = new Mapper.Concrete.MyAutoMapper.Mapper();
        }


        public IFileCreate<File> fileCreate { get; private set; }
        public IMapper mapper { get; private set; }
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

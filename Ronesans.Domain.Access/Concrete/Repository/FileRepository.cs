using Ronesans.Domain.Access.Abstract.IRepository;
using Ronesans.Domain.Access.Helpers;
using File = Ronesans.Domain.Concrete.Domain.File;

namespace Ronesans.Domain.Access.Concrete.Repository
{
    public class FileRepository : Repository<File>, IFileRepository
    {
        public FileRepository(RonesansDbContext ronesansDbContext) : base(ronesansDbContext)
        {

        }
        public RonesansDbContext ronesansDbContext { get { return _Context as RonesansDbContext; } }


    }
}

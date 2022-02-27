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
            userRepository = new UserRepository(_RonesansDbContext);
            fileRepository = new FileRepository(_RonesansDbContext);
            fileCreate = new FileCreate<File>();
            userFileRepository = new UserFileRepository(_RonesansDbContext);
            ruleUser = new RuleUser(userRepository);
            ruleFile = new RuleFile(fileRepository);
        }

        public IUserRepository userRepository { get; private set; }


        public IFileRepository fileRepository { get; private set; }

        public IFileCreate<File> fileCreate { get; private set; }

        public IUserFileRepository userFileRepository { get; private set; }

        public IRule<User> ruleUser { get; private set; }

        public IRule<File> ruleFile { get; private set; }

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

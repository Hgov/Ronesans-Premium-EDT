using Ronesans.Domain.Access.Abstract.IRepository;
using Ronesans.Domain.Access.Helpers;
using Ronesans.Domain.Concrete.Domain;
using Ronesans.Rule.Rule.Abstract;
using Ronesans.Rule.Rule.Concrete;
using Ronesans.UnitOfWork.Abstract;

namespace Ronesans.UnitOfWork.Concrete
{
    public class UnitOfWorkRules:IUnitOfWorkRules
    {
        private RonesansDbContext _RonesansDbContext;
        private UnitOfWorkRepositories _unitOfWorkRepositories;
        private UnitOfWork _unitOfWork;
        public UnitOfWorkRules(RonesansDbContext RonesansDbContext)
        {
            _RonesansDbContext = RonesansDbContext;
            _unitOfWorkRepositories = new UnitOfWorkRepositories(_RonesansDbContext);
            _unitOfWork = new UnitOfWork(_RonesansDbContext);
            ruleUser = new RuleUser(_unitOfWorkRepositories.userRepository, _unitOfWorkRepositories.genderRepository, _unitOfWorkRepositories.roleRepository);
            ruleFile = new RuleFile(_unitOfWorkRepositories.fileRepository, _unitOfWork.fileCreate);
            ruleUserFile = new RuleUserFile(_unitOfWorkRepositories.userFileRepository);
            ruleGender = new RuleGender(_unitOfWorkRepositories.genderRepository);
            ruleCity = new RuleCity(_unitOfWorkRepositories.cityRepository);
            ruleRole = new RuleRole(_unitOfWorkRepositories.roleRepository);
            ruleShop = new RuleShop(_unitOfWorkRepositories.shopRepository, _unitOfWorkRepositories.userRepository, _unitOfWorkRepositories.cityRepository);
        }

        public IRule<User> ruleUser { get; private set; }

        public IRule<File> ruleFile { get; private set; }

        public IRule<UserFile> ruleUserFile { get; private set; }


        public IRule<Gender> ruleGender { get; private set; }


        public IRule<City> ruleCity { get; private set; }


        public IRule<Role> ruleRole { get; private set; }

        public IRule<Shop> ruleShop { get; private set; }


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

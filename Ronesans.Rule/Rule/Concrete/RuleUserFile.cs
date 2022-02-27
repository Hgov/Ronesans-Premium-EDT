using Ronesans.Domain.Access.Abstract.IRepository;
using Ronesans.Domain.Concrete.Domain;
using Ronesans.Rule.Rule.Abstract;
using System;

namespace Ronesans.Rule.Rule.Concrete
{
    public class RuleUserFile : IRule<UserFile>
    {
        private IUserRepository _userRepository;
        public RuleUserFile(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void RuleDelete(int id, string destination)
        {
            throw new NotImplementedException();
        }

        public void RuleGet()
        {
            throw new NotImplementedException();
        }

        public void RuleGetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserFile RulePost(UserFile UserFile)
        {
            return UserFile;
        }

        public UserFile RulePut(int id, UserFile UserFile)
        {
            throw new NotImplementedException();
        }
    }
}

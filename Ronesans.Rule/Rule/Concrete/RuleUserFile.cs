using Ronesans.Domain.Access.Abstract.IRepository;
using Ronesans.Domain.Access.Helpers;
using Ronesans.Domain.Concrete.Domain;
using Ronesans.Rule.Rule.Abstract;
using System;

namespace Ronesans.Rule.Rule.Concrete
{
    public class RuleUserFile : IRule<UserFile>
    {
        private IUserFileRepository _userFileRepository;
        public RuleUserFile(IUserFileRepository userFileRepository)
        {
            _userFileRepository = userFileRepository;
        }

        public void RuleDelete(int id)
        {
            throw new NotImplementedException();
        }

        public void RuleGet()
        {

            if (_userFileRepository.CountAsync().Result == 0)
                throw new AppException("No Records Found");
        }

        public void RuleGetById(int id)
        {
            var _user = _userFileRepository.GetByIdUserWithFileAsync(id).Result;
            if (_user == null)
                throw new AppException("User File Not Found.");
        }

        public UserFile RulePost(UserFile entity)
        {
            throw new NotImplementedException();
        }

        public UserFile RulePut(int id, UserFile entity)
        {
            throw new NotImplementedException();
        }
    }
}

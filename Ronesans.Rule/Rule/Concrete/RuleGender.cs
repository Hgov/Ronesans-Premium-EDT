using Ronesans.Domain.Access.Abstract.IRepository;
using Ronesans.Domain.Access.Helpers;
using Ronesans.Domain.Concrete.Domain;
using Ronesans.Rule.Rule.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ronesans.Rule.Rule.Concrete
{
   public class RuleGender:IRule<Gender>
    {
        private IGenderRepository _genderRepository;
        public RuleGender(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public void RuleDelete(int id)
        {
            var _gender = _genderRepository.GetByID(id);
            if (_gender == null)
                throw new AppException("Gender Not Found.");
        }

        public void RuleGet()
        {
            if (_genderRepository.CountAsync().Result == 0)
                throw new AppException("No Records Found");
        }

        public void RuleGetById(int id)
        {
            var _gender = _genderRepository.GetByID(id);
            if (_gender == null)
                throw new AppException("Gender Not Found.");
        }

        public Gender RulePost(Gender Gender)
        {
            var _gender = _genderRepository.GetByID(Gender.gender_id);
            if (_gender != null)
                throw new AppException(Gender.gender_id+ " is already taken");
            return Gender;
        }

        public Gender RulePut(int id, Gender Gender)
        {
            var _gender = _genderRepository.GetByID(id);
            if (_gender == null)
                throw new AppException("Gender Not Found.");

            if (!string.IsNullOrWhiteSpace(Gender.name) && _gender.name != Gender.name)
                _gender.name = Gender.name;
            return _gender;
        }
    }
}

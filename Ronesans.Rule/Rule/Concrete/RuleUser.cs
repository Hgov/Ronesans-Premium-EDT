using Ronesans.Domain.Access.Abstract.IRepository;
using Ronesans.Domain.Access.Helpers;
using Ronesans.Domain.Concrete.Domain;
using Ronesans.Rule.Rule.Abstract;
using System;

namespace Ronesans.Rule.Rule.Concrete
{
    public class RuleUser:IRule<User>
    {
        private IUserRepository _userRepository;
        public RuleUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void RuleGet()
        {

            if (_userRepository.Count() == 0)
                throw new AppException("No Records Found");
        }

        public void RuleGetById(int id)
        {
            var _user = _userRepository.GetByID(id);
            if (_user == null)
                throw new AppException("User Not Found.");
        }


        public User RulePost(User User)
        {
            //all ready taken data
            var _userEmail = _userRepository.GetEmailAny(User.email);
            if (_userEmail)
                throw new AppException(User.email + " is already taken");
            var _userPhone = _userRepository.GetPhoneAny(User.phone);
            if (_userPhone)
                throw new AppException(User.phone + " is already taken");

            //data change base
            User.creation_tsz = DateTime.Now;
            User.last_updated_tsz = DateTime.Now;

            return User;
        }
        public User RulePut(int id, User User)
        {
            var _user = _userRepository.GetByID(id);
            if (_user == null)
                throw new AppException("User Not Found.");



            //all ready taken data
            var _userEmail = _userRepository.GetEmailAny(User.email);
            if (_userEmail)
                throw new AppException(User.email + " is already taken");
            var _userPhone = _userRepository.GetPhoneAny(User.phone);
            if (_userPhone)
                throw new AppException(User.phone + " is already taken");



            //data change
            if (!string.IsNullOrWhiteSpace(User.role_id.ToString()) && _user.role_id != User.role_id)
                _user.role_id = User.role_id;
            if (!string.IsNullOrWhiteSpace(User.gender_id.ToString()) && _user.gender_id != User.gender_id)
                _user.gender_id = User.gender_id;
            if (!string.IsNullOrWhiteSpace(User.first_name) && _user.first_name != User.first_name)
                _user.first_name = User.first_name;
            if (!string.IsNullOrWhiteSpace(User.last_name) && _user.last_name != User.last_name)
                _user.last_name = User.last_name;
            if (!string.IsNullOrWhiteSpace(User.email) && _user.email != User.email)
                _user.email = User.email;
            if (!string.IsNullOrWhiteSpace(User.password) && _user.password != User.password)
                _user.password = User.password;
            if (!string.IsNullOrWhiteSpace(User.phone) && _user.phone != User.phone)
                _user.phone = User.phone;
            if (!string.IsNullOrWhiteSpace(User.bio) && _user.bio != User.bio)
                _user.bio = User.bio;
            if (User.status_active != null && _user.status_active != User.status_active)
                _user.status_active = User.status_active;
            if (User.status_visibility != null && _user.status_visibility != User.status_visibility)
                _user.status_visibility = User.status_visibility;
            if (!string.IsNullOrWhiteSpace(User.delete_tsz.ToString()) && _user.delete_tsz != User.delete_tsz)
                _user.delete_tsz = User.delete_tsz;
            if (!string.IsNullOrWhiteSpace(User.creation_tsz.ToString()) && _user.creation_tsz != User.creation_tsz)
                _user.creation_tsz = User.creation_tsz;



            _user.last_updated_tsz = DateTime.UtcNow;

            return _user;
        }

        public void RuleDelete(int id, string destination)
        {
            var _user = _userRepository.GetByID(id);
            if (_user == null)
                throw new AppException("User Not Found.");


        }
    }
}

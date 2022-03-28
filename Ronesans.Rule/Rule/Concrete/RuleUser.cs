using Ronesans.Domain.Access.Abstract.IRepository;
using Ronesans.Domain.Access.Helpers;
using Ronesans.Domain.Concrete.Domain;
using Ronesans.Rule.Rule.Abstract;
using System;
using System.Threading.Tasks;

namespace Ronesans.Rule.Rule.Concrete
{
    public class RuleUser:IRule<User>
    {
        private IUserRepository _userRepository;
        private IGenderRepository _genderRepository;
        private IRoleRepository _roleRepository;
        public RuleUser(IUserRepository userRepository, IGenderRepository genderRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _genderRepository = genderRepository;
            _roleRepository = roleRepository;
        }
        public void RuleGet()
        {

            if (_userRepository.CountAsync().Result == 0)
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
            var _userEmail = _userRepository.GetEmailAnyAsync(User.email).Result;
            if (_userEmail)
                throw new AppException(User.email + " is already taken");
            var _userPhone = _userRepository.GetPhoneAnyAsync(User.phone).Result;
            if (_userPhone)
                throw new AppException(User.phone + " is already taken");
            var _isRole = _roleRepository.GetAnyAsync((int)User.role_id).Result;
            if(!_isRole)
                throw new AppException("Role Not Found.");
            var _isGender = _genderRepository.GetAnyAsync((int)User.gender_id).Result;
            if (!_isGender)
                throw new AppException("Gender Not Found.");


            //data change base
            User.creation_tsz = DateTime.Now;
            User.last_updated_tsz = DateTime.Now;

            return  User;
        }
        public User RulePut(int id, User User)
        {
            var _user = _userRepository.GetByID(id);
            if (_user == null)
                throw new AppException("User Not Found.");



            //all ready taken data
            var _userEmail = _userRepository.GetEmailAnyAsync(User.email).Result;
            if (_userEmail)
                throw new AppException(User.email + " is already taken");
            var _userPhone = _userRepository.GetPhoneAnyAsync(User.phone).Result;
            if (_userPhone)
                throw new AppException(User.phone + " is already taken");



            //data change
            if (!string.IsNullOrWhiteSpace(User.role_id.ToString()) && _user.role_id != User.role_id)
            {
                var _isRole = _roleRepository.GetAnyAsync((int)User.role_id).Result;
                if (!_isRole)
                    throw new AppException("Role Not Found.");
                _user.role_id = User.role_id;
            }
            if (!string.IsNullOrWhiteSpace(User.gender_id.ToString()) && _user.gender_id != User.gender_id)
            {
                var _isGender = _genderRepository.GetAnyAsync((int)User.gender_id).Result;
                if (!_isGender)
                    throw new AppException("Gender Not Found.");
                _user.gender_id = User.gender_id;
            }
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



            _user.last_updated_tsz = DateTime.Now;

            return _user;
        }

        public void RuleDelete(int id)
        {
            var _user = _userRepository.GetByID(id);
            if (_user == null)
                throw new AppException("User Not Found.");
        }
    }
}

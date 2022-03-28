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
    public class RuleRole:IRule<Role>
    {
        private IRoleRepository _RoleRepository;
        public RuleRole(IRoleRepository RoleRepository)
        {
            _RoleRepository = RoleRepository;
        }


        public void RuleDelete(int id)
        {
            var _Role = _RoleRepository.GetByID(id);
            if (_Role == null)
                throw new AppException("Role Not Found.");
        }

        public void RuleGet()
        {
            if (_RoleRepository.CountAsync().Result == 0)
                throw new AppException("No Records Found");
        }

        public void RuleGetById(int id)
        {
            var _Role = _RoleRepository.GetByID(id);
            if (_Role == null)
                throw new AppException("Role Not Found.");
        }

        public Role RulePost(Role Role)
        {
            var _Role = _RoleRepository.GetByID(Role.role_id);
            if (_Role != null)
                throw new AppException(Role.role_id + " is already taken");
            return Role;
        }

        public Role RulePut(int id, Role Role)
        {
            var _Role = _RoleRepository.GetByID(id);
            if (_Role == null)
                throw new AppException("Role Not Found.");

            if (!string.IsNullOrWhiteSpace(Role.role) && _Role.role != Role.role)
                _Role.role = Role.role;
            if (!string.IsNullOrWhiteSpace(Role.description) && _Role.description != Role.description)
                _Role.description = Role.description;
            return _Role;
        }
    }
}

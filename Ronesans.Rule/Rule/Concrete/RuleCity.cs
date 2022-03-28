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
   public class RuleCity : IRule<City>
    {
        private ICityRepository _cityRepository;
        public RuleCity(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public void RuleDelete(int id)
        {
            var _city = _cityRepository.GetByID(id);
            if (_city == null)
                throw new AppException("City Not Found.");
        }

        public void RuleGet()
        {
            if (_cityRepository.CountAsync().Result == 0)
                throw new AppException("No Records Found");
        }

        public void RuleGetById(int id)
        {
            var _city = _cityRepository.GetByID(id);
            if (_city == null)
                throw new AppException("City Not Found.");
        }

        public City RulePost(City City)
        {
            var _city = _cityRepository.GetByID(City.city_id);
            if (_city != null)
                throw new AppException(City.city_id + " is already taken");
            return City;
        }

        public City RulePut(int id, City City)
        {
            var _city = _cityRepository.GetByID(id);
            if (_city == null)
                throw new AppException("City Not Found.");

            if (!string.IsNullOrWhiteSpace(City.name) && _city.name != City.name)
                _city.name = City.name;
            return _city;
        }
    }
}

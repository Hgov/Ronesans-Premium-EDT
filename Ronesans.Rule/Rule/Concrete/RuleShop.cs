using Ronesans.Domain.Access.Abstract.IRepository;
using Ronesans.Domain.Access.Helpers;
using Ronesans.Domain.Concrete.Domain;
using Ronesans.Rule.Rule.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ronesans.Rule.Rule.Concrete
{
    public class RuleShop : IRule<Shop>
    {
        private IUserRepository _userRepository;
        private ICityRepository _cityRepository;
        private IShopRepository _shopRepository;
        public RuleShop(IShopRepository shopRepository, IUserRepository userRepository, ICityRepository cityRepository)
        {
            _userRepository = userRepository;
            _cityRepository = cityRepository;
            _shopRepository = shopRepository;
        }

        public void RuleDelete(int id)
        {
            var _shop = _shopRepository.GetByID(id);
            if (_shop == null)
                throw new AppException("Shop Not Found.");
        }

        public void RuleGet()
        {

            if (_shopRepository.CountAsync().Result == 0)
                throw new AppException("No Records Found");
        }

        public void RuleGetById(int id)
        {
            var _shop = _shopRepository.GetByID(id);
            if (_shop == null)
                throw new AppException("Shop Not Found.");
        }

        public Shop RulePost(Shop Shop)
        {
            Shop.shop_name = Shop.shop_name.Replace(' ', '-').ToLower();
            //all ready taken data
            var _isUser = _userRepository.GetIdAnyAsync((int)Shop.user_id).Result;
            if (!_isUser)
                throw new AppException("User Not Found.");
            var _isCity = _cityRepository.GetIdAnyAsync((int)Shop.city_id).Result;
            if (!_isCity)
                throw new AppException("City Not Found.");
            var _isShopName = _shopRepository.GetShopNameAnyAsync(Shop.shop_name).Result;
            if (_isShopName)
                throw new AppException(Shop.shop_name + " is already taken");
            var _isShopTitle = _shopRepository.GetShopTitleAnyAsync(Shop.title).Result;
            if (_isShopTitle)
                throw new AppException(Shop.title + " is already taken");


            //data change base
            Shop.creation_tsz = DateTime.Now;
            Shop.last_updated_tsz = DateTime.Now;

            return Shop;
        }

        public Shop RulePut(int id, Shop Shop)
        {
            var _shop = _shopRepository.GetByID(id);
            if (_shop == null)
                throw new AppException("Shop Not Found.");

            var _isShopName = _shopRepository.GetShopNameAnyAsync(!string.IsNullOrWhiteSpace(Shop.shop_name) ? Shop.shop_name.Replace(' ', '-').ToLower():Shop.shop_name).Result;
            if (_isShopName)
                throw new AppException(Shop.shop_name + " is already taken");
            var _isShopTitle = _shopRepository.GetShopTitleAnyAsync(Shop.title).Result;
            if (_isShopTitle)
                throw new AppException(Shop.title + " is already taken");

            //data change
            if (!string.IsNullOrWhiteSpace(Shop.user_id.ToString()) && _shop.user_id != Shop.user_id)
            {
                var _isUser = _userRepository.GetIdAnyAsync((int)Shop.user_id).Result;
                if (!_isUser)
                    throw new AppException("User Not Found.");
                _shop.user_id = Shop.user_id;
            }
            if (!string.IsNullOrWhiteSpace(Shop.city_id.ToString()) && _shop.city_id != Shop.city_id)
            {
                var _isCity = _cityRepository.GetIdAnyAsync((int)Shop.city_id).Result;
                if (!_isCity)
                    throw new AppException("City Not Found.");
                _shop.city_id = Shop.city_id;
            }
            if (!string.IsNullOrWhiteSpace(Shop.shop_name) && _shop.shop_name != Shop.shop_name)
                _shop.shop_name = Shop.shop_name.Replace(' ', '-').ToLower();
            
            if (!string.IsNullOrWhiteSpace(Shop.title) && _shop.title != Shop.title)
                _shop.title = Shop.title;
            if (!string.IsNullOrWhiteSpace(Shop.About) && _shop.About != Shop.About)
                _shop.About = Shop.About;
            if (!string.IsNullOrWhiteSpace(Shop.first_line) && _shop.first_line != Shop.first_line)
                _shop.first_line = Shop.first_line;
            if (!string.IsNullOrWhiteSpace(Shop.second_line) && _shop.second_line != Shop.second_line)
                _shop.second_line = Shop.second_line;
            if (!string.IsNullOrWhiteSpace(Shop.state) && _shop.state != Shop.state)
                _shop.state = Shop.state;
            if (!string.IsNullOrWhiteSpace(Shop.zip) && _shop.zip != Shop.zip)
                _shop.zip = Shop.zip;
            if (!string.IsNullOrWhiteSpace(Shop.currency_code) && _shop.currency_code != Shop.currency_code)
                _shop.currency_code = Shop.currency_code;


            if (Shop.status_active != null && _shop.status_active != Shop.status_active)
                _shop.status_active = Shop.status_active;
            if (Shop.status_visibility != null && _shop.status_visibility != Shop.status_visibility)
                _shop.status_visibility = Shop.status_visibility;
            if (!string.IsNullOrWhiteSpace(Shop.delete_tsz.ToString()) && _shop.delete_tsz != Shop.delete_tsz)
                _shop.delete_tsz = Shop.delete_tsz;
            if (!string.IsNullOrWhiteSpace(Shop.creation_tsz.ToString()) && _shop.creation_tsz != Shop.creation_tsz)
                _shop.creation_tsz = Shop.creation_tsz;


            _shop.last_updated_tsz = DateTime.Now;
            return _shop;
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ronesans.Domain.Abstract.Domain.Models.Model.Shop
{
    public class DTOShopPut
    {
        public int? user_id { get; set; }
        public int? city_id { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9''-'\s]{1,40}$", ErrorMessage = "The field is not a valid shop name")]
        public string shop_name { get; set; }
        public string title { get; set; }
        public string About { get; set; }
        public string first_line { get; set; }
        public string second_line { get; set; }
        public string state { get; set; }
        [RegularExpression(@"^(\d{5}-\d{4}|\d{5}|\d{9})$|^([a-zA-Z]\d[a-zA-Z] \d[a-zA-Z]\d)$", ErrorMessage = "The field is not a valid zipcode")]
        public string zip { get; set; }
        public string currency_code { get; set; }
    }
}

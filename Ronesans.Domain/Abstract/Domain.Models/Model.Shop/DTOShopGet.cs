using Ronesans.Domain.Concrete.Domain;

namespace Ronesans.Domain.Abstract.Domain.Models.Model.Shop
{
    public class DTOShopGet:Base
    {
        public int shop_id { get; set; }
        public int? user_id { get; set; }
        public virtual User.DTOUserGet User { get; set; }
        public int? city_id { get; set; }
        public virtual City.DTOCityGet City { get; set; }
        public string shop_name { get; set; }
        public string title { get; set; }
        public string About { get; set; }
        public string first_line { get; set; }
        public string second_line { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string currency_code { get; set; }
    }
}

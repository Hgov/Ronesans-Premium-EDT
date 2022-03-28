using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ronesans.Domain.Concrete.Domain
{
    [Table("Shops")]
    public class Shop : Base
    {
        public Shop()
        {
            ShopFiles = new HashSet<ShopFile>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int shop_id { get; set; }
        public int? user_id { get; set; }
        [ForeignKey("user_id")]
        [JsonIgnore]
        public virtual User User { get; set; }
        public int? city_id { get; set; }
        [ForeignKey("city_id")]
        [JsonIgnore]
        public virtual City City { get; set; }
        public string shop_name { get; set; }
        public string title { get; set; }
        public string About { get; set; }
        public string first_line { get; set; }
        public string second_line { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string currency_code { get; set; }
        public virtual ICollection<ShopFile> ShopFiles { get; set; }

    }
}

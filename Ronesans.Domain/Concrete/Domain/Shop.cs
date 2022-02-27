using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ronesans.Domain.Concrete.Domain
{
    [Table("Shops")]
    public class Shop : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int shop_id { get; set; }

        public int? city_id { get; set; }
        [ForeignKey("city_id")]
        [JsonIgnore]
        public virtual City City { get; set; }
        //public string user_id
        //{
        //    get
        //    {
        //        return string.NewGuid();
        //    }
        //    private set
        //    {
        //    }
        //}
        //[ForeignKey("user_id")]
        //[JsonIgnore]
        //public virtual User User { get; set; }
        public string shop_name { get; set; }
        public string title { get; set; }
        public string About { get; set; }
        public string url { get; set; }
        public string banner_image_name { get; set; }
        public string icon_name { get; set; }
        public string first_line { get; set; }
        public string second_line { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string currency_code { get; set; }
    }
}

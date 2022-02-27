using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ronesans.Domain.Concrete.Domain
{
    [Table("Cities")]
    public class City
    {
        public City()
        {
            Shops = new List<Shop>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int city_id { get; set; }
        public string name { get; set; }
        public virtual ICollection<Shop> Shops { get; set; }
    }
}

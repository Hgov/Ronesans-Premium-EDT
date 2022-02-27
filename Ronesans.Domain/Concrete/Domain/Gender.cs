using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ronesans.Domain.Concrete.Domain
{
    [Table("Genders")]
    public class Gender
    {
        public Gender()
        {
            User = new List<User>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int gender_id { get; set; }
        public string name { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}

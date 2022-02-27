using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ronesans.Domain.Concrete.Domain
{
    [Table("Roles")]
    public class Role
    {
        public Role()
        {
            Users = new List<User>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int role_id { get; set; }
        public string role { get; set; }
        public string description { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}

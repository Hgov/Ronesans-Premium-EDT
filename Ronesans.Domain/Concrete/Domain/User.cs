using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ronesans.Domain.Concrete.Domain
{
    [Table("Users")]
    public class User : Base
    {
        public User()
        {
            UserFiles = new HashSet<UserFile>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int user_id { get; set; }
        public int? role_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string password { get; set; }
        [EmailAddress]
        public string email { get; set; }
        [Phone]
        public string phone { get; set; }
        public string bio { get; set; }
        public int? gender_id { get; set; }
        [ForeignKey("gender_id")]
        [JsonIgnore]
        public virtual Gender gender { get; set; }
        [ForeignKey("role_id")]
        [JsonIgnore]
        public virtual Role Role { get; set; }
        public virtual ICollection<UserFile> UserFiles { get; set; }
        public virtual ICollection<Shop> Shops { get; set; }


    }
}

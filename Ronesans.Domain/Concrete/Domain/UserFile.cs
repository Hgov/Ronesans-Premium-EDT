using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ronesans.Domain.Concrete.Domain
{
    public class UserFile
    {
        public int user_id{get; set;}
        public virtual User User { get; set; }
        public int file_id { get; set; }
        public virtual File File { get; set; }
    }
}

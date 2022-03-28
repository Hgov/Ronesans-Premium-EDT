using System.ComponentModel.DataAnnotations;

namespace Ronesans.Domain.Abstract.Domain.Models.Model.Role
{
    public class DTORolePost
    {
        [Required]
        public int role_id { get; set; }
        [Required]
        public string role { get; set; }
        public string description { get; set; }
    }
}

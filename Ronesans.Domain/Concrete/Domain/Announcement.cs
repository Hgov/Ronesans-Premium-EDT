using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ronesans.Domain.Concrete.Domain
{
    [Table("Announcements")]
    public class Announcement : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int announcement_id { get; set; }
        public string title { get; set; }
        public string announcement { get; set; }
    }
}

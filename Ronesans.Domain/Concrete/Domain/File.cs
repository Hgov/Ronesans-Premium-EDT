using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ronesans.Domain.Concrete.Domain
{
    [Table("Files")]
    public  class File
    {
        public File()
        {
            UserFiles = new HashSet<UserFile>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int file_id { get; set; }
        [Required]
        public string content_type { get; set; }
        [Required]
        public string file_name { get; set; }
        public long length { get; set; }
        [Required]
        public string destination_name { get; set; }
        [NotMapped]
        public IFormFile from_file { get; set; }
        public ICollection<UserFile> UserFiles { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ronesans.Domain.Abstract.Domain.Models.Model.File
{
   public class DTOFileGet
    {
        public int file_id { get; set; }
        public string content_type { get; set; }
        public string file_name { get; set; }
        public long length { get; set; }
        public string destination_name { get; set; }
    }
}

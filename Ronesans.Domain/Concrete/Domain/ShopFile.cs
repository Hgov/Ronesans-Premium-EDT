using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ronesans.Domain.Concrete.Domain
{
   public class ShopFile
    {
        public int shop_id { get; set; }
        public virtual Shop Shop { get; set; }
        public int file_id { get; set; }
        public virtual File File { get; set; }
    }
}

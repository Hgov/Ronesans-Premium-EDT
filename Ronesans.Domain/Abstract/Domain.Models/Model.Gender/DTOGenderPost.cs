using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ronesans.Domain.Abstract.Domain.Models.Model.Gender
{
    public class DTOGenderPost
    {
        [Required]
        public int gender_id { get; set; }
        [Required]
        public string name { get; set; }
    }
}

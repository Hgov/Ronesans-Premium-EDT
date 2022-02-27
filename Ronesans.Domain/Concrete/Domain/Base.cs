using System;

namespace Ronesans.Domain.Concrete.Domain
{
    public class Base
    {
        public DateTime? creation_tsz { get; set; }
        public DateTime? last_updated_tsz { get; set; }
        public DateTime? delete_tsz { get; set; }
        public bool? status_active { get; set; }
        public bool? status_visibility { get; set; }
        //public string base_note { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CitySpeaks.Domain.Models
{
    public partial class ProgramCategory
    {
        public ProgramCategory()
        {
            Programs = new HashSet<Program>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Program> Programs { get; set; }
    }
}

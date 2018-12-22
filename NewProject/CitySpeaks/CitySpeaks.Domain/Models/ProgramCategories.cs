using System;
using System.Collections.Generic;

namespace CitySpeaks.Domain.Models
{
    public partial class ProgramCategories
    {
        public ProgramCategories()
        {
            Programs = new HashSet<Programs>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Programs> Programs { get; set; }
    }
}

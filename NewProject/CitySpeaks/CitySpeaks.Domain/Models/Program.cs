using System;
using System.Collections.Generic;

namespace CitySpeaks.Domain.Models
{
    public partial class Program
    {
        public int ProgramId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public byte[] BigImageData { get; set; }
        public string BigImageMimeType { get; set; }
        public byte[] SmallImageData { get; set; }
        public string SmallImageMimeType { get; set; }
        public int CategoryId { get; set; }

        public virtual ProgramCategory Category { get; set; }
    }
}

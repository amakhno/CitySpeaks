using System;
using System.Collections.Generic;

namespace CitySpeaks.Domain.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}

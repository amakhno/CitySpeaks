using System;
using System.Collections.Generic;

namespace CitySpeaks.Domain.Models
{
    public partial class CustomPages
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Page { get; set; }
        public byte[] BigImageData { get; set; }
        public string BigImageMimeType { get; set; }
        public bool IsShow { get; set; }
    }
}

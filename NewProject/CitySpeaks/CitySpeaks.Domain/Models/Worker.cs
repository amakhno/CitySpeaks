using System;
using System.Collections.Generic;

namespace CitySpeaks.Domain.Models
{
    public partial class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public byte[] BigImageData { get; set; }
        public string BigImageMimeType { get; set; }
    }
}

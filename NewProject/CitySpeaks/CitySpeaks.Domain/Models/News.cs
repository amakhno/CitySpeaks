using System;
using System.Collections.Generic;

namespace CitySpeaks.Domain.Models
{
    public partial class News
    {
        public int NewsId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public DateTime Date { get; set; }
        public byte[] BigImageData { get; set; }
        public string BigImageMimeType { get; set; }
        public byte[] SmallImageData { get; set; }
        public string SmallImageMimeType { get; set; }
    }
}

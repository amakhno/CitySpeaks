using System;
using System.Collections.Generic;

namespace CitySpeaks.Domain.Models
{
    public partial class MainPage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public byte[] MainImageData { get; set; }
        public string MainImageMimeType { get; set; }
        public byte[] LogolImageData { get; set; }
        public string LogoImageMimeType { get; set; }
    }
}

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
        public int? SmallImageId { get; set; }
        public int? BigImageId { get; set; }
        public virtual Image SmallImage { get; set; }
        public virtual Image BigImage { get; set; }
    }
}

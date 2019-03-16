using System.ComponentModel;

namespace CitySpeaks.Domain.Models
{
    public partial class Worker
    {
        public int Id { get; set; }
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Коротко о себе")]
        public string ShortDescription { get; set; }
        [DisplayName("Биография")]
        public string FullDescription { get; set; }
        public int? SmallImageId { get; set; }
        public int? BigImageId { get; set; }
        public virtual Image SmallImage { get; set; }
        public virtual Image BigImage { get; set; }
    }
}

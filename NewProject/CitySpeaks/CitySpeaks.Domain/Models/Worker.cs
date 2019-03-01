namespace CitySpeaks.Domain.Models
{
    public partial class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public int? SmallImageId { get; set; }
        public int? BigImageId { get; set; }
        public virtual Image SmallImage { get; set; }
        public virtual Image BigImage { get; set; }
    }
}

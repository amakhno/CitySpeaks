namespace CitySpeaks.Domain.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public int? ImageId { get; set; }
        public virtual Image Image { get; set; }
    }
}

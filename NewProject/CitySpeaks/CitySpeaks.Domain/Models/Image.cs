namespace CitySpeaks.Domain.Models
{
    public class Image
    {
        public int Id { get; protected set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}

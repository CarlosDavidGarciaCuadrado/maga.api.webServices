
namespace maga.Bussines
{
    public class VideoDto
    {
        public ulong id { get; set; }
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string pathFile { get; set; } = string.Empty;
        public DateTime creationDate { get; set; } = DateTime.Now;
        public ulong userCreation { get; set; }
        public int indexReproduction { get; set; }
        public byte[] videoData { get; set; }
    }
}

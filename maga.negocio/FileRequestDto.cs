
using Microsoft.AspNetCore.Http;

namespace maga.Bussines
{
    public class FileRequestDto
    {
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public int indexReproduction { get; set; }
        public IFormFile file { get; set; }
    }

    public class FileResponseDto
    {
        public bool success { get; set; }
    }
}

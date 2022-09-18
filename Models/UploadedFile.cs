using System.ComponentModel.DataAnnotations;

namespace ProjectHUB.Models
{
    public class UploadedFile
    {
        public int id { get; set; }
        public IFormFile Content { get; set; }
    }
}

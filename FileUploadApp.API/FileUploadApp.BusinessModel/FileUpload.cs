using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FileUploadApp.BusinessModel
{
    public class FileUpload
    {
        [Required]
        public IFormFile File { get; set; }
    }
}

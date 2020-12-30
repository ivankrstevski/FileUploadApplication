using FileUploadApp.BusinessLogic.Interfaces;
using FileUploadApp.BusinessModel;
using Microsoft.AspNetCore.Mvc;

namespace FileUploadApp.Controllers
{
    [Route("api/file-upload")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IFileUploadBusinessLogic _fileUploadBusinessLogic;

        public FileUploadController(IFileUploadBusinessLogic fileUploadBusinessLogic)
        {
            _fileUploadBusinessLogic = fileUploadBusinessLogic;
        }

        [HttpPost("upload-file")]
        public IActionResult UploadFile([FromForm] FileUpload fileUploadObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (fileUploadObject.File.Length <= 0)
            {
                return BadRequest();
            }

            if (fileUploadObject.File.ContentType != "text/plain")
            {
                return BadRequest("Provided file format is invalid");
            }

            _fileUploadBusinessLogic.UploadFile(fileUploadObject);

            return Ok();
        }

        [HttpGet("get-uploaded-files")]
        public IActionResult GetUploadedFiles()
        {
            var uploadedFiles = _fileUploadBusinessLogic.GetUploadedFiles();

            return Ok(uploadedFiles);
        }

        [HttpGet("get-file-content-items")]
        public IActionResult GetFileContentItems(string fileId)
        {
            if (string.IsNullOrEmpty(fileId))
            {
                return BadRequest();
            }

            var uploadedFiles = _fileUploadBusinessLogic.GetFileContentItems(fileId);

            return Ok(uploadedFiles);
        }
    }
}

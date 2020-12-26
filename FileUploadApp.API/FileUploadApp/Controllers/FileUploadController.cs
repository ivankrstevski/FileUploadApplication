using FileUploadApp.BusinessLogic.Interfaces;
using FileUploadApp.BusinessModel;
using FileUploadApp.Configurations.CustomExceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace FileUploadApp.Controllers
{
    [Route("api/file-upload")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IFileUploadBusinessLogic _fileUploadBusinessLogic;

        public FileUploadController(ILogger<FileUploadController> logger,
            IFileUploadBusinessLogic fileUploadBusinessLogic)
        {
            _logger = logger;
            _fileUploadBusinessLogic = fileUploadBusinessLogic;
        }

        [HttpPost("upload-file")]
        public IActionResult UploadFile([FromForm] FileUpload fileUploadObject)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (fileUploadObject.File.Length <= 0)
                {
                    return BadRequest("Provided file format is invalid");
                }

                if (fileUploadObject.File.ContentType != "text/plain")
                {
                    return BadRequest();
                }

                _fileUploadBusinessLogic.UploadFile(fileUploadObject);

                return Ok();
            }
            catch (FileAlreadyExistsException ex)
            {
                _logger.LogError($"Method: UploadFile, Error: {ex.Message}");
                return StatusCode(501, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Method: UploadFile, Error: {ex.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet("get-uploaded-files")]
        public IActionResult GetUploadedFiles()
        {
            try
            {
                var uploadedFiles = _fileUploadBusinessLogic.GetUploadedFiles();

                return Ok(uploadedFiles);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Method: GetUploadedFiles, Error: {ex.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet("get-file-content-items")]
        public IActionResult GetFileContentItems(string fileId)
        {
            try
            {
                if (string.IsNullOrEmpty(fileId))
                {
                    return BadRequest();
                }

                var uploadedFiles = _fileUploadBusinessLogic.GetFileContentItems(fileId);

                return Ok(uploadedFiles);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Method: GetFileContentItems, Error: {ex.Message}");
                return StatusCode(500);
            }
        }
    }
}

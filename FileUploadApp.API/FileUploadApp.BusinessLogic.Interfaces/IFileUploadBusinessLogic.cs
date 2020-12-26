using FileUploadApp.BusinessModel;
using System.Collections.Generic;

namespace FileUploadApp.BusinessLogic.Interfaces
{
    public interface IFileUploadBusinessLogic
    {
        public void UploadFile(FileUpload fileUploadObject);

        public List<UploadedFile> GetUploadedFiles();

        public List<FileContentItem> GetFileContentItems(string fileId);
    }
}

using FileUploadApp.DataModel;
using System.Collections.Generic;

namespace FileUploadApp.Services.Interfaces
{
    public interface IFileUploadService
    {
        public string SaveFile(string fileName);

        public void SaveFileContentItems(string fileId, List<FileContentItem> contentItems);

        public List<UploadedFile> GetUploadedFiles();

        public List<FileContentItem> GetFileContentItems(string fileId);

        public bool CheckIfFileAlreadyExist(string fileName);
    }
}

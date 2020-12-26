using FileUploadApp.DataModel;
using System.Collections.Generic;

namespace FileUploadApp.Repositories.Interfaces
{
    public interface IFileUploadRepository
    {
        public string SaveFile(string fileName);

        public void SaveFileContentItems(string fileId, List<FileContentItem> contentItems);

        public List<UploadedFile> GetUploadedFiles();

        public List<FileContentItem> GetFileContentItems(string fileId);

        public bool CheckIfFileAlreadyExist(string fileName);
    }
}

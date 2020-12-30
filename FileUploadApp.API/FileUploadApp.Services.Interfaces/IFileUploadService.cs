using FileUploadApp.DataModel;
using System.Collections.Generic;

namespace FileUploadApp.Services.Interfaces
{
    public interface IFileUploadService
    {
        public void BeginTransaction();

        public void RollbackTransaction();

        public void CommitTransaction();

        public UploadedFile SaveFile(string fileName);

        public void SaveFileContentItems(UploadedFile uploadedFile, List<FileContentItem> contentItems);

        public List<UploadedFile> GetUploadedFiles();

        public List<FileContentItem> GetFileContentItems(string fileId);

        public bool CheckIfFileAlreadyExist(string fileName);
    }
}

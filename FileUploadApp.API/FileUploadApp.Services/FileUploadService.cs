using FileUploadApp.DataModel;
using FileUploadApp.Repositories.Interfaces;
using FileUploadApp.Services.Interfaces;
using System.Collections.Generic;

namespace FileUploadApp.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IFileUploadRepository _fileUploadRepository;

        public FileUploadService(IFileUploadRepository fileUploadRepository)
        {
            _fileUploadRepository = fileUploadRepository;
        }

        public void BeginTransaction()
        {
            _fileUploadRepository.BeginTransaction();
        }

        public void RollbackTransaction()
        {
            _fileUploadRepository.RollbackTransaction();
        }

        public void CommitTransaction()
        {
            _fileUploadRepository.CommitTransaction();
        }

        public UploadedFile SaveFile(string fileName)
        {
            return _fileUploadRepository.SaveFile(fileName);
        }

        public void SaveFileContentItems(UploadedFile uploadedFile, List<FileContentItem> contentItems)
        {
            _fileUploadRepository.SaveFileContentItems(uploadedFile, contentItems);
        }

        public List<UploadedFile> GetUploadedFiles()
        {
            return _fileUploadRepository.GetUploadedFiles();
        }

        public List<FileContentItem> GetFileContentItems(string fileId)
        {
            return _fileUploadRepository.GetFileContentItems(fileId);
        }

        public bool CheckIfFileAlreadyExist(string fileName)
        {
            return _fileUploadRepository.CheckIfFileAlreadyExist(fileName);
        }
    }
}

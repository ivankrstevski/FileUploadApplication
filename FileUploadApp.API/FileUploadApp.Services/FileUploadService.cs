using FileUploadApp.DataModel;
using FileUploadApp.Repositories.Interfaces;
using FileUploadApp.Services.Interfaces;
using System;
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

        public string SaveFile(string fileName)
        {
            try
            {
                return _fileUploadRepository.SaveFile(fileName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveFileContentItems(string fileId, List<FileContentItem> contentItems)
        {
            try
            {
                _fileUploadRepository.SaveFileContentItems(fileId, contentItems);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<UploadedFile> GetUploadedFiles()
        {
            try
            {
                return _fileUploadRepository.GetUploadedFiles();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<FileContentItem> GetFileContentItems(string fileId)
        {
            try
            {
                return _fileUploadRepository.GetFileContentItems(fileId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckIfFileAlreadyExist(string fileName)
        {
            try
            {
                return _fileUploadRepository.CheckIfFileAlreadyExist(fileName);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

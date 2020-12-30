using FileUploadApp.BusinessLogic.Interfaces;
using FileUploadApp.BusinessModel;
using FileUploadApp.Configurations.CustomExceptions;
using FileUploadApp.Configurations.Interfaces;
using FileUploadApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileUploadApp.BusinessLogic
{
    public class FileUploadBusinessLogic : IFileUploadBusinessLogic
    {
        private readonly IFileUploadService _fileUploadService;
        private readonly IAutoMapperAdapter _autoMapper;

        public FileUploadBusinessLogic(IFileUploadService fileUploadService,
            IAutoMapperAdapter autoMapper)
        {
            _fileUploadService = fileUploadService;
            _autoMapper = autoMapper;
        }

        public void UploadFile(FileUpload fileUploadObject)
        {
            var numberOfColumns = 3;
            var file = fileUploadObject.File;
            var fileName = file.FileName;
            var fileContentItems = new List<DataModel.FileContentItem>();


            if (fileUploadObject.File.Length > 0)
            {
                var fileExist = _fileUploadService.CheckIfFileAlreadyExist(fileName);

                if (fileExist)
                {
                    throw new FileAlreadyExistsException(fileName);
                }

                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            var splittedLine = line.Split(",");

                            if (splittedLine.Length == numberOfColumns)
                            {
                                var color = splittedLine[0].Trim();
                                int.TryParse(splittedLine[1], out var number);
                                var label = splittedLine[numberOfColumns - 1].Trim();

                                if (number > 0 && !string.IsNullOrWhiteSpace(color)
                                    && !string.IsNullOrWhiteSpace(label))
                                {
                                    var fileItem = new DataModel.FileContentItem
                                    {
                                        Color = color,
                                        Number = number,
                                        Label = label
                                    };

                                    fileContentItems.Add(fileItem);
                                }
                            }
                            else
                            {
                                throw new Exception("Invalid file content.");
                            }
                        }
                    }
                }

                if (fileContentItems.Count > 0)
                {
                    try
                    {
                        _fileUploadService.BeginTransaction();

                        var uploadedFile = _fileUploadService.SaveFile(fileName);

                        _fileUploadService.SaveFileContentItems(uploadedFile, fileContentItems);

                        _fileUploadService.CommitTransaction();
                    }
                    catch (Exception)
                    {
                        _fileUploadService.RollbackTransaction();
                        throw;
                    }
                }
            }
        }

        public List<UploadedFile> GetUploadedFiles()
        {
            var dataResult = _fileUploadService.GetUploadedFiles();

            var result = _autoMapper.Map<List<DataModel.UploadedFile>, List<UploadedFile>>(dataResult);

            var sortedResultList = result.OrderByDescending(x => x.CreatedAt).ToList();

            return sortedResultList;
        }

        public List<FileContentItem> GetFileContentItems(string fileId)
        {
            var dataResult = _fileUploadService.GetFileContentItems(fileId);

            var result = _autoMapper.Map<List<DataModel.FileContentItem>, List<FileContentItem>>(dataResult);

            return result;
        }
    }
}

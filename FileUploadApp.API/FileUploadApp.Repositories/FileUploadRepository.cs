using FileUploadApp.DataModel;
using FileUploadApp.Repositories.Common;
using FileUploadApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileUploadApp.Repositories
{
    public class FileUploadRepository : IFileUploadRepository
    {
        private readonly ApplicationDbContext _context;

        public FileUploadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public UploadedFile SaveFile(string fileName)
        {
            var newFile = new UploadedFile
            {
                Name = fileName,
                CreatedAt = DateTime.Now
            };

            _context.UploadedFiles.Add(newFile);

            _context.SaveChanges();

            return newFile;
        }

        public void SaveFileContentItems(UploadedFile uploadedFile, List<FileContentItem> contentItems)
        {
            uploadedFile.ContentItems = new List<FileContentItem>();

            foreach (var item in contentItems)
            {
                item.CreatedAt = DateTime.Now;
                uploadedFile.ContentItems.Add(item);
            }

            _context.SaveChanges();
        }

        public List<UploadedFile> GetUploadedFiles()
        {
            return _context.UploadedFiles.OrderByDescending(x => x.CreatedAt).ToList();
        }

        public List<FileContentItem> GetFileContentItems(string fileId)
        {
            return _context.FileContentItems.Where(x => x.UploadedFile.Id == Guid.Parse(fileId)).ToList();
        }

        public bool CheckIfFileAlreadyExist(string fileName)
        {
            return _context.UploadedFiles.Where(x => x.Name == fileName).Any();
        }
    }
}

using FileUploadApp.DataModel;
using Microsoft.EntityFrameworkCore;

namespace FileUploadApp.Repositories.Common
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<UploadedFile> UploadedFiles { get; set; }
        public DbSet<FileContentItem> FileContentItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UploadedFile>().ToTable("UploadedFile");
            modelBuilder.Entity<FileContentItem>().ToTable("FileContentItem");
        }
    }
}

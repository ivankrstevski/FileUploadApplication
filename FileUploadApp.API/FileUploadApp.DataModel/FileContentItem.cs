using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileUploadApp.DataModel
{
    public class FileContentItem : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public string Label { get; set; }

        [Required]
        public UploadedFile UploadedFile { get; set; }
    }
}

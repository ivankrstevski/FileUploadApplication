using System;

namespace FileUploadApp.DataModel
{
    public class BaseEntity
    {
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}

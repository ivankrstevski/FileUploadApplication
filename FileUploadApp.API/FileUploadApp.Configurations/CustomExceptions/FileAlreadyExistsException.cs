using System;

namespace FileUploadApp.Configurations.CustomExceptions
{
    public class FileAlreadyExistsException : Exception
    {
        public FileAlreadyExistsException() { }

        public FileAlreadyExistsException(string fileName)
            : base($"File {fileName} already exists.")
        {
        }
    }
}

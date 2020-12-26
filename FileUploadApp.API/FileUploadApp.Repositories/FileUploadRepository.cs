using FileUploadApp.DataModel;
using FileUploadApp.Repositories.Common;
using FileUploadApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FileUploadApp.Repositories
{
    public class FileUploadRepository : IFileUploadRepository
    {
        private readonly string _connectionString;

        public FileUploadRepository(ApplicationDbContext applicationDbContext)
        {
            _connectionString = applicationDbContext.DefaultDbConnection;
        }

        public string SaveFile(string fileName)
        {
            try
            {
                string fileId = null;

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    var query = "insert into dbo.UploadedFile (Name, CreatedAt) output Inserted.Id VALUES (@name, @createdAt)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", fileName);
                        command.Parameters.AddWithValue("@createdAt", DateTime.Now);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                fileId = reader["Id"].ToString();
                            }
                        }

                        connection.Close();
                    }
                }

                return fileId;
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
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    var query = @"insert into dbo.FileContentItem 
                        (ParentId, Color, Number, Label, CreatedAt)
                        VALUES (@parentId, @color, @number, @label, @createdAt)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        foreach (var item in contentItems)
                        {
                            command.Parameters.Clear();

                            command.Parameters.AddWithValue("@parentId", fileId);
                            command.Parameters.AddWithValue("@color", item.Color);
                            command.Parameters.AddWithValue("@number", item.Number);
                            command.Parameters.AddWithValue("@label", item.Label);
                            command.Parameters.AddWithValue("@createdAt", DateTime.Now);

                            command.ExecuteNonQuery();
                        }

                        connection.Close();
                    }
                }
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
                var uploadedFiles = new List<UploadedFile>();

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    var query = @"select * from dbo.UploadedFile";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                uploadedFiles.Add(new UploadedFile
                                {
                                    Id = reader["Id"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    CreatedAt = DateTime.Parse(reader["CreatedAt"].ToString())
                                });
                            }
                        }

                        connection.Close();
                    }
                }

                return uploadedFiles;
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
                var fileContentItems = new List<FileContentItem>();

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    var query = @"select fci.Color, fci.Label, fci.Number from dbo.UploadedFile uf 
                        inner join dbo.FileContentItem fci on uf.Id = fci.ParentId where uf.Id = @fileId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@fileId", fileId);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                fileContentItems.Add(new FileContentItem
                                {
                                    Color = reader["Color"].ToString(),
                                    Label = reader["Label"].ToString(),
                                    Number = int.Parse(reader["Number"].ToString())
                                });
                            }
                        }

                        connection.Close();
                    }
                }

                return fileContentItems;
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
                var fileExist = false;

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    var query = @"select Id from dbo.UploadedFile where Name = @fileName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@fileName", fileName);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            fileExist = reader.HasRows;
                        }

                        connection.Close();
                    }
                }

                return fileExist;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

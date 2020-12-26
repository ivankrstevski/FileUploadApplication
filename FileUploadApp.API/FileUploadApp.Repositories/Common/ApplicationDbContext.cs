using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploadApp.Repositories.Common
{
    public class ApplicationDbContext
    {
        public string DefaultDbConnection { get; set; }

        public ApplicationDbContext(string defaultDbConnection)
        {
            DefaultDbConnection = defaultDbConnection;
        }
    }
}

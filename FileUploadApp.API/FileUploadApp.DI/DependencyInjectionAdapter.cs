using FileUploadApp.BusinessLogic;
using FileUploadApp.BusinessLogic.Interfaces;
using FileUploadApp.Configurations;
using FileUploadApp.Configurations.Interfaces;
using FileUploadApp.Repositories;
using FileUploadApp.Repositories.Common;
using FileUploadApp.Repositories.Interfaces;
using FileUploadApp.Services;
using FileUploadApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FileUploadApp.DI
{
    public static class DependencyInjectionAdapter
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:DefaultDbConnection"];

            // Auto Mapper
            services.AddSingleton(AutoMapperConfigurator.Create());
            services.AddScoped<IAutoMapperAdapter, AutoMapperAdapter>();

            // Repositories
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IFileUploadRepository, FileUploadRepository>();

            // Services
            services.AddScoped<IFileUploadService, FileUploadService>();

            // BusinessLogic
            services.AddScoped<IFileUploadBusinessLogic, FileUploadBusinessLogic>();
        }
    }
}

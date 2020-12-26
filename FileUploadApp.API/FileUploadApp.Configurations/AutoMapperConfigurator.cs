using AutoMapper;
using FileUploadApp.Configurations.MappingProfiles;

namespace FileUploadApp.Configurations
{
    public static class AutoMapperConfigurator
    {
        public static IMapper Create()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            return mapperConfig.CreateMapper();
        }
    }
}

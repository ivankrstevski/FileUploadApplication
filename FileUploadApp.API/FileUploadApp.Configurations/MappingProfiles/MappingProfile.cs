using AutoMapper;
using FileUploadApp.BusinessModel;

namespace FileUploadApp.Configurations.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DataModel.UploadedFile, UploadedFile>();
            CreateMap<DataModel.FileContentItem, FileContentItem>();
        }
    }
}

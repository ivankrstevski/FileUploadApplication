using AutoMapper;
using FileUploadApp.Configurations.Interfaces;

namespace FileUploadApp.Configurations
{
    public class AutoMapperAdapter : IAutoMapperAdapter
    {
        private readonly IMapper _mapper;

        public AutoMapperAdapter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public T Map<T>(object objectToMap)
        {
            return _mapper.Map<T>(objectToMap);
        }

        public T1 Map<T, T1>(T objectToMap)
        {
            return _mapper.Map<T, T1>(objectToMap);
        }
    }
}

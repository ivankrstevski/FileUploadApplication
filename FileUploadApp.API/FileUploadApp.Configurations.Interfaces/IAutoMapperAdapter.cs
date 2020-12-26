namespace FileUploadApp.Configurations.Interfaces
{
    public interface IAutoMapperAdapter
    {
        public T Map<T>(object objectToMap);
        public T1 Map<T, T1>(T objectToMap);
    }
}

namespace CloudLibrary.Interface
{
    public interface ICloudServiceProvider
    {
        void InitializeInfrastructure(string infrastructureName);
        void AddResource<T>(T resource);
        void CreateInfrastructure();
        void DeleteInfrastructure(string infrastructureName);
    }
}

using CloudLibrary.Interface;
using CloudLibrary.Model;

namespace CloudLibrary.Domain
{
    public class ComingSoon2CloudService : ICloudServiceProvider
    {
        private const string ProviderName = "ComingSoon2";

        private Infrastructure _infrastructure;


        public void InitializeInfrastructure(string infrastructureName)
        {
            throw new System.NotImplementedException();
        }

        public void AddResource<T>(T resource)
        {
            throw new System.NotImplementedException();
        }

        public void CreateInfrastructure()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteInfrastructure(string infrastructureName)
        {
            throw new System.NotImplementedException();
        }
    }
}

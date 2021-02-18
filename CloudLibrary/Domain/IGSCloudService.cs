using System.IO;
using CloudLibrary.Common;
using CloudLibrary.Interface;
using CloudLibrary.Model;

namespace CloudLibrary.Domain
{
    public class IGSCloudService : ICloudServiceProvider
    {
        private const string ProviderName = "IGS";

        private Infrastructure _infrastructure;
        public void InitializeInfrastructure(string infrastructureName)
        {
            _infrastructure = new Infrastructure
            {
                Provider = ProviderName,
                Name = infrastructureName
            };
            LogHelper.Log("Infrastructure initialized successfully.");
        }

        public void AddResource<T>(T resource)
        {
            if (resource is VirtualMachine vm)
            {
                _infrastructure.VirtualMachines.Add(vm);
            }

            if (resource is Database db)
            {
                _infrastructure.Databases.Add(db);
            }
        }

        public void CreateInfrastructure()
        {
            FileOperationHelper.WriteInfrastructureDataToFile(_infrastructure);
        }

        public void DeleteInfrastructure(string infrastructureName)
        {
            var path = Path.Combine(FileOperationHelper.GetDesktopPath(), ProviderName, infrastructureName);
            FileOperationHelper.DeleteInfrastructureDataFiles(path);
        }
    }
}

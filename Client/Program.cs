using System;
using CloudLibrary.Api;
using CloudLibrary.Common;
using CloudLibrary.Interface;
using CloudLibrary.Model;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();

            ICloudServiceProvider igsCloudProvider = CloudServiceProvider.GetCloudProvider(CloudProvider.IGS);
            igsCloudProvider.InitializeInfrastructure("UAT");

            VirtualMachine virtualMachine1 = new VirtualMachine
            {
                CpuCore = "8",
                Ram = "16GB",
                Storage = "1TB",
                OperatingSystem = "Windows"
            };

  VirtualMachine virtualMachine2 = new VirtualMachine
            {
                CpuCore = "8",
                Ram = "16GB",
                Storage = "1TB",
                OperatingSystem = "Windows"
            };

            Database database1 = new Database
            {
                CpuCore = "4",
                Ram = "8GB",
                Storage = "256GB",
                Engine = "SQL Server"
            };
            
            Database database2 = new Database
            {
                CpuCore = "4",
                Ram = "8GB",
                Storage = "256GB",
                Engine = "SQL Server"
            };

            igsCloudProvider.AddResource(virtualMachine1);
            igsCloudProvider.AddResource(virtualMachine2);
            igsCloudProvider.AddResource(database1);
            igsCloudProvider.AddResource(database2);
            
            igsCloudProvider.CreateInfrastructure();

            Console.WriteLine();
            Console.Write("All infrastructure data will be deleted. Continue?[Y/N]");
            var answer = Console.ReadLine();
            Console.WriteLine();

            if (answer != null && answer.ToLower().Equals("y"))
                igsCloudProvider.DeleteInfrastructure("UAT");


            Console.WriteLine("Press eny key to exit...");
            Console.ReadKey();
        }
    }
}

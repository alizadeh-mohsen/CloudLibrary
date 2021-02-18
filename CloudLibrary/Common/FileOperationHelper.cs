using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using CloudLibrary.Model;
using Newtonsoft.Json;

namespace CloudLibrary.Common
{
    public class FileOperationHelper
    {
        #region Public Methods
        public static void WriteInfrastructureDataToFile(Infrastructure infrastructure)
        {
            var path = Path.Combine(GetDesktopPath(), infrastructure.Provider, infrastructure.Name);

            CreateJsonFile(infrastructure, path, Constants.VirtualMachine);
            CreateJsonFile(infrastructure, path, Constants.Database);

            LogHelper.Log("Infrastructure data was created successfully in the following path...", false);
            LogHelper.Log(path);

        }

        public static void DeleteInfrastructureDataFiles(string path)
        {
            var files = Directory.GetFiles(path, "*.json");
            if (files.Length > 0)
            {
                foreach (var file in files)
                {
                    File.Delete(file);
                    LogHelper.Log($"{file} was deleted successfully.");
                }

                return;
            }

            if (Directory.GetDirectories(path).Length > 0)
            {
                var innerDirectories = Directory.GetDirectories(path);
                foreach (var directory in innerDirectories)
                    DeleteInfrastructureDataFiles(directory);

                foreach (var directory in innerDirectories)
                {
                    DeleteInfrastructureDataFiles(directory);
                    LogHelper.Log($"{directory} was deleted successfully.");
                }
            }
        }

        public static string GetDesktopPath()
        {
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            return Path.Combine(desktop, Constants.DefaultOutputFolderName);
        }

        #endregion

        #region Private Methods

        private static void CreateJsonFile(Infrastructure infrastructure, string path, string resource)
        {
            Directory.CreateDirectory(Path.Combine(path, resource));
            var resourcePath = Path.Combine(path, resource, infrastructure.Name + GetPrefix(resource));
            try
            {
                switch (resource)
                {
                    case Constants.VirtualMachine:
                        File.WriteAllText(resourcePath, JsonConvert.SerializeObject(infrastructure.VirtualMachines, Formatting.Indented));
                        break;
                    case Constants.Database:
                        File.WriteAllText(resourcePath, JsonConvert.SerializeObject(infrastructure.Databases, Formatting.Indented));
                        break;
                }
            }
            catch (IOException ioEx)
            {
                Debug.WriteLine(ioEx.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            LogHelper.Log($"{resource} added to infrastructure successfully.");
        }

        private static string GetPrefix(string resource)
        {
            switch (resource)
            {
                case Constants.VirtualMachine:
                    return Constants.VmPostFix;
                case Constants.Database:
                    return Constants.DbPostFix;
                default:
                    return "Undefined";
            }
        }

        #endregion
    }
}

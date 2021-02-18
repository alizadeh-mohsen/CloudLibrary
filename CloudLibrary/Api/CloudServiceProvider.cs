using CloudLibrary.Common;
using CloudLibrary.Domain;
using CloudLibrary.Interface;

namespace CloudLibrary.Api
{
    public class CloudServiceProvider
    {
        public static ICloudServiceProvider GetCloudProvider(CloudProvider cloudProvider)
        {
            switch (cloudProvider)
            {
                case CloudProvider.IGS:
                    return new IGSCloudService();

                case CloudProvider.ComingSoon1:
                    return new IGSCloudService();

                case CloudProvider.ComingSoon2:
                    return new IGSCloudService();

                default:
                    return new IGSCloudService();
            }
        }
    }
}

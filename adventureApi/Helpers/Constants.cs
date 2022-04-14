using System;
namespace adventureApi.Helpers
{
    public class Constants
    {
        public enum UserRole
        {
            Basic = 1,
            Contributor = 10,
            Admin = 100
        }

        public enum LocationType
        {
            Restaurant = 1,
            Shopping = 2,
            Experience = 3,
            PointOfInterest = 4
        }
    }
}

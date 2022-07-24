using System;
using System.Runtime.Serialization;

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
            [EnumMember(Value = "Restaurant")]
            Restaurant = 1,
            [EnumMember(Value = "Shopping")]
            Shopping = 2,
            [EnumMember(Value = "Experience")]
            Experience = 3,
            [EnumMember(Value = "PointOfInterest")]
            PointOfInterest = 4
        }

        public enum NotificationType
        {
            [EnumMember(Value = "AddedToAdventure")]
            AddedToAdventure = 1
        }
    }
}

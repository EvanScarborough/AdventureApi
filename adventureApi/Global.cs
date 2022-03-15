using System;
namespace adventureApi
{
    public static class Global
    {
        public static readonly string PASSWORD_REGEX = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[ @$!%*#?&-])[ A-Za-z\d@$!%*#?&-]{8,24}$";
    }
}

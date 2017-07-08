using System;

namespace BSAWeatherApp.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime UnixTimeStampToDateTime(this int unixTimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
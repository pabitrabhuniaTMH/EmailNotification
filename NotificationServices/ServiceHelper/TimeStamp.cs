﻿namespace EmailNotificationServices.ServiceHelper
{
    public static class TimeStamp
    {
        public static long GetTimeStamp()
        {
            var baseDate = new DateTime(1970, 01, 01);           
            var numberOfSeconds = DateTime.Now.Subtract(baseDate).TotalSeconds;
            return Convert.ToInt64(numberOfSeconds);
        }
        public static long GetTimeStamp(DateTime dateTime)
        {
            var baseDate = new DateTime(1970, 01, 01);
            var numberOfSeconds = dateTime.Subtract(baseDate).TotalSeconds;
            return Convert.ToInt64(numberOfSeconds);
        }
    }
}

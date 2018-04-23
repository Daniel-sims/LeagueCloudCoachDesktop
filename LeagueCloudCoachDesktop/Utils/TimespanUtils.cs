using System;

namespace LeagueCloudCoachDesktop.Utils
{
    public static class TimeSpanUtils
    {
        public static string ConvertTimespanToFriendly(int secs)
        {
            var t = TimeSpan.FromSeconds(secs);
            string friendlyTime;
            if (t.TotalMinutes < 1.0)
            {
                friendlyTime = string.Format("{0}s", t.Seconds);
            }
            else if (t.TotalHours < 1.0)
            {
                friendlyTime = string.Format("{0}:{1:D2}", t.Minutes, t.Seconds);
            }
            else // more than 1 hour
            {
                friendlyTime = string.Format("{0}:{1:D2}:{2:D2}", (int)t.TotalHours, t.Minutes, t.Seconds);
            }

            return friendlyTime;
        }
    }
}

namespace HumanReadableDauration
{
    public class HumanTimeReadableFormat
    {
        public static string formatDuration(int seconds)
        {
            //if the input is zero we have to return now 
            if (seconds == 0)
            {
                return "now";
            }
            else if (seconds < 60)
            {
                // handle the case of dealing with seconds
                if (seconds == 1)
                {
                    return $"{seconds} second";
                }
                return $"{seconds} seconds";
            }
            else if (seconds >= 60 && seconds < 3600)
            {
                // handle the case of dealing with minutes
                var m = seconds / 60;
                var s = (seconds % 60) % 60;

                return $"{m} {(m == 1 ? "minute" : "minutes")}{(s == 0 ? "" : $" and {s} {(s == 1 ? "second" : "seconds")}")}";

            }
            else if (seconds >= 3600 && seconds < 86400)
            {
                // handle the case of dealing with hours
                var hrs = seconds / 3600;
                var m = Convert.ToInt32(((float)seconds % (float)3600) / 60);
                var s = ((seconds % 60) % 60);

                return $"{hrs} {(hrs == 1 ? "hour" : "hours")}{(m == 0 ? "" : $"{(s == 0 ? " and" : ",")} {m} {(m == 1 ? "minute" : "minutes")}")}{(s == 0 ? "" : $" and {s} {(s == 1 ? "second" : "seconds")}")}";


            }
            else if (seconds >= 86400 && seconds < 31536000)
            {
                // handle the case of dealing with days
                var days = seconds / 86400;
                var hrs = (seconds % 86400) / 3600;
                var m = ((seconds % 86400) % 3600) / 60;
                var s = ((seconds % 86400) % 3600) % 60;

                return $"{days} {(days == 1 ? "day" : "days")}{(hrs == 0 ? "" : $"{((m == 0 && s == 0) ? " and" : ",")} {hrs} {(hrs == 1 ? "hour" : "hours")}")}{(m == 0 ? "" : $"{(s == 0 ? " and" : ",")} {m} {(m == 1 ? "minute" : "minutes")}")}{(s == 0 ? "" : $" and {s} {(s == 1 ? "second" : "seconds")}")}";


            }
            else if (seconds >= 31536000)
            {
                // handle the case of dealing with years
                var years = seconds / 31536000;
                var days = (seconds % 31536000) / 86400;
                var hrs = (seconds % 31536000) % 86400 / 3600;
                var m = (seconds % 31536000) % 86400 % 3600 / 60;
                var s = (seconds % 31536000) % 86400 % 3600 % 60;

                return $"{years} {(years == 1 ? "year" : "years")}{(days == 0 ? "" : $"{((hrs == 0 && m == 0 && s == 0) ? " and" : ",")} {days} {(days == 1 ? "day" : "days")}")}{(hrs == 0 ? "" : $"{((m == 0 && s == 0) ? " and" : ",")} {hrs} {(hrs == 1 ? "hour" : "hours")}")}{(m == 0 ? "" : $"{(s == 0 ? " and" : ",")} {m} {(m == 1 ? "minute" : "minutes")}")}{(s == 0 ? "" : $" and {s} {(s == 1 ? "second" : "seconds")}")}";


            }

            return "";
        }
    }
}
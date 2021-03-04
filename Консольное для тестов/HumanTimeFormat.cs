using System;
using System.Collections.Generic;
using System.Text;

namespace HumanTimeFormatSpace
{
    public enum CountSecondsInInterval
    {
        second = 1,
        minute = 60,
        hour = 60 * minute,
        day = 24 * hour,
        year = 365 * day
    }
    public class HumanTimeFormat
    {

        public static string formatDuration(int seconds)
        {
            if (seconds == 0)
                return "now";
            BuildResultList(out List<string> resultList, seconds);
            string result = FormatResultList(resultList);
            return result;
        }
        public static string FormatResultList(List<string> resultList)
        {
            if(resultList.Count == 1)
            return resultList[0];
            if (resultList.Count == 2)
            {
                resultList[0] += " and ";
                return resultList[0] + resultList[1];
            }
            for (int i = 0; i <= resultList.Count - 3; i++)
            {
                resultList[i] += ", ";
            }
            resultList[resultList.Count - 2] += " and ";
            StringBuilder sb = new StringBuilder();
            sb.AppendJoin("",resultList);
            return sb.ToString();
            

        }
        public static List<string> BuildResultList(out List<string> resultList, int seconds)
        {
            resultList = new List<string>();
            resultList.AddRange(GetIEnumerableStrings(seconds));
            return resultList;
        }
        public static IEnumerable<string> GetIEnumerableStrings(int seconds)
        {
            FillingTheDictionaryWithIntervals(out Dictionary<int, CountSecondsInInterval> allIntervals);
            foreach (KeyValuePair<int, CountSecondsInInterval> keyValue in allIntervals)
            {
                int count = 0;
                if (seconds >= (int)keyValue.Value)
                {
                    while (seconds >= (int)keyValue.Value)
                    {
                        count++;
                        seconds -= (int)keyValue.Value;
                    }
                    yield return GetSorNot(count, keyValue.Value);
                }
            }
        }
        public static void FillingTheDictionaryWithIntervals(out Dictionary<int, CountSecondsInInterval> allIntervals)
        {
            allIntervals = new Dictionary<int, CountSecondsInInterval>();
            allIntervals.Add(0, CountSecondsInInterval.year);
            allIntervals.Add(1, CountSecondsInInterval.day);
            allIntervals.Add(2, CountSecondsInInterval.hour);
            allIntervals.Add(3, CountSecondsInInterval.minute);
            allIntervals.Add(4, CountSecondsInInterval.second);

        }
        public static string GetSorNot(int count, CountSecondsInInterval countSecondsInInterval)
        {
            if (count == 1)
                return count + " " + countSecondsInInterval.ToString();
            return count + " "+ countSecondsInInterval.ToString() + "s"; 
        }
    }
}

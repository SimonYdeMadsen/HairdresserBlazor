using System.Globalization;

namespace BlazorDbAccess.Utility
{
	public static class CalendarUtility
	{

		private static CultureInfo cultureInfo = new CultureInfo("de-DE");
		private static Calendar calendar = cultureInfo.Calendar;
		private static CalendarWeekRule weekRule;
		private static DayOfWeek weeksFirstDay;

		static CalendarUtility()
		{
			SetUpCalendar();
		}

		private static void SetUpCalendar()
		{
			weekRule = cultureInfo.DateTimeFormat.CalendarWeekRule;
			weeksFirstDay = cultureInfo.DateTimeFormat.FirstDayOfWeek;
			if (weeksFirstDay != DayOfWeek.Monday)
			{
				throw new InvalidTimeZoneException();
			}
		}

		public static DateTime GetNormalizedWeekStartDate(DateTime date)
		{
			var normalizedDate = date.Date;
			return normalizedDate.AddDays(-(int)normalizedDate.DayOfWeek + 1);
		}

		public static int GetWeekNumber(DateTime date)
		{
			var weekOfYear = calendar.GetWeekOfYear(date, weekRule, weeksFirstDay);

			return weekOfYear;
		}


	}
}

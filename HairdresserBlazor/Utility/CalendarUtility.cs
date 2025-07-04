﻿using System.Globalization;

namespace HairdresserBlazor.Utility
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

			/*
			 * 0 => 6; 1 => 0; 2 => 1; 3 => 2; 4 => 3; 5 => 4; 6 => 5
			 => x+6 (mod 7)
			*/

			int dayOfWeek = (int)normalizedDate.DayOfWeek + 6 % 7;

			return normalizedDate.AddDays(-dayOfWeek);
		}

		public static int GetWeekNumber(DateTime date)
		{
			var weekOfYear = calendar.GetWeekOfYear(date, weekRule, weeksFirstDay);

			return weekOfYear;
		}


	}
}

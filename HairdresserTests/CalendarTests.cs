using HairdresserBlazor.Utility;

namespace HairdresserTests
{
	[TestClass]
	public class CalendarTests
	{
		[TestMethod]
		public void WeekStartDate_ReturnsCorrectDayOnValidInput()
		{
			DateTime date = new(2023, 3, 19);
			var result = CalendarUtility.GetNormalizedWeekStartDate(date);

			Assert.AreEqual(DayOfWeek.Monday, result.DayOfWeek);
		}

		[TestMethod]
		public void WeekStartDate_ReturnsCorrectDateOnValidInput()
		{
			DateTime date = new(2023, 3, 19);
			var result = CalendarUtility.GetNormalizedWeekStartDate(date);

			Assert.AreEqual(new DateTime(2023, 3, 13), result);
		}

		[TestMethod]
		public void WeekNumber_OnValidInput()
		{
			// Week 09 is from Monday, February 27, 2023 until (and including) Sunday, March 5, 2023.
			DateTime date = new(2023, 3, 5);
			var weekNumber = CalendarUtility.GetWeekNumber(date);

			Assert.AreEqual(9, weekNumber);
		}

		[TestMethod]
		public void WeekNumber_OnMoreValidInput()
		{
			// Week 09 is from Monday, February 27, 2023 until (and including) Sunday, March 5, 2023.
			DateTime date = new(2023, 3, 19);
			var weekNumber = CalendarUtility.GetWeekNumber(date);

			Assert.AreEqual(11, weekNumber);
		}
	}
}
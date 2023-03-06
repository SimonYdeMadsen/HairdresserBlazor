using HairdresserBlazor.Utility;

namespace HairdresserTests
{
	[TestClass]
	public class CalendarTests
	{
		[TestMethod]
		public void NormalizedWeek_OnValidInput()
		{
			var date = DateTime.Now;
			var result = CalendarUtility.GetNormalizedWeekStartDate(date);

			Assert.AreEqual(DayOfWeek.Monday, result.DayOfWeek);
		}

		[TestMethod]
		public void WeekNumber_OnValidInput()
		{
			// Week 09 is from Monday, February 27, 2023 until (and including) Sunday, March 5, 2023.
			var date = new DateTime(2023, 3, 5);
			var weekNumber = CalendarUtility.GetWeekNumber(date);

			Assert.AreEqual(9, weekNumber);
		}

	}
}
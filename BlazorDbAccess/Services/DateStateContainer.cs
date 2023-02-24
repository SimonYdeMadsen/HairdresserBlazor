namespace BlazorDbAccess.Services
{
	public class DateStateContainer
	{
		private DateTime _date;

		public DateTime Date
		{
			get => _date;
			set
			{
				_date = value;
				NotifyStateChanged();
			}
		}
		public event Action OnDateChosen;




		private void NotifyStateChanged()
		{
			
			// If Event has subscribers. 
			if (OnDateChosen != null)
			{
				// Then Broadcast the data.
				Console.WriteLine($"Broadcasting new date: {_date.Date}, {_date.TimeOfDay}");
				OnDateChosen.Invoke();
			}


		}
	}
}

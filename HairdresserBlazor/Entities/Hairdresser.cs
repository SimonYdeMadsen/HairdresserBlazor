namespace HairdresserBlazor.Entities
{
	public class Hairdresser
	{
		public Hairdresser(string userName) : base(userName)
		{
		}

		public double PayRate { get; set; }
	}
}

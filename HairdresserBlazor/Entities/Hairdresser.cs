namespace HairdresserBlazor.Entities
{
	public class Hairdresser : User
	{
		public Hairdresser(string userName) : base(userName)
		{
		}

		public double PayRate { get; set; }
	}
}

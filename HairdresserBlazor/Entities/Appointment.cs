using System.ComponentModel.DataAnnotations.Schema;

namespace HairdresserBlazor.Entities
{
	public class Appointment
	{
		public int Id { get; set; }
		[ForeignKey("UserId")]
		public int UserId { get; set; }
		[ForeignKey("HairdresserId")]
		public int HairdresserId { get; set; }

		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }

		public override string ToString()
		{
			return $"Appointment #{Id}: User({UserId}) serviced by Hairdresser({HairdresserId})";
		}
	}
}

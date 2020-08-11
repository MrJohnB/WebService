
namespace LiteBulb.WebService.Models
{
	public class Guitar
	{
		public int Id { get; set; }
		public string Brand { get; set; }
		public string Model { get; set; }
		public int StringCount { get; set; }
		public GuitarType Type { get; set; }

		public Guitar()
		{
			Id = int.MinValue;
			Brand = string.Empty;
			Model = string.Empty;
			StringCount = int.MinValue;
			Type = GuitarType.Undefined;
		}
	}
}

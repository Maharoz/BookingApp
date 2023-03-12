namespace Shared.RequestFeatures;

public class HotelSearchParameters 
{
	public uint MinRating { get; set; }
	public uint MaxRating { get; set; } = int.MaxValue;
	public bool ValidRatingRange => MaxRating > MinRating;

	public string? SearchTerm { get; set; }
}

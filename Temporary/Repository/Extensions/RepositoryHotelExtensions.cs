using Entities.Models;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;
using Repository.Extensions.Utility;

namespace Repository.Extensions;

public static class RepositoryHotelExtensions
{
	public static IQueryable<Hotel> FilterHotels(this IQueryable<Hotel> hotels, uint minAge, uint maxAge) =>
		hotels.Where(e => (e.Ratings >= minAge && e.Ratings <= maxAge));

	public static IQueryable<Hotel> Search(this IQueryable<Hotel> hotels, string searchTerm)
	{
		if (string.IsNullOrWhiteSpace(searchTerm))
			return hotels;

		var lowerCaseTerm = searchTerm.Trim().ToLower();

		return hotels.Where(e => e.Name.ToLower().Contains(lowerCaseTerm) || e.Location.ToLower().Contains(lowerCaseTerm));
	}

	public static IQueryable<Hotel> Sort(this IQueryable<Hotel> hotels, string orderByQueryString)
	{
		if (string.IsNullOrWhiteSpace(orderByQueryString))
			return hotels.OrderBy(e => e.Name);

		var orderQuery = OrderQueryBuilder.CreateOrderQuery<Hotel>(orderByQueryString);

		if (string.IsNullOrWhiteSpace(orderQuery))
			return hotels.OrderBy(e => e.Name);

		return hotels.OrderBy(orderQuery);
	}
}

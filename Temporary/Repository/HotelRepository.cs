using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	internal sealed class HotelRepository : RepositoryBase<Hotel>, IHotelRepository
	{
		public HotelRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}

		public void CreateHotel(Hotel hotel) => Create(hotel);

		public async Task<Hotel> GetHotelAsync(int hotelId, bool trackChanges) =>
		await FindByCondition(c => c.Hotel_Id.Equals(hotelId), trackChanges)
		.SingleOrDefaultAsync();


		public async Task<IEnumerable<Hotel>> GetAllHotelAsync(bool trackChanges) =>
	await FindAll(trackChanges)
			.Include(u=>u.Comments).ThenInclude(x=>x.Replys)
	.OrderBy(c => c.Hotel_Id)
	.ToListAsync();

		public async Task<IEnumerable<Hotel>> GetHotelsAsync(int hotelId,
	HotelSearchParameters hotelparameters, bool trackChanges)
		{
			var hotels = new List<Hotel>();
			if (hotelId == 0)
			{
				hotels = await FindAll(trackChanges)
			   .Include(u => u.Comments).ThenInclude(x => x.Replys)
			   .FilterHotels(hotelparameters.MinRating, hotelparameters.MaxRating)
			   .Search(hotelparameters.SearchTerm)
			   .OrderBy(e => e.Name)
			   .ToListAsync();
			}
			else{

				hotels = await FindByCondition(e => e.Hotel_Id.Equals(hotelId), trackChanges)
						   .Include(u => u.Comments).ThenInclude(x => x.Replys)
						   .FilterHotels(hotelparameters.MinRating, hotelparameters.MaxRating)
						   .Search(hotelparameters.SearchTerm)
						   .OrderBy(e => e.Name)
						   .ToListAsync();
			}
		

			return hotels;
		}

		public void DeleteHotel(Hotel hotel) => Delete(hotel);
		public void UpdateHotel(Hotel hotel) => Update(hotel);

	}
}

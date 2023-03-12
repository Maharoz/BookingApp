using Entities.Models;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
	public interface IHotelRepository
	{
		Task<Hotel> GetHotelAsync(int hotelId, bool trackChanges);
		void CreateHotel(Hotel hotel);
		Task<IEnumerable<Hotel>> GetAllHotelAsync(bool trackChanges);
        void DeleteHotel(Hotel hotel);
		void UpdateHotel(Hotel hotel);
		Task<IEnumerable<Hotel>> GetHotelsAsync(int hotelId,
	HotelSearchParameters hotelparameters, bool trackChanges);
	}
}

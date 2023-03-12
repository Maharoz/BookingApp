using Entities.Models;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
	public interface IHotelService
	{
		Task<HotelDto> GetHotelAsync(int hotelId, bool trackChanges);
		Task<HotelDto> CreateHotelAsync(HotelForCreationDto hotel);
		Task<IEnumerable<HotelDto>> GetAllRHotelAsync(bool trackChanges);
        void DeleteHotelAsync(int id);
        Task UpdateHotelAsync(int Id, HotelForUpdateDto hotelForUpdate, bool trackChanges);
		Task<IEnumerable<HotelDto>> GetHotelsAsync
	(int hotelId, HotelSearchParameters hotelparameters, bool trackChanges);

	}
}

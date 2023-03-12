using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{


	internal sealed class HotelService : IHotelService
	{
		private readonly IRepositoryManager _repository;
		private readonly ILoggerManager _logger;
		private readonly IMapper _mapper;

        public HotelService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
		{
			_repository = repository;
			_logger = logger;
			_mapper = mapper;
		}


		public async Task<HotelDto> CreateHotelAsync(HotelForCreationDto hotel)
		{
           
			
			var hotelEntity = _mapper.Map<Hotel>(hotel);

			_repository.Hotel.CreateHotel(hotelEntity);
			await _repository.SaveAsync();

			var hotelToReturn = _mapper.Map<HotelDto>(hotelEntity);
          
            return hotelToReturn;
		}



		public async Task<IEnumerable<HotelDto>> GetHotelsAsync
	(int hotelId, HotelSearchParameters hotelparameters, bool trackChanges)
		{
			if (!hotelparameters.ValidRatingRange)
				throw new MaxRatingRangeBadRequestException();

			//await GetHotelAndCheckIfItExists(companyId, trackChanges);

			var hotelsWithMetaData = await _repository.Hotel
				.GetHotelsAsync(hotelId, hotelparameters, trackChanges);
			var hotelsDto = _mapper.Map<IEnumerable<HotelDto>>(hotelsWithMetaData);

			return hotelsDto;
		}


		public async Task<HotelDto> GetHotelAsync(int id, bool trackChanges)
		{
			var hotel = await GetHotelAndCheckIfItExists(id, trackChanges);

			HotelDto hotelDto = _mapper.Map<HotelDto>(hotel);

			
			return hotelDto;
		}

		private async Task<Hotel> GetHotelAndCheckIfItExists(int id, bool trackChanges)
		{
			Hotel hotel = await _repository.Hotel.GetHotelAsync(id, trackChanges);

		
			if (hotel is null)
				throw new HotelNotFoundException(id);

			return hotel;
		}

		public async Task<IEnumerable<HotelDto>> GetAllRHotelAsync(bool trackChanges)
		{
			var hotels = await _repository.Hotel.GetAllHotelAsync(trackChanges);


			IEnumerable<HotelDto> hotelsDto = _mapper.Map<IEnumerable<HotelDto>>(hotels);


		return hotelsDto;
		}

        public async Task UpdateHotelAsync(int hotelId,
        HotelForUpdateDto hotelsForUpdate, bool trackChanges)
        {
            var hotel = await GetHotelAndCheckIfItExists(hotelId, trackChanges);

			//_mapper.Map(hotelForUpdate, hotel);
			Hotel hotelDto = _mapper.Map<Hotel>(hotelsForUpdate);
			hotelDto.Hotel_Id= hotelId;
			_repository.Hotel.UpdateHotel(hotelDto);
			await _repository.SaveAsync();
        }


        public void DeleteHotelAsync(int hotelId)
        {
            var hotel = GetHotelAndCheckIfItExists(hotelId, false);

			
            _repository.Hotel.DeleteHotel(hotel.Result);
			_repository.SaveAsync();
        }


	}
}

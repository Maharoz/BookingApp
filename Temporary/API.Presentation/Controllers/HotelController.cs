using API.Presentation.ActionFilters;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Presentation.Controllers
{
	[Route("api/hotel")]
	[ApiController]

	public class HotelController : ControllerBase
	{
		private readonly IServiceManager _service;

		public HotelController(IServiceManager service) => _service = service;

		/// <summary>
		/// Gets the list of all hotels
		/// </summary>
		/// <returns>The hotels list</returns>
		[HttpGet(Name = "GetHotels")]
		//[Authorize(Roles = "Manager")]
		public async Task<IActionResult> GetHotels()
		{
			var hotels = await _service.HotelService.GetAllRHotelAsync(trackChanges: false);

			return Ok(hotels);
		}

		[HttpGet("{id:int}", Name = "HotelById")]
		[HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)]
		[HttpCacheValidation(MustRevalidate = false)]
		public async Task<IActionResult> GetHotel(int id)
		{
			var hotel = await _service.HotelService.GetHotelAsync(id, trackChanges: false);
			return Ok(hotel);
		}


		[HttpGet]
		[Route("GetHotelsCollection")]
		[HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)]
		[HttpCacheValidation(MustRevalidate = false)]
		public async Task<IActionResult> GetHotelsBySearch(int hotelId,
		[FromQuery] HotelSearchParameters hotelparameters)
		{
			var pagedResult = await _service.HotelService.GetHotelsAsync(hotelId,
				hotelparameters, trackChanges: false);

			//Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

			return Ok(pagedResult);
		}

		/// <summary>
		/// Creates a newly created hotel
		/// </summary>
		/// <param name="hotel"></param>
		/// <returns>A newly created hotel</returns>
		/// <response code="201">Returns the newly created item</response>
		/// <response code="400">If the item is null</response>
		/// <response code="422">If the model is invalid</response>
		[HttpPost(Name = "CreateHotel")]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(422)]
		[ServiceFilter(typeof(ValidationFilterAttribute))]
		public async Task<IActionResult> Createhotel([FromBody] HotelForCreationDto hotel)
		{

			//Need to adjust in professional projects//
			hotel.CreatedDate= DateTime.Now;
			hotel.UpdatedDate= DateTime.Now;
			//*************//
			var createdhotel = await _service.HotelService.CreateHotelAsync(hotel);

            return CreatedAtRoute("hotelById", new { id = createdhotel.Hotel_Id }, createdhotel);
		}


		[HttpPut("{id:int}")]
		[ServiceFilter(typeof(ValidationFilterAttribute))]
		public async Task<IActionResult> Updatehotel(int id, [FromBody] HotelForUpdateDto hotel)
		{
			await _service.HotelService.UpdateHotelAsync(id, hotel, trackChanges: true);
	
			return NoContent();
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteHotel(int id)
		{
			 _service.HotelService.DeleteHotelAsync(id);

			return NoContent();
		}


	}
}

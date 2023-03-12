using API.Presentation.ActionFilters;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Presentation.Controllers
{
	[Route("api/Reply")]
	[ApiController]

	public class ReplyController : ControllerBase
	{
		private readonly IServiceManager _service;

		public ReplyController(IServiceManager service) => _service = service;

		/// <summary>
		/// Gets the list of all replys
		/// </summary>
		/// <returns>The replys list</returns>
		[HttpGet(Name = "GetReplys")]
		//[Authorize(Roles = "Manager")]
		public async Task<IActionResult> GetReplys()
		{
			var companies = await _service.ReplyService.GetAllReplyAsync(trackChanges: false);

			return Ok(companies);
		}

		[HttpGet("{id:int}", Name = "ReplyById")]
		public async Task<IActionResult> GetReply(int id)
		{
			var reply = await _service.ReplyService.GetReplyAsync(id, trackChanges: false);
			return Ok(reply);
		}

		

		/// <summary>
		/// Creates a newly created reply
		/// </summary>
		/// <param name="reply"></param>
		/// <returns>A newly created reply</returns>
		/// <response code="201">Returns the newly created item</response>
		/// <response code="400">If the item is null</response>
		/// <response code="422">If the model is invalid</response>
		[HttpPost(Name = "CreateReply")]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(422)]
		[ServiceFilter(typeof(ValidationFilterAttribute))]
		public async Task<IActionResult> CreateReply([FromBody] ReplyForCreationDto reply)
		{

			//Need to adjust in professional projects//
			reply.CreatedDate= DateTime.Now;
			reply.UpdatedDate= DateTime.Now;
			//*************//
			var createdreply = await _service.ReplyService.CreateReplyAsync(reply);

            return CreatedAtRoute("ReplyById", new { id = createdreply.Reply_Id }, createdreply);
		}


	

	

	}
}

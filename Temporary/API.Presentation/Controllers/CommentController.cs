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
	[Route("api/comment")]
	[ApiController]

	public class CommentController : ControllerBase
	{
		private readonly IServiceManager _service;

		public CommentController(IServiceManager service) => _service = service;

		/// <summary>
		/// Gets the list of all comments
		/// </summary>
		/// <returns>The comments list</returns>
		[HttpGet(Name = "GetComments")]
		//[Authorize(Roles = "Manager")]
		public async Task<IActionResult> GetComments()
		{
			var comments = await _service.CommentService.GetAllCommentAsync(trackChanges: false);

			return Ok(comments);
		}

		[HttpGet("{id:int}", Name = "CommentById")]
		public async Task<IActionResult> GetComment(int id)
		{
			var comment = await _service.CommentService.GetCommentAsync(id, trackChanges: false);
			return Ok(comment);
		}

		

		/// <summary>
		/// Creates a newly created comment
		/// </summary>
		/// <param name="comment"></param>
		/// <returns>A newly created comment</returns>
		/// <response code="201">Returns the newly created item</response>
		/// <response code="400">If the item is null</response>
		/// <response code="422">If the model is invalid</response>
		[HttpPost(Name = "CreateComment")]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(422)]
		[ServiceFilter(typeof(ValidationFilterAttribute))]
		public async Task<IActionResult> CreateComment([FromBody] CommentForCreationDto comment)
		{

			//Need to adjust in professional projects//
			comment.CreatedDate= DateTime.Now;
			comment.UpdatedDate= DateTime.Now;
			//*************//
			var createdcomment = await _service.CommentService.CreateCommentAsync(comment);

            return CreatedAtRoute("CommentById", new { id = createdcomment.Comment_Id }, createdcomment);
		}


	

	

	}
}

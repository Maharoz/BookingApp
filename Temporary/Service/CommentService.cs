using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{


	internal sealed class CommentService : ICommentService
	{
		private readonly IRepositoryManager _repository;
		private readonly ILoggerManager _logger;
		private readonly IMapper _mapper;

        public CommentService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
		{
			_repository = repository;
			_logger = logger;
			_mapper = mapper;
		}


		public async Task<CommentDto> CreateCommentAsync(CommentForCreationDto comment)
		{
           
			
			var commentEntity = _mapper.Map<Comment>(comment);

			_repository.Comment.CreateComment(commentEntity);
			await _repository.SaveAsync();

			var commentToReturn = _mapper.Map<CommentDto>(commentEntity);
          
            return commentToReturn;
		}


		public async Task<CommentDto> GetCommentAsync(int id, bool trackChanges)
		{
			var comment = await GetCommentAndCheckIfItExists(id, trackChanges);

			CommentDto commentDto = _mapper.Map<CommentDto>(comment);

			
			return commentDto;
		}

		private async Task<Comment> GetCommentAndCheckIfItExists(int id, bool trackChanges)
		{
			Comment comment = await _repository.Comment.GetCommentAsync(id, trackChanges);

		
			if (comment is null)
				throw new HotelNotFoundException(id);

			return comment;
		}

		public async Task<IEnumerable<CommentDto>> GetAllCommentAsync(bool trackChanges)
		{
			var comments = await _repository.Reply.GetAllReplyAsync(trackChanges);


			IEnumerable<CommentDto> commentDto =_mapper.Map<IEnumerable<CommentDto>>(comments);


		return commentDto;
		}

	
	}
}

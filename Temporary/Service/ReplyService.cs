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


	internal sealed class ReplyService : IReplyService
	{
		private readonly IRepositoryManager _repository;
		private readonly ILoggerManager _logger;
		private readonly IMapper _mapper;

        public ReplyService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
		{
			_repository = repository;
			_logger = logger;
			_mapper = mapper;
		}


		public async Task<ReplyDto> CreateReplyAsync(ReplyForCreationDto reply)
		{
           
			
			var replyEntity = _mapper.Map<Reply>(reply);

			_repository.Reply.CreateReply(replyEntity);
			await _repository.SaveAsync();

			var replyToReturn = _mapper.Map<ReplyDto>(replyEntity);
          
            return replyToReturn;
		}


		public async Task<ReplyDto> GetReplyAsync(int id, bool trackChanges)
		{
			var reply = await GetReplyAndCheckIfItExists(id, trackChanges);

			ReplyDto replyDto = _mapper.Map<ReplyDto>(reply);

			
			return replyDto;
		}

		private async Task<Reply> GetReplyAndCheckIfItExists(int id, bool trackChanges)
		{
			Reply reply = await _repository.Reply.GetReplyAsync(id, trackChanges);

		
			if (reply is null)
				throw new HotelNotFoundException(id);

			return reply;
		}

		public async Task<IEnumerable<ReplyDto>> GetAllReplyAsync(bool trackChanges)
		{
			var replys = await _repository.Reply.GetAllReplyAsync(trackChanges);


			IEnumerable<ReplyDto> replyDto =_mapper.Map<IEnumerable<ReplyDto>>(replys);


		return replyDto;
		}

	
	}
}

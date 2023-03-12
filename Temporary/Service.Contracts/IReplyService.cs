using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
	public interface IReplyService
	{
		Task<ReplyDto> GetReplyAsync(int applicationId, bool trackChanges);
		Task<ReplyDto> CreateReplyAsync(ReplyForCreationDto hotel);
		Task<IEnumerable<ReplyDto>> GetAllReplyAsync(bool trackChanges);

    }
}

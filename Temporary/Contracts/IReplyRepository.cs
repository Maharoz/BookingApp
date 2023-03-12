using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
	public interface IReplyRepository
	{
		Task<Reply> GetReplyAsync(int hotelId, bool trackChanges);
		void CreateReply(Reply reply);
		Task<IEnumerable<Reply>> GetAllReplyAsync(bool trackChanges);
        void DeleteReply(Reply reply);
		void UpdateReply(Reply reply);
	}
}

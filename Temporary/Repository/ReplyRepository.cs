using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	internal sealed class ReplyRepository : RepositoryBase<Reply>, IReplyRepository
	{
		public ReplyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}

		public void CreateReply(Reply hotel) => Create(hotel);

		public async Task<Reply> GetReplyAsync(int replyId, bool trackChanges) =>
		await FindByCondition(c => c.Reply_Id.Equals(replyId), trackChanges)
		.SingleOrDefaultAsync();


		public async Task<IEnumerable<Reply>> GetAllReplyAsync(bool trackChanges) =>
	await FindAll(trackChanges)
	.OrderBy(c => c.Reply_Id)
	.ToListAsync();


        public void DeleteReply(Reply reply) => Delete(reply);
		public void UpdateReply(Reply reply) => Update(reply);

	}
}

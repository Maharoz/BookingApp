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
	internal sealed class CommentRepository : RepositoryBase<Comment>, ICommentRepository
	{
		public CommentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}

		public void CreateComment(Comment hotel) => Create(hotel);

		public async Task<Comment> GetCommentAsync(int commentId, bool trackChanges) =>
		await FindByCondition(c => c.Comment_Id.Equals(commentId), trackChanges)
		.SingleOrDefaultAsync();


		public async Task<IEnumerable<Comment>> GetAllCommentAsync(bool trackChanges) =>
	await FindAll(trackChanges)
	.OrderBy(c => c.Comment_Id)
	.ToListAsync();


        public void DeleteComment(Comment comment) => Delete(comment);
		public void UpdateComment(Comment comment) => Update(comment);

	}
}

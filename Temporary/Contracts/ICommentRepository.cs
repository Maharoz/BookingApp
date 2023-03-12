using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
	public interface ICommentRepository
	{
		Task<Comment> GetCommentAsync(int hotelId, bool trackChanges);
		void CreateComment(Comment comment);
		Task<IEnumerable<Comment>> GetAllCommentAsync(bool trackChanges);
        void DeleteComment(Comment comment);
		void UpdateComment(Comment comment);
	}
}

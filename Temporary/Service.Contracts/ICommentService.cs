using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
	public interface ICommentService
	{
		Task<CommentDto> GetCommentAsync(int commentId, bool trackChanges);
		Task<CommentDto> CreateCommentAsync(CommentForCreationDto comment);
		Task<IEnumerable<CommentDto>> GetAllCommentAsync(bool trackChanges);

    }
}

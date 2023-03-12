namespace Contracts;

public interface IRepositoryManager
{
	
	IHotelRepository Hotel { get; }
	ICommentRepository Comment { get; }
	IReplyRepository Reply { get; }
	Task SaveAsync();
}

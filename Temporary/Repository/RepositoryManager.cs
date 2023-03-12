using Contracts;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
	private readonly RepositoryContext _repositoryContext;
	private readonly Lazy<IHotelRepository> _hotelRepository;
	private readonly Lazy<IReplyRepository> _replyRepository;
	private readonly Lazy<ICommentRepository> _commentRepository;
	public RepositoryManager(RepositoryContext repositoryContext)
	{
		_repositoryContext = repositoryContext;
		
		_hotelRepository = new Lazy<IHotelRepository>(() => new HotelRepository(repositoryContext));
		_replyRepository = new Lazy<IReplyRepository>(() => new ReplyRepository(repositoryContext));
		_commentRepository = new Lazy<ICommentRepository>(() => new CommentRepository(repositoryContext));


	}

	public IHotelRepository Hotel => _hotelRepository.Value;
	public IReplyRepository Reply => _replyRepository.Value;
	public ICommentRepository Comment => _commentRepository.Value;

	public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}

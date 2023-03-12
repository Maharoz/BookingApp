using AutoMapper;
using Contracts;
using Entities.ConfigurationModels;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
	
    private readonly Lazy<IAuthenticationService> _authenticationService;
	private readonly Lazy<IHotelService> _hotelService;
	private readonly Lazy<ICommentService> _commentService;
	private readonly Lazy<IReplyService> _replyService;

	public ServiceManager(IRepositoryManager repositoryManager,
		ILoggerManager logger,
		IMapper mapper,
		UserManager<User> userManager,
		IOptions<JwtConfiguration> configuration)
	{
		_authenticationService = new Lazy<IAuthenticationService>(() =>
			new AuthenticationService(logger, mapper, userManager, configuration));
		
		_hotelService = new Lazy<IHotelService>(() =>
			new HotelService(repositoryManager, logger, mapper));
		_commentService = new Lazy<ICommentService>(() =>
			new CommentService(repositoryManager, logger, mapper));
		_replyService = new Lazy<IReplyService>(() =>
			new ReplyService(repositoryManager, logger, mapper));

	}
	public IAuthenticationService AuthenticationService => _authenticationService.Value;

	public IHotelService HotelService => _hotelService.Value;
	public ICommentService CommentService => _commentService.Value;
	public IReplyService ReplyService => _replyService.Value;
}

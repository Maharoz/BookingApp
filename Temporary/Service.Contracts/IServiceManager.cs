namespace Service.Contracts;

public interface IServiceManager
{
	IAuthenticationService AuthenticationService { get; }
	IHotelService HotelService { get; }
	ICommentService CommentService { get; }
	IReplyService ReplyService { get; }
}

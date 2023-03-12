using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace API;

public class MappingProfile : Profile
{
	public MappingProfile()
	{

		CreateMap<HotelForCreationDto, Hotel>();
		CreateMap<HotelForCreationDto, Hotel>().ReverseMap();
		CreateMap<Hotel, HotelDto>().ForMember(pts => pts.Comment, opt => opt.MapFrom(ps => ps.Comments));
			
		CreateMap<HotelForUpdateDto, Hotel>();

		CreateMap<CommentForCreationDto, Comment>();
		CreateMap<CommentForCreationDto, Comment>().ReverseMap();
		CreateMap<Comment, CommentDto>().ForMember(pts => pts.Reply, opt => opt.MapFrom(ps => ps.Replys)); ;

		CreateMap<ReplyForCreationDto, Reply>();
		CreateMap<ReplyForCreationDto, Reply>().ReverseMap();
		CreateMap<Reply, ReplyDto>();
    }
}

using AutoMapper;
using SocialHelpApi.Models.Dto;
using SocialHelpApi.Models.Entities;

namespace SocialHelpApi.Models.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Message, MessageAllDto>()
            .ForMember(dest => dest.DateMessage, opt => opt.MapFrom(src => src.DateMessage.ToString("dd.MM.yyyy HH:mm:ss")));
            CreateMap<MessageDto, Message>();
            CreateMap<Group, GroupDto>();
            CreateMap<GroupDto, Group>();
        }
    }
}

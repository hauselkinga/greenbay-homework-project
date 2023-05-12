namespace GreenBay_Backend.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreationDTO, User>()
                .ForMember(
                    dest => dest.UserName,
                    opt => opt.MapFrom(src => src.UserName)
                )
                .ForMember(
                    dest => dest.Password,
                    opt => opt.MapFrom(src => src.Password)
                );
        }
    }
}

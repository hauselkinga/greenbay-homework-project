namespace GreenBay_Backend.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemDTO>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name)
                )
                .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => src.Description)
                )
                .ForMember(
                    dest => dest.PhotoURL,
                    opt => opt.MapFrom(src => src.PhotoURL)
                )
                .ForMember(
                    dest => dest.Price,
                    opt => opt.MapFrom(src => src.Price)
                )
                .ForMember(
                    dest => dest.Seller,
                    opt => opt.MapFrom(src => src.User.UserName)
                );

            CreateMap<ItemCreationDTO, Item>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name)
                )
                .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => src.Description)
                )
                .ForMember(
                    dest => dest.PhotoURL,
                    opt => opt.MapFrom(src => src.PhotoURL)
                )
                .ForMember(
                    dest => dest.Price,
                    opt => opt.MapFrom(src => src.Price)
                )
                .ForMember(
                    dest => dest.UserId,
                    opt => opt.MapFrom(src => src.UserId)
                );
        }
    }
}

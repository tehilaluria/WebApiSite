using AutoMapper;
using DTO;
using Entities;


namespace WebApiSite
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            //CreateMap<Book, BookDTO>().ReverseMap(); ;
            CreateMap<Book, BookDTO>().ForMember(dest => dest.CategoryName,
               opts => opts.MapFrom(src => src.Category.CategoryName)).ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap(); ;
            CreateMap<User, UserLoginDTO>().ReverseMap(); ;
            CreateMap<Order, OrderDTO>().ReverseMap(); ;
            CreateMap<Category, CategoryDTO>().ReverseMap(); ;
            CreateMap<OrderBook, OrderBookDTO>().ReverseMap(); ;
        }
       
    }
}

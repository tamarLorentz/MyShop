



using DTO;
using AutoMapper;
using Entites;

namespace MyShop
{
    public class Mapper:Profile
    {
        
   public Mapper()
        {
           
            CreateMap<Category, GetCategoryDTO>();
            CreateMap<Order, GetOrderDTO>();
            CreateMap<PostOrderDTO, Order>();
            CreateMap<Product, ProductDTO>();
            CreateMap<User, GetUserDTO>();
            CreateMap<PostUserDTO,User>();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
           
        }
    }
}

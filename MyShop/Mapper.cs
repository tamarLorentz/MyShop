



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
            CreateMap<Order, PostOrderDTO>();
            CreateMap<Product, ProductDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<OrderItem, GetOrderItemDTO>();
        }
    }
}

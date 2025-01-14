using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Entites;


namespace DTO
{
   public record OrderItemDTO(int ProuductId, int? Quantity);
    public record GetOrderDTO(int Id, DateOnly Date, float Sum, int UserId , ICollection<OrderItemDTO> OrderItems); 
   
    //whene do date???
    public record PostOrderDTO( int UserId, ICollection<OrderItemDTO> OrderItems); 
}




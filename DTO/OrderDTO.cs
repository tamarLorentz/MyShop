using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Entites;


namespace DTO
{
   public record GetOrderItemDTO(int Id, int ProuductId, int? Quantity);
    public record GetOrderDTO(int Id, DateOnly Date, float Sum, int UserId , ICollection<GetOrderItemDTO> OrderItems); 
    public record PostOrderDTO(int Id, DateOnly Date, float Sum, int UserId); 
}




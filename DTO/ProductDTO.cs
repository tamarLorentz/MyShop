using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public record ProductDTO(int Id,int CategoryId, string CategoryName,string Name,string Description,int Price,string Image);


}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
 public  record  GetUserDTO(int Id,string UserName,string  FirstName,string LastName);
    public record PostUserDTO(
       [Required][EmailAddress] string UserName,
       [StringLength(30, ErrorMessage = "fristName can be between 2 till 30 chars", MinimumLength = 2)] string FirstName,
       [StringLength(30, ErrorMessage = "Last name can be between 2 till 30 chars", MinimumLength = 2)] string LastName,
       [Required] string Password);

}

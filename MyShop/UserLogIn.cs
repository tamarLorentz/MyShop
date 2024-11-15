using System.ComponentModel.DataAnnotations;

namespace MyShop;

public class UserLogIn
{
    public int Id { get; set; }
    [EmailAddress]
    public string UserName { get; set; }
    public string Password { get; set; }
}

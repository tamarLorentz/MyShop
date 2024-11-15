using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    IUserServices userServices;
   public  UsersController (IUserServices _userServices)
    {

        userServices = _userServices;


}


    string pathFile = "M:\\WebAPI\\lesson1\\MyShop\\MyShop\\db.txt";
    // GET: api/<UsersController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return userServices.Get();
    }

    // GET api/<UsersController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return userServices.Get(id);
    }

    // POST api/<UsersController>
    [HttpPost]
    public ActionResult Post([FromBody] User user)
    {
        User newuser = userServices.Post(user);
        return CreatedAtAction(nameof(Get), new { id = newuser.Id }, newuser);


    }
    // POST api/<UsersController>
    [HttpPost]
    [Route("login")]
    public ActionResult PostLogIn([FromQuery] string userName,string password)
    {
        User userFind = userServices.PostLogIn(userName, password);
        if (userFind!=null)
                    return Ok(userFind);
        return NoContent();
    }
   

        

    // PUT api/<UsersController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] User user)
    {
       userServices.Put(id,user);
    }

    // DELETE api/<UsersController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
    [HttpPost]
    [Route("check")]
    public int CheckPassword([FromQuery] string password)
    {
        return userServices.CheckPassword(password);
    }
}

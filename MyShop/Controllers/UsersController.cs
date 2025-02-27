using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Services;
using Entites;
using DTO;
using AutoMapper;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
//no change to delete delte,post
namespace MyShop.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    IUserServices userServices;
    IMapper mapper;
    private readonly ILogger<UsersController> logger;
    public  UsersController (IUserServices _userServices, IMapper mapper, ILogger<UsersController> logger)
    {
    this.mapper =  mapper;
    userServices = _userServices;
    this.logger = logger;
}
    
 

    // GET api/<UsersController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> Get(int id)
    {
    User user = await userServices.Get(id);
    UserDTO userDTO = mapper.Map<User, UserDTO>(user);

    if (userDTO != null)
         {  
            return Ok(userDTO);
        }
        else return NoContent();
    }

    // POST api/<UsersController>
    [HttpPost]
    public async Task<ActionResult<User>> Post([FromBody] User user)
    {
        User newuser = await userServices.Post(user);
        UserDTO userDTO = mapper.Map<User, UserDTO>(newuser);

        return CreatedAtAction(nameof(Get), new { id = userDTO.Id }, userDTO);
    }
    // POST api/<UsersController>
    [HttpPost]
    [Route("login")]
    public async Task< ActionResult<User>> PostLogIn([FromQuery] string userName,string password)
    {
        User userFind = await userServices.PostLogIn(userName, password);
        UserDTO userDTO = mapper.Map<User, UserDTO>(userFind);

        if (userDTO != null) {
            logger.LogInformation($"login attempt with usernsme:{userName} and password:{password}");

            return Ok(userDTO);
        }
        return NoContent();
    }
   

        

    // PUT api/<UsersController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult<User>> Put(int id, [FromBody] User user)
    {
       User newUser = await  userServices.Put(id,user);
        UserDTO userDTO = mapper.Map<User, UserDTO>(newUser);
        if (userDTO != null)
            return Ok(userDTO);
        else
        return NoContent();

    }

    
    [HttpGet]
    [Route("check")]
    public int CheckPassword([FromQuery] string password)
    {
        return userServices.CheckPassword(password);
    }
}

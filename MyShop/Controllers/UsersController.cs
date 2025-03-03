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
    public async Task<ActionResult<GetUserDTO>> Get(int id)
    {
    User user = await userServices.Get(id);
    GetUserDTO userDTO = mapper.Map<User, GetUserDTO>(user);

    if (userDTO != null)
         {  
            return Ok(userDTO);
        }
        else return NoContent();
    }

    // POST api/<UsersController>
    [HttpPost]
    public async Task<ActionResult<GetUserDTO>> Post([FromBody] PostUserDTO userDTO)
    {
        User user = mapper.Map<PostUserDTO, User>(userDTO);
        User newuser = await userServices.Post(user);
        GetUserDTO getuserDTO = mapper.Map<User, GetUserDTO>(newuser);

        return CreatedAtAction(nameof(Get), new { id = getuserDTO.Id }, getuserDTO);
    }
    // POST api/<UsersController>
    [HttpPost]
    [Route("login")]
    public async Task< ActionResult<User>> PostLogIn([FromQuery] string userName,string password)
    {
        User userFind = await userServices.PostLogIn(userName, password);
        GetUserDTO userDTO = mapper.Map<User, GetUserDTO>(userFind);

        if (userDTO != null) {

          

            return Ok(userDTO);
        }
        return NoContent();
    }
   

        

    // PUT api/<UsersController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult<User>> Put(int id, [FromBody] PostUserDTO postUserDTO) {
        User user = mapper.Map<PostUserDTO, User>(postUserDTO);
        user.Id = id;
        User upDateUser = await  userServices.Put(id,user);
        if (upDateUser == null)
        {
            return BadRequest();
        }
        GetUserDTO userDTO = mapper.Map<User, GetUserDTO>(upDateUser);
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

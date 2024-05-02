using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{

    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(){
        return await _context.Users.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUser(int id){
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    [HttpPost]
    public async Task<ActionResult> PostUser(AppUser user){
        if(user != null)
        {
            return BadRequest();
        }
        else{
          var newUser = await  _context.Users.AddAsync(user);
            return Ok(newUser);
        }
    }

}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AccountBalance.Models;
using AccountBalance.Data;

namespace AccountBalance.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AccountBalanceContext _context;

        public UserController(AccountBalanceContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            return Ok(await _context.Users.ToListAsync());

        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser(UserDTO userDTO)
        {
            var user = new User() 
            {
            
                FirstName= userDTO.FirstName,
                LastName= userDTO.LastName
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]

        public async Task<ActionResult> DeleteUser(int id)
        {
            var deleteuser = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(deleteuser == null)
            {
                return NotFound();
            }

            _context.Users.Remove(deleteuser);
            await _context.SaveChangesAsync();
            return Ok();
        }
        
    } 
    
}

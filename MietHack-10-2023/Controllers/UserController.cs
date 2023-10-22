using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MietHack_10_2023.Database;
using MietHack_10_2023.Database.Models;
using System.Threading.Tasks;

namespace MietHack_10_2023.Controllers
{
    public class UserController : Controller
    {
        private readonly DatabaseContext _context;

        public UserController (DatabaseContext context)
        {
            _context = context;
        }

        [HttpPut]
        [Route("Add{user}")]
        public async Task<IActionResult> Add(User user)
        {
            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("GetPassword{id}")]
        public async Task<IActionResult> GetPassword(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);

            return Ok(user?.PasswordHash);
        }
    }
}

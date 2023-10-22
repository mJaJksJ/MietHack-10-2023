using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MietHack_10_2023.Database;
using MietHack_10_2023.Database.Models;
using System.Threading.Tasks;
using System;

namespace MietHack_10_2023.Controllers
{
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly DatabaseContext _context;

        public EventController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpPut]
        [Route("Add{ev}")]
        public async Task<IActionResult> Add(Event ev)
        {
            _context.Events.Add(ev);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("Delete{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Events.SingleOrDefaultAsync(s => s.Id == id);

            if (student is not null)
            {
                _context.Events.Remove(student);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpPut]
        [Route("Update{ev}")]
        public async Task<IActionResult> Update(Event ev)
        {
            var updatedEvent = await _context.Events.SingleOrDefaultAsync(s => s.Id == ev.Id);

            if (updatedEvent is null)
            {
                throw new NullReferenceException("Такого пользователя не существует");
            }

            updatedEvent.Date = ev.Date;
            updatedEvent.Name = ev.Name;
            updatedEvent.Organizer = ev.Organizer;
            updatedEvent.LinqToGroup = ev.LinqToGroup;

            _context.Events.Update(updatedEvent);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Events.ToListAsync());
        }

        [HttpGet]
        [Route("GetById{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _context.Events.SingleOrDefaultAsync(s => s.Id == id));
        }
    }
}

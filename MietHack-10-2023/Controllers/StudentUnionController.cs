using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MietHack_10_2023.Database;
using MietHack_10_2023.Database.Models;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace MietHack_10_2023.Controllers
{
    [Route("api/[controller]")]
    public class StudentUnionController : Controller
    {
        private readonly DatabaseContext _context;

        public StudentUnionController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpPut]
        [Route("Add{studentUnion}")]
        public async Task<IActionResult> Add(StudentUnion studentUnion)
        {
            _context.StudentUnions.Add(studentUnion);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("Delete{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var studentUnion = await _context.StudentUnions.SingleOrDefaultAsync(s => s.Id == id);

            if (studentUnion is not null)
            {
                _context.StudentUnions.Remove(studentUnion);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpPut]
        [Route("Update{studentUnion}")]
        public async Task<IActionResult> Update(StudentUnion studentUnion)
        {
            var updatedStudentUnions = await _context.StudentUnions.SingleOrDefaultAsync(s => s.Id == studentUnion.Id);

            if (updatedStudentUnions is null)
            {
                throw new NullReferenceException("Такого пользователя не существует");
            }

            updatedStudentUnions.Description = studentUnion.Description;
            updatedStudentUnions.Goals = studentUnion.Goals;
            updatedStudentUnions.Tasks = studentUnion.Tasks;
            updatedStudentUnions.Participants = studentUnion.Participants;
            updatedStudentUnions.Manager = studentUnion.Manager;
            updatedStudentUnions.Name = studentUnion.Name;
            updatedStudentUnions.Logo = studentUnion.Logo;

            _context.StudentUnions.Update(updatedStudentUnions);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.StudentUnions.ToListAsync());
        }

        [HttpGet]
        [Route("GetById{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _context.StudentUnions.SingleOrDefaultAsync(s => s.Id == id));
        }
    }
}

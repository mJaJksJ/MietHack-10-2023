using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MietHack_10_2023.Database;
using MietHack_10_2023.Database.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MietHack_10_2023.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly DatabaseContext _context;

        public StudentController(DatabaseContext context)
        {
            _context = context;
        }


        [HttpPut]
        [Route("Add{student}")]
        public async Task<IActionResult> Add(Student student)
        {
            _context.Students.Add(student);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("Delete{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students.SingleOrDefaultAsync(s => s.Id == id);

            if (student is not null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpPut]
        [Route("Update{student}")]
        public async Task<IActionResult> Update(Student student)
        {
            var updatedStudent = await _context.Students.SingleOrDefaultAsync(s => s.Id == student.Id);

            if (updatedStudent is null)
            {
                throw new NullReferenceException("Такого пользователя не существует");
            }

            updatedStudent.FullName = student.FullName;
            updatedStudent.LinkToProfile = student.LinkToProfile;
            updatedStudent.Group = student.Group;

            _context.Students.Update(updatedStudent);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Students.ToListAsync());
        }

        [HttpGet]
        [Route("GetById{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _context.Students.SingleOrDefaultAsync(s => s.Id == id));
        }
    }
}
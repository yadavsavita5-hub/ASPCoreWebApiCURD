using ASPCoreWebApiCURD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ASPCoreWebApiCURD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly TestDbContext context;

        public StudentAPIController(TestDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var data = await context.Students.ToListAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
       public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await context.Students.FindAsync(id);
            if(student==null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student std)
        {
           await context.Students.AddAsync(std);
            await context.SaveChangesAsync();
            return Ok(std);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student std)
        {
            if(id!=std.Id)
            {
                return BadRequest();
            }
            context.Entry(std).State=EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(std);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchStudent(int id, Student updatedFields)
        {
            var student = await context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            if (!string.IsNullOrEmpty(updatedFields.StudentName))
                student.StudentName = updatedFields.StudentName;

            if (updatedFields.Age != 0)
                student.Age = updatedFields.Age;

            await context.SaveChangesAsync();

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var srd = await context.Students.FindAsync(id);
            if(srd==null)
            {
                return NotFound();

            }
            context.Students.Remove(srd);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}

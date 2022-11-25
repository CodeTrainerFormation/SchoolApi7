using Dal;
using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly SchoolContext context;

        public ClassroomController(SchoolContext context)
        {
            this.context = context;

            //this.context.Database.EnsureDeleted();
            this.context.Database.EnsureCreated();
        }

        // GET : /Classroom
        [HttpGet]
        public IActionResult GetClassrooms()
        {
            return Ok(this.context.Classrooms.ToList());
        }

        // GET /Classroom/5
        [HttpGet("{id}")]
        public IActionResult GetClassroom([FromRoute] int? id)
        {
            if (id == null)
                return BadRequest();

            // Récupération de l’objet
            var classroom = this.context.Classrooms.Find(id);

            if(classroom == null)
                return NotFound();

            return Ok(classroom);
        }

        // POST /Classroom + body
        [HttpPost]
        public IActionResult PostClassroom([FromBody] Classroom classroom)
        {
            if (classroom == null)
                return BadRequest();

            // insertion de notre objet
            this.context.Classrooms.Add(classroom);
            this.context.SaveChanges();

            return Created($"Classroom/{classroom.ClassroomID}", classroom);
        }

        // PUT /Classroom/5 + body
        [HttpPut("{id}")]
        public IActionResult PutClassroom([FromRoute] int id, [FromBody] Classroom classroom)
        {
            if (classroom.ClassroomID != id)
                return BadRequest();

            // modification de l'objet
            this.context.Classrooms.Update(classroom);
            this.context.SaveChanges();

            return NoContent();
        }

        // DELETE /Classroom/5
        [HttpDelete("{id}")]
        public IActionResult DeleteClassroom([FromRoute] int? id)
        {
            if (id == null)
                return BadRequest();

            var classroom = this.context.Classrooms.Single(c => c.ClassroomID == id.Value);

            // suppression de l'objet
            this.context.Classrooms.Remove(classroom);
            this.context.SaveChanges();

            return Ok(classroom);
        }
    }
}

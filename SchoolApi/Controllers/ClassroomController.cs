using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        // GET : /Classroom
        [HttpGet]
        public IActionResult GetClassrooms()
        {
            List<Classroom> classrooms = new List<Classroom>()
            {
                new Classroom()
                {
                    ClassroomID = 1,
                    Name = "Salle Bill Gates",
                    Floor = 2,
                    Corridor = "Rouge"
                },
                new Classroom()
                {
                    ClassroomID = 2,
                    Name = "Salle Scott Hanselman",
                    Floor = 4,
                    Corridor = "Bleu"
                },
                new Classroom()
                {
                    ClassroomID = 3,
                    Name = "Salle Satya Nadella",
                    Floor = 3,
                    Corridor = "Rouge"
                }
            };

            return Ok(classrooms);
        }

        // GET /Classroom/5
        [HttpGet("{id}")]
        public IActionResult GetClassroom([FromRoute] int? id)
        {
            if (id == null)
                return BadRequest();

            // Récupération de l’objet
            Classroom classroom = new Classroom()
            {
                ClassroomID = id.Value,
                Name = "Salle Bill Gates",
                Floor = 2,
                Corridor = "Rouge"
            };

            return Ok(classroom);
        }

        // POST /Classroom + body
        [HttpPost]
        public IActionResult PostClassroom([FromBody] Classroom classroom)
        {
            if (classroom == null)
                return BadRequest();

            // insertion de notre objet
            classroom.ClassroomID = 5;

            return Created($"Classroom/{classroom.ClassroomID}", classroom);
        }

        // PUT /Classroom/5 + body
        [HttpPut("{id}")]
        public IActionResult PutClassroom([FromRoute] int id, [FromBody] Classroom classroom)
        {
            if (classroom.ClassroomID != id)
                return BadRequest();

            // modification de l'objet

            return NoContent();
        }

        // DELETE /Classroom/5
        [HttpDelete("{id}")]
        public IActionResult DeleteClassroom([FromRoute] int? id)
        {
            if (id == null)
                return BadRequest();

            // suppression de l'objet
            Classroom classroom = new Classroom()
            {
                ClassroomID = id.Value,
                Name = "Salle Bill Gates",
                Floor = 2,
                Corridor = "Rouge"
            };

            return Ok(classroom);
        }
    }
}

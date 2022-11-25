using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    [Table(nameof(Classroom))]
    public class Classroom
    {
        public int ClassroomID { get; set; }

        public string Name { get; set; }

        public int Floor { get; set; }

        public string Corridor { get; set; }

        // navigation properties
        public ICollection<Student>? Students { get; set; }

        public Teacher? Teacher { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MietHack_10_2023.Database.Models
{
    public class StudentUnion
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Logo { get; set; }

        public string Goals { get; set; }

        public string Tasks { get; set; }

        public string Description { get; set; }

        public User Manager { get; set; }
        
        public List<Student> Participants { get; set; } = new List<Student>();
    }
}

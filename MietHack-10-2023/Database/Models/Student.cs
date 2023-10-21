using System.ComponentModel.DataAnnotations;

namespace MietHack_10_2023.Database.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Group { get; set; }

        public string LinkToProfile { get; set; }
    }
}

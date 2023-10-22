using System;
using System.ComponentModel.DataAnnotations;

namespace MietHack_10_2023.Database.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTimeOffset Date { get; set; }

        public Student Organizer { get; set; }

        public string LinqToGroup { get; set; }
    }
}

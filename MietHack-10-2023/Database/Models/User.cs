using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MietHack_10_2023.Database.BaseTypes;
using System.ComponentModel.DataAnnotations;

namespace MietHack_10_2023.Database.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Login { get; set; }

        public string PasswordHash { get; set; }

        public Student Student { get; set; }
        
        public Status Status { get; set; }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Login).IsRequired();
            builder.Property(x => x.PasswordHash).IsRequired();
        }
    }
}

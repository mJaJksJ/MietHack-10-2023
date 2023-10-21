using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MietHack_10_2023.Database.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Login).IsRequired();
            builder.Property(x => x.PasswordHash).IsRequired();
        }
    }
}

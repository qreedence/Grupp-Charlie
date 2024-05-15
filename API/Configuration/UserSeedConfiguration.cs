using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API.Data.Models;

namespace API.Configuration
{
    internal class UserSeedConfiguration : IEntityTypeConfiguration<Realtor>
    {   //Comment
        public void Configure(EntityTypeBuilder<Realtor> builder)
        {
            var hasher = new PasswordHasher<Realtor>();
            builder.HasData(
                new Realtor
                {
                    Id = "e2680c44-32bb-432e-9cae-53b8ce24a0dd",
                    Email = "johanna.eriksson@bostadsbubblan.se",
                    NormalizedEmail = "johanna.eriksson@bostadsbubblan.se",
                    UserName= "johanna.eriksson@bostadsbubblan.se",
                    NormalizedUserName = "johanna.eriksson@bostadsbubblan.se",
                    FirstName = "Johanna",
                    LastName = "Eriksson",
                    PasswordHash = hasher.HashPassword(null, "Test1234!"),
                    EmailConfirmed= true,
                    Avatar = "https://example.com/avatar.jpg"
                }
            );
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API.Data.Models;

namespace API.Configuration
{
    internal class UserSeedConfiguration : IEntityTypeConfiguration<Realtor>
    {
        public void Configure(EntityTypeBuilder<Realtor> builder)
        {
            var hasher = new PasswordHasher<Realtor>();
            builder.HasData(
                new Realtor
                {
                    Id = "e2680c44-32bb-432e-9cae-53b8ce24a0dd",
                    Email = "anders.andersson@maklarna.se",
                    NormalizedEmail = "ANDERS.ANDERSSON@MAKLARNA.SE",
                    UserName= "anders.andersson@maklarna.se",
                    NormalizedUserName = "ANDERS.ANDERSSON@MAKLARNA.SE",
                    FirstName = "Anders",
                    LastName = "Andersson",
                    PasswordHash = hasher.HashPassword(null, "Julafton=1"),
                    EmailConfirmed= true,
                    Avatar = "exempel"
                }
            );
        }
    }
}
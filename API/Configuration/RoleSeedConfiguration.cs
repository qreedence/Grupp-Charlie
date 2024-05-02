using API.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace API.Configuration
{
    internal class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "da5b71a0-e6eb-489f-ab37-c1c743a0ec01",
                    Name = UserRoles.Admin,
                    NormalizedName = UserRoles.Admin.ToUpper(),
                },
                new IdentityRole
                {
                    Id = "f33fe94a-66ae-40ef-8386-735585582b3d",
                    Name = UserRoles.User,
                    NormalizedName = UserRoles.User.ToUpper(),
                }
            
            );
        }
    }
}
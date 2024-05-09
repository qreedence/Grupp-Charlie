using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Auth;
using API.Data.Models;
using API.Data.Interfaces;
using System.Globalization;

namespace API.Controllers
{
    //Authors: Susanna Renström, Mikaela Älgekrans, Eden Yusof-Ioannidis
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAgency agencyRepository;
        private readonly UserManager<Realtor> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticateController(IAgency agencyRepository,
            UserManager<Realtor> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            this.agencyRepository = agencyRepository;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        //Author GetUserName: Susanna Renström
        [HttpGet]
        [Route("getusername")]
        public ActionResult<string> GetUserName(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

                var usernameClaim = jsonToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
                if (usernameClaim != null)
                {
                    return Ok(usernameClaim.Value);
                }
                else
                {
                    return BadRequest("Inget användarnamn hittades");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ett fel uppstod: {ex.Message}");
            }
        }
        
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            //var user = await _userManager.FindByNameAsync(model.Username);
            //if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            //{

            var user = await _userManager.FindByNameAsync(model.Username);
            // if user email is not yet confirmed, deny access
            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                
                return Unauthorized();
            }
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
               

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {   //Comment
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Epostadressen finns redan registrerad!" });
            var hasher = new PasswordHasher<Realtor>();
            string firstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.FirstName.ToLower());
            string lastName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.LastName.ToLower());
            Realtor user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = firstName,
                LastName = lastName,
                Avatar = model.Avatar,
                PasswordHash = hasher.HashPassword(null, model.Password),
                Agency = await agencyRepository.GetByIdAsync(model.Agency.AgencyId),
                EmailConfirmed = false,
                PhoneNumber = model.PhoneNumber,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = true,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                UserName = model.Email,
                NormalizedUserName = model.Email.ToUpper()
                

            };
            var result = await _userManager.CreateAsync(user);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Något gick fel! Kontrollera dina användaruppgifter och försök igen." });

            return Ok(new Response { Status = "Success", Message = "Användaren har skapats!" });
        }
        [HttpGet]
        [Route("status")]
        public IActionResult CheckAuthenticationStatus()
        {
            // Check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                // User is authenticated, return 200 OK with a success message
                return Ok(new { Status = "Authenticated", Message = "User is logged in" });
            }
            else
            {
                // User is not authenticated, return 401 Unauthorized with an error message
                return Unauthorized(new { Status = "NotAuthenticated", Message = "User is not logged in" });
            }
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Epostadressen finns redan registrerad!" });
            var hasher = new PasswordHasher<Realtor>();
            Realtor user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Avatar = model.Avatar,
                PasswordHash = hasher.HashPassword(null, model.Password),
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Något gick fel! Kontrollera dina användaruppgifter och försök igen." });

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }
            return Ok(new Response { Status = "Success", Message = "Användaren har skapats!" });
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}

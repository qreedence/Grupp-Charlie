﻿using Microsoft.AspNetCore.Identity;

namespace API.Data.Models
{
    public class Realtor : IdentityUser
    {
        public Agency? Agency { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string Avatar { get; set; }
        
    }
}

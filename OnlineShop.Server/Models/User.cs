using Microsoft.AspNetCore.Identity;
using System;

namespace OnlineShop.Models
{
    public class User : IdentityUser
    {
        public int UserId { get; set; } 

        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public string Role { get; set; } = "Customer";
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}

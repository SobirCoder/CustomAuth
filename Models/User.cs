using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CustomAuth
{
    public class User:IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
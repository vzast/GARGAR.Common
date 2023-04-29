using Microsoft.AspNetCore.Identity;

namespace Data.Models.Public
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
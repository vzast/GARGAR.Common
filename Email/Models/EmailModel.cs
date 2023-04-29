using System.ComponentModel.DataAnnotations;

namespace Email.Models
{
    public struct EmailModel
    {
        [EmailAddress]
        public string Email { get; set; }

        public string Subject { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Body { get; set; }
    }
}
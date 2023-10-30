using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User 
    {
        [EmailAddress(ErrorMessage = "This field must have an email address")]
        public string UserName { get; set; }

        [StringLength(10, ErrorMessage = "your password can't be more then 10")]
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }
    }
}
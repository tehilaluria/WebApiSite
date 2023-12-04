using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {

        public int UserId { get; set; }
        [EmailAddress(ErrorMessage = "This field must have an email address")]
        public string UserName { get; set; }
        [StringLength(10, ErrorMessage = "your password can't be more then 10")]

        public string Password { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities;

public partial class User
{
    [EmailAddress(ErrorMessage = "This field must have an email address")]
    public string UserName { get; set; } = null!;
    [StringLength(10, ErrorMessage = "your password can't be more then 10")]
    public string Password { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }
    
    public int UserId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp_Model__23_2__ONSITE_.Models;

public partial class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Format")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    public string Password { get; set; }

    //[Required(ErrorMessage = "Role is required")]
    //[RegularExpression(@"^(User|Admin|SuperAdmin)$", ErrorMessage = "Role must be either User, Admin, or SuperAdmin")]
    public string? Role { get; set; } 
}

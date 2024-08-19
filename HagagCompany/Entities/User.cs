using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HagagCompany.Entities;

public partial class User 
{
    [Required]
    [Display(Name = "Username")]
    public string UserName { get; set; } = null!;
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HagagCompany.Entities;

public partial class Employee
{
  
    public int? Number { get; set; }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EmpolyeeId { get; set; }
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;
    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = null!;
    [Required]
    [StringLength(50)]
    public string? EmailId { get; set; }
    [Phone]
    public string? PhoneNumber { get; set; }

    public int? JobId { get; set; }

    public DateTime JoiningDate { get; set; }

    public virtual Job Job { get; set; }
}

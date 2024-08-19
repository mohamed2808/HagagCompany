using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HagagCompany.Entities;

public partial class Job
{
    [Required]
    public int JobId { get; set; }

    public string? JobName { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
   

}

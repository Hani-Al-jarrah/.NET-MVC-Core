using System;
using System.Collections.Generic;

namespace Task8WithGroup_3_7_25_.Models;

public partial class Manager
{
    public int ManagerId { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? ProfileImage { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}

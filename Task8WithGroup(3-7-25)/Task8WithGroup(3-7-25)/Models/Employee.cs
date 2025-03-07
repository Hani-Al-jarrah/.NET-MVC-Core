using System;
using System.Collections.Generic;

namespace Task8WithGroup_3_7_25_.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public int ManagerId { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? ProfileImage { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<EmpTask> EmpTasks { get; set; } = new List<EmpTask>();

    public virtual Manager Manager { get; set; } = null!;
}

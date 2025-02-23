using System;
using System.Collections.Generic;

namespace WebApp_Model__23_2__ONSITE_.Models;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string Head { get; set; } = null!;

    public int EmployeesCount { get; set; }
}

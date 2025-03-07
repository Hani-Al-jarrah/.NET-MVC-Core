using System;
using System.Collections.Generic;

namespace Task8WithGroup_3_7_25_.Models;

public partial class EmpTask
{
    public int TaskId { get; set; }

    public int EmployeeId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}

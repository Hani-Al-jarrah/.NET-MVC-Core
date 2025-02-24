using System;
using System.Collections.Generic;

namespace WebApp_Model__23_2__ONSITE_.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string Description { get; set; } = null!;

    public string Details { get; set; } = null!;

    public string Image { get; set; } = null!;
}

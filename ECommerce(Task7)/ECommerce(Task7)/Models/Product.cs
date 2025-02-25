using System;
using System.Collections.Generic;

namespace ECommerce_Task7_.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string Description { get; set; } = null!;

    public string Image { get; set; } = null!;
}

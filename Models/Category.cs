using System;
using System.Collections.Generic;

namespace forum.Server.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string CategoryDescription { get; set; } = null!;

    public DateTime? Created { get; set; }
}

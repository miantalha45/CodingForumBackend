using System;
using System.Collections.Generic;

namespace forum.Server.Models;

public partial class User
{
    public int Sno { get; set; }

    public string UserName { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public DateTime? Dt { get; set; }
}

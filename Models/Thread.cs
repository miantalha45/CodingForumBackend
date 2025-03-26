using System;
using System.Collections.Generic;

namespace forum.Server.Models;

public partial class Threads
{
    public int ThreadId { get; set; }

    public string ThreadTitle { get; set; } = null!;

    public string ThreadDesc { get; set; } = null!;

    public int ThreadCatId { get; set; } 

    public int ThreadUserId { get; set; }

    public DateTime? Timestamp { get; set; }

    public string ThreadUserName { get; set; } = null!;
}

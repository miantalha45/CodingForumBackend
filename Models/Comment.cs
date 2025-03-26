using System;
using System.Collections.Generic;

namespace forum.Server.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public string CommentContent { get; set; } = null!;

    public int ThreadId { get; set; }

    public string CommentBy { get; set; }

    public DateTime? CommntTime { get; set; }
}

using System;
using System.Collections.Generic;

namespace MODEL;

public partial class TbPlayer
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public int Level { get; set; }

    public int Experience { get; set; }

    public int Rank { get; set; }

    public int Mmr { get; set; }

    public int Kills { get; set; }

    public int Deaths { get; set; }

    public int Assists { get; set; }

    public int Wins { get; set; }

    public int Losses { get; set; }
}

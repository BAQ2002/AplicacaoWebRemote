using System;
using System.Collections.Generic;

namespace MODEL;

public partial class TbPlayer
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public int Level { get; set; } =0;

    public int Experience { get; set; } = 0;

    public int Rank { get; set; } = 0;

    public int Mmr { get; set; } = 0;

    public int Kills { get; set; } =0;

    public int Deaths { get; set; } = 0;

    public int Assists { get; set; } = 0;

    public int Wins { get; set; } = 0;

    public int Losses { get; set; } = 0;
}

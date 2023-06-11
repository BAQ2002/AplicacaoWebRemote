using System;
using System.Collections.Generic;

namespace MODEL;

public partial class TbPlayerInMatch
{
    public int Id { get; set; }

    public int IdPlayer { get; set; }

    public int IdTeam { get; set; }

    public int Kills { get; set; }

    public int Deaths { get; set; }

    public int Assists { get; set; }

    public int Points { get; set; }
}

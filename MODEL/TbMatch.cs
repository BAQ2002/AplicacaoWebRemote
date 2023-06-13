using System;
using System.Collections.Generic;

namespace MODEL;

public partial class TbMatch
{
    public int Id { get; set; }

    public int TeamRed => Id * 10 + 1;

    public int TeamBlue => Id * 10 + 2;

    public int WinsRed { get; set; }

    public int WinsBlue { get; set; }

    public DateTime Date { get; set; }
}

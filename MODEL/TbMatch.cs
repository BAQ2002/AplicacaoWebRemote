using System;
using System.Collections.Generic;

namespace MODEL;

public partial class TbMatch
{
    public int Id { get; set; }

    public int TeamRed { get; set; }

    public int TeamBlue { get; set; }

    public int WinsRed { get; set; }

    public int WinsBlue { get; set; }

    public DateTime Date { get; set; }
}

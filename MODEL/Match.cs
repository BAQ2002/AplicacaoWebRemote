using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class Match
    {
        public int Id { get; set; }

        public List<TbPlayerInMatch> TeamRed { get; set; } = new List<TbPlayerInMatch>();
        public List<TbPlayerInMatch> TeamBlue { get; set; } = new List<TbPlayerInMatch>();

        public int WinsRed { get; set; }

        public int WinsBlue { get; set; }

        public DateTime Date { get; set; }
   
}
}

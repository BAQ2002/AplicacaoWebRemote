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

        public List<TbPlayerInMatch>? TeamRed { get; set; }
        public List<TbPlayerInMatch>? TeamBlue { get; set; }

        public int WinsRed { get; set; }

        public int WinsBlue { get; set; }

        public DateTime Date { get; set; }
   
}
}

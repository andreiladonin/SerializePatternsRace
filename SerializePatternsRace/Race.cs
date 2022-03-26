using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializePatternsRace
{
    public class Race
    {
        public int Id { get; set; }
        public Player Player { get; set; }
        public double Points { get; set; }
        public string TypeRace { get; set; }
    }
}

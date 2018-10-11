using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stomatoloska.BLL
{
    public class Narudzba
    {
        public int TerminId { get; set; }
        public DateTime Termin { get; set; }
        public DateTime DCR { get; set; }
        public TerminStatus TerminStatus { get; set; }
        public Zahtjev Zahtjev { get; set; }
        public Pacijent Pacijent { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stomatoloska.BLL
{
    public class Narudzba
    {
        public int NarudzbaId { get; set; }
        public DateTime Termin { get; set; }
        public DateTime DCR { get; set; }
        public TerminStatus TerminStatus { get; set; }
        public ZahvatBLL Zahtjev { get; set; }
        public PacijentBLL Pacijent { get; set; }

    }
}

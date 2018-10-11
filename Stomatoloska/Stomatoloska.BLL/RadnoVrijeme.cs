using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stomatoloska.BLL
{
    public class RadnoVrijeme
    {
        public int RadnoVrijemeId { get; set; }
        public string RadniDan { get; set; } // P;U;S;Č;P
        public DateTime OdDana { get; set; }
        public TimeSpan Pocetak { get; set; }
        public TimeSpan Kraj { get; set; }
    }
}

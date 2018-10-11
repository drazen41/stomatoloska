using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Stomatoloska.BLL
{
    public class Pacijent
    {
        public int PacijentId { get; set; }
        public string Prezime { get; set; }
        public string Ime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; } // MOže null
    }
}
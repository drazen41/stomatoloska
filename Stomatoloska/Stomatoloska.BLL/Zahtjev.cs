using System;

namespace Stomatoloska.BLL
{
    public class Zahtjev
    {
        public int ZahtjevId { get; set; }
        public string NazivZahtjeva { get; set; }
        public decimal Cijena { get; set; }
        public int TrajanjeMinuta { get; set; }
        public DateTime DCR { get; set; }
    }
}
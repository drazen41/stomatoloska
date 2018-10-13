using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stomatoloska.DAL.Baza;
using Stomatoloska.DAL;

namespace Stomatoloska.BLL
{
    public class RadnoVrijemeBLL
    {
        private List<string> radniDani;
        private StomatoloskaUoW uow;
        public RadnoVrijemeBLL()
        {
            radniDani = new List<string> { "ponedjeljak", "utorak", "srijeda", "četvrtak", "petak" };
            uow = new StomatoloskaUoW();
        }
        public List<string> PribaviRadneDane()
        {
            return radniDani;
        }

        public void UnesiRadnaVremena(List<RadnoVrijeme> vremena)
        {
            foreach (var vrijeme in vremena)
            {
                uow.RadnoVrijemeRepo.Insert(vrijeme);
                
            }
            uow.Spremi();
        }
        public List<RadnoVrijeme> PribaviVremenaOdDatuma(DateTime datum)
        {
            return uow.RadnoVrijemeRepo.PribaviRadnaVremenaOdDatuma(datum);
        }
    }
}

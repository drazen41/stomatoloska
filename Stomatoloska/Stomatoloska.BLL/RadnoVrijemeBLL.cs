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
            var vremenaBaza = uow.RadnoVrijemeRepo.Get();
            

            foreach (var vrijeme in vremena)
            {
                var dan = vremenaBaza.Where(x => x.radni_dan == vrijeme.radni_dan).FirstOrDefault();
                if (dan != null)
                {
                    dan.pocetak = vrijeme.pocetak;
                    dan.kraj = vrijeme.kraj;
                    dan.dcr = vrijeme.dcr;
                    uow.RadnoVrijemeRepo.Update(dan);
                }
                else 
                {
                    uow.RadnoVrijemeRepo.Insert(vrijeme);
                }
                

            }
            uow.Spremi();
        }
        public List<RadnoVrijeme> PribaviRadnaVremena()
        {
           return uow.RadnoVrijemeRepo.Get().ToList();
        }
    }
}

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
        public string RadniDanZaDatum(DateTime datum)
        {
            var dan = datum.DayOfWeek;
            string danBaza = "";
            switch (dan)
            {
                case DayOfWeek.Sunday:
                    danBaza = "nedjelja";
                    break;
                case DayOfWeek.Monday:
                    danBaza = "ponedjeljak";
                    break;
                case DayOfWeek.Tuesday:
                    danBaza = "utorak";
                    break;
                case DayOfWeek.Wednesday:
                    danBaza = "srijeda";
                    break;
                case DayOfWeek.Thursday:
                    danBaza = "četvrtak";
                    break;
                case DayOfWeek.Friday:
                    danBaza = "petak";
                    break;
                case DayOfWeek.Saturday:
                    danBaza = "subota";
                    break;
                default:
                    break;
            }
            return danBaza;
        }
        public RadnoVrijeme PribaviRadnoVrijemeZaDatum(DateTime datum)
        {
            var radniDan = RadniDanZaDatum(datum);

            return uow.RadnoVrijemeRepo.Get(x => x.radni_dan == radniDan).FirstOrDefault();
        }
        public bool ProvjeriRadnoVrijeme(DateTime datum)
        {
            var radnoVrijeme = PribaviRadnoVrijemeZaDatum(datum);
            return  (datum.TimeOfDay >= radnoVrijeme.pocetak && datum.TimeOfDay <= radnoVrijeme.kraj); 
            
        }
    }
}

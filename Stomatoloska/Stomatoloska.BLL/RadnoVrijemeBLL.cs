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
            var vremenaBaza = uow.RadnoVrijemeRepo.Get(null, q => q.OrderByDescending(x => x.od_datuma), null);

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
        public void UnesiRadnoVrijeme(RadnoVrijeme radnoVrijeme )
        {
            var rv = uow.RadnoVrijemeRepo.Get(x => x.radni_dan == radnoVrijeme.radni_dan, q => q.OrderByDescending(x => x.od_datuma)).FirstOrDefault();
            if (rv == null || rv.od_datuma < radnoVrijeme.od_datuma)
            {
                uow.RadnoVrijemeRepo.Insert(radnoVrijeme);
                uow.Spremi();
            }
            else
            {
                //throw new Exception("Nije moguće unesti radno vrijeme.");
            }
        }
        public RadnoVrijeme PribaviRadnoVrijeme(int id)
        {
            return uow.RadnoVrijemeRepo.GetByID(id);
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
        public List<RadnoVrijeme> PribaviAktivnoRadnoVrijeme()
        {
            return uow.RadnoVrijemeRepo.PribaviRadnaVremenaManjaJednakaOdDatuma(DateTime.Now).ToList();
        }
        public void AzurirajRadnoVrijeme(RadnoVrijeme radnoVrijeme )
        {
            var rv = uow.RadnoVrijemeRepo.GetByID(radnoVrijeme.radno_vrijeme_id);
            if (rv != null)
            {
                NarudzbaBLL narudzbaBLL = new NarudzbaBLL();
                var narudzbe = narudzbaBLL.PribaviNarudzbe(rv);
                foreach (var narudzba in narudzbe )
                {
                    if (narudzba.termin_pocetak.TimeOfDay < radnoVrijeme.pocetak || narudzba.termin_kraj.TimeOfDay > radnoVrijeme.kraj )
                    {
                        throw new Exception("Za radno vrijeme ima narudžbi.");
                    }
                }
                rv.dcr = radnoVrijeme.dcr;
                rv.kraj = radnoVrijeme.kraj;
                rv.pocetak = radnoVrijeme.pocetak;
                rv.od_datuma = radnoVrijeme.od_datuma;
                uow.RadnoVrijemeRepo.Update(rv);
                uow.Spremi();
            }
        }
    }
}

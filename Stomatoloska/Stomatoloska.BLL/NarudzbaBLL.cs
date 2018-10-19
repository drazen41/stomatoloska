using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stomatoloska.DAL.Baza;
using Stomatoloska.DAL;

namespace Stomatoloska.BLL
{
    public class NarudzbaBLL
    {
        public class CalendarEvent
        {
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
            public string Name { get; set; }
            public int Id { get; set; }
            public string Status { get; set; }
        }
        public enum Status
        {
            Kreirana,Izvrsena,Otkazana,Greska,NijeDosao
        }
        private StomatoloskaUoW uow = null;
        public NarudzbaBLL()
        {
            uow = new StomatoloskaUoW();
        }
        public List<Narudzba> PribaviNarudzbe()
        {
            return uow.NarudzbaRepo.Get().ToList<Narudzba>();
        }
        public List<Narudzba> PribaviNarudzbe(DateTime start,DateTime end)
        {
            return uow.NarudzbaRepo
                .Get(x => x.termin_pocetak >= start && x.termin_kraj  <= end, q => q.OrderBy(x => x.termin_pocetak), "Pacijent,Zahvat")
                .ToList<Narudzba>();
        }
        public List<Narudzba >PribaviNarudzbe(DateTime datum)
        {
            var start = datum.Date;
            var end = datum.AddDays(1).AddTicks(-1);
            return PribaviNarudzbe(start, end);
        }
        public List<CalendarEvent> PribaviPodatkeZaKalendar(DateTime start, DateTime end, bool sve = false)
        {
            List<CalendarEvent> eventi = new List<CalendarEvent>();
            //var narudzbe = PribaviNarudzbe(start, end).Where(x => x.status == Status.Kreirana.ToString() || x.status==Status.Izvrsena.ToString());
            IEnumerable<Narudzba> narudzbe = null;
            if (!sve)
            {
                narudzbe = PribaviNarudzbe(start,end).Where(x => x.status == Status.Kreirana.ToString() || x.status == Status.Izvrsena.ToString());
            }
            else
            {
                narudzbe = PribaviNarudzbe(start,end).Where(x => x.status != Status.Greska.ToString());
            }
            foreach (var narudzba in narudzbe )
            {
                CalendarEvent ce = new CalendarEvent();
                Zahvat zahvat = narudzba.Zahvat;
                Pacijent pacijent = narudzba.Pacijent;
                ce.Start = narudzba.termin_pocetak;
                ce.End = narudzba.termin_kraj;
                ce.Id = narudzba.narudzba_id;
                ce.Name = pacijent.prezime + " " + pacijent.ime + "-" + zahvat.sifra;
                ce.Status = narudzba.status;
                eventi.Add(ce);
            }
            return eventi;
        }
        public List<CalendarEvent> PribaviPodatkeZaKalendar(DateTime datum, bool sve = false)
        {
            List<CalendarEvent> eventi = new List<CalendarEvent>();
            IEnumerable<Narudzba> narudzbe = null;
            if (!sve)
            {
                narudzbe = PribaviNarudzbe(datum).Where(x => x.status == Status.Kreirana.ToString() || x.status == Status.Izvrsena.ToString());
            }
            else
            {
                narudzbe = PribaviNarudzbe(datum).Where(x => x.status != Status.Greska.ToString());
            }
            foreach (var narudzba in narudzbe)
            {
                CalendarEvent ce = new CalendarEvent();
                Zahvat zahvat = narudzba.Zahvat;
                Pacijent pacijent = narudzba.Pacijent;
                ce.Start = narudzba.termin_pocetak;
                ce.End = narudzba.termin_kraj;
                ce.Id = narudzba.narudzba_id;
                ce.Name = pacijent.prezime + " " + pacijent.ime + "-" + zahvat.naziv;
                ce.Status = narudzba.status;
                eventi.Add(ce);
            }
            return eventi;
        }
        
        public bool ProvjeriTerminPrijeUnosa(Narudzba narudzba )
        {
            bool ok = true;            
            //var zahvat = uow.ZahvatRepo.GetByID(/*sifraZahvata*/);
            var radnoVrijemeBll = new RadnoVrijemeBLL();
            var dan = radnoVrijemeBll.RadniDanZaDatum(narudzba.termin_pocetak);
            var radnoVrijeme = uow.RadnoVrijemeRepo.Get(x => x.radni_dan == dan).FirstOrDefault();

            if (narudzba.termin_pocetak.TimeOfDay < radnoVrijeme.pocetak || narudzba.termin_kraj.TimeOfDay > radnoVrijeme.kraj)
                return false;
            var slijedecaNarudzba = uow.NarudzbaRepo.Get(x => x.termin_pocetak >= narudzba.termin_pocetak && x.status == Status.Kreirana.ToString(),q=>q.OrderBy(x=>x.termin_pocetak))
                .FirstOrDefault();
            if (slijedecaNarudzba != null && slijedecaNarudzba.termin_pocetak  < narudzba.termin_kraj)
                return false;
            
            


            return ok;
        }
        public void UnesiNarudzbu(Narudzba narudzba)
        {
            if (!ProvjeriTerminPrijeUnosa(narudzba))
                throw new Exception("Nema vremena za narudžbu.");
            uow.NarudzbaRepo.Insert(narudzba);
            uow.Spremi();
        }
        public Narudzba PribaviNarudzbu(int narudzbaId)
        {
            return uow.NarudzbaRepo.GetByID(narudzbaId);
        }
        public void AzurirajStatusNarudzbe(Narudzba narudzba )
        {
            Narudzba narudzbaBaza = PribaviNarudzbu(narudzba.narudzba_id);
            if (narudzbaBaza == null || narudzba.status == NarudzbaBLL.Status.Kreirana.ToString())
            {
                return;

            }
            narudzbaBaza.status = narudzba.status;
            uow.NarudzbaRepo.Update(narudzbaBaza);
            uow.Spremi();
        }
        public  IEnumerable<Narudzba> PribaviNarudzbeZaStatus(Status status)
        {
            IEnumerable<Narudzba> lista = null;
            switch (status)
            {
                case Status.Kreirana:

                    break;
                case Status.Izvrsena:
                    lista = uow.NarudzbaRepo.Get(x => x.status == "Izvrsena", q => q.OrderBy(x => x.zahvat_id), "Zahvat");
                    break;
                case Status.Otkazana:
                    break;
                case Status.Greska:
                    break;
                case Status.NijeDosao:
                    break;
                default:
                    break;
            }
            return lista;
        }
    }
}

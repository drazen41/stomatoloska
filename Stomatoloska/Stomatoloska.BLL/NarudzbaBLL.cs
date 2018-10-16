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
        }
        public enum Status
        {
            Kreirana,Izvrsena,Otkazana
        }
        private StomatoloskaUoW uow = null;
        public NarudzbaBLL()
        {
            uow = new StomatoloskaUoW();
        }
        public List<Narudzba> PribaviNarudzbe(DateTime start,DateTime end)
        {
            return uow.NarudzbaRepo
                .Get(x => x.termin >= start && x.termin <= end, q => q.OrderBy(x => x.termin), "Pacijent,Zahvat")
                .ToList<Narudzba>();
        }
        public List<Narudzba >PribaviNarudzbe(DateTime datum)
        {
            var start = datum.Date;
            var end = datum.AddDays(1).AddTicks(-1);
            return PribaviNarudzbe(start, end);
        }
        public List<CalendarEvent> PribaviPodatkeZaKalendar(DateTime start, DateTime end)
        {
            List<CalendarEvent> eventi = new List<CalendarEvent>();
            var narudzbe = PribaviNarudzbe(start, end);
            foreach (var narudzba in narudzbe )
            {
                CalendarEvent ce = new CalendarEvent();
                Zahvat zahvat = narudzba.Zahvat;
                Pacijent pacijent = narudzba.Pacijent;
                ce.Start = narudzba.termin;
                ce.End = narudzba.termin.AddMinutes(zahvat.trajanje_minuta);
                ce.Id = narudzba.narudzba_id;
                ce.Name = pacijent.prezime + " " + pacijent.ime + "-" + zahvat.sifra;
                eventi.Add(ce);
            }
            return eventi;
        }
        public List<CalendarEvent> PribaviPodatkeZaKalendar(DateTime datum)
        {
            List<CalendarEvent> eventi = new List<CalendarEvent>();
            var narudzbe = PribaviNarudzbe(datum);
            foreach (var narudzba in narudzbe)
            {
                CalendarEvent ce = new CalendarEvent();
                Zahvat zahvat = narudzba.Zahvat;
                Pacijent pacijent = narudzba.Pacijent;
                ce.Start = narudzba.termin;
                ce.End = narudzba.termin.AddMinutes(zahvat.trajanje_minuta);
                ce.Id = narudzba.narudzba_id;
                ce.Name = pacijent.prezime + " " + pacijent.ime + "-" + zahvat.sifra;
                eventi.Add(ce);
            }
            return eventi;
        }
        public bool ProvjeriTerminPrijeUnosa(DateTime termin, int sifraZahvata)
        {
            bool ok = true;
            var narudzba = uow.NarudzbaRepo.Get(x => x.termin > termin).OrderBy(x=>x.termin).FirstOrDefault();
            if (narudzba != null)
            {

            }

            return ok;
        }
        public void UnesiNarudzbu(Narudzba narudzba)
        {
            uow.NarudzbaRepo.Insert(narudzba);
            uow.Spremi();
        }
    }
}

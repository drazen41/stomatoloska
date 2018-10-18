using Stomatoloska.DAL;
using Stomatoloska.DAL.Baza;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stomatoloska.BLL
{
    public class ZahvatBLL
    {
        private StomatoloskaUoW uow = null;
        public ZahvatBLL()
        {
            uow = new StomatoloskaUoW();
        }
        public List<Zahvat> PribaviZahvate()
        {
            return uow.ZahvatRepo.Get(null,q=>q.OrderByDescending(x=>x.dcr)).ToList();
        }
        public List<Zahvat> PribaviZahvate(int page, int broj)
        {
            return PribaviZahvate().Skip(page * broj).Take(broj).ToList<Zahvat>();
        }
        public void UnesiZahvat(Zahvat zahvat)
        {
            var uBazi = uow.ZahvatRepo.Get(x => x.naziv == zahvat.naziv).FirstOrDefault();
            if (uBazi != null)
            {
                throw new Exception("Zahvat " + zahvat.naziv + " ima u bazi.");
            }
            uow.ZahvatRepo.Insert(zahvat);
            uow.Spremi();
        }
        
        public void AzurirajZahvat(Zahvat zahvat )
        {
            uow.ZahvatRepo.Update(zahvat);
            uow.Spremi();
        }
        public void AzurirajZahvat(Zahvat zahvat, string staraSifra)
        {
            var zahvatBaza = uow.ZahvatRepo.Get(x => x.sifra == staraSifra).FirstOrDefault();
            zahvatBaza.sifra = zahvat.sifra;
            zahvatBaza.naziv = zahvat.naziv;
            zahvatBaza.dcr = DateTime.Now;
            zahvatBaza.cijena = zahvat.cijena;
            zahvatBaza.trajanje_minuta = zahvat.trajanje_minuta;
            uow.ZahvatRepo.Update(zahvatBaza);
            uow.Spremi();
        }
        public Zahvat PribaviZahvatZaSifru(string sifra)
        {
            return uow.ZahvatRepo.Get(x => x.sifra == sifra).FirstOrDefault();
        }
        public void ObrisiZahvat(string sifra )
        {
            uow.ZahvatRepo.Delete(sifra);
            uow.Spremi();
        }
        public Zahvat PribaviZahvat(int id)
        {
            return uow.ZahvatRepo.GetByID(id);
        }
    }
}
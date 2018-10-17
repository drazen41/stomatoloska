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
            return uow.ZahvatRepo.Get().ToList();
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
        public Zahvat PribaviZahvatZaSifru(string sifra)
        {
            return uow.ZahvatRepo.GetByID(sifra);
        }
        public void ObrisiZahvat(string sifra )
        {
            uow.ZahvatRepo.Delete(sifra);
            uow.Spremi();
        }
    }
}
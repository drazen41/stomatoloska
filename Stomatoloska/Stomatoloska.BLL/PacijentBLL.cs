using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stomatoloska.DAL;
using Stomatoloska.DAL.Baza;
namespace Stomatoloska.BLL
{
    public class PacijentBLL
    {
        private StomatoloskaUoW uow = null;
        public PacijentBLL()
        {
            uow = new StomatoloskaUoW();
        }
        public List<Pacijent> PribaviPacijente()
        {
            return uow.PacijentRepo.Get().ToList<Pacijent>();
        }
        public List<Pacijent> PribaviPacijente(int skip, int take)
        {
            return uow.PacijentRepo.Get().Skip(skip * take).Take(take).ToList<Pacijent>();
        }
        public void UnesiPacijenta(Pacijent pacijent)
        {
            
            var pacijentBaza = PribaviPacijentZaPrezimeImeDatumRodjenja(pacijent);
            if (pacijentBaza == null)
            {
                uow.PacijentRepo.Insert(pacijent);
                uow.Spremi();
            }
            else
            {
                throw new Exception("Pacijent je u bazi.");
            }
        }
        public Pacijent PribaviPacijentaZaId(int id)
        {
            return uow.PacijentRepo.GetByID(id);
        }
        public void AzurirajPacijenta(Pacijent pacijent)
        {
            Pacijent pacijentBaza = uow.PacijentRepo.GetByID(pacijent.pacijent_id);
            pacijentBaza.datum_rodjenja = pacijent.datum_rodjenja;
            pacijentBaza.adresa = pacijent.adresa;
            pacijentBaza.prezime = pacijent.prezime;
            pacijentBaza.ime = pacijent.ime;
            pacijentBaza.telefon = pacijent.telefon;
            uow.PacijentRepo.Update(pacijentBaza);
            uow.Spremi();

        }
        public Pacijent PribaviPacijentZaPrezimeImeDatumRodjenja(Pacijent pacijent)
        {
            return uow.PacijentRepo.Get(x => x.prezime == pacijent.prezime && x.ime == pacijent.ime && x.adresa == pacijent.adresa).FirstOrDefault();
        }
        public void ObrisiPacijent(int pacijentId)
        {
            uow.PacijentRepo.Delete(pacijentId);
            uow.Spremi();
        }
        public static List<Pacijent> GetPacijenti(int maximumRows,int startRowIndex, string sortVal)
        {
            List<Pacijent> pacijenti = new List<Pacijent>();
            StomatoloskaUoW uows = new StomatoloskaUoW();
            pacijenti = uows.PacijentRepo.PribaviPodskupPacijenata(maximumRows, startRowIndex);
            //var sortirani = uows.PacijentRepo.SortirajPacijente(pacijenti,sortVal)

            return pacijenti;

        }
    }
}
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
        public void UnesiPacijenta(Pacijent pacijent)
        {
            uow.PacijentRepo.Insert(pacijent);
            uow.Spremi();
        }
    }
}
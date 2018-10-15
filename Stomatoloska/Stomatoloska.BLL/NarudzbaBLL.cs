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
        private StomatoloskaUoW uow = null;
        public NarudzbaBLL()
        {
            uow = new StomatoloskaUoW();
        }
        
    }
}

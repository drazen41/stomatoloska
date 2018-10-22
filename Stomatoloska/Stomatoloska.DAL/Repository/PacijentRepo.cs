using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stomatoloska.DAL.Baza;
using System.Reflection;

namespace Stomatoloska.DAL.Repository
{
    public class PacijentRepo : StomatoloskaRepo<Pacijent>
    {
        public PacijentRepo(stomatoloskaEntities db)
            : base(db)
        {          
        }
        public IQueryable<Pacijent> PribaviSvePacijente()
        {
            return dbSet.Select(x=>x);
        }
        public List<Pacijent> PribaviPodskupPacijenata(int skip, int take)
        {
            return PribaviSvePacijente().Skip(skip * take).Take(take).ToList();
        }
        public List<Pacijent> SortirajPacijente(List<Pacijent> pacijenti, string sortVal, bool descending )
        {
            IOrderedEnumerable<Pacijent> sortirani = null;
            Type tip = this.GetType();
            foreach (PropertyInfo info in tip.GetProperties())
            {
                if (info.Name == sortVal)
                {
                    if (descending)
                    {
                        sortirani = pacijenti.OrderByDescending(x => info.Name);
                    }
                    else
                    {
                        sortirani = pacijenti.OrderBy(x => info.Name);
                    }
                    
                }
            }

            return sortirani.ToList();
        }
         


    }
}

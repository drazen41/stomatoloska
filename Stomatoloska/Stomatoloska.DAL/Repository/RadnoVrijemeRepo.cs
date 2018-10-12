using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stomatoloska.DAL.Baza;

namespace Stomatoloska.DAL.Repository
{
    public class RadnoVrijemeRepo : StomatoloskaRepo<RadnoVrijeme>
    {
        public RadnoVrijemeRepo(stomatoloskaEntities db)
            : base(db)
        {          
        }
        public List<RadnoVrijeme> PribaviAktivnaRadnaVremena(DateTime datum)
        {
            var sql = "select * FROM tRadnoVrijeme where radno_vrijeme_id IN ( select MAX(radno_vrijeme_id) rv_id  FROM tRadnoVrijeme where od_dana <= @datum group by radni_dan )";
            return base.GetWithRawSql(sql, datum).ToList();
            
        }
        

         


    }
}

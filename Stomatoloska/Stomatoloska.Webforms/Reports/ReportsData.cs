using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stomatoloska.BLL;
using Stomatoloska.DAL.Baza;

namespace Stomatoloska.Webforms.Reports
{
    public class ReportsData
    {
        
        private NarudzbaBLL narudzbaBLL = new NarudzbaBLL();
        public List<Narudzba> PribaviIzvrseneNarudzbe()
        {
            return narudzbaBLL.PribaviNarudzbeZaStatus(NarudzbaBLL.Status.Izvrsena);
        }


    }
}
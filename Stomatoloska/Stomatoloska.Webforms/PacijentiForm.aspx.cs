using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stomatoloska.BLL;
using Stomatoloska.DAL.Baza;

namespace Stomatoloska.Webforms
{
    public partial class PacijentiForm : System.Web.UI.Page
    {
        PacijentBLL pacijentBll = new PacijentBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            PopuniGridPacijenti();
        }
        private void PopuniGridPacijenti()
        {
            var pacijenti = pacijentBll.PribaviPacijente();
            gvPacijenti.DataSource = pacijenti;
            gvPacijenti.DataBind();
        }

        protected void btnUnosPacijenta_Click(object sender, EventArgs e)
        {
            Pacijent pacijent = new Pacijent();
            pacijent.adresa = txtAdresa.Text;
            pacijent.datum_rodjenja = DateTime.ParseExact(txtDatumRodjenja.Text,"dd.MM.yyyy",null);
            pacijent.ime = txtIme.Text;
            pacijent.prezime = txtPrezime.Text;
            pacijent.telefon = txtTelefon.Text;
            pacijentBll.UnesiPacijenta(pacijent);
            PopuniGridPacijenti();
        }
    }
}
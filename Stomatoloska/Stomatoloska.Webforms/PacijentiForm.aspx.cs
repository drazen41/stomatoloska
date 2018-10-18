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
        Pacijent pacijent = new Pacijent();
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
            if (!string.IsNullOrEmpty(txtAdresa.Text ))
                pacijent.adresa = txtAdresa.Text;
            pacijent.datum_rodjenja = DateTime.Parse(txtDatumRodjenja.Text);
            pacijent.ime = txtIme.Text;
            pacijent.prezime = txtPrezime.Text;
            pacijent.telefon = txtTelefon.Text;
            try
            {
                if (gvPacijenti.SelectedIndex > -1)
                {
                    pacijent.pacijent_id = (int)ViewState["pacijent_id"];
                    pacijentBll.AzurirajPacijenta(pacijent);
                }
                else
                {

                    pacijentBll.UnesiPacijenta(pacijent);
                }
                
            }
            catch (Exception ex)
            {
                string greska = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Podaci nisu spremljeni.')", true);

            }

            gvPacijenti.SelectedIndex = -1;
            btnUnosPacijenta.Text = "Unos pacijenta";
            PopuniGridPacijenti();
            btnOdustani.Visible = false;
        }

        protected void gvPacijenti_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOdustani.Visible = true;
            var pacijentId = (int)gvPacijenti.SelectedDataKey.Value;
            Pacijent pacijent = pacijentBll.PribaviPacijentaZaId(pacijentId);
            txtPrezime.Text = pacijent.prezime;
            txtIme.Text = pacijent.ime;
            txtTelefon.Text = pacijent.telefon;
            txtDatumRodjenja.Text = pacijent.datum_rodjenja.Date.ToShortDateString();
            txtDatumRodjenja_CalendarExtender.SelectedDate = pacijent.datum_rodjenja;
            txtAdresa.Text = pacijent.adresa;
            btnUnosPacijenta.Text = "Ažuriraj pacijenta";
            ViewState["pacijent_id"] = pacijentId;
        }

        protected void btnOdustani_Click(object sender, EventArgs e)
        {
            gvPacijenti.SelectedIndex = -1;
            btnOdustani.Visible = false;
            btnUnosPacijenta.Text = "Unos pacijenta";
        }

        protected void gvPacijenti_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName == "Obrisi")
            {
                var pacijentId = int.Parse(e.CommandArgument.ToString());
                pacijentBll.ObrisiPacijent(pacijentId);
                PopuniGridPacijenti();
            }
        }

        
    }
}
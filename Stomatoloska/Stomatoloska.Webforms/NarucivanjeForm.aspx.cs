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
    public partial class NarucivanjeForm : System.Web.UI.Page
    {
        ZahvatBLL zahvatBLL = new ZahvatBLL();
        PacijentBLL pacijentBLL = new PacijentBLL();
        RadnoVrijemeBLL radnoVrijemeBLL = new RadnoVrijemeBLL();
        NarudzbaBLL narudzbaBLL = new NarudzbaBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack )
            {
                var zahvati = zahvatBLL.PribaviZahvate().OrderBy(x=>x.naziv);
                ddlZahvati.Items.Add(new ListItem { Text = "-- Odaberite --", Value = "-1", Selected = true });
                foreach (var zahvat in zahvati )
                {
                    ddlZahvati.Items.Add(new ListItem { Text = zahvat.naziv, Value = zahvat.sifra });
                }
                var pacijenti = pacijentBLL.PribaviPacijente().OrderBy(x=>x.prezime);
                foreach (var pacijent in pacijenti)
                {
                    lbPacijenti.Items.Add(new ListItem
                    {
                        Text = pacijent.prezime + " " + pacijent.ime + " (" + pacijent.datum_rodjenja.ToShortDateString() + ")",
                        Value = pacijent.pacijent_id.ToString()
                    });
                }
            }
        }

        

        private void PrikaziRezerviraneTermine(List<Narudzba> narudzbe)
        {
            var radnaVremena = radnoVrijemeBLL.PribaviRadnaVremena();
            
            
        }

        protected void ddlZahvati_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlZahvati.SelectedIndex != -1)
            {
                var zahvat = zahvatBLL.PribaviZahvatZaSifru(ddlZahvati.SelectedValue);
                lblCijenaZahvata.Text = string.Format("{0:C}", zahvat.cijena);
                lblTrajanjeZahvata.Text = zahvat.trajanje_minuta.ToString() + " minuta";
            }
        }

        protected void DayPilotCalendar_EventClick(object sender, DayPilot.Web.Ui.Events.EventClickEventArgs e)
        {
            var start = e.Start;
        }
    }
}
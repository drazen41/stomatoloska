using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stomatoloska.BLL;
using Stomatoloska.DAL.Baza;
using System.Threading;

namespace Stomatoloska.Webforms
{
    public partial class frmNarucivanje : System.Web.UI.Page
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
                    ddlZahvati.Items.Add(new ListItem { Text = zahvat.naziv, Value = zahvat.zahvat_id.ToString() });
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
                calNarucivanje.SelectedDate = DateTime.Today;
                DayPilotCalendar.DataSource = narudzbaBLL.PribaviPodatkeZaKalendar(calNarucivanje.SelectedDate);
                DayPilotCalendar.DataBind();
                
            }
        }

        protected void calNarucivanje_SelectionChanged(object sender, EventArgs e)
        {
            List<Narudzba> narudzbe = null;
            PribaviPodatkeZaKalendar();
            PrikaziRezerviraneTermine(narudzbe);
        }
        private void PribaviPodatkeZaKalendar()
        {
            if (calNarucivanje.SelectedDates.Count > 1)
            {

                var start = calNarucivanje.SelectedDates[0].Date;
                var end = calNarucivanje.SelectedDates[4].Date.AddHours(23).AddMinutes(59);
                DayPilotCalendar.ViewType = DayPilot.Web.Ui.Enums.Calendar.ViewTypeEnum.WorkWeek;
                DayPilotCalendar.StartDate = start;
                DayPilotCalendar.DataSource = narudzbaBLL.PribaviPodatkeZaKalendar(start, end);
                DayPilotCalendar.DataBind();
            }
            else
            {
                DayPilotCalendar.ViewType = DayPilot.Web.Ui.Enums.Calendar.ViewTypeEnum.Day;
                DayPilotCalendar.StartDate = calNarucivanje.SelectedDate;
                DayPilotCalendar.DataSource = narudzbaBLL.PribaviPodatkeZaKalendar(calNarucivanje.SelectedDate);
                DayPilotCalendar.DataBind();
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
                var zahvat = zahvatBLL.PribaviZahvat(Int32.Parse(ddlZahvati.SelectedValue));
                lblCijenaZahvata.Text = string.Format("{0:C}", zahvat.cijena);
                lblTrajanjeZahvata.Text = zahvat.trajanje_minuta.ToString() + " minuta";
            }
        }

        protected void DayPilotCalendar_EventClick(object sender, DayPilot.Web.Ui.Events.EventClickEventArgs e)
        {
            var start = e.Start;
            // populate the fields

            TextBoxPacijentEdit.Text = e.Text.Split('-')[0];
            TextBoxEditName.Text = e.Text.Split('-')[1];
            TextBoxEditStart.Text = e.Start.ToString("dd.MM.yyyy HH:mm");
            TextBoxEditEnd.Text = e.End.ToString("dd.MM.yyyy HH:mm");
            HiddenEditId.Value = e.Id;
            ddlStatus.DataSource = Enum.GetNames(typeof(NarudzbaBLL.Status));
            ddlStatus.DataBind();

            UpdatePanelEdit.Update();
            ModalPopupEdit.Show();
        }
        protected void ButtonEditSave_Click(object sender, EventArgs e)
        {
            DateTime start = DateTime.Parse(TextBoxEditStart.Text);
            DateTime end = DateTime.Parse(TextBoxEditEnd.Text);
            string name = TextBoxEditName.Text;
            int id = Int32.Parse(HiddenEditId.Value);

            Narudzba narudzba = new Narudzba();
            narudzba.narudzba_id = id;
            narudzba.status = ddlStatus.SelectedValue;
            narudzbaBLL.AzurirajStatusNarudzbe(narudzba);

            PribaviPodatkeZaKalendar();

            ModalPopupEdit.Hide();


        }

        protected void ButtonEditCancel_Click(object sender, EventArgs e)
        {
            ModalPopupEdit.Hide();
        }
        protected void DayPilotCalendar_TimeRangeSelected(object sender, DayPilot.Web.Ui.Events.TimeRangeSelectedEventArgs e)
        {

            var datum = e.Start;
            //var radnoVrijeme = radnoVrijemeBLL.PribaviRadnaVremena().Where(x=>x.ra)
            if (ddlZahvati.SelectedValue == "-1" || lbPacijenti.SelectedItem.Value == "-1")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Odaberite pacijenta i zahvat.')", true);
                //DayPilotCalendar_BeforeEventRender(this.DayPilotCalendar, this.DayPilotCalendar.,);
                return;
            }
            var ok = radnoVrijemeBLL.ProvjeriRadnoVrijeme(datum);
            if (!ok )
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Neradno vrijeme.')", true);
                return;
            }
            TextBoxPacijent.Text = lbPacijenti.SelectedItem.Text;
           
            TextBoxCreateName.Text = ddlZahvati.SelectedItem.Text ;
            TextBoxCreateStart.Text = e.Start.ToString("dd.MM.yyyy HH:mm");
            TextBoxCreateEnd.Text = e.Start.AddMinutes(Double.Parse(lblTrajanjeZahvata.Text.Split(' ')[0])).ToString("dd.MM.yyyy HH:mm");
            //TextBoxCreateEnd.Text = e.End.ToString("dd.MM.yyyy HH:mm");

            UpdatePanelCreate.Update();
            ModalPopupCreate.Show();
        }
        protected void ButtonCreateSave_Click(object sender, EventArgs e)
        {

            DateTime start = DateTime.ParseExact(TextBoxCreateStart.Text, "dd.MM.yyyy HH:mm", Thread.CurrentThread.CurrentCulture);
            DateTime end = DateTime.ParseExact(TextBoxCreateEnd.Text, "dd.MM.yyyy HH:mm", Thread.CurrentThread.CurrentCulture);
            string name = TextBoxCreateName.Text;

            Narudzba narudzba = new Narudzba();
            narudzba.dcr = DateTime.Now;
            narudzba.pacijent_id = Int32.Parse(lbPacijenti.SelectedValue);
            narudzba.zahvat_id = Int32.Parse(ddlZahvati.SelectedValue);
            narudzba.termin_pocetak = start;
            narudzba.termin_kraj = end;
            NarudzbaBLL.Status status = NarudzbaBLL.Status.Kreirana;
            narudzba.status = status.ToString();
            try
            {
                narudzbaBLL.UnesiNarudzbu(narudzba);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('" + ex.Message + "')", true);

            }
            
            
            ModalPopupCreate.Hide();

            PribaviPodatkeZaKalendar();
        }

        protected void ButtonCreateCancel_Click(object sender, EventArgs e)
        {
            ModalPopupCreate.Hide();
        }

        protected void DayPilotCalendar_BeforeEventRender(object sender, DayPilot.Web.Ui.Events.Calendar.BeforeEventRenderEventArgs e)
        {
            if (e.DataItem.Source != null )
            {
                NarudzbaBLL.Status status = NarudzbaBLL.Status.Kreirana;
                Enum.TryParse<NarudzbaBLL.Status>(e.DataItem["Status"].ToString(),out status);
                switch (status)
                {
                    case NarudzbaBLL.Status.Kreirana:
                        e.DurationBarColor = "Blue";
                        break;
                    case NarudzbaBLL.Status.Izvrsena:
                        e.DurationBarColor = "Green";
                        break;
                    case NarudzbaBLL.Status.Otkazana:
                        e.DurationBarColor = "Orange";
                        break;
                    
                    case NarudzbaBLL.Status.NijeDosao:
                        e.DurationBarColor = "Red";
                        break;
                    default:
                        break;
                }
               
            }
           
        }
    }
}
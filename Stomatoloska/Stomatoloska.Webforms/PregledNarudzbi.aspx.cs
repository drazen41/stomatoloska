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
    public partial class PregledNarudzbi : System.Web.UI.Page
    {
        ZahvatBLL zahvatBLL = new ZahvatBLL();
        PacijentBLL pacijentBLL = new PacijentBLL();
        RadnoVrijemeBLL radnoVrijemeBLL = new RadnoVrijemeBLL();
        NarudzbaBLL narudzbaBLL = new NarudzbaBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack )
            {
                
                calNarucivanje.SelectedDate = DateTime.Today;
                DayPilotCalendar.DataSource = narudzbaBLL.PribaviPodatkeZaKalendar(calNarucivanje.SelectedDate,true);
                DayPilotCalendar.DataBind();
                
            }
        }

        protected void calNarucivanje_SelectionChanged(object sender, EventArgs e)
        {
            
            PribaviPodatkeZaKalendar();
            
        }
        private void PribaviPodatkeZaKalendar()
        {
            if (calNarucivanje.SelectedDates.Count > 1)
            {

                var start = calNarucivanje.SelectedDates[0].Date;
                var end = calNarucivanje.SelectedDates[4].Date.AddHours(23).AddMinutes(59);
                DayPilotCalendar.ViewType = DayPilot.Web.Ui.Enums.Calendar.ViewTypeEnum.WorkWeek;
                DayPilotCalendar.StartDate = start;
                DayPilotCalendar.DataSource = narudzbaBLL.PribaviPodatkeZaKalendar(start, end,true);
                DayPilotCalendar.DataBind();
            }
            else
            {
                DayPilotCalendar.ViewType = DayPilot.Web.Ui.Enums.Calendar.ViewTypeEnum.Day;
                DayPilotCalendar.StartDate = calNarucivanje.SelectedDate;
                DayPilotCalendar.DataSource = narudzbaBLL.PribaviPodatkeZaKalendar(calNarucivanje.SelectedDate,true);
                DayPilotCalendar.DataBind();
            }
        }
        

        

        protected void DayPilotCalendar_EventClick(object sender, DayPilot.Web.Ui.Events.EventClickEventArgs e)
        {
            
        }
        protected void ButtonEditSave_Click(object sender, EventArgs e)
        {
            


        }

        protected void ButtonEditCancel_Click(object sender, EventArgs e)
        {
          
        }
        protected void DayPilotCalendar_TimeRangeSelected(object sender, DayPilot.Web.Ui.Events.TimeRangeSelectedEventArgs e)
        {

            var datum = e.Start;
            //var radnoVrijeme = radnoVrijemeBLL.PribaviRadnaVremena().Where(x=>x.ra)
            
            
            
        }
        protected void ButtonCreateSave_Click(object sender, EventArgs e)
        {

            
        }

        protected void ButtonCreateCancel_Click(object sender, EventArgs e)
        {
            
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
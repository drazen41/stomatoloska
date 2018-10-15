using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stomatoloska.DAL.Baza;
using Stomatoloska.DAL;
using Stomatoloska.BLL;

namespace Stomatoloska.Webforms
{
    public partial class frmRadnoVrijeme : System.Web.UI.Page
    {
        RadnoVrijemeBLL radnoVrijemeBLL = new RadnoVrijemeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {         
           if (!Page.IsPostBack)
            {
                Inicijalizacija();
                PrikaziRadnoVrijeme();
            }
            
        }

        private void PrikaziRadnoVrijeme()
        {
            List<RadnoVrijeme> dani = radnoVrijemeBLL.PribaviRadnaVremena();
            foreach (var dan in dani)
            {
                string radnoVrijeme = dan.pocetak.ToString(@"hh\:mm") + "-" + dan.kraj.ToString(@"hh\:mm");
               
                switch (dan.radni_dan )
                {
                    case "ponedjeljak":
                        ponRadnoVrijeme.Text = radnoVrijeme;
                        break;
                    case "utorak":
                        utoRadnoVrijeme.Text = radnoVrijeme;
                        break;
                    case "srijeda":
                        sriRadnoVrijeme.Text = radnoVrijeme;
                        break;
                    case "četvrtak":
                        cetRadnoVrijeme.Text = radnoVrijeme;
                        break;
                    case "petak":
                        petRadnoVrijeme.Text = radnoVrijeme;
                        break;
                    default:
                        break;
                }
            }
            //RadnoVrijeme ponedjeljak = vremena.Where(x => x.radni_dan == "ponedjeljak").FirstOrDefault();
           
        }

        private void Inicijalizacija()
        {
            for (int i = 0; i <= 8; i++)
            {
                int pocetakSat = 8 + i;
                int krajSat = 12 + i;
                DropDownListPocetakSat.Items.Add(new ListItem() { Text = pocetakSat.ToString(), Value = pocetakSat.ToString() });
                DropDownListKrajSat.Items.Add(new ListItem() { Text = krajSat.ToString(), Value = krajSat.ToString() });
            }
            DropDownListPocetakMinuta.Items.Add(new ListItem() { Text = "30", Value = "30" });
            DropDownListPocetakMinuta.Items.Add(new ListItem() { Text = "00", Value = "00",Selected = true });
            DropDownListKrajMinuta.Items.Add(new ListItem() { Text = "30", Value = "30" });
            DropDownListKrajMinuta.Items.Add(new ListItem() { Text = "00", Value = "00", Selected = true });
        }

        protected void btnUnos_Click(object sender, EventArgs e)
        {
            List<RadnoVrijeme> vremena = new List<RadnoVrijeme>();
            foreach (ListItem dan  in CheckBoxListRadniDan.Items)
            {
                if (dan.Selected)
                {
                    RadnoVrijeme radnoVrijeme = new RadnoVrijeme();
                    radnoVrijeme.dcr = DateTime.Now;
                    radnoVrijeme.kraj = new TimeSpan(Convert.ToInt32(DropDownListKrajSat.SelectedValue), Convert.ToInt32(DropDownListKrajMinuta.SelectedValue), 0);
                    radnoVrijeme.pocetak = new TimeSpan(Convert.ToInt32(DropDownListPocetakSat.SelectedValue), Convert.ToInt32(DropDownListPocetakMinuta.SelectedValue), 0);
                    radnoVrijeme.radni_dan = dan.Value;
                    vremena.Add(radnoVrijeme);
                }

            }
            radnoVrijemeBLL.UnesiRadnaVremena(vremena);
            PrikaziRadnoVrijeme();
        }

        
    }
}
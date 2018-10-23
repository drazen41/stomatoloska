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
            //List<RadnoVrijeme> dani = radnoVrijemeBLL.PribaviRadnaVremena();
            List<RadnoVrijeme> dani = radnoVrijemeBLL.PribaviAktivnoRadnoVrijeme();
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
            RadnoVrijeme radnoVrijeme = new RadnoVrijeme();
            radnoVrijeme.dcr = DateTime.Now;
            radnoVrijeme.kraj = new TimeSpan(Convert.ToInt32(DropDownListKrajSat.SelectedValue), Convert.ToInt32(DropDownListKrajMinuta.SelectedValue), 0);
            radnoVrijeme.pocetak = new TimeSpan(Convert.ToInt32(DropDownListPocetakSat.SelectedValue), Convert.ToInt32(DropDownListPocetakMinuta.SelectedValue), 0);
            radnoVrijeme.od_datuma = DateTime.Parse(txtOdDatuma.Text);

            if (gvVremena.SelectedIndex == -1)
            {
                foreach (ListItem  item in CheckBoxListRadniDan.Items )
                {
                    if (item.Selected )
                    {
                        radnoVrijeme.radni_dan = item.Value;
                        radnoVrijemeBLL.UnesiRadnoVrijeme(radnoVrijeme);
                    }
                }
            }
            else
            {
                radnoVrijeme.radno_vrijeme_id = (int)ViewState["rvid"];
                try
                {
                    radnoVrijemeBLL.AzurirajRadnoVrijeme(radnoVrijeme);
                    gvVremena.DataBind();
                    gvVremena.SelectedIndex = -1;
                    btnOdustani.Visible = false;
                    btnUnos.Text = "Unos radnog vremena";
                   
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('" + ex.Message + "')", true);

                }
                ViewState["rvid"] = null;
            }
        }
        private void UnesiRadnaVremena()
        {
            List<RadnoVrijeme> vremena = new List<RadnoVrijeme>();
            foreach (ListItem dan in CheckBoxListRadniDan.Items)
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
        protected void gvVremena_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOdustani.Visible = true;
            btnUnos.Text = "Ažuriranje radnog vremana";
            var id = (int)gvVremena.SelectedDataKey.Value;

            ViewState["rvid"] = id;
            var rv = radnoVrijemeBLL.PribaviRadnoVrijeme(id);
            txtOdDatuma.Text = rv.od_datuma.ToShortDateString();
            DropDownListPocetakSat.SelectedValue = rv.pocetak.Hours.ToString();
            string minutePocetak = rv.pocetak.Minutes.ToString();
            if (minutePocetak == "0")
            {
                minutePocetak = "00";
            }
            string minuteKraj = rv.kraj.Minutes.ToString();
            if (minuteKraj == "0")
            {
                minuteKraj = "00";
            }
            DropDownListPocetakMinuta.SelectedValue = minutePocetak;
            DropDownListKrajSat.SelectedValue = rv.kraj.Hours.ToString();
            DropDownListKrajMinuta.SelectedValue = minuteKraj;
            foreach (ListItem item in CheckBoxListRadniDan.Items )
            {
                if (item.Text == rv.radni_dan )
                {
                    item.Selected = true;
                }
                else
                {
                    item.Selected = false;
                }
            }
        }

        protected void btnOdustani_Click(object sender, EventArgs e)
        {
            gvVremena.SelectedIndex = -1;
            btnOdustani.Visible = false;
        }
    }
}
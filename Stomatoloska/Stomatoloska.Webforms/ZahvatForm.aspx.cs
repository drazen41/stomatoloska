﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stomatoloska.DAL.Baza;
using Stomatoloska.BLL;

namespace Stomatoloska.Webforms
{
    public partial class ZahtvatForm : System.Web.UI.Page
    {
        private ZahvatBLL zahvatBll = null;
        Zahvat zahvat = new Zahvat();
        protected void Page_Load(object sender, EventArgs e)
        {
            zahvatBll = new ZahvatBLL();
        }

        protected void btnUnos_Click(object sender, EventArgs e)
        {
            if (Page.IsValid )
            {
                
                zahvat.trajanje_minuta = Convert.ToInt32(ddlVrijeme.SelectedValue);
                zahvat.naziv = txtNaziv.Text;
                zahvat.dcr = DateTime.Now;
                zahvat.sifra = txtSifra.Text;

                if (gvZahvati.SelectedIndex > -1)
                {
                    zahvatBll.AzurirajZahvat(zahvat);
                    gvZahvati.SelectedIndex = -1;
                    btnCancel.Visible = false;
                }
                else
                {
                    try
                    {
                        zahvatBll.UnesiZahvat(zahvat);
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('" + ex.Message + "')", true);
                        
                    }
                   
                    
                }
                
            }
            btnUnos.Text = "Unesi zahvat";
            txtSifra.Enabled = true;



        }

        protected void CustomValidatorCijena_ServerValidate(object source, ServerValidateEventArgs args)
        {
            decimal cijena = 0;
            if (!Decimal.TryParse(txtCijena.Text, out cijena))
            {
                RequiredFieldValidatorCijena.Visible = false;
                args.IsValid = false;
            }
            else
            {
                RequiredFieldValidatorCijena.Visible = true;
                zahvat.cijena = cijena;
            }
        }

        protected void gvZahvati_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCancel.Visible = true;
            var red = gvZahvati.SelectedRow;
            txtSifra.Text = red.Cells[1].Text;
            txtNaziv.Text = red.Cells[2].Text;
            txtCijena.Text = red.Cells[3].Text;
            ddlVrijeme.SelectedValue = red.Cells[4].Text;
            btnUnos.Text = "Ažuriraj zahvat";
            txtSifra.Enabled = false;
        }

        protected void gvZahvati_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var red = gvZahvati.Rows[e.RowIndex];
            var sifra = red.Cells[1].Text;
            zahvatBll.ObrisiZahvat(sifra);
        }

        protected void gvZahvati_PreRender(object sender, EventArgs e)
        {
            var zahvati = zahvatBll.PribaviZahvate();
            gvZahvati.DataSource = zahvati;
            gvZahvati.DataBind();
           
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            gvZahvati.SelectedIndex = -1;
            btnCancel.Visible = false;
            btnUnos.Text = "Unesi zahvat";
            Inicijalizacija();
        }

        private void Inicijalizacija()
        {
            txtSifra.Text = "";
            txtCijena.Text = "";
            txtNaziv.Text = "";
            txtSifra.Enabled = true;
        }
    }
}
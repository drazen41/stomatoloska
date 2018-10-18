using Microsoft.Reporting.WebForms;
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
    public partial class Izvjestaji : System.Web.UI.Page
    {
        private NarudzbaBLL narudzbeBll = new NarudzbaBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack )
            {
                PopuniDDL();
            }
        }

        private void PopuniDDL()
        {
            ddlIzvjestaji.Items.Add(new ListItem { Text = "-- Izvještaj --", Selected = true, Value = "-1" });
            ddlIzvjestaji.Items.Add(new ListItem { Text = "Iskorišteni termini po zahvatu", Value = "1" });
            ddlIzvjestaji.Items.Add(new ListItem { Text = "Iskorišteni termini po danima", Value = "2" });
            ddlIzvjestaji.Items.Add(new ListItem { Text = "Neiskorišteni termini po zahvatu", Value = "3" });
            ddlIzvjestaji.Items.Add(new ListItem { Text = "Neiskorišteno vrijeme", Value = "4" });
            ddlIzvjestaji.DataBind();
        }

        protected void ddlIzvjestaji_SelectedIndexChanged(object sender, EventArgs e)
        {
            int report = Int32.Parse(ddlIzvjestaji.SelectedValue);
            string path = "";
            switch (report)
            {
                case 1:
                    path = "Reports/rptIskoristeniTermini.rdlc";
                    break;
                default:
                    break;
            }
            LocalReport localReport = this.ReportViewerStomatoloska.LocalReport;
            localReport.ReportPath = "Reports/rptIskoristeniTermini.rdlc";

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = narudzbeBll.PribaviNarudzbeZaStatus(NarudzbaBLL.Status.Izvrsena);
            localReport.DataSources.Add(rds);
            //rds.va
           //this.ReportViewerStomatoloska.LocalReport.DataSources.a
        }
        
    }
}
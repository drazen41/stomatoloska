using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stomatoloska.BLL;
using Stomatoloska.DAL.Baza;
using Stomatoloska.Webforms.Reports;
using System.Data;

namespace Stomatoloska.Webforms
{
    public partial class Izvjestaji : System.Web.UI.Page
    {
        private ReportsData reportsData = new ReportsData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
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
            LocalReport localReport = this.ReportViewerStomatoloska.LocalReport;
            ReportDataSource rds = new ReportDataSource();
            int report = Int32.Parse(ddlIzvjestaji.SelectedValue);
            string path = "";
            switch (report)
            {
                case 1:
                    path = Server.MapPath("~/Reports/rptTerminZahvat.rdlc");
                    rds.Name = "DataSet1";
                    rds.Value = reportsData.PribaviIskoristeneTerminePoZahvatu();
                    localReport.DataSources.Add(rds);
                    break;
                case 2:
                    path = Server.MapPath("~/Reports/rptTerminDan.rdlc");
                    rds.Name = "DataSet1";
                    rds.Value = reportsData.PribaviIskoristeneTerminePoDanima();
                    localReport.DataSources.Add(rds);
                    break;
                case 3:
                    path = Server.MapPath("~/Reports/rptNeiskoristeniTerminiZahvat.rdlc");
                    rds.Name = "DataSet1";
                    rds.Value = reportsData.PribaviNeiskoristeneTerminePoZahvatu();
                    localReport.DataSources.Add(rds);
                    break;
                case 4:
                    path = Server.MapPath("~/Reports/rptNeiskoristenTerminDan.rdlc");
                    //DataTable table = reportsData.PribaviNeiskoristeneTerminePoDanima();
                    rds.Name = "DataSet1";
                    rds.Value = reportsData.PribaviNeiskoristeneTerminePoDanima();
                    localReport.DataSources.Add(rds);
                    break;
                default:
                    break;
            }

            localReport.ReportPath = path;



            //rds.va
            //this.ReportViewerStomatoloska.LocalReport.DataSources.a
        }


    }
}
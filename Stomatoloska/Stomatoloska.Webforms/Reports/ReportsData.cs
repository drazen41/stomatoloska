using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stomatoloska.BLL;
using Stomatoloska.DAL.Baza;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace Stomatoloska.Webforms.Reports
{
    public class ReportsData
    {
        
        private NarudzbaBLL narudzbaBLL = new NarudzbaBLL();
        public DataTable PribaviIskoristeneTerminePoZahvatu()
        {
            DataTable table = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT b.sifra, b.naziv, b.cijena,a.termin_pocetak, a.termin_kraj FROM tNarudzba a JOIN tZahvat b on a.zahvat_id = b.zahvat_id ");
            sb.Append("where a.status = 'Izvrsena' ORDER by a.termin_pocetak ");
            string connString = ConfigurationManager.ConnectionStrings["stomatoloskaConnectionStringProd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand comm = new SqlCommand(sb.ToString(), conn);
            SqlDataAdapter sda = new SqlDataAdapter(comm);
            sda.Fill(table);
            return table;
            
        }
        public DataTable PribaviNeiskoristeneTerminePoZahvatu()
        {
            DataTable table = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT b.sifra, b.naziv, b.cijena,a.termin_pocetak, a.termin_kraj FROM tNarudzba a JOIN tZahvat b on a.zahvat_id = b.zahvat_id ");
            sb.Append("where a.status = 'NijeDosao' ORDER by a.termin_pocetak ");
            string connString = ConfigurationManager.ConnectionStrings["stomatoloskaConnectionStringProd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand comm = new SqlCommand(sb.ToString(), conn);
            SqlDataAdapter sda = new SqlDataAdapter(comm);
            sda.Fill(table);
            return table;

        }
        public DataTable PribaviIskoristeneTerminePoDanima()
        {
            DataTable table = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT CAST(a.termin_pocetak AS DATE) dan, b.sifra, b.naziv, b.cijena, a.termin_pocetak, a.termin_kraj FROM tNarudzba a JOIN tZahvat b on a.zahvat_id = b.zahvat_id ");
            sb.Append("where a.status = 'Izvrsena' ORDER BY a.termin_pocetak ");
            string connString = ConfigurationManager.ConnectionStrings["stomatoloskaConnectionStringProd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand comm = new SqlCommand(sb.ToString(), conn);
            SqlDataAdapter sda = new SqlDataAdapter(comm);
            sda.Fill(table);
            return table;

        }
        

    }
}
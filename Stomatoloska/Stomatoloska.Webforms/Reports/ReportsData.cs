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
        private RadnoVrijemeBLL radnoVrijemeBll = new RadnoVrijemeBLL();
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
        public DataTable PribaviNeiskoristeneTerminePoDanima()
        {
            DataTable table = new DataTable();
            var radnoVrijeme = radnoVrijemeBll.PribaviRadnaVremena();
            var narudzbe = narudzbaBLL.PribaviNarudzbe()
                .Where(x=>x.status == NarudzbaBLL.Status.Izvrsena.ToString() || x.status==NarudzbaBLL.Status.Kreirana.ToString() || x.status == NarudzbaBLL.Status.NijeDosao.ToString());
            var minDatum = narudzbe.Min(x => x.termin_pocetak).Date;
            int dana = (DateTime.Now - minDatum).Days;
            table.Columns.Add("datum",typeof(DateTime));
            table.Columns.Add("termin_pocetak",typeof(DateTime));
            table.Columns.Add("termin_kraj",typeof(DateTime));
            table.Columns.Add("razlika",typeof(Int32));
            //DataRow red = table.NewRow();
            //red["datum"] = DateTime.Now;
            //red["termin_pocetak"] = DateTime.Now.AddHours(1);
            //red["termin_kraj"] = DateTime.Now.AddHours(2);
            //red["razlika"] = 60;
            //table.Rows.Add(red);
            var trenutniDatum = minDatum;
            for (int i = 0 ; i < dana+1  ; i++)
            {
                var radniDan = radnoVrijemeBll.RadniDanZaDatum(trenutniDatum);
                var radnoVrijemeDan = radnoVrijeme.Where(x => x.radni_dan == radniDan).FirstOrDefault();
                double minuta = 0;
                if (radnoVrijemeDan != null)
                {
                    minuta = radnoVrijemeDan.kraj.TotalMinutes - radnoVrijemeDan.pocetak.TotalMinutes;
                    int brojac = 0;
                    while (brojac < minuta)
                    {
                        DataRow red = table.NewRow();
                        red["datum"] = trenutniDatum.AddDays(i);
                        red["termin_pocetak"] = trenutniDatum.AddMinutes(brojac);
                        red["termin_kraj"] = trenutniDatum.AddMinutes(brojac + 60);
                        red["razlika"] = 60;
                        table.Rows.Add(red);
                        brojac += 30;

                    }

                }
                
            }



            return table;
        }
        

    }
}
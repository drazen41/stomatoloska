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
                .Where(x=>x.status == NarudzbaBLL.Status.Izvrsena.ToString() || x.status==NarudzbaBLL.Status.Kreirana.ToString() || x.status == NarudzbaBLL.Status.NijeDosao.ToString()).ToList();
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
            DateTime terminPocetak = new DateTime(1900, 1, 1);
            DateTime terminKraj = new DateTime(1900, 1, 1);
            bool noviPocetak = false;
            for (int i = 0 ; i < dana+1  ; i++)
            {
                trenutniDatum = minDatum.AddDays(i).Date;
                var radniDan = radnoVrijemeBll.RadniDanZaDatum(trenutniDatum);
                var radnoVrijemeDan = radnoVrijeme.Where(x => x.radni_dan == radniDan).FirstOrDefault();
                Narudzba termin = null;
                double minuta = 0;
                if (radnoVrijemeDan != null)
                {
                    minuta = radnoVrijemeDan.kraj.TotalMinutes - radnoVrijemeDan.pocetak.TotalMinutes;
                    trenutniDatum = trenutniDatum.Add(radnoVrijemeDan.pocetak);
                    int brojac = 0;
                    DataRow red = null;
                    int razlika = 0;
                    while (brojac < minuta)
                    {
                        termin = narudzbe.Where(x => x.termin_pocetak == trenutniDatum).FirstOrDefault();
                        //if (termin != null)
                        //{

                        //}


                        if (termin != null)
                        {
                            terminKraj = termin.termin_kraj;
                            int minutaTermin = (int)((termin.termin_kraj - termin.termin_pocetak).TotalMinutes);
                            if (terminPocetak.Date > new DateTime(1900, 1, 1))
                            {
                                //terminPocetak = termin.termin_pocetak;
                                //razlika += (int)(terminKraj - terminPocetak).TotalMinutes;
                                red = table.NewRow();
                                red["datum"] = trenutniDatum.Date;
                                red["termin_pocetak"] = terminPocetak;
                                red["termin_kraj"] = trenutniDatum;
                                red["razlika"] = (int)((trenutniDatum - terminPocetak).TotalMinutes);
                                table.Rows.Add(red);
                                brojac += (int)(terminKraj - trenutniDatum).TotalMinutes;
                                terminPocetak = new DateTime(1900, 1, 1);
                                terminKraj = new DateTime(1900, 1, 1);                               
                                trenutniDatum = trenutniDatum.AddMinutes(minutaTermin);
                                razlika = 0;
                            }
                            else
                            {
                                
                                trenutniDatum = trenutniDatum.AddMinutes(minutaTermin);
                                brojac += minutaTermin;
                            }
                            noviPocetak = true;
                        }
                        else
                        {
                            if (noviPocetak || trenutniDatum.TimeOfDay == radnoVrijemeDan.pocetak)
                                terminPocetak = trenutniDatum;
                            trenutniDatum = trenutniDatum.AddMinutes(30);
                            brojac += 30;
                            //razlika += 30;
                            if (trenutniDatum.TimeOfDay == radnoVrijemeDan.kraj)
                            {
                                red = table.NewRow();
                                red["datum"] = trenutniDatum.Date;
                                red["termin_pocetak"] = terminPocetak;
                                red["termin_kraj"] = trenutniDatum;
                                red["razlika"] = (int)((trenutniDatum - terminPocetak).TotalMinutes);
                                table.Rows.Add(red);
                                terminPocetak = new DateTime(1900, 1, 1);
                                terminKraj = new DateTime(1900, 1, 1);
                                razlika = 0;
                            }
                            noviPocetak = false;

                        }
                        
                        
                      

                    }

                }
                
                
            }



            return table;
        }
        

    }
}
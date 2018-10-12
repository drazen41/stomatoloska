using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stomatoloska.DAL.Baza;
using Stomatoloska.DAL.Baza.StomatoloskaDataSetTableAdapters;
using Stomatoloska.DAL;
using Stomatoloska.Data;


namespace Stomatoloska
{
    public partial class frmRadnoVrijeme : Form
    {
        public frmRadnoVrijeme()
        {
            InitializeComponent();
            PopuniDataGrid();
        }

        private void PopuniDataGrid()
        {
            StomatoloskaUoW uow = new StomatoloskaUoW();

            //var podaci = uow.RadnoVrijemeRepo.PribaviAktivnaRadnaVremena(DateTime.Now);
            //stomatoloskaEntities1 entities1 = new stomatoloskaEntities1();
            //var podaci = from rv in entities1.tRadnoVrijeme select rv;
            var podaci = uow.RadnoVrijemeRepo.Get();

            foreach (var pod in podaci)
            {
                MessageBox.Show(pod.radno_vrijeme_id + pod.radni_dan + pod.od_dana + pod.pocetak + pod.kraj);
            }

            //tRadnoVrijemeTableAdapter adapter = new tRadnoVrijemeTableAdapter();
            //StomatoloskaDataSet.tRadnoVrijemeDataTable table = new StomatoloskaDataSet.tRadnoVrijemeDataTable();
            //adapter.FillRadnoVrijemeSve(table);

            //DataSet1.DataTable1DataTable table = new DataSet1.DataTable1DataTable();
            //Stomatoloska.Data.DataSet1TableAdapters.DataTable1TableAdapter adapter = new Data.DataSet1TableAdapters.DataTable1TableAdapter();
            //adapter.Fill(table);


            //foreach (var red in table)
            //{
            //    MessageBox.Show(red.radni_dan + ": " + red.radno_vrijeme_id.ToString() + red.dcr.ToString() + red.pocetak + red.kraj);
            //}
        }
    }
}

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
            tRadnoVrijemeTableAdapter adapter = new tRadnoVrijemeTableAdapter();
            StomatoloskaDataSet.tRadnoVrijemeDataTable table = new StomatoloskaDataSet.tRadnoVrijemeDataTable();
            adapter.FillRadnoVrijemeSve(table);
            foreach (var red in table )
            {
                MessageBox.Show(red.radni_dan + ": " + red.radno_vrijeme_id.ToString() + red.dcr.ToString() + red.pocetak + red.kraj);
            }
            
        }
    }
}

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
        private BindingSource bindingSource1 = new BindingSource();
        private Button reloadButton = new Button();
        private Button submitButton = new Button();
        private DataGridView dataGridView1 = new DataGridView();
        public frmRadnoVrijeme()
        {
            InitializeComponent();
            //dataGridView1.Dock = DockStyle.Fill;

            reloadButton.Text = "reload";
            submitButton.Text = "submit";
            reloadButton.Click += new System.EventHandler(reloadButton_Click);
            submitButton.Click += new System.EventHandler(submitButton_Click);

            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Dock = DockStyle.Top;
            panel.AutoSize = true;
            panel.Controls.AddRange(new Control[] { reloadButton, submitButton });

            //this.Controls.AddRange(new Control[] { dataGridView1, panel });
            this.Load += new System.EventHandler(Form1_Load);
            this.Text = "DataGridView databinding and updating demo";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = bindingSource1;
            dataGridView2.DataSource = bindingSource1;
            PopuniDataGrid();

        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PopuniDataGrid()
        {
            StomatoloskaUoW uow = new StomatoloskaUoW();

            var zadnjiPodaci = uow.RadnoVrijemeRepo.PribaviRadnaVremenaOdDatuma(DateTime.Now);
            var sviPodaci = uow.RadnoVrijemeRepo.Get().ToList<RadnoVrijeme>();
            var bindingList = new BindingList<RadnoVrijeme>(sviPodaci);
            bindingSource1.DataSource = bindingList;
            //dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);

            //stomatoloskaEntities1 entities1 = new stomatoloskaEntities1();
            //var podaci = from rv in entities1.tRadnoVrijeme select rv;
            //var podaci = uow.RadnoVrijemeRepo.Get();

            //foreach (var pod in zadnjiPodaci)
            //{
            //    MessageBox.Show(pod.radno_vrijeme_id + pod.radni_dan + pod.od_dana + pod.pocetak + pod.kraj);
            //}

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

        private void reloadButton_Click(object sender, System.EventArgs e)
        {
            // Reload the data from the database.
            PopuniDataGrid();
        }
    }
}

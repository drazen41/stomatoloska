using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stomatoloska
{
    public partial class frmNarucivanje : Form
    {
        public frmNarucivanje()
        {
            InitializeComponent();
        }

        private void calendar1_LoadItems(object sender, System.Windows.Forms.Calendar.CalendarLoadEventArgs e)
        {

        }

        private void calendar1_ItemClick(object sender, System.Windows.Forms.Calendar.CalendarItemEventArgs e)
        {
            
        }

        

        private void calendar1_ItemCreated(object sender, System.Windows.Forms.Calendar.CalendarItemCancelEventArgs e)
        {
           // MessageBox.Show("Termin kreiran.");
        }

        private void calendar1_ItemTextEditing(object sender, System.Windows.Forms.Calendar.CalendarItemCancelEventArgs e)
        {
            MessageBox.Show("Ažuriran.");
        }

        private void pregledNarudžbiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pregledRadnogVremenaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRadnoVrijeme frmRadnoVrijeme = new frmRadnoVrijeme();
            frmRadnoVrijeme.Show();
            this.Hide();
        }

        private void test1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnumsAndComboBox enumsAndComboBox = new EnumsAndComboBox();
            enumsAndComboBox.Show();
            this.Hide();
        }
    }
}

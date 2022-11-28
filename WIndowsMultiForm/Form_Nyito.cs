using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsGyumolcs;

namespace WIndowsMultiForm
{
    public partial class Form_Nyito : Form
    {
        Database database = new Database();
        public Form_Nyito()
        {
            InitializeComponent();
        }

        private void módositásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.gyumolcsUpdate.ShowDialog();

        }

        private void újToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.gyumolcsInsert.ShowDialog();
        }

        private void tanulókToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listBox_gyumolcsok_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        public void GyumolcsokBetoltese()
        {
            //érétkek szájfeltöltése 
            listBox_gyumolcsok.Items.Clear();
            foreach (Gyumolcsok item in database.getAllGyumolcs())
            {
                listBox_gyumolcsok.Items.Add(item);
            }
        }
        private void Form_Nyito_Load(object sender, EventArgs e)
        {
            GyumolcsokBetoltese();
        }

        private void törlésToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Program.gyumolcsDelete.ShowDialog();
        }
    }
}

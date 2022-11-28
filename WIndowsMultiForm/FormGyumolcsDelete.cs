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
    public partial class FormGyumolcsDelete : Form
    {
        Database database = new Database();
        public FormGyumolcsDelete()
        {
            InitializeComponent();
        }

      

        private void FormGyumolcsDelete_Load(object sender, EventArgs e)
        {
            MessageBox.Show(Program.form_Nyito.listBox_gyumolcsok.Text + " adatainak törlése");
            Gyumolcsok ja = (Gyumolcsok)Program.form_Nyito.listBox_gyumolcsok.SelectedItem;
            textBox_id.Text = Convert.ToString(ja.Id);
            textBox_nev.Text = Convert.ToString(ja.Nev);
            numericUpDown_egysegar.Value = Convert.ToDecimal(ja.Egysegar);
            numericUpDown_mennyiseg.Value = Convert.ToDecimal(ja.Mennyiseg);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Gyumolcsok deleteGyumolcs = new Gyumolcsok(1, textBox_nev.Text, (double)numericUpDown_egysegar.Value, (double)numericUpDown_mennyiseg.Value);
            if (database.deleteGyumolcs(deleteGyumolcs))
            {
                MessageBox.Show("Sikeres rögzites!");
                textBox_id.Text = "";
                textBox_nev.Text = "";
                numericUpDown_egysegar.Value = numericUpDown_egysegar.Minimum;
                numericUpDown_mennyiseg.Value = numericUpDown_mennyiseg.Minimum;
            }
            else
            {
                MessageBox.Show("Sikertelen rögzites!");
            }
            Program.form_Nyito.GyumolcsokBetoltese();
            Close();
        }
    }
}

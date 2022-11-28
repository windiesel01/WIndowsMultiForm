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
    public partial class FormGyumolcsUpdate : Form
    {
        Database database = new Database();
        public FormGyumolcsUpdate()
        {
            InitializeComponent();
        }

        private void FormTanulokUpdate_Load(object sender, EventArgs e)
        {
            MessageBox.Show(Program.form_Nyito.listBox_gyumolcsok.Text + " adatainak a módositása");
            Gyumolcsok ja = (Gyumolcsok)Program.form_Nyito.listBox_gyumolcsok.SelectedItem;
            textBox_id.Text = Convert.ToString(ja.Id);
            textBox_nev.Text = Convert.ToString(ja.Nev);
            numericUpDown_egysegar.Value = Convert.ToDecimal(ja.Egysegar);
            numericUpDown_mennyiseg.Value = Convert.ToDecimal(ja.Mennyiseg);
        }

        private bool HiagyzoAdat()
        {
            if (string.IsNullOrEmpty(textBox_nev.Text))
            {
                MessageBox.Show("Adja meg a gyümölcs nevét!");
                textBox_nev.Focus();
                return true;
            }
            if (numericUpDown_egysegar.Value <= 0)
            {
                MessageBox.Show("Érvénytelen egységár!");
                numericUpDown_mennyiseg.Focus();
                return true;
            }
            if (numericUpDown_mennyiseg.Value <= 0)
            {
                MessageBox.Show("Érvénytelen mennyiség!");
                numericUpDown_mennyiseg.Focus();
                return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (HiagyzoAdat())
            {
                return;
            }
            Gyumolcsok updateGyumolcs = new Gyumolcsok(1, textBox_nev.Text, (double)numericUpDown_egysegar.Value, (double)numericUpDown_mennyiseg.Value);
            if (database.updateGyumolcs(updateGyumolcs))
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

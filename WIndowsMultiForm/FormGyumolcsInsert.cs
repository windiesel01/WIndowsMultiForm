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
    public partial class FormGyumolcsInsert : Form
    {
        Database database = new Database();
        public FormGyumolcsInsert()
        {
            InitializeComponent();
        }

        private void FormGyumolcsInsert_Load(object sender, EventArgs e)
        {
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
            Gyumolcsok insertGyumolcs = new Gyumolcsok(1, textBox_nev.Text, (double)numericUpDown_egysegar.Value, (double)numericUpDown_mennyiseg.Value);
            if (database.insertGyumolcs(insertGyumolcs))
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
        }
    }
}

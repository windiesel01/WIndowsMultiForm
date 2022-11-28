using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WIndowsMultiForm
{
    internal static class Program
    {
        static public FormGyumolcsUpdate gyumolcsUpdate= null;
        static public FormGyumolcsDelete gyumolcsDelete = null;
        static public FormGyumolcsInsert gyumolcsInsert = null;
        static public Form_Nyito form_Nyito = null;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            gyumolcsUpdate = new FormGyumolcsUpdate();
            gyumolcsDelete = new FormGyumolcsDelete();
            gyumolcsInsert = new FormGyumolcsInsert();
            form_Nyito = new Form_Nyito();
            Application.Run(form_Nyito);
        }
    }
}

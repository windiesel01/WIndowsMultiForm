using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WIndowsMultiForm;

namespace WindowsFormsGyumolcs
{

    internal class Database
    {
        static public MySqlCommand cmd;
        static public MySqlConnection connection;

        public Database(string server = "localhost", string user = "root", string password = "", string db = "gyumolcsok")
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = server;
            builder.UserID = user;
            builder.Password = password;
            builder.Database = db;
            connection = new MySqlConnection(builder.ConnectionString);
            if (Kapcsolatok())
            {
                cmd = connection.CreateCommand();
            }
        }

        public List<Gyumolcsok> getAllGyumolcs()
        {
            List<Gyumolcsok> list = new List<Gyumolcsok>();
            cmd.CommandText = "SELECT * FROM gyumolcsok;";
            Nyitas();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    Gyumolcsok gyumolcs = new Gyumolcsok(dr.GetInt32("id"), dr.GetString("nev"), dr.GetDouble("egysegar"), dr.GetDouble("mennyiseg"));
                    list.Add(gyumolcs);
                }
            }
            Zaras();
            return list;
        }

        private void Nyitas()
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }
        private void Zaras()
        {
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        private bool Kapcsolatok()
        {
            try
            {
                connection.Open();
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        internal bool insertGyumolcs(Gyumolcsok insertGyumolcs)
        {
            cmd.CommandText = "INSERT INTO `gyumolcsok`(`id`, `nev`, `egysegar`, `mennyiseg`) VALUES (null, @nev, @egysegar, @mennyiseg);";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@nev", insertGyumolcs.Nev);
            cmd.Parameters.AddWithValue("@egysegar", insertGyumolcs.Egysegar);
            cmd.Parameters.AddWithValue("@mennyiseg", insertGyumolcs.Mennyiseg);
            Nyitas();
            if (cmd.ExecuteNonQuery() == 1)
            {
                Zaras();
                return true;
            }
            else
            {
                Zaras();
                return false;
            }
        }

        internal bool updateGyumolcs(Gyumolcsok updateGyumolcs)
        {

            cmd.CommandText = "UPDATE `gyumolcsok` SET `nev`= @nev,`egysegar`= @egysegar,`mennyiseg`= @mennyiseg WHERE `id`=@id;";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", Program.gyumolcsUpdate.textBox_id.Text);
            cmd.Parameters.AddWithValue("@nev", Program.gyumolcsUpdate.textBox_nev.Text);
            cmd.Parameters.AddWithValue("@egysegar", Program.gyumolcsUpdate.numericUpDown_egysegar.Value);
            cmd.Parameters.AddWithValue("@mennyiseg", Program.gyumolcsUpdate.numericUpDown_mennyiseg.Value);
            Nyitas();
            if (cmd.ExecuteNonQuery() == 1)
            {
                Zaras();
                return true;
            }
            else
            {
                Zaras();
                return false;
            }
        }
        internal bool deleteGyumolcs(Gyumolcsok deleteGyumolcs)
        {

            cmd.CommandText = "DELETE FROM `gyumolcsok` WHERE `id` = @id;";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", Program.gyumolcsDelete.textBox_id.Text);
            Nyitas();
            if (cmd.ExecuteNonQuery() == 1)
            {
                Zaras();
                return true;
            }
            else
            {
                Zaras();
                return false;
            }
        }
    }
}



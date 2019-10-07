using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace SpellEffectV3
{
    public class MySqlConn : System.IDisposable
    {
        // pour une créer une instance de connexion Mysql
        public IDbConnection conn;
        public IDbCommand cmd;
        public IDataReader reader;                 // pour créer des cmd SQL
        public MySqlDataReader readerSql = null;

        public MySqlConn(string username, string password, string db, string ip)
        {
            MySqlOpenConn(username, password, db, ip);
        }

        public void MySqlOpenConn(string username, string password, string db, string ip)
        {
            if (conn != null)
                conn.Close();

            // initialisation de la connexion
            string connStr = String.Format("server={0};user id={1}; password={2}; database={3}; pooling=false",
                                           ip, username, password, db);
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                cmd = conn.CreateCommand();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur lors de la connexion à la Bdd.\n" + ex.Message);
            }
        }

        public void MysqlDisconnect()
        {
            conn.Close();
        }

        public void Dispose()
        {
            this.MysqlDisconnect();
        }
    }
}

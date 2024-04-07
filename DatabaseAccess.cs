using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirjasto_ohjelma
{
    public class DatabaseAccess
    {
        public MySqlConnection connection;
        private string connectionString = "SERVER=LOCALHOST;PORT=3306;DATABASE=kirjasto;UID=root;PASSWORD=AWPDl0re;";
        private static readonly object _lock = new object();
        private static DatabaseAccess instance;

        private DatabaseAccess()
        {
            // Initialize connection
            connection = new MySqlConnection(connectionString);
        }

        public static DatabaseAccess GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new DatabaseAccess();
                    }
                }
            }
            return instance;
        }

        public void OpenConnection()
        {
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    //MessageBox.Show("Yhteyden muodostaminen onnistui");
                } catch
                {
                    MessageBox.Show("Yhteyttä ei muodostettu");
                }
            }
        }

        public void CloseConnection()
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }
    }
}

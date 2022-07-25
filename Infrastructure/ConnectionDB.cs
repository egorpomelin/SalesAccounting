using MySql.Data.MySqlClient;
using SalesAccounting.Interfece;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalesAccounting.Infrastructure
{
    internal class ConnectionDB : IConnectionDB
    {
        MySqlConnection connection = new MySqlConnection($"server={Properties.Settings.Default.serverAddress};username={Properties.Settings.Default.user};password={Properties.Settings.Default.password};database={Properties.Settings.Default.nameDB}");
        
        public void closeCOnnection(string stringConnection)
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Нет подключения");
            }
        }

        public void openCOnnection(string stringConnection)
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Нет подключения");
            }
        }

        public MySqlConnection returnConnection()
        {
            try
            {
                return connection;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Нет подключения");

                return null;
            }
        }
    }
}

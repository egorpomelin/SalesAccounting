using MySql.Data.MySqlClient;
using SalesAccounting.Interfece;
using System;
using System.Data;
using System.Windows;

namespace SalesAccounting.Infrastructure
{
    internal class ConnectionDB : IConnectionDB
    {
        static MySqlConnection connection = new MySqlConnection($"server={Properties.Settings.Default.serverAddress};username={Properties.Settings.Default.user};password={Properties.Settings.Default.password};database={Properties.Settings.Default.nameDB}");

        public void closeCOnnection()
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Нет подключения");
            }
        }

        public void openCOnnection()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
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

        public DataTable returnProduct(string name, string barcode)
        {
            try
            {
                openCOnnection();
                connection = returnConnection();
                string sql = $"SELECT * FROM `товары` WHERE CONCAT(`{name}`) LIKE '{barcode}'";
                MySqlDataAdapter command = new MySqlDataAdapter(sql, connection);
                DataTable product = new DataTable();
                command.Fill(product);
                closeCOnnection();
                return product;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Нет подключения");
                return null;
            }
        }
    }
}

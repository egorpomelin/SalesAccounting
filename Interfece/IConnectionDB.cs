using MySql.Data.MySqlClient;
using System.Data;

namespace SalesAccounting.Interfece
{
    internal interface IConnectionDB
    {
        public void openCOnnection(); //открывает соединение 
        public void closeCOnnection();//закрывает соединение
        public MySqlConnection returnConnection();//возвращает соединение
        public DataTable returnProduct(string name, string barcode);//возвращает продукт
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAccounting.Interfece
{
    internal interface IConnectionDB
    {
        public void openCOnnection(string stringConnection); //открывает соединение 
        public void closeCOnnection(string stringConnection);//закрывает соединение
        public MySqlConnection returnConnection();//возвращает соединение
    }
}

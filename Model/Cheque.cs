using SalesAccounting.Infrastructure;
using System;
using System.Data;
using System.Windows;

namespace SalesAccounting.Model
{
    internal class Cheque
    {

        int countProduct;//количество продуктов
        public int CountProduct
        {
            get { return countProduct; }
            set { countProduct = value; }
        }

        int amount;//сумма покупки без скидки
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        int amountSales;//сумма покупки со скидкой
        public int AmountSales
        {
            get { return amountSales; }
            set { amountSales = value; }
        }

        DataTable tableProduct = new DataTable();//список продуктов
        public DataTable TableProduct
        {
            get { return tableProduct; }
            set
            {
                tableProduct = value;
            }
        }
        ConnectionDB db = new ConnectionDB();

        public DataTable addListProduct(string name, string barcode)
        {
            try
            {
                DataTable prod = db.returnProduct(name, barcode);
                TableProduct.Merge(prod);

                return TableProduct;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Нет подключения");
                return TableProduct;
            }

        }

        public int returnCountProduct()
        {
            CountProduct = TableProduct.Rows.Count;
            
            return CountProduct;
        }

        public int returnAmount()
        {
            int sum = TableProduct.Rows[0].Field<int>(columnIndex: 6);
            Amount += Convert.ToInt16(sum);
            return Amount;
        }
    }
}

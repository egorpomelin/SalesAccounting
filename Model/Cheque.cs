using SalesAccounting.Infrastructure;
using System;
using System.Data;
using System.Windows;

namespace SalesAccounting.Model
{
    internal class Cheque
    {
        public Cheque()
        {
            TableProduct.Columns.Add(BarcodeColumn);
            TableProduct.Columns.Add(brandColumn);
            TableProduct.Columns.Add(lineColumn);
            TableProduct.Columns.Add(nameColumn);
            TableProduct.Columns.Add(remainsColumn);
            TableProduct.Columns.Add(priceColumn);
            TableProduct.Columns.Add(colColumn);
            colColumn.DefaultValue = 1;
            TableProduct.Columns.Add(saleColumn);
        }
        

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




        DataColumn BarcodeColumn = new DataColumn("штрихкод");
        DataColumn brandColumn = new DataColumn("бренд");
        DataColumn lineColumn = new DataColumn("линейка");
        DataColumn nameColumn = new DataColumn("наименование");
        DataColumn remainsColumn = new DataColumn("количество", Type.GetType("System.Int32"));
        DataColumn priceColumn = new DataColumn("цена", Type.GetType("System.Int32"));
        DataColumn colColumn = new DataColumn("кол", Type.GetType("System.Int32"));
        DataColumn saleColumn = new DataColumn("скидка", Type.GetType("System.Int32"));


        DataTable tableProduct = new DataTable();//список продуктов
        public DataTable TableProduct
        {
            get { return tableProduct; }
            set { tableProduct = value; }
        }



        ConnectionDB db = new ConnectionDB();

        public DataTable addListProduct(string name, string barcode)
        {
            try
            {
                int colum = 0;
                for (int i = 0; i < countProduct; i++)
                {
                    if (TableProduct.Rows[i].Field<string>(0) == barcode)
                    {
                        colum = 1;
                        colum = TableProduct.Rows[i].Field<int>(6) + 1;
                        TableProduct.Rows[i][6] = colum;
                        break;
                    }
                }
                switch (colum)
                {
                    case 0:
                        
                        DataTable prod = db.returnProduct(name, barcode);

                        TableProduct.Rows.Add(new object[] { prod.Rows[0].Field<string>(1), prod.Rows[0].Field<string>(2), prod.Rows[0].Field<string>(3),
                            prod.Rows[0].Field<string>(4), prod.Rows[0].Field<int>(5), prod.Rows[0].Field<int>(6), 1, prod.Rows[0].Field<int>(7) });
                        break;
                }
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
            int count = 0;
            for (int i = 0; i < TableProduct.Rows.Count; i++)
            {
                count += TableProduct.Rows[i].Field<int>(6);
            }
            CountProduct = count;
            
            return CountProduct;
        }

        public int returnAmount()
        {
            try
            {
                Amount += TableProduct.Rows[0].Field<int>(columnIndex: 5);
                return Amount;
            }
            catch
            {
                return 0;
            }

        } 

        public int calculationDiscont()
        {
            AmountSales = 0;


            for (int i = 0; i < TableProduct.Rows.Count; i++)
            {
                double amoun = TableProduct.Rows[i].Field<int>(5) * TableProduct.Rows[i].Field<int>(6);
                double sale = TableProduct.Rows[i].Field<int>(7);
                double sum = amoun / 100 * sale;
                AmountSales += (int)amoun - (int)sum;
            }
            return AmountSales;
        }
    }
}

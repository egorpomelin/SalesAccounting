using SalesAccounting.Infrastructure;
using SalesAccounting.Model;
using SalesAccounting.ViewModel.Base;
using System.Data;
using System.Windows.Input;

namespace SalesAccounting.ViewModel
{
    internal class SalesAccountingWindowViewModel : ViewModelBase
    {

        public SalesAccountingWindowViewModel()
        {
            AddProductCheque = new command(OnAddProductChequeExecuted, CanAddProductChequeExecuted);
        }

        string title = "Регистрация продаж";
        public string Title
        {
            get { return title; }
            set { Set(ref title, value); }
        }

        string barcode = "";
        public string Barcode
        {
            get { return barcode; }
            set { Set(ref barcode, value); }
        }

        DataTable product = new DataTable();
        public DataTable Product
        {
            get { return product; }
            set { Set(ref product, value); }
        }

        int countProduct;//количество продуктов
        public int CountProduct
        {
            get { return countProduct; }
            set { Set(ref countProduct, value);  }
        }

        int amount;//сумма покупки без скидки
        public int Amount
        {
            get { return amount; }
            set { Set(ref amount, value); }
        }

        ConnectionDB DB = new ConnectionDB();
        Cheque cheque = new Cheque();

        public ICommand AddProductCheque { get; }//добавление товара в чек

        private void OnAddProductChequeExecuted(object p)
        {
            
            Product = cheque.addListProduct("штрихкод", barcode);
            CountProduct = cheque.returnCountProduct();
            Amount = cheque.returnAmount();
            Barcode = "";        }

        private bool CanAddProductChequeExecuted(object p) => true;


    }
}
